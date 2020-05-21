<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/MasterPage.master" CodeFile="information.aspx.cs" Inherits="view_order_information" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row" align="center">
<div class="col-md-12">
<div class="raw" align="center">
<div class="col-lg-2"></div>
<div class="col-lg-7">
<div class="form-horizontal" role="form">
<div class="col-lg-offset-2 col-lg-10">
    <h3>주문내역<br/><br /></h3>
</div>
<div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed"
        AutoGenerateColumns="False" GridLines="None">
        <Columns>
            <asp:BoundField DataField="order_number" HeaderText="주문번호" />
            <asp:BoundField DataField="order_name" HeaderText="주문이름" />
            <asp:BoundField DataField="date" HeaderText="주문일" />
            <asp:BoundField DataField="cost" HeaderText="주문총액" />
            <asp:BoundField DataField="state" HeaderText="주문상태" />
        </Columns>
    </asp:GridView>
</div>
</div>
</div>        
</div>
<div class="col-lg-3"></div>
</div>
</asp:Content>