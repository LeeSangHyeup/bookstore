using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_account_withdraw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_withdraw_Click(object sender, EventArgs e)
    {
        string memberId = Request.Cookies["memberId"].Value;
        memberId = Server.UrlDecode(memberId);

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        bool isWithDrawSuccess = dbHandler.deleteMember(memberId);

        if (isWithDrawSuccess==false)
        {
            MessageBox.show("계정정보가 유효하지 않습니다.", this.Page);
            return;
        }
        FormsAuthentication.SignOut();

        Response.Cookies["memberId"].Expires = new System.DateTime(1990, 1, 1);

        Response.Redirect("withdrawComplete.aspx");
    }
}