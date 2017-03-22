<%@ Page Title="" Language="C#" MasterPageFile="~/Assn07Master.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Theme/Report.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    <div id="wrapper">
    <asp:Literal ID="litReport" runat="server"></asp:Literal>
    </div>
</asp:Content>

