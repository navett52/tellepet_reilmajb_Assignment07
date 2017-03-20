<%@ Page Title="" Language="C#" MasterPageFile="~/Assn07Master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tellepet_reilmajb_Assignment07_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="Server">
    <div id="wrapper">
        <asp:Table ID="tContent" runat="server" Height="500px" Width="700px" HorizontalAlign="Center">
            <asp:TableRow runat="server">

                <asp:TableCell runat="server">
                    <asp:Calendar ID="calStartDate" runat="server" BackColor="White"></asp:Calendar>
                </asp:TableCell>

                <asp:TableCell runat="server">
                    <asp:Calendar ID="calEndDate" runat="server" BackColor="White"></asp:Calendar>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">

                <asp:TableCell runat="server">Minimum Quantity Sold
                    <br />
                    <asp:TextBox ID="txtMinQty" runat="server"></asp:TextBox>
                </asp:TableCell>

                <asp:TableCell runat="server">Maximum Quantity Sold
                    <br />
                    <asp:TextBox ID="txtMaxQty" runat="server"></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow runat="server">

                <asp:TableCell runat="server">Pick the Product<br />
                    <asp:DropDownList ID="ddProducts" runat="server" Width="300"></asp:DropDownList>
                </asp:TableCell>

                <asp:TableCell runat="server">
                    Pick the store(s)
                    <br />
                    <div id="storeList">
                        <asp:CheckBoxList ID="cblStores" runat="server"></asp:CheckBoxList>
                    </div>
                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>

        <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
    </div>
</asp:Content>

