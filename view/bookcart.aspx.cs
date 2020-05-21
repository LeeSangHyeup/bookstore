using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_order_bookcart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
            Debug.Assert(dbHandler != null);

            string memberId = Request.Cookies["memberId"].Value;
            memberId = Server.UrlDecode(memberId);

            GridView1.DataSource = dbHandler.inquiryBookCartItems(memberId);
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0) btn_order.Visible = false;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        int itemNumber = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "deleteItem")
        {
            dbHandler.deleteBookCartItem(itemNumber);
        }
        GridView1.DataBind();

        Response.Redirect("bookcart.aspx");
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string memberId = Request.Cookies["memberId"].Value;
        memberId = Server.UrlDecode(memberId);

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        int rowCount = this.GridView1.Rows.Count;

        for(int i=0; i<rowCount; i++)
        {
            string bookName = GridView1.Rows[i].Cells[0].Text.Replace("&#160;", "");
            int cost = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
            
            TextBox quantityTextBox = (TextBox)GridView1.Rows[i].Cells[2].FindControl("quantity");
            int quantity = Convert.ToInt32(quantityTextBox.Text);

            dbHandler.insertTemporaryOrderItem(memberId, bookName, cost, quantity);
        }

        Response.Redirect("order.aspx");
    }
}