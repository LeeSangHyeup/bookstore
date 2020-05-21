using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_order_information : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
            Debug.Assert(dbHandler != null);

            string memberId = Request.Cookies["memberId"].Value;
            memberId = Server.UrlDecode(memberId);

            GridView1.DataSource = dbHandler.inquiryOrder(memberId);
            GridView1.DataBind();
        }
    }
}