namespace GradeBook
{
  public class Book {

    public Book(string name, List<double>? grades)
    {
      this.name = name;
      this.grades = grades == null ? new List<double>() : grades;
    }


    public void AddGrade(double grade)
    {
      if (grade >= 0 && grade <= 100)
      {
        grades.Add(grade);
      }
    }

    public void ShowStatistics()
    {
      var res = GetStatistics();

      Console.WriteLine($"The average grade is {res.average:N2}");
      Console.WriteLine($"The low grade is {res.lowgrade}");
      Console.WriteLine($"The hiugh grade is {res.highgrade}");
    }

    public (double average, double lowgrade, double highgrade) GetStatistics()
    {
      var average = 0.0;
      var highgrade = double.MinValue;
      var lowgrade = double.MaxValue;

      foreach(var number in grades) {
        lowgrade = Math.Min(number, lowgrade);
        highgrade = Math.Max(number, highgrade);
        average += number;
      }

      average /= grades.Count;

      return (average, lowgrade, highgrade);
    }

    private List<double> grades;
    private string name;
  }
}
