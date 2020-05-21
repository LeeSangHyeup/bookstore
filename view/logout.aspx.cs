using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_account_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["memberId"].Expires = new System.DateTime(1990, 1, 1);
        FormsAuthentication.SignOut();

        string prevPage = Request.UrlReferrer.ToString();
        Response.Redirect("main.aspx");
    }
}