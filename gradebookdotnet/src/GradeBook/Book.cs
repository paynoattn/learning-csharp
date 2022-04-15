namespace GradeBook
{
  public abstract class Book : NamedObject
  {

    public Book(string name) : base(name)
    {
      this.Grades = new List<Grade>() {};
    }
    
    public Book(string name, List<Grade> grades) : base(name)
    {
      this.Grades = grades;
    }

    public void ShowStatistics()
    {
      var res = GetStatistics();

      Console.WriteLine($"The average grade is {res.average:N2}");
      Console.WriteLine($"The low grade is {res.lowGrade}");
      Console.WriteLine($"The high grade is {res.highGrade}");
      Console.WriteLine($"The letter grade is {res.letterGrade}");
    }

    public virtual
    (double average, double lowGrade, double highGrade, char letterGrade) 
    GetStatistics()
    {
      var average = 0.0;
      var highGrade = double.MinValue;
      var lowGrade = double.MaxValue;

      foreach(var grade in Grades) {
        lowGrade = Math.Min(grade.Points, lowGrade);
        highGrade = Math.Max(grade.Points, highGrade);
        average += grade.Points;
      }

      average /= Grades.Count;

      var letterGrade = Grade.GetLetterGradeFromDouble(average);

      return (average, lowGrade, highGrade, letterGrade);
    }

    protected void FireGradeAddedEvent() {
      if (GradeAdded != null)
      {
        GradeAdded(this, new EventArgs());
      }
    }

    public event GradeAddedDelegate? GradeAdded;

    public readonly List<Grade> Grades;
  }
}
