using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_account_findPasswd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_findPassword_Click(object sender, EventArgs e)
    {
        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        Member member = null;

        try
        {
            member = dbHandler.inquiryMember(id.Text);
        }
        catch
        {
            MessageBox.show("서버문제로 회원정보를 읽어오지 못했습니다.", this.Page);
            return;
        }
        Debug.Assert(member != null);
        if (member == null)
        {
            MessageBox.show("입력하신 아이디가 존재하지 않습니다.", this.Page);
            return;
        }

        Response.Redirect("findPasswd2.aspx"+"?targetId="+id.Text);
    }
}