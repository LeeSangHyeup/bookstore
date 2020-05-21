<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master"  CodeFile="findPasswd2.aspx.cs" Inherits="view_account_findPasswd2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-md-2">
</div>
<div class="col-md-1"></div>
<div class="col-md-6" align="center">
<h2>비밀번호 찾기</h2><br/><br/>
<div class="form-horizontal" role="form">
   <div class="form-group" align = "left">
    <label class="col-lg-2 control-label" id="question">본인확인 질문</label>
    <div class="col-lg-10">
      <p class="form-control-static"><asp:Label ID="question" runat="server"></asp:Label></p>
    </div>
  </div>
  <div class="form-group">
    <label for="answer" class="col-lg-2 control-label">본인확인 답</label>
    <div class="col-lg-10" align="left">
      <asp:Textbox type="text" class="form-control" id="answer" runat="server" placeholder="정답입력"></asp:Textbox>
      <asp:RequiredFieldValidator ControlToValidate="answer" 
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="본인확인 답을 입력하세요" 
            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <asp:Button type="submit" class="btn btn-default" runat="server" 
      ID="btn_findPassword" Text="임시 비밀번호 발송" onclick="btn_findPassword_Click"/>
</div>
</div>
<div class="col-md-3"></div>
</div>
</asp:Content>
