<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="findId.aspx.cs" Inherits="view_account_findId" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-md-2">
</div>
<div class="col-md-1"></div>
<div class="col-md-6" align="center">
<h2>아이디 찾기</h2></br></br>
<div class="form-horizontal" role="form">
  <div class="form-group">
    <label for="subEmail" class="col-lg-2 control-label">2차 Email 주소</label>
    <div class="col-lg-10" align="left">
      <asp:Textbox type="text" class="form-control" id="subEmail" runat="server" placeholder="HongGilDong@gmail.com"></asp:Textbox>
      <asp:RegularExpressionValidator ControlToValidate="subEmail" 
            ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="이메일의 형식이 올바르지 않습니다." 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Display="Dynamic"></asp:RegularExpressionValidator>
      <asp:RequiredFieldValidator ControlToValidate="subEmail" 
            ID="RequiredFieldValidator2" runat="server" ErrorMessage="2차이메일을 입력하세요" 
            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <asp:Button type="submit" id="findId" runat="server" class="btn btn-default" 
       Text="아이디 찾기" onclick="findId_Click"/>
</div>
</div>
<div class="col-md-3"></div>
    </div>
</asp:Content>