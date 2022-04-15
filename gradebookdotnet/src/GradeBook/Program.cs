namespace GradeBook
{
  class Program 
  {
    static void Main(string[] args) 
    {
      if (args.Length == 0)
      {
        Console.WriteLine("Invalid Parameters supplied. Please provide a gradebook name");
      }
      else if (args.Length == 1)
      {
        Program.RunWithName(args);
      }
      else
      {
        Program.RunWithArgs(args);
      }
    }

    static void RunWithName(string[] args) {
      var book = new InMemoryBook(args[0]);
      book.GradeAdded += OnGradedAdded;

      while (true)
      {
        Console.WriteLine($"Entering grades for {book.Name}");
        Console.WriteLine("Enter a grade or 'q' to quit");
        Console.WriteLine("Enter ? to show statistics");

        var input = Console.ReadLine();
        
        if (input == "q")
        {
          book.GetStatistics();
          break;
        }
        else if (input == "?")
        {
          book.ShowStatistics();
        }
        else if (input != null)
        {
          try 
          {
            var grade = new Grade(input);
            book.AddGrade(grade);
          } catch (Exception ex) 
          {
            Console.WriteLine($"Invalid grade: {ex.Message}");
          }
        }
        else 

        {
          Console.WriteLine("Invalid grade provided. Please try again");
        }
      }
    }

    static void RunWithArgs(string[] args) {
      try {
        var name = args[0];
        var gradeStrings = new List<string>(args);
        gradeStrings.RemoveAt(0);
        var grades = gradeStrings
          .ConvertAll<Grade>(str => new Grade(str));
        
        var book = new InMemoryBook(name, grades);
        book.ShowStatistics();
      }
      catch (Exception ex) {
        Console.WriteLine($"Invalid grade: {ex.Message}");
      }
    }
    
    static void OnGradedAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added.");
    }
  }
}
