<%@ Page Title="" Language="C#" MasterPageFile="~/Assn07Master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tellepet_reilmajb_Assignment07_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    <div>
        <asp:Calendar ID="calStartDate" runat="server"></asp:Calendar>
        <asp:Calendar ID="calEndDate" runat="server"></asp:Calendar>
        <asp:TextBox ID="txtMinQty" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtMaxQty" runat="server"></asp:TextBox>
        <asp:DropDownList ID="ddProducts" runat="server"></asp:DropDownList>
        <asp:CheckBoxList ID="cblStores" runat="server"></asp:CheckBoxList>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
    </div>
</asp:Content>

