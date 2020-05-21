<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="findPasswd.aspx.cs" Inherits="view_account_findPasswd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-md-2">
</div>
<div class="col-md-1"></div>
<div class="col-md-6" align="center">
<h2>비밀번호 찾기</h2><br/><br/>
<div class="form-horizontal" role="form">
  <div class="form-group">
    <label for="inputPassword" class="col-lg-2 control-label">아이디</label>
    <div class="col-lg-10" align="left">
      <asp:Textbox type="text" class="form-control" id="id" runat="server" placeholder="비밀번호를 찾으려는 아이디를 입력하세요."></asp:Textbox>
      <asp:RegularExpressionValidator ControlToValidate="id" 
            ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="아이디의 형식이 올바르지 않습니다." 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Display="Dynamic"></asp:RegularExpressionValidator>
      <asp:RequiredFieldValidator ControlToValidate="id" 
            ID="RequiredFieldValidator2" runat="server" ErrorMessage="아이디를 입력하세요." 
            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <asp:Button type="submit" class="btn btn-default" runat="server" 
      ID="btn_findPassword" Text="다음" onclick="btn_findPassword_Click"/>
</div>
</div>
<div class="col-md-3"></div>
    </div>
</asp:Content>
