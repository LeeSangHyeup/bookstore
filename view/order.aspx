<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="order.aspx.cs" Inherits="view_order_order" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw" align="center">
<div class="col-lg-2"></div>
<div class="col-lg-7">
<div class="form-horizontal" role="form" >
<div class="col-lg-offset-2 col-lg-10">
    <h3>주문하기<br/><br /></h3>
</div>
<div align="left">
    <h4>주문상품 확인<br/><br /></h4>
</div>
<div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed"
        AutoGenerateColumns="False" GridLines="None">
        <Columns>
            <asp:BoundField DataField="book_name" HeaderText="도서명" />
            <asp:BoundField DataField="cost" HeaderText="가격" />
            <asp:TemplateField HeaderText="수량">
                <ItemTemplate>
                    <asp:TextBox ID="quantity" runat="server" type="number" class="input-sm" width="15%" Text='<%#Eval("quantity") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="수량을 입력하세요." ControlToValidate="quantity" Display="Dynamic"></asp:RequiredFieldValidator>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<br/><br/>
<div align="left">
    <h4>주문자 정보</h4>
    <br />
    <div class="input-group">
    </div>
</div>

<div class="form-group">
<label for="inputName" class="col-lg-2 control-label">받으시는분</label>
<div class="col-lg-10" align="left">
    <asp:Textbox type="text" class="form-control" id="recipient" runat="server" placeholder="ex) 홍길동"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="받으시는분 이름을 입력하세요." ControlToValidate="recipient" Display="Dynamic"></asp:RequiredFieldValidator>
</div>
</div>
<div class="form-group">
<label for="inputPhone" class="col-lg-2 control-label">연락처</label>
<div class="col-lg-10" align="left">
    <asp:Textbox type="text" class="form-control" runat="server" id="phone" placeholder="ex) xxx-xxxx-xxxx"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="받으시는분 연락처를 입력하세요." ControlToValidate="phone" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ControlToValidate="phone" 
            ID="RegularExpressionValidator4" runat="server" 
            ErrorMessage="연락처의 형식이 올바르지 않습니다." 
            Display="Dynamic" ValidationExpression="\d{3}-\d{4}-\d{4}"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group">
<label for="inputEmail" class="col-lg-2 control-label">Email</label>
<div class="col-lg-10" align="left">
    <asp:Textbox type="text" class="form-control" runat="server" id="email" placeholder="ex) HonGilDong@gmail.com"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="받으시는분 이메일을 입력하세요." ControlToValidate="email" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ControlToValidate="email" 
            ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="이메일의 형식이 올바르지 않습니다." 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group">
<label for="inputMailNumber" class="col-lg-2 control-label">우편번호</label>
<div class="col-lg-10" align="left">
    <asp:Textbox type="text" runat="server" class="form-control" id="mailNumber" placeholder="ex) xxx-xxx"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="받으시는분 우편번호를 입력하세요." ControlToValidate="mailNumber" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ControlToValidate="mailNumber" 
            ID="RegularExpressionValidator5" runat="server" 
            ErrorMessage="우편번호의 형식이 올바르지 않습니다." 
            Display="Dynamic" ValidationExpression="\d{3}-\d{2,3}"></asp:RegularExpressionValidator>
</div>
</div>
<div class="form-group">
<label for="inputAddress" class="col-lg-2 control-label">주소</label>
<div class="col-lg-10" align="left">
    <asp:Textbox type="text" class="form-control" id="address" runat="server" placeholder="ex) 충북 서천군 기산면 두북리 63-1"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="받으시는분 주소를 입력하세요." ControlToValidate="address" Display="Dynamic"></asp:RequiredFieldValidator>
</div>
</div>
<br/>
입금하실 계좌번호: <b>xx은행 xxx-xxx-xxxxxx 북스토어</b>
<br/><br/>
<div class="form-group">
<div class="col-lg-offset-2 col-lg-10">
    <asp:Button type="submit" runat="server" class="btn btn-default" Text="주문완료" 
        onclick="Unnamed1_Click"/>
    <br/><br/>
</div>
</div>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</div>
</asp:Content>