<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/includeSideBarMasterPage.master" CodeFile="book.aspx.cs" Inherits="view_book_book" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="col-md-7 table-responsive">
<table class="table-condensed table-condensed">
<tr>
    <td rowspan="6">
        <asp:Image ID="bookImage" CssClass="img-responsive img-rounded" runat="server"/>
    </td>
</tr>
<tr>
    <td>도서명: </td>
    <td><asp:Label ID="bookName" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>&nbsp분야: </td>
    <td><asp:Label ID="category" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>&nbsp저자: </td>
    <td><asp:Label ID="author" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>출판사: </td>
    <td><asp:Label ID="publisher" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
    <td>판매가: </td>
    <td><asp:Label ID="cost" runat="server" Text=""></asp:Label> 원</td>
</tr>
<tr><td><br /></td></tr>
<tr>
    <td colspan="2"></td>
    <td colspan="2">
        <asp:Button type="button" class="btn btn-info" Text="북카트"  runat="server" 
            onclick="Unnamed1_Click"/>
        <asp:Button type="button" class="btn btn-warning" Text="바로구매" runat="server" 
            onclick="Unnamed2_Click"/>
    </td>
</tr>
<tr>
    <td colspan="4">
    <dl>
        <dt><h3>&nbsp;소개</h3></br></dt>
        <dd><pre><asp:Label ID="introduce" runat="server"></asp:Label></pre></dd>
        <dt><h3>&nbsp;저자 소개</h3></br></dt>
        <dd><pre><asp:Label ID="authorIntroduce" runat="server"></asp:Label></pre></dd>
    </dl>
    </td>
</tr>
</table>
<br /><br /><br />
</div>
</asp:Content>

