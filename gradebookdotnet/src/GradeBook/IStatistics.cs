namespace GradeBook {
  public interface IStatistics { 
    double Average { get; }
    double LowGrade { get; }
    double HighGrade { get; }
    char LetterGrade { get; }
  }
}
