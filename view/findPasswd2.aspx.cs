using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_account_findPasswd2 : System.Web.UI.Page
{
    private Member member;
    private DBHandler dbHandler;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);


        try
        {
            this.member = this.dbHandler.inquiryMember(Request.QueryString["targetId"]);
        }
        catch
        {
            MessageBox.show("서버문제로 회원정보를 읽어오지 못했습니다.", this.Page);
            return;
        }
        Debug.Assert(this.member != null);
        if (this.member == null)
        {
            MessageBox.show("입력하신 아이디가 존재하지 않습니다.", this.Page);
            return;
        }
        question.Text = this.member.getAuthenticationQustion();
    }
    protected void btn_findPassword_Click(object sender, EventArgs e)
    {
        if (!answer.Text.Equals(this.member.getAuthenticationAnswer()))
        {
            MessageBox.show("입력하신 답이 올바르지 않습니다.", this.Page);
            return;
        }
        string temporaryPassword = this.dbHandler.updateMemberPassword(this.member);
        try
        {
            new MailSender().sendFindPasswordEmail(this.member.getId(), temporaryPassword);
        }
        catch
        {
            MessageBox.show("임시패스워드 전송 실패", this.Page);
            return;
        }
        Response.Redirect("completeFindPassword.aspx");
    }
}