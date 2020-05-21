using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.IsAuthenticated)
        {
            login.Visible = false;
            register.Visible = false;
        }
        else
        {
            logout.Visible = false;
            accountManagement.Visible = false;
            orderStatement.Visible = false;
            bookcart.Visible = false;
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (ValidChecker.checkStringValid(inputKeyword.Text) == false) return;

        Response.Redirect("search.aspx?keyword=" + inputKeyword.Text);
    }
}
