namespace GradeBook
{
  class Program 
  {
    static void Main() 
    {

      var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
      var book = new Book("chris's grade book", grades);
      book.AddGrade(56.1);

      book.ShowStatistics();
    }
  }
}
