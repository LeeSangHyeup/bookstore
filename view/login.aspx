<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-md-4"></div>
<div class="col-md-4">
    <div class="container">
        <h2 class="form-signin-heading">BookStore Login</h2><br />
        <asp:TextBox class="form-control" id="inputID" autofocus="" type="text" runat="server" placeholder="아이디"></asp:TextBox>
        <asp:TextBox class="form-control" id="inputPassword" type="password" runat="server" placeholder="비밀번호"></asp:TextBox>
        <br />
        <ul class="nav nav-pills nav-justified">
            <li><a href="findId.aspx">아이디찾기</a></li>
            <li><a href="findPasswd.aspx">비밀번호찾기</a></li>
        </ul>
        <br />
        <asp:Button ID="loginbtn" class="btn btn-lg btn-primary btn-block" type="submit" runat="server" onclick="loginbtn_Click" Text="Login"/></button>
    </div> <!-- /container -->
</div>
</div>
<div class="col-md-4"></div>
</asp:Content>