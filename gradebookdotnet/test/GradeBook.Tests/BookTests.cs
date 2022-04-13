using Xunit;
using GradeBook;
using System.Collections.Generic;

namespace GradeBook.Tests;

public class BookTetsts
{
    [Fact]
    public void TestStatistics()
    {
      var scores = new List<double>() { 89.1, 90.5, 77.3 };
      var book = new Book("test book", scores);

      var result = book.GetStatistics();

      Assert.Equal(85.6, result.average, 1);
      Assert.Equal(90.5, result.highgrade, 1);
      Assert.Equal(77.3, result.lowgrade, 1);
    }
}
