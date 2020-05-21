<%@ Page Title="" Language="C#" MasterPageFile="~/view/includeSideBarMasterPage.master" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="col-md-10">
<h2>&nbsp;&nbsp;추천도서</h2>
<div class="col-sm-6 col-md-2">    <div class="thumbnail">      <asp:Image ID="humanImage" runat="server" /></div>
<div class="caption"><h3>인문분야</h3><p><asp:Label ID="humanLabel" runat="server" Text="Label"></asp:Label></p></div></div>
<div class="col-sm-6 col-md-2">    <div class="thumbnail">      <asp:Image ID="novelImgae" runat="server" /></div>
<div class="caption"><h3>소설</h3><p><asp:Label ID="novelLabel" runat="server" Text="Label"></asp:Label></p></div></div>
<div class="col-sm-6 col-md-2">    <div class="thumbnail">      <asp:Image ID="selfDevelopImage" runat="server" /></div>
<div class="caption"><h3>자기개발</h3><p><asp:Label ID="selfDevelopeLabel" runat="server" Text="Label"></asp:Label></p></div></div>
<div class="col-sm-6 col-md-2">    <div class="thumbnail">      <asp:Image ID="youthImage" runat="server" /></div>
<div class="caption"><h3>청소년</h3><p><asp:Label ID="youthLabel" runat="server" Text="Label"></asp:Label></p></div></div>
<div class="col-sm-6 col-md-2">    <div class="thumbnail">      <asp:Image ID="foreignImage" runat="server" /></div>
<div class="caption"><h3>해외도서</h3><p><asp:Label ID="foreignLabel" runat="server" Text="Label"></asp:Label></p></div></div>
</div>
</asp:Content>