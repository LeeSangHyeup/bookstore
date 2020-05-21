using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

public partial class view_account_idAuthentication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string requestMemberId = "";
        requestMemberId += Request.Form["memberId"];
        string requestActivationCode = "";
        requestActivationCode += Request.Form["activationCode"];

        if ((requestMemberId==null) || (requestActivationCode==null)) return;

        //해쉬함수로 계정활성화코드(ActivationCode) 생성
        byte[] tmpSource  = ASCIIEncoding.ASCII.GetBytes(requestMemberId);
        byte[] tmpHash =  new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        //생성된 해쉬값을 string타입으로 변환
        StringBuilder sOutput = new StringBuilder(tmpHash.Length);
        for (int i = 0; i < tmpHash.Length - 1; i++)
        {
            sOutput.Append(tmpHash[i].ToString("X2"));
        }
        string activationCode = sOutput.ToString();

        if (requestActivationCode.Equals(activationCode))
        {
            DBHandler dbHandler = (DBHandler)Application.Get("dbHandler");
            dbHandler.updateMemberAuthentication(requestMemberId);
            Response.Redirect("memberAuthenticationComplete.aspx");
        }
    }
}