using Xunit;

namespace GradeBook.Tests
{
  public class GradeTests
  {
    [Fact]
    public void ShouldConstruct()
    {
      var grade1 = new Grade(99);
      var grade2 = new Grade('A');
      var grade3 = new Grade("B");
      var grade4 = new Grade("99.9");

      Assert.Equal(99, grade1.Points);
      Assert.Equal(90, grade2.Points);
      Assert.Equal(80, grade3.Points);
      Assert.Equal(99.9, grade4.Points);
    }

    [Fact]
    public void ShoulNotConstruct()
    {
      var grade1 = new Grade("asdf");
      var grade2 = new Grade("");
      var grade3 = new Grade("99 9 ");
      var grade4 = new Grade(101);

      var grades = new Grade[] {
        grade1,
        grade2,
        grade3,
        grade4
      };

      foreach(var grade in grades) {
        Assert.Equal(0, grade.Points);
      }
    }
  }
}
