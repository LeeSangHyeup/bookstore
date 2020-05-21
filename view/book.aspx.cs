using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_book_book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
            Debug.Assert(dbHandler != null);

            string bookNumber = Request.QueryString["bookNumber"];

            Book book = null;

            try
            {
                book = dbHandler.inquiryBook(bookNumber);
            }
            catch
            {
                MessageBox.show("서버로부터 책 정보를 읽어오지 못했습니다.", this.Page);
                return;
            }
            Debug.Assert(book != null);

            bookImage.ImageUrl = "~/view/bookImages/" + book.getbookNumber() + ".jpg";
            category.Text = book.getCategory();
            bookName.Text = book.getName();
            author.Text = book.getAuthor();
            publisher.Text = book.getPublisher();
            cost.Text = book.getCost().ToString();
        
            introduce.Text = book.getIntroduce();
            authorIntroduce.Text = book.getAuthorIntroduce();
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string memberId = null;
        try
        {
            memberId = Request.Cookies["memberId"].Value;
        }
        catch
        {
            MessageBox.show("장바구니 및 도서구매는 회원만 가능합니다.", this.Page);
            return;
        }
        memberId = Server.UrlDecode(memberId);

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        string bookNumber = Request.QueryString["bookNumber"];
        dbHandler.insertBookCartItem(memberId, bookName.Text, Int32.Parse(cost.Text), 1);
        MessageBox.show("선택하신 도서가 북카트에 추가 되었습니다", this.Page);
    }
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        string memberId = null;
        try
        {
            memberId = Request.Cookies["memberId"].Value;
        }
        catch
        {
            MessageBox.show("장바구니 및 도서구매는 회원만 가능합니다.", this.Page);
            return;
        }
        memberId = Server.UrlDecode(memberId);

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        dbHandler.insertTemporaryOrderItem(memberId, bookName.Text, Int32.Parse(cost.Text), 1);

        Response.Redirect("order.aspx");
    }
}