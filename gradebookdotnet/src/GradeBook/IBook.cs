namespace GradeBook
{
  public interface IBook
  {
    void AddGrade(Grade grade);
    (double average, double lowGrade, double highGrade, char letterGrade) 
    GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }
}
