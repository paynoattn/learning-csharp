namespace GradeBook
{
  class Program 
  {
    static void Main(string[] args) 
    {
      if (args.Length <= 1)
      {
        Console.WriteLine("Invalid Parameters supplied. Please provide a gradebook name and grades.");
        Console.WriteLine("ex: Chris 91.1 A B 55");
      }
      else
      {
        var name = args[0];
        var gradeStrings = new List<string>(args);
        gradeStrings.RemoveAt(0);
        var grades = gradeStrings
          .ConvertAll<Grade>(str => new Grade(str));
        
        var book = new Book(name, grades);
        book.ShowStatistics();
      }
    }
  }
}
