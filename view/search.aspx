<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/view/includeSideBarMasterPage.master" CodeFile="search.aspx.cs" Inherits="view_book_Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="table-responsive ">
<h3>검색결과</h3><br /><br />
<div class="col-md-7" align="center">
<div class="table-responsive">
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" class="table tablextable-hover" 
    PagerSettings-Mode="NumericFirstLast" AutoGenerateColumns="False" 
    GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" RowStyle-HorizontalAlign="Center">
    <Columns>
        <asp:TemplateField HeaderText="책이미지">
            <itemTemplate>
                <asp:Image ID="bookImage" runat="server" ImageUrl='<%#"~/view/bookImages/"+Eval("book_number")+".jpg" %>' CssClass="img-responsive img-rounded"/>
            </itemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataTextField="name" DataNavigateUrlFields="book_number" DataNavigateUrlFormatString="./book.aspx?bookNumber={0}" HeaderText="책이름" />
        <asp:BoundField DataField="author" HeaderText="저자" />
        <asp:BoundField DataField="publisher" HeaderText="출판사" />
        <asp:BoundField DataField="cost" HeaderText="가격" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="addToCartButton" Text="북카트" runat="server" class="btn-info" CommandName="addToCart" CommandArgument='<%#Eval("book_number") %>'/>
                <asp:Button ID="buyNowButton" Text="바로구매" runat="server" class="btn-warning" CommandName="buyNow" CommandArgument='<%#Eval("book_number") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
<PagerSettings Mode="NumericFirstLast"></PagerSettings>
</asp:GridView>
</div>

</div>
</div>
<div class="col-lg-3"></div>
</asp:Content>