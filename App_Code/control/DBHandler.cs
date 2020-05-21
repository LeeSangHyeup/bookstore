using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Data;
using System.IO;
using Npgsql;
using System.Drawing;

/// <summary>
/// 웹 애플리케이션에서의 db에대한 모든 접근을 관리
/// </summary>
public class DBHandler
{
    //db기본연결정보
    private string serverIp ="192.168.0.6";
    private string serverPort = "5432";
    private string dbUserName = "postgres";
    private string dbPassword = "00000NUL(null)";
    private string dbName = "bookstore";
    //테이블 이름
    private string memberTable = "member";
    private string bookTable = "book";
    private string bookCartItemTable = "bookcartitem";
    private string temporaryOrderItemTable = "temporaryorderitem";
    private string bookOrderTable = "bookorder";

    private NpgsqlConnection connection;
    public DBHandler()
    {
        string connectionString =
            "Server=" + serverIp +
            ";Port=" + serverPort +
            ";UserId=" + dbUserName +
            ";Password=" + dbPassword +
            ";Database="+  dbName +
            ";Integrated Security=true;";

        this.connection = new NpgsqlConnection();

        this.connection.ConnectionString = connectionString;
        try
        {
            this.connection.Open();
        }
        catch(Exception e)
        {
            throw e;
        }

    }
    ~DBHandler()
    {
        this.connection.Close();
    }
    //계정관리
    public bool registerMember(Member member)
    {
        Debug.Assert(member != null);
        if (member==null) return false;

        string id = member.getId();
        string password = member.getPassword();
        string subEmail = member.getSubEmail();
        string address = member.getAddress();
        string phone = member.getPhone();
        string mailNumber = member.getMailNumber();
        string authenticationQustion = member.getAuthenticationQustion();
        string authenticationAnswer = member.getAuthenticationAnswer();

        string query = "insert into "+memberTable+ " (id, password,sub_email,phone,mail_number,address,authentication_question,authentication_answer)" +
            "values(@id,@password,@subEmail,@phone,@mailNumber,@address,@authenticationQustion,@authenticationAnswer);";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@password", password);
        sqlCommand.Parameters.AddWithValue("@subEmail", subEmail);
        sqlCommand.Parameters.AddWithValue("@phone", phone);
        sqlCommand.Parameters.AddWithValue("@mailNumber", mailNumber);
        sqlCommand.Parameters.AddWithValue("@address", address);
        sqlCommand.Parameters.AddWithValue("@authenticationQustion", authenticationQustion);
        sqlCommand.Parameters.AddWithValue("@authenticationAnswer", authenticationAnswer);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        

        new MailSender().sendRegisterAuthenticationEmail(id);

        return true;
    }
    public bool checkCanLogin(string id, string password)
    {
        string query = "select exists (select 1 from " + memberTable + " where Id='" + id + "' and password='"+password+"');";
        NpgsqlCommand cmd = new NpgsqlCommand(query, this.getConnection());
        NpgsqlDataReader dr = null;
        try
        {
            dr = cmd.ExecuteReader();
        }
        catch
        {
            return false;
        }
        Debug.Assert(dr!=null);

        string resultString = "";
        while (dr.Read()) { resultString += dr[0]; }
        resultString = resultString.Trim();

        if (resultString.Equals("True")) return true;
        return false;
    }
    public bool updateMemberAuthentication(string memberId)
    {
        string query = "update "+memberTable+" set isauthentication='t' where id='"+memberId+"';";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);
        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool checkMemberExist(string memberId)
    {
        string query = "select exists (select 1 from "+memberTable+" where Id='"+memberId+"');";
        NpgsqlCommand cmd = new NpgsqlCommand(query, this.getConnection());
        NpgsqlDataReader dr = cmd.ExecuteReader();

        string resultString = "";
        while (dr.Read()) { resultString += dr[0]; }
        resultString = resultString.Trim();

        if (resultString.Equals("True")) return true;
        return false;
    }
    public bool deleteMember(string memberId)
    {
        if (ValidChecker.checkStringValid(memberId) == false) return false;
        if(this.deleteAllMemberInformation(memberId)==false)return false;


        string query = "delete from "+this.memberTable+" where id='"+memberId+"';";
        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }

