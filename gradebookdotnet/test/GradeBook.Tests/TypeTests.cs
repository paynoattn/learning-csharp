using Xunit;

namespace GradeBook.Tests;

public class TypeTests
{

  [Fact]
  public void CSharpIsPassByValue()
  {
    var book1 = GetBook("Book 1");
    GetBookSetName(book1, "new name");
    Assert.Equal("Book 1", book1.Name);
  }

  private void GetBookSetName(Book book, string name)
  {
    book = new Book(name);
  }
  
  
  [Fact]
  public void CanSetNameFromRef()
  {
    var book1 = GetBook("book 1");
    book1.Name = "New Name";

    Assert.Equal("New Name", book1.Name);
  }


  [Fact]
  public void GetBookReturnsDifferentObjects()
  {
    var book1 = GetBook("book 1");
    var book2 = GetBook("book 2");

    Assert.Equal("book 1", book1.Name);
    Assert.Equal("book 2", book2.Name);
    Assert.NotSame(book1, book2);
  }

  [Fact]
  public void TwoVarsCanRefSameObj()
  {
    var book1 = GetBook("book 1");
    var book2 = book1;

    Assert.Same(book1, book2);
  }

  private Book GetBook(string name)
  {
    return new Book(name);
  }
}
