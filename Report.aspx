<%@ Page Title="" Language="C#" MasterPageFile="~/Assn07Master.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    <div class="reportCell">
        <asp:Label ID="lblStoreName" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblManufacturer" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblQty" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

