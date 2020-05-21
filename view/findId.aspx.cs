using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_account_findId : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void findId_Click(object sender, EventArgs e)
    {
        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        Member member = null;
        try
        {
            member = dbHandler.inquiryMemberSubEmail(subEmail.Text);
        }
        catch
        {
            MessageBox.show("서버문제로 회원정보를 읽어오지 못했습니다.", this.Page);
            return;
        }
        Debug.Assert(member != null);
        if (member == null)
        {
            MessageBox.show("입력하신 2차 이메일을 가진 계정은 존재하지 않습니다.", this.Page);
            return;
        }
        string mailRecipient = subEmail.Text;
        string memberId = member.getId();

        MailSender mailSender = new MailSender();
        mailSender.sendFindIdMail(mailRecipient, memberId);

        Response.Redirect("completeFindId.aspx");
    }
}