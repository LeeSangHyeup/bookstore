using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics; 

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_register_Click(object sender, EventArgs e)
    {
        string id = inputID.Text;
        string password = inputPassword1.Text;
        string subEmail = inputEmail.Text;
        string phone = inputPhone.Text;
        string mailNumber = inputMailNumber.Text;
        string address = inputAddress.Text;
        string authenticationQuestion = inputAuthenticationQuestion.Text;
        string authenticationAnswer = inputAuthenticationAnswer.Text;

        DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
        Debug.Assert(dbHandler != null);

        Member newMember = null;

        if (dbHandler.checkMemberExist(id))
        {
            MessageBox.show("다른 회원이 사용중인 ID입니다. 다른아이디를 입력해 주세요.", this.Page);
            return;
        }
        try
        {
            newMember = new Member(id, password, subEmail, phone, mailNumber, address, authenticationQuestion, authenticationAnswer);
        }
        catch (ArgumentException argumentException)
        {
            MessageBox.show("입력된 회원정보가 유효하지 않습니다. "+argumentException.Message, this.Page);
        }
        catch(Exception exception)
        {
            MessageBox.show(exception.Message, this.Page);
        }
        Debug.Assert(newMember != null);


        bool isRegisterSuccess=false;

        try
        {
            isRegisterSuccess = dbHandler.registerMember(newMember);
        }
        catch(Exception exception)
        {
            MessageBox.show(exception.Message, this.Page);
        }        
        if (!isRegisterSuccess)
        {
            MessageBox.show("서버 오류로 인해 데이터베이스에 회원을 등록하지 못하였습니다.", this.Page);
        }

        new MailSender().sendRegisterAuthenticationEmail(id);
        Response.Redirect("registerAuthentication.aspx");
    }
}