<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="registerAuthentication.aspx.cs" Inherits="view_account_registerAuthentication" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="form-horizontal" role="form" id="refister_form">
    <div class="col-lg-12" align="center">
        <abbr><h3>계정등록이 완료되었습니다.</h3></abbr><br />
        <abbr>서비스를 이용하기 위해서는 이메일을 통해 계정을 인증하여야 합니다.</abbr><br />
        <abbr>등록하신 아이디(이메일계정)의 받은메일함에서 인증메일을 열어 인증하기 버튼을 클릭해 주세요</abbr><br/><br/>
        <asp:Button class="btn btn-default" runat="server" Text="로그인하기" ID="btn_login" onclick="btn_login_Click"/>
    </div>
</div>
</asp:Content>