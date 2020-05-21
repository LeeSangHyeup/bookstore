using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// 메일발송
/// </summary>
public class MailSender
{
    private string senderAddress = "bookStore@bookStore.com";
    private string senderName = "BookStore Admin";
    private string smtpClientAddress = "localhost";

	public MailSender()
	{

    }
    public bool sendRegisterAuthenticationEmail(string mailRecipient)
    {
        /*  자체 SMTP서버 사용
        if (ValidChecker.checkStringValid(mailRecipient) == false) return false;

        MailMessage mailMessage = new MailMessage();
	    mailMessage.From = new MailAddress(this.senderAddress, this.senderName, System.Text.Encoding.Default);
        mailMessage.Subject = "BookStore 회원인증메일";
        mailMessage.IsBodyHtml = false;
        //해쉬함수로 계정활성화코드(ActivationCode) 생성
        byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(mailRecipient);
        byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        //생성된 해쉬값을 string타입으로 변환
        StringBuilder sOutput = new StringBuilder(tmpHash.Length);
        for (int i = 0; i < tmpHash.Length - 1; i++)
        {
            sOutput.Append(tmpHash[i].ToString("X2"));
        }
        string activationCode = sOutput.ToString();
        mailMessage.Body = ""+
        "<!DOCTYPE html>"+
        "<html><body><p>BookStore의 계정을 인증하려면 계정인증버튼을 눌러주세요.</p>"+
        "<form method=\"post\" action=\"http://218.156.146.189/view/idAuthentication.aspx\">"+
        "<input type=\"hidden\" name=\"memberId\" value=\""+mailRecipient+"\">"+
        "<input type=\"hidden\" name=\"activationCode\" value=\""+activationCode+"\">"+
        "<input type=\"submit\" value=\"계정인증\"/></form></body></html>";
        mailMessage.SubjectEncoding = System.Text.Encoding.Default;
        mailMessage.BodyEncoding = System.Text.Encoding.Default;
        mailMessage.To.Add(mailRecipient);

        SmtpClient smtpClient = new SmtpClient(this.smtpClientAddress);
        smtpClient.Send(mailMessage);
        */

        if (ValidChecker.checkStringValid(mailRecipient) == false) return false;

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(this.senderAddress, this.senderName, System.Text.Encoding.Default);
        mailMessage.Subject = "BookStore 회원인증메일";
        mailMessage.IsBodyHtml = true;
        //해쉬함수로 계정활성화코드(ActivationCode) 생성
        byte[] tmpSource  = ASCIIEncoding.ASCII.GetBytes(mailRecipient);
        byte[] tmpHash =  new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        //생성된 해쉬값을 string타입으로 변환
        StringBuilder sOutput = new StringBuilder(tmpHash.Length);
        for (int i = 0; i < tmpHash.Length - 1; i++)
        {
            sOutput.Append(tmpHash[i].ToString("X2"));
        }
        string activationCode = sOutput.ToString();

        mailMessage.Body = ""+
        "<!DOCTYPE html>"+
        "<html><body><p>BookStore의 계정을 인증하려면 계정인증버튼을 눌러주세요.</p>"+
        "<form method=\"post\" action=\"http://218.156.146.189/view/idAuthentication.aspx\">" +
        "<input type=\"hidden\" name=\"memberId\" value=\""+mailRecipient+"\">"+
        "<input type=\"hidden\" name=\"activationCode\" value=\""+activationCode+"\">"+
        "<input type=\"submit\" value=\"계정인증\"/></form></body></html>";

        mailMessage.SubjectEncoding = System.Text.Encoding.Default;
        mailMessage.BodyEncoding = System.Text.Encoding.Default;
        mailMessage.To.Add(mailRecipient);

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new System.Net.NetworkCredential("mia22rmrjs9", "gldpflrmrjs9");
        smtpClient.Send(mailMessage);
        
        return true;
    }

    public bool sendFindIdMail(string mailRecipient, string memberId)
    {
        if (ValidChecker.checkStringValid(mailRecipient) == false) return false;
        if (ValidChecker.checkStringValid(memberId) == false) return false;

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(this.senderAddress, this.senderName, System.Text.Encoding.Default);
        mailMessage.Subject = "회원님의 BookStore 아이디입니다.";
        mailMessage.IsBodyHtml = false;
        mailMessage.Body = "BookStore 아이디는 " + memberId + " 입니다.";
        mailMessage.SubjectEncoding = System.Text.Encoding.Default;
        mailMessage.BodyEncoding = System.Text.Encoding.Default;
        mailMessage.To.Add(mailRecipient);

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new System.Net.NetworkCredential("mia22rmrjs9", "gldpflrmrjs9");
        smtpClient.Send(mailMessage);

        return true;
    }

    public bool sendFindPasswordEmail(string mailRecipient, string memberPassword)
    {
        if (ValidChecker.checkStringValid(mailRecipient) == false) return false;

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(this.senderAddress, this.senderName, System.Text.Encoding.Default);
        mailMessage.Subject = "회원님의 BookStore 임시 비밀번호 입니다.";
        mailMessage.IsBodyHtml = false;
        mailMessage.Body = "BookStore 임시 비밀번호는 " + memberPassword + " 입니다.\n"+
        "서비스 이용전에 반드시 비밀번호를 변경해 주세요.";
        mailMessage.SubjectEncoding = System.Text.Encoding.Default;
        mailMessage.BodyEncoding = System.Text.Encoding.Default;
        mailMessage.To.Add(mailRecipient);

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new System.Net.NetworkCredential("mia22rmrjs9", "gldpflrmrjs9");
        smtpClient.Send(mailMessage);

        return true;
    }
}