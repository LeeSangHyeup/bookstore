<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="check.aspx.cs" Inherits="view_account_check" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw" align="center">
<div class="col-lg-3"></div>
<div class="col-lg-6">
<h3>본인확인<br/><br /></h3>
<div class="form-horizontal" role="form">
  <div class="form-group">
    <label for="inputPassword" class="col-lg-2 control-label">계정 비밀번호</label>
    <div class="col-lg-10" align="left">
      <asp:Textbox type="password" runat="server" class="form-control" id="Password" placeholder="비밀번호입력"/>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="비밀번호를 입력하세요." ControlToValidate="Password" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
   <div class="form-group">
    <label for="question" id="lbl_question" class="col-lg-2 control-label">본인확인 질문</label>
    <div class="col-lg-10" align = "left">
        <asp:Label ID="question" class="col-lg-2 control-label" runat="server"></asp:Label>
    </div>
  </div>
  <div class="form-group">
    <label for="answer" class="col-lg-2 control-label">본인확인 답</label>
    <div class="col-lg-10" align="left">
      <asp:Textbox type="text" runat="server" class="form-control" id="answer" placeholder="정답입력"/>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="본인확인 답을 입력하세요." ControlToValidate="answer" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>

  <asp:Button type="submit" runat="server" class="btn btn-default" Text="본인확인" 
      onclick="Unnamed1_Click"/>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</div>
</asp:Content>