        return true;
    }
    public Member inquiryMember(string memberId)
    {
        if (ValidChecker.checkStringValid(memberId) == false) return null;

        string query = "select * from member where id='" + memberId + "';";
        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        NpgsqlDataReader dataReader=null;

        try
        {
            dataReader = sqlCommand.ExecuteReader();
        }
        catch
        {
            return null;
        }

        Debug.Assert(dataReader != null);

        if(!dataReader.HasRows)return null;

        string id = null;
        string password = null;
        string sub_email = null;
        string phone = null;
        string mail_number = null;
        string address = null;
        string authentication_question = null;
        string authentication_answer = null;

        while (dataReader.Read())
        {
            id = dataReader.GetString(1);
            password = dataReader.GetString(2);
            sub_email = dataReader.GetString(3);
            phone = dataReader.GetString(4);
            mail_number = dataReader.GetString(5);
            address = dataReader.GetString(6);
            authentication_question = dataReader.GetString(7);
            authentication_answer = dataReader.GetString(8);
        }

        dataReader.Close();

        Member member = new Member(id, password, sub_email, phone, mail_number, address, authentication_question, authentication_answer);
        Debug.Assert(member != null);

        return member;
    }
    public Member inquiryMemberSubEmail(string subEmail)
    {
        if (ValidChecker.checkStringValid(subEmail) == false) return null;

        string query = "select * from member where sub_email='" + subEmail+"';";
        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        NpgsqlDataReader dataReader = null;

        try
        {
            dataReader = sqlCommand.ExecuteReader();
        }
        catch
        {
            return null;
        }

        Debug.Assert(dataReader != null);

        if (!dataReader.HasRows) return null;

        string id = null;
        string password = null;
        string sub_email = null;
        string phone = null;
        string mail_number = null;
        string address = null;
        string authentication_question = null;
        string authentication_answer = null;

        while (dataReader.Read())
        {
            id = dataReader.GetString(1);
            password = dataReader.GetString(2);
            sub_email = dataReader.GetString(3);
            phone = dataReader.GetString(4);
            mail_number = dataReader.GetString(5);
            address = dataReader.GetString(6);
            authentication_question = dataReader.GetString(7);
            authentication_answer = dataReader.GetString(8);
        }

        dataReader.Close();

        Member member = new Member(id, password, sub_email, phone, mail_number, address, authentication_question, authentication_answer);
        Debug.Assert(member != null);

        return member;
    }
    public bool updateMemberInformation(Member member)
    {
        if (member == null) return false;

        string id = member.getId();
        string password = member.getPassword();
        string subEmail = member.getSubEmail();
        string address = member.getAddress();
        string phone = member.getPhone();
        string mailNumber = member.getMailNumber();
        string authenticationQustion = member.getAuthenticationQustion();
        string authenticationAnswer = member.getAuthenticationAnswer();

        string query = "update " + memberTable + " set "+
            "password='"+password+"', "+
            "sub_email='"+subEmail+"', "+
            "phone='"+phone+"', "+
            "mail_Number='"+mailNumber+"', "+
            "address='"+address+"', "+
            "authentication_question='"+authenticationQustion+"', "+
            "authentication_answer='"+authenticationAnswer+"' "+
            "where id='" + member.getId() + "';";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);
        
        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        return true;
    }
    public string updateMemberPassword(Member member)
    {
        if (member == null) return null;
        string tempPassword = createTempPassword();

        string query = "update " + this.memberTable + " set " +
            "password='" + tempPassword + "' " +
            "where id='"+member.getId()+"';";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return null;
        }

        return tempPassword;
    }
    public string createTempPassword()
    {
        string password = string.Empty;
        string[] alpabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z" };
        string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        string[] special = { "!", "@", "#", "$", "%", "^", "&", "*" };

        Random nalpabet = new Random();
        Random nnumber = new Random();
        Random nspecial = new Random();

        password = alpabet[nalpabet.Next(0, 24)] + alpabet[nalpabet.Next(0, 24)] + alpabet[nalpabet.Next(0, 24)]
                    + number[nnumber.Next(0, 9)] + number[nnumber.Next(0, 9)] + number[nnumber.Next(0, 9)]
                    + special[nspecial.Next(0, 7)] + special[nspecial.Next(0, 7)];

        return password;
    }
    public bool checkMemberAuthentication(string memberId)
    {
        if (ValidChecker.checkStringValid(memberId) == false) return false;

        string query = "select isauthentication from " + memberTable + " where id='" + memberId + "';";

        NpgsqlCommand cmd = new NpgsqlCommand(query, this.getConnection());
        NpgsqlDataReader dr = cmd.ExecuteReader();

        string resultString = "";
        while (dr.Read()) { resultString += dr[0]; }
        resultString = resultString.Trim();

        if (resultString.Equals("True")) return true;
        return false;
    }
    //도서관리
    public DataSet inquiryBooks(string category)
    {
        if(ValidChecker.checkStringValid(category)==false){ return null; }

        string query = "select distinct on(name) * from book where category='"+category+"';";

        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
        dataAdapter.SelectCommand = new NpgsqlCommand(query, this.connection);

        DataSet dataSet = new DataSet("ds1");

        dataAdapter.Fill(dataSet, "ds1");

        return dataSet;
    }
    public Book inquiryBook(string bookNumber)
    {
        if (ValidChecker.checkStringValid(bookNumber) == false) { return null; }

        string query = "select * from book where book_number='" + bookNumber + "';";
        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        NpgsqlDataReader dataReader = null;

        try
        {
            dataReader = sqlCommand.ExecuteReader();
        }
        catch
        {
            return null;
        }

        Debug.Assert(dataReader != null);

        if (!dataReader.HasRows) return null;

        int book_number = -1;
        string name = null;
        string author = null;
        string publisher = null;
        int cost = -1;
        string introduce = null;
        string authorIntroduce = null;
        string category = null;

        while (dataReader.Read())
        {
            book_number = dataReader.GetInt32(0);
            name = dataReader.GetString(1);
            author = dataReader.GetString(2);
            publisher = dataReader.GetString(3);
            cost = dataReader.GetInt32(4);
            introduce = dataReader.GetString(5);
            authorIntroduce = dataReader.GetString(6);
            category = dataReader.GetString(7);
        }

        dataReader.Close();

        Book book = new Book(book_number, name, author, publisher, cost, introduce, authorIntroduce, category);
        Debug.Assert(book!= null);

        return book;
    }
    public DataSet searchBook(string bookName)
    {
        if (ValidChecker.checkStringValid(bookName) == false) { return null; }

        string query = "select * from book where name like'%" + bookName + "%';";

        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
        dataAdapter.SelectCommand = new NpgsqlCommand(query, this.connection);

        DataSet dataSet = new DataSet("ds1");

        dataAdapter.Fill(dataSet, "ds1");

        return dataSet;
    }
    public Book inquaryRandomBook(string inputCategory)
    {
        if (ValidChecker.checkStringValid(inputCategory) == false) return null;

        string query = "select * from " + bookTable + " where category='" + inputCategory + "' order by random() limit 1;";
        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        NpgsqlDataReader dataReader = null;

        try
        {
            dataReader = sqlCommand.ExecuteReader();
        }
        catch
        {
            return null;
        }

        Debug.Assert(dataReader != null);

        if (!dataReader.HasRows) return null;

        int book_number = -1;
        string name = null;
        string author = null;
        string publisher = null;
        int cost = -1;
        string introduce = null;
        string authorIntroduce = null;
        string category = null;

        while (dataReader.Read())
        {
            book_number = dataReader.GetInt32(0);
            name = dataReader.GetString(1);
            author = dataReader.GetString(2);
            publisher = dataReader.GetString(3);
            cost = dataReader.GetInt32(4);
            introduce = dataReader.GetString(5);
            authorIntroduce = dataReader.GetString(6);
            category = dataReader.GetString(7);
        }

        dataReader.Close();

        Book book = new Book(book_number, name, author, publisher, cost, introduce, authorIntroduce, category);
        Debug.Assert(book != null);

        return book;


    }
    //장바구니, 주문관련
    public bool insertBookCartItem(string memberId, string bookName, int bookCost, int bookQuantity)
    {
        if (ValidChecker.checkStringValid(memberId)==false) return false;
        if (ValidChecker.checkStringValid(bookName) == false) return false;
        if (bookCost < 0) return false;
        if (bookQuantity <= 0) return false;

        string cost = bookCost.ToString();
        string quantity = bookQuantity.ToString();

        string query = "insert into " + bookCartItemTable + " (memberid, book_name, cost, quantity)" +
            "values(@MEMBER_ID, @BOOK_NAME, @COST, @QUANTITY);";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        sqlCommand.Parameters.AddWithValue("@MEMBER_ID", memberId);
        sqlCommand.Parameters.AddWithValue("@BOOK_NAME", bookName);
        sqlCommand.Parameters.AddWithValue("@COST", cost);
        sqlCommand.Parameters.AddWithValue("@QUANTITY", quantity);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }

        return true;
    }
    public DataSet inquiryBookCartItems(string memberId)
    {
        if(ValidChecker.checkStringValid(memberId)==false)return null;

        string query = "select * from "+bookCartItemTable+" where memberid='"+memberId+"';";

        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
        dataAdapter.SelectCommand = new NpgsqlCommand(query, this.connection);

        DataSet dataSet = new DataSet("ds1");

        dataAdapter.Fill(dataSet, "ds1");

        return dataSet;

    }
    public bool deleteBookCartItem(int itemNumber)
    {
        if (itemNumber <= 0) return false;

        string query = "delete from " + bookCartItemTable + " where item_number='" + itemNumber + "';";
        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }

        return true;
    }
    public bool insertTemporaryOrderItem(string memberId, string bookName, int bookCost, int bookQuantity)
    {
        if(ValidChecker.checkStringValid(memberId)==false)return false;
        if (ValidChecker.checkStringValid(bookName) == false) return false;
        if (bookCost < 0) return false;
        if (bookQuantity <= 0) return false;

        string cost = bookCost.ToString();
        string quantity = bookQuantity.ToString();

        string query = "insert into " + temporaryOrderItemTable + " (memberid, book_name, cost, quantity)" +
            "values(@MEMBER_ID, @BOOK_NAME, @COST, @QUANTITY);";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        sqlCommand.Parameters.AddWithValue("@MEMBER_ID", memberId);
        sqlCommand.Parameters.AddWithValue("@BOOK_NAME", bookName);
        sqlCommand.Parameters.AddWithValue("@COST", cost);
        sqlCommand.Parameters.AddWithValue("@QUANTITY", quantity);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }

        return true;
    }
    public DataSet inquiryTemporaryOrderItems(string memberId)
    {
        if (ValidChecker.checkStringValid(memberId) == false) return null;

        string query = "select * from " + temporaryOrderItemTable + " where memberid='" + memberId + "';";

        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
        dataAdapter.SelectCommand = new NpgsqlCommand(query, this.connection);

        DataSet dataSet = new DataSet("ds1");

        dataAdapter.Fill(dataSet, "ds1");

        return dataSet;

    }
    public bool deleteTemporaryOrderItems(string memberId)
    {
        if (ValidChecker.checkStringValid(memberId) == false) return false;

        string query = "delete from " + temporaryOrderItemTable + " where memberid='" + memberId + "';";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }

        return true;
    }
    public bool insertOrder(Order order)
    {
        if (order == null) return false;

        string memberId = order.getMemberId();
        string orderName = order.getOrderName();
        string date = order.getDate();
        int cost = order.getCost();
        string state = order.getState();
        string receiver = order.getReceiver();
        string phone = order.getPhone();
        string email= order.getEmail();
        string mailNumber = order.getMailNumber();
        string address = order.getAddress();

        string query = "insert into " + bookOrderTable + " (memberid,order_name,date,cost,state,receiver,phone,email,mailnumber,address)" +
            "values(@MEMBER_ID,@ORDER_NAME,@DATE,@COST,@STATE,@RECEIVER,@PHONE,@EMAIL,@MAIL_NUMBER,@ADDRESS);";

        NpgsqlCommand sqlCommand = new NpgsqlCommand(query, this.connection);

        sqlCommand.Parameters.AddWithValue("@MEMBER_ID", memberId);
        sqlCommand.Parameters.AddWithValue("@ORDER_NAME", orderName);
        sqlCommand.Parameters.AddWithValue("@DATE", date);
        sqlCommand.Parameters.AddWithValue("@COST", cost);
        sqlCommand.Parameters.AddWithValue("@STATE", state);
        sqlCommand.Parameters.AddWithValue("@RECEIVER", receiver);
        sqlCommand.Parameters.AddWithValue("@PHONE", phone);
        sqlCommand.Parameters.AddWithValue("@EMAIL", email);
        sqlCommand.Parameters.AddWithValue("@MAIL_NUMBER", mailNumber);
        sqlCommand.Parameters.AddWithValue("@ADDRESS", address);

        try
        {
            sqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        return true;;
    }
    public DataSet inquiryOrder(string memberId)
    {
        if (ValidChecker.checkStringValid(memberId) == false) return null;

        string query = "select * from " + bookOrderTable + " where memberid='" + memberId + "';";

        NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter();
        dataAdapter.SelectCommand = new NpgsqlCommand(query, this.connection);

        DataSet dataSet = new DataSet("ds1");

        dataAdapter.Fill(dataSet, "ds1");

        return dataSet;
    }
    public bool deleteAllMemberInformation(string memberId)
    {
        if(ValidChecker.checkStringValid(memberId)==false) return false;

        try
        {
            string bookCartITemDeleteQuery = "delete from "+bookCartItemTable+" where memberid='"+memberId+"';";
            NpgsqlCommand deleteBookCartItemSqlCommand = new NpgsqlCommand(bookCartITemDeleteQuery, this.connection);
            deleteBookCartItemSqlCommand.ExecuteNonQuery();

            string OrderDeleteQuery = "delete from "+bookOrderTable+" where memberid='"+memberId+"';";
            NpgsqlCommand DeleteOrderSqlCommand = new NpgsqlCommand(OrderDeleteQuery, this.connection);
            DeleteOrderSqlCommand.ExecuteNonQuery();
        }
        catch
        {
            return false;
        }
        

        return true;

    }
    public NpgsqlConnection getConnection(){ return this.connection; }
}