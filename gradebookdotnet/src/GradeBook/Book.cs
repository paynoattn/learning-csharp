namespace GradeBook
{
  public class Book {

    public Book(string name)
    {
      this.Name = name;
      this.Grades = new List<Grade>() {};
    }
    
    public Book(string name, List<Grade> grades)
    {
      this.Name = name;
      this.Grades = grades;
    }


    public void AddGrade(double grade)
    {
      Grades.Add(new Grade(grade));
    }

    public void AddGrade(Grade grade)
    {
      Grades.Add(grade);
      if (GradeAdded != null)
      {
        GradeAdded(this, new EventArgs());
      }
    }

    public void ShowStatistics()
    {
      var res = GetStatistics();

      Console.WriteLine($"The average grade is {res.average:N2}");
      Console.WriteLine($"The low grade is {res.lowGrade}");
      Console.WriteLine($"The high grade is {res.highGrade}");
      Console.WriteLine($"The letter grade is {res.letterGrade}");
    }

    public 
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

    public event GradeAddedDelegate GradeAdded;

    public readonly List<Grade> Grades;
    public string Name;
  }
}
