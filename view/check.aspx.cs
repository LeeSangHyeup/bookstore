using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_account_check : System.Web.UI.Page
{
    string collectAnswer;
    string collenctPassword;

    protected void Page_Load(object sender, EventArgs e)
    {
        string memberId = Request.Cookies["memberId"].Value;
        memberId = Server.UrlDecode(memberId);

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        Member member = null;
        try
        {
            member = dbHandler.inquiryMember(memberId);
        }
        catch
        {
            MessageBox.show("서버문제로 회원정보를 읽어오지 못했습니다.", this.Page);
            return; 
        }
        Debug.Assert(member != null);
        if (member  == null)
        {
            MessageBox.show("계정정보가 유효하지 않습니다.", this.Page);
            return; 
        }

        question.Text = member.getAuthenticationQustion().Trim();

        this.collectAnswer = member.getAuthenticationAnswer();
        this.collenctPassword = member.getPassword();
          
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        string inputAnswer = answer.Text;
        string inputPassword = Password.Text;

        if (!inputPassword.Equals(this.collenctPassword))
        {
            MessageBox.show("비밀번호가 일치하지 않습니다.", this.Page);
            return;
        }

        if (!inputAnswer.Equals(this.collectAnswer))
        {
            MessageBox.show("본인확인 답이 틀렸습니다.", this.Page);
            return; 
        }

        Response.Redirect("change.aspx");
    }
}