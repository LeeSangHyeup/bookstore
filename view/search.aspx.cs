using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_book_Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
            Debug.Assert(dbHandler != null);

            string keyword = Request.QueryString["keyword"];

            GridView1.DataSource = dbHandler.searchBook(keyword);
            GridView1.DataBind();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        string keyword = Request.QueryString["keyword"];

        GridView1.DataSource = dbHandler.searchBook(keyword);
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string memberId = null;

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        int bookNumber = Convert.ToInt32(e.CommandArgument);

        Book book = dbHandler.inquiryBook(bookNumber.ToString());
        string bookName = book.getName();
        int cost = book.getCost();

        if (e.CommandName == "addToCart")
        {
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

            dbHandler.insertBookCartItem(memberId, bookName, cost, 1);
            MessageBox.show("선택하신 도서가 북카트에 추가 되었습니다", this.Page);
        }
        else if (e.CommandName == "buyNow")
        {
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

            dbHandler.insertTemporaryOrderItem(memberId, bookName, cost, 1);
            Response.Redirect("order.aspx");
        }
    }
}