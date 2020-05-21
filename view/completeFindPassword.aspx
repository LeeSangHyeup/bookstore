<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="completeFindPassword.aspx.cs" Inherits="view_account_completeFindPassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw" align="center">
<div class="col-lg-3"></div>
<div class="col-lg-6">
<h3>비밀번호찾기메일 발송됨<br/><br /></h3>
<abbr>2차 이메일로 BookSTore 비밀번호찾기 메일이 발송되었습니다..<br />.<br /></abbr>
<div class="form-horizontal" role="form">
    <asp:Button type="submit" class="btn btn-default" runat="server" 
      ID="btn_findPassword" Text="로그인하기" onclick="btn_login_Click"/>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</div>
</div>
</asp:Content>