<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfdrop.aspx.cs" Inherits="wfdrop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:DetailsView ID="dvRegistrations" runat="server" AllowPaging="True" 
        AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
        Height="214px" onpageindexchanging="DetailsView1_PageIndexChanging" 
        Width="268px">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="RegistrationNumber" HeaderText="Registration" />
            <asp:BoundField DataField="Student.FullName" HeaderText="Student" />
            <asp:BoundField DataField="Course.CourseType" HeaderText="Course" />
            <asp:BoundField DataField="RegistrationDate" HeaderText="Date" />
            <asp:BoundField DataField="Grade" HeaderText="Grade" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <br />
    <asp:LinkButton ID="LinkButtonDrop" runat="server" 
        onclick="LinkButtonDrop_Click">Drop</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButtonReturn" runat="server" 
        onclick="LinkButtonReturn_Click">Return to registration listing</asp:LinkButton>
&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="lblException" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>

