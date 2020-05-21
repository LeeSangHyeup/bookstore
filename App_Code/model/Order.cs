using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

/// <summary>
/// Order의 요약 설명입니다.
/// </summary>
public class Order
{
    string memberId;
    string orderName;
    string date;
    int cost;
    string state;
    string receiver;
    string phone;
    string email;
    string mailNumber;
    string address;

	public Order(string memberId, string orderName, string date,int cost, string state, string receiver, string phone, string email, string mailNumber, string address)
	{
        Debug.Assert(ValidChecker.checkStringValid(memberId) );
        Debug.Assert(ValidChecker.checkStringValid(orderName));
        Debug.Assert(ValidChecker.checkStringValid(date) );
        Debug.Assert(cost > 0);
        Debug.Assert(ValidChecker.checkStringValid(state) );
        Debug.Assert(ValidChecker.checkStringValid(receiver));
        Debug.Assert(ValidChecker.checkStringValid(phone) );
        Debug.Assert(ValidChecker.checkStringValid(email));
        Debug.Assert(ValidChecker.checkStringValid(mailNumber));
        Debug.Assert(ValidChecker.checkStringValid(address));

        this.memberId = memberId;
        this.orderName = orderName;
        this.date = date;
        this.cost = cost;
        this.state = state;
        this.receiver = receiver;
        this.phone = phone;
        this.email = email;
        this.mailNumber = mailNumber;
        this.address = address;

	}
    public string getMemberId() { return this.memberId; }
    public string getOrderName() { return this.orderName; }
    public string getDate() { return this.date; }
    public int getCost() { return this.cost; }
    public string getState() { return this.state; }
    public string getReceiver() { return this.receiver; }
    public string getPhone() { return this.phone; }
    public string getEmail() { return this.email; }
    public string getMailNumber() { return this.mailNumber; }
    public string getAddress() { return this.address; }
}