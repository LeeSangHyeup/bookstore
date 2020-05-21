using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Diagnostics; 

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void loginbtn_Click(object sender, EventArgs e)
    {
        string id = inputID.Text;
        string password = inputPassword.Text;

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        if (dbHandler.checkCanLogin(id, password) == false)
        {
            MessageBox.show("계정정보가 유효하지 않습니다.", this.Page);
            return;
        }
        if (dbHandler.checkMemberAuthentication(id) == false)
        {
            MessageBox.show("메일인증이 필요한 회원입니다..", this.Page);
            return;
        }

        Response.Cookies["memberId"].Value = Server.UrlEncode(id);
        FormsAuthentication.RedirectFromLoginPage(id, false);
    }
}