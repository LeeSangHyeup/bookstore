<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="register.aspx.cs" Inherits="register" Debug="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw">
<div class="col-lg-2"></div>
<div class="col-lg-7">
<div class="form-horizontal" role="form" id="refister_form">
    <div class="col-lg-offset-2 col-lg-10">
      <h3>회원가입<br/><br /></h3>
    </div>
  <div class="form-group">
    <label for="inputID" class="col-lg-2 control-label">아이디(Email)</label>
    <div class="col-lg-10" align="left">
      <asp:TextBox ID="inputID" class="form-control "
            placeholder="ex) HongGildong.gmail.com" runat="server"></asp:TextBox>
      <asp:RegularExpressionValidator ControlToValidate="inputID" 
            ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="이메일의 형식이 올바르지 않습니다." 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Display="Dynamic"></asp:RegularExpressionValidator>
      <asp:RequiredFieldValidator ControlToValidate="inputID" 
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="아이디를 입력하세요" 
            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <div class="form-group">
    <label for="inputPassword1" class="col-lg-2 control-label">비밀번호</label>
    <div class="col-lg-10" align="left">
      <asp:TextBox class="form-control" id="inputPassword1" runat="server" 
            placeholder="글자, 숫자를 조합하여 7자리 이상" TextMode="Password"></asp:TextBox>
      <asp:RequiredFieldValidator ControlToValidate="inputPassword1" 
            ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="비밀번호를 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ControlToValidate="inputPassword1" 
            ID="RegularExpressionValidator2" runat="server" 
            ErrorMessage="숫자와 글자를 조합하여 7자리 이상이어야 합니다." Display="Dynamic" 
            ValidationExpression="\w{7,}"></asp:RegularExpressionValidator>
    </div>
  </div>
  <div class="form-group">
    <label for="inputPassword2" class="col-lg-2 control-label">비밀번호 확인</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputPassword2" placeholder="비밀번호와 동일하게 입력" TextMode="Password" runat="server"></asp:textbox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ErrorMessage="비빌번호와 일치하지 않습니다." ControlToCompare="inputPassword1" 
            ControlToValidate="inputPassword2" Display="Dynamic"></asp:CompareValidator>
        <asp:RequiredFieldValidator ControlToValidate="inputPassword2" 
            ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="비밀번호 확인을 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <div class="form-group">
    <label for="inputEmail" class="col-lg-2 control-label">2차 Email</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputEmail" placeholder="아이디와 다른 사용가능한 이메일" runat="server"></asp:textbox>
      <asp:RequiredFieldValidator ControlToValidate="inputEmail" 
            ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="2차 이메일을 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ControlToValidate="inputEmail" ControlToCompare="inputID" 
            ID="RegularExpressionValidator3" runat="server" 
            ErrorMessage="2차 이메일의 형식이 올바르지 않습니다." 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator" Operator="NotEqual" ControlToCompare="inputID" ControlToValidate="inputEmail" Display="Dynamic"></asp:CompareValidator>
    </div>
  </div>
  <div class="form-group">
    <label for="inputPhone" class="col-lg-2 control-label">전화번호</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputPhone" placeholder="ex) xxx-xxxx-xxxx" runat="server"></asp:textbox>
      <asp:RequiredFieldValidator ControlToValidate="inputPhone" 
            ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="연락처를 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ControlToValidate="inputPhone" 
            ID="RegularExpressionValidator4" runat="server" 
            ErrorMessage="연락처의 형식이 올바르지 않습니다." 
            Display="Dynamic" ValidationExpression="\d{3}-\d{4}-\d{4}"></asp:RegularExpressionValidator>
    </div>
  </div>
  <div class="form-group">
    <label for="inputMailNumber" class="col-lg-2 control-label">우편번호</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputMailNumber" runat="server" placeholder="ex) xxx-xxx 또는 xxx-xx"></asp:textbox>
      <asp:RequiredFieldValidator ControlToValidate="inputMailNumber" 
            ID="RequiredFieldValidator6" runat="server" 
            ErrorMessage="우편번호를 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ControlToValidate="inputMailNumber" 
            ID="RegularExpressionValidator5" runat="server" 
            ErrorMessage="우편번호의 형식이 올바르지 않습니다." 
            Display="Dynamic" ValidationExpression="\d{3}-\d{2,3}"></asp:RegularExpressionValidator>
    </div>
  </div>
  <div class="form-group">
    <label for="inputAddress" class="col-lg-2 control-label">배송지 주소</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputAddress" runat="server" placeholder="배송받을 상세주소"></asp:textbox>
      <asp:RequiredFieldValidator ControlToValidate="inputAddress" 
            ID="RequiredFieldValidator7" runat="server" 
            ErrorMessage="배송지 주소를 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
   <div class="form-group">
    <label for="inputAuthenticationQuestion" class="col-lg-2 control-label">본인확인 질문</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputAuthenticationQuestion" runat="server" placeholder="계정의 아이디 또는 비밀번호를 분실하였을 시 이를 찾기위해 사용됩니다."></asp:textbox>
      <asp:RequiredFieldValidator ControlToValidate="inputAuthenticationQuestion" 
            ID="RequiredFieldValidator8" runat="server" 
            ErrorMessage="본인확인 질문을 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
   <div class="form-group">
    <label for="inputAuthenticationAnswer" class="col-lg-2 control-label">본인확인 답</label>
    <div class="col-lg-10" align="left">
      <asp:textbox class="form-control" id="inputAuthenticationAnswer" runat="server" placeholder="본인확인 질문에 대한 정답"></asp:textbox>
      <asp:RequiredFieldValidator ControlToValidate="inputAuthenticationAnswer" 
            ID="RequiredFieldValidator9" runat="server" 
            ErrorMessage="본인확인 답을 입력하세요." Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
  </div>
  <div class="form-group">
    <div class="col-lg-offset-2 col-lg-10">
    </div>
  </div>
  <div class="form-group">
    <div class="col-lg-offset-2 col-lg-10">
      <asp:Button type="submit" class="btn btn-default" runat="server" Text="회원가입" ID="btn_register" onclick="btn_register_Click"/>
    </div>
  </div>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</div>
</asp:Content>
