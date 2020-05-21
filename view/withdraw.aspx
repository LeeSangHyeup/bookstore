<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="withdraw.aspx.cs" Inherits="view_account_withdraw" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw" align="center">
<div class="col-lg-2"></div>
<div class="col-lg-7">
<div class="form-horizontal" role="form">
    <div class="col-lg-offset-2 col-lg-10">
      <h3>회원탈퇴<br/><br/></h3>
      <abbr>BookStore에서의 모든 주문정보와 회원정보가 영구적으로 삭제되며, 복구할 수 없습니다.<br/></abbr>
      <abbr>확실하다면 계정비밀번호를 입력하고 회원탈퇴 버튼을 눌러주세요.</abbr><br /><br /><br />
    </div>
  <div class="form-group">
    <label for="inputPassword1" class="col-lg-2 control-label">비밀번호</label>
    <div class="col-lg-10 col-lg-2" align="left">
      <asp:Textbox type="password" class="form-control" id="inputPassword" runat="server" placeholder="*******"/>
      <asp:RequiredFieldValidator ControlToValidate="inputPassword" 
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="비밀번호를 입력하세요." 
            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <br /><br />
  <div class="col-lg-offset-2 col-lg-10">
      <asp:Button type="submit" class="btn btn-default" Text="회원탈되" runat="server" 
          ID="btn_withdraw" onclick="btn_withdraw_Click"/>
  </div>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</div>
</asp:Content>
