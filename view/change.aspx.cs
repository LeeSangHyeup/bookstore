using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class view_account_change : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
            if (member == null)
            {
                MessageBox.show("계정정보가 유효하지 않습니다.", this.Page);
                return;
            }

            inputID.Text = member.getId();
            inputPassword1.Text = member.getPassword();
            inputPassword2.Text = member.getPassword();
            inputEmail.Text = member.getSubEmail();
            inputPhone.Text = member.getPhone();
            inputMailNumber.Text = member.getMailNumber();
            inputAddress.Text = member.getAddress();
            inputAuthenticationQuestion.Text = member.getAuthenticationQustion();
            inputAuthenticationAnswer.Text = member.getAuthenticationAnswer();
        }
    }
    protected void btn_change_Click(object sender, EventArgs e)
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
        if (member == null)
        {
            MessageBox.show("계정정보가 유효하지 않습니다.", this.Page);
            return;
        }

        member.setPassword(inputPassword1.Text);
        member.setSubEmail(inputEmail.Text);
        member.setPhone(inputPhone.Text);
        member.setMailNumber(inputMailNumber.Text);
        member.setAddress(inputAddress.Text);
        member.setAuthenticationQustion(inputAuthenticationQuestion.Text);
        member.setAuthenticationAnswer(inputAuthenticationAnswer.Text);

        try
        {
            dbHandler.updateMemberInformation(member);
        }
        catch
        {
            MessageBox.show("서버문제로 회원정보 업데이트를 하지 못하였습니다..", this.Page);
        }
        Response.Redirect("completeChange.aspx");
    }
}