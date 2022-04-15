namespace GradeBook
{
  public class InMemoryBook : Book, IBook
  {

    public InMemoryBook(string name) : base(name) {}

    public InMemoryBook(string name, List<Grade> grades) : base(name, grades) {}

    string IBook.Name => throw new NotImplementedException();

    public void AddGrade(double grade)
    {
      Grades.Add(new Grade(grade));
    }

    public void AddGrade(Grade grade)
    {
      Grades.Add(grade);
      FireGradeAddedEvent();
    }
  }
}
