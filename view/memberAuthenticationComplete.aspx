<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="memberAuthenticationComplete.aspx.cs" Inherits="view_account_memberAuthenticationComplete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="form-horizontal" role="form" id="refister_form" >
    <div class="col-lg-12" align="center">
        <abbr><h3>계정인증이 완료되었습니다.</h3></abbr><br />
        <abbr>이제 등록하신 계정으로 BookStore에 로그인 할 수 있습니다.</abbr><br/><br/>
        <asp:Button class="btn btn-default" runat="server" Text="로그인하기" ID="btn_login" onclick="btn_login_Click"/>
    </div>
</div>
</asp:Content>