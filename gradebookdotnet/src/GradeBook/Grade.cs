namespace GradeBook
{
  public class Grade {

    public static char GetLetterGradeFromDouble(double points)
    {
      switch (points)
      {
        case var a when a >= 90:
          return 'A';
        case var a when a >= 80:
          return 'B';
        case var a when a >= 70:
          return 'C';
        case var a when a >= 60:
          return 'D';
        default:
          return 'F';
      }
    }

    public static double GetPointsFromLetterGrade(char letter) 
    {
      switch (letter)
      {
        case 'A':
          return 90;
        case 'B':
          return 80;
        case 'C':
          return 70;
        case 'D':
          return 60;
        default:
          return 0;
      }
    }

    public static char[] ValidLetterGrades = new char[] { 'A', 'B', 'C', 'D', 'F' };

    public Grade(double grade)
    {
      if (grade >= 0 && grade <= 100)
      { 
        this.Points = grade;
      }
      else {
        this.Points = 0;
        Console.WriteLine($"You entered an invalid grade. Expected nuber between 0 and 100 and recieved {grade}");
      }
    }

    public Grade(char letter)
    {
      this.Points = Grade.GetPointsFromLetterGrade(letter);
    }

    public Grade(string str)
    {
      double Val;
      var doubleSuccess = double.TryParse(str, out Val);

      char LetterGrade;
      var leterSuccess = char.TryParse(str, out LetterGrade);
      
      if (str.Length == 1 &&  Grade.ValidLetterGrades.Any(c => LetterGrade == c))
      {
        this.Points = Grade.GetPointsFromLetterGrade(LetterGrade);
      }
      else if (doubleSuccess && !double.IsNaN(Val) && !double.IsInfinity(Val))
      {
        this.Points = Val;
      }
      else
      {
        this.Points = 0;
        Console.WriteLine($"You may have passed an invalid grade. You passed {str} but we expected a number like 90.1 or a letter like A");
      }
    }

    public char GetLetterGrade()
    {
      return Grade.GetLetterGradeFromDouble(Points);
    }

    public readonly double Points;
  }
}
