using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

/// <summary>
/// Book의 요약 설명입니다.
/// </summary>
public class Book
{
    private int bookNumber;
    private string name;
    private string author;
    private string publisher;
    private int cost;
    private string introduce;
    private string authorIntroduce;
    private string category;

	public Book(int bookNumber, string name, string author, string publisher, int cost, string introduce, string authorintroduce, string category)
	{
        if (bookNumber < 0) throw new System.ArgumentException("Book형 객체를 생성하기 위한 bookNumber가 유효하지 않습니다. 입니다.", "Book.bookNumber");
        if (ValidChecker.checkStringValid(name)==false) throw new System.ArgumentException("Book형 객체를 생성하기 위한 name이 유효하지 않습니다. 입니다.", "Book.name");
        if (ValidChecker.checkStringValid(author) == false) throw new System.ArgumentException("Book형 객체를 생성하기 위한 author가 유효하지 않습니다. 입니다.", "Book.author");
        if (ValidChecker.checkStringValid(publisher) == false) throw new System.ArgumentException("Book형 객체를 생성하기 위한 publisher가 유효하지 않습니다. 입니다.", "Book.publisher");
        if (cost < 0) throw new System.ArgumentException("Book형 객체를 생성하기 위한 cost가 유효하지 않습니다. 입니다.", "Book.cost");
        if (ValidChecker.checkStringValid(introduce) == false) throw new System.ArgumentException("Book형 객체를 생성하기 위한 nameintroduce가 유효하지 않습니다. 입니다.", "Book.introduce");
        if (ValidChecker.checkStringValid(authorintroduce) == false) throw new System.ArgumentException("Book형 객체를 생성하기 위한 authorintroduce가 유효하지 않습니다. 입니다.", "Book.authorintroduce");
        if (ValidChecker.checkStringValid(category) == false) throw new System.ArgumentException("Book형 객체를 생성하기 위한 category가 유효하지 않습니다. 입니다.", "Book.category");

        this.bookNumber = bookNumber;
        this.name = name;
        this.author = author;
        this.publisher = publisher;
        this.cost = cost;
        this.introduce = introduce;
        this.authorIntroduce = authorintroduce;
        this.category = category;
	}
    public int getbookNumber() { return this.bookNumber; }
    public string getName() { return this.name; }
    public string getAuthor() { return this.author; }
    public string getPublisher() { return this.publisher; }
    public int getCost() { return this.cost; }
    public string getIntroduce() { return this.introduce; }
    public string getAuthorIntroduce() { return this.authorIntroduce; }
    public string getCategory() { return this.category; }
}