using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;

public partial class view_order_order : System.Web.UI.Page
{
    private string _memberId=null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
            Debug.Assert(dbHandler != null);

            this._memberId = Request.Cookies["memberId"].Value;
            this._memberId = Server.UrlDecode(this._memberId);

            GridView1.DataSource = dbHandler.inquiryTemporaryOrderItems(this._memberId);
            GridView1.DataBind();

            Member member = dbHandler.inquiryMember(this._memberId);

            phone.Text = member.getPhone();
            email.Text = member.getId();
            mailNumber.Text = member.getMailNumber();
            address.Text = member.getAddress();
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        dbHandler.deleteTemporaryOrderItems(this._memberId);
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        this._memberId = Request.Cookies["memberId"].Value;
        this._memberId = Server.UrlDecode(this._memberId);

        int rowCount = this.GridView1.Rows.Count;

        string orderName="";
        int totalCost = 0;
        int totalQuantity=-1;

        for(int i=0; i<rowCount; i++)
        {
            string bookName = GridView1.Rows[i].Cells[0].Text.Replace("&#160;", "");
            if(i==0)orderName = bookName+"외 ";

            int cost = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text);
            totalCost+=cost;
            
            TextBox quantityTextBox = (TextBox)GridView1.Rows[i].Cells[2].FindControl("quantity");
            int quantity = Convert.ToInt32(quantityTextBox.Text);
            totalQuantity += quantity;

            dbHandler.insertTemporaryOrderItem(this._memberId, bookName, cost, quantity);
        }
        orderName += totalQuantity.ToString()+"권";
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Order newOrder = new Order(this._memberId, orderName, date, totalCost, "주문완료", recipient.Text, phone.Text, email.Text, mailNumber.Text, address.Text);
        try
        {
            dbHandler.insertOrder(newOrder);
        }
        catch
        {
            MessageBox.show("서버에 주문추가 실패", this.Page);
        }
        Response.Redirect("information.aspx");
    }
}