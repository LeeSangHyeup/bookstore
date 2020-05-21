<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="bookcart.aspx.cs" Inherits="view_order_bookcart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw" align="center">
<div class="col-lg-2"></div>
<div class="col-lg-7">
<div class="form-horizontal" role="form">
<div class="col-lg-offset-2 col-lg-10">
    <h3>Book Cart<br/><br /></h3>
</div>

<div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed" OnRowCommand="GridView1_RowCommand"
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
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="deleteButton" Text="삭제" runat="server" class="btn-danger" CommandName="deleteItem" CommandArgument='<%#Eval("item_number") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<div class="form-group">
<div class="col-lg-offset-2 col-lg-10">
    <asp:Button type="submit" class="btn btn-default" id="btn_order" runat="server" text="주문하기" 
        onclick="Unnamed1_Click"/>
</div>
</div>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</div>
</asp:Content>