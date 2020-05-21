using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Member의 요약 설명입니다.
/// </summary>
public class Member
{
    private string id;
    private string password;
    private string subEmail;
    private string phone;
    private string mailNumber;
    private string address;
    private string authenticationQustion;
    private string authenticationAnswer;


    public Member(string id, string password, string subEmail, string phone, string mailNumber, string address, string authenticationQustion, string authenticationAnswer)
	{
        if (ValidChecker.checkStringValid(id) == false) throw new System.ArgumentException("Member형 객체를 생성하기 위한 id가 유효하지 않습니다. 입니다.", "Member.id");
        if (ValidChecker.checkStringValid(password) == false) throw new System.ArgumentException("Member형 객체를 생성하기 위한 password가 유효하지 않습니다.", "Member.password");
        if (ValidChecker.checkStringValid(subEmail) == false) throw new System.ArgumentException("Member형 객체를 생성하기 위한 subEmail이 유효하지 않습니다.", "Member.subEmail");
        if (ValidChecker.checkStringValid(phone) == false) throw new System.ArgumentException("Member형 객체를 생성하기 위한 phone이 유효하지 않습니다.", "Member.phone");
        if (ValidChecker.checkStringValid(address) == false) throw new System.ArgumentException("Member형 객체를 생성하기 위한 address가 유효하지 않습니다.", "Member.address");
        if (ValidChecker.checkStringValid(mailNumber) == false) throw new System.ArgumentException("Member형 객체를 생성하기 위한 mailNumber가 유효하지 않습니다.", "Member.mailNumber");
        if (ValidChecker.checkStringValid(authenticationQustion) == false) throw new System.ArgumentException(
            "Member형 객체를 생성하기 위한 authenticationQustion이 유효하지 않습니다.", "Member.authenticationQustion");
        if (ValidChecker.checkStringValid(authenticationAnswer) == false) throw new System.ArgumentException(
            "Member형 객체를 생성하기 위한 authenticationAnswer이 유효하지 않습니다.", "Member.authenticationAnswer");

        this.id = id;
        this.password = password;
        this.subEmail = subEmail;
        this.phone = phone;
        this.mailNumber = mailNumber;
        this.address = address;
        this.authenticationQustion = authenticationQustion;
        this.authenticationAnswer = authenticationAnswer;
	}
    public string getId(){ return this.id; }
    public string getPassword() { return this.password; }
    public string getSubEmail() { return this.subEmail; }
    public string getPhone() { return this.phone; }
    public string getMailNumber() { return this.mailNumber; }
    public string getAddress() { return this.address; }
    public string getAuthenticationQustion() { return this.authenticationQustion; }
    public string getAuthenticationAnswer() { return this.authenticationAnswer; }

    public bool setPassword(string password) 
    {
        if (ValidChecker.checkStringValid(password) == false) return false;
        this.password = password;
        return true;
    }
    public bool setSubEmail(string subEmail)
    {
        if (ValidChecker.checkStringValid(subEmail) == false) return false;
        this.subEmail = subEmail;
        return true;
    }
    public bool setPhone(string phone)
    {
        if (ValidChecker.checkStringValid(phone) == false) return false;
        this.phone = phone;
        return true;
    }
    public bool setMailNumber(string mailNumber)
    {
        if (ValidChecker.checkStringValid(mailNumber) == false) return false;
        this.mailNumber = mailNumber;
        return true;
    }    
    public bool setAddress(string address)
    {
        if (ValidChecker.checkStringValid(address) == false) return false;
        this.address = address;
        return true;
    }
    public bool setAuthenticationQustion(string question)
    {
        if (ValidChecker.checkStringValid(question) == false) return false;
        this.authenticationQustion = question;
        return true;
    }
    public bool setAuthenticationAnswer(string answer)
    {
        if (ValidChecker.checkStringValid(answer) == false) return false;
        this.authenticationAnswer = answer;
        return true;
    }
}