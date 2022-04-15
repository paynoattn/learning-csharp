using Xunit;
using System.Collections.Generic;

namespace GradeBook.Tests;

public class BookTetsts
{
    [Fact]
    public void TestStatistics()
    {
      var scores = new List<Grade>() { new Grade(89.1),  new Grade(90.5), new Grade(77.3) };
      var book = new Book("test book", scores);

      var result = book.GetStatistics();

      Assert.Equal(85.6, result.average, 1);
      Assert.Equal(90.5, result.highGrade, 1);
      Assert.Equal(77.3, result.lowGrade, 1);
      Assert.Equal('B', result.letterGrade);
    }

    [Fact]
    public void AddGradeShouldAddGrade()
    {
      var book = new Book("test book");
      book.AddGrade(99);
      var grades = book.Grades;

      Assert.Equal(99, grades[0].Points);
    }


    [Fact]
    public void AddGradeShouldNotAddInvalidGrade()
    {
      var book = new Book("test book");
      book.AddGrade(101);
      var grades = book.Grades;

      Assert.Equal(0, grades[0].Points);
    }
}
