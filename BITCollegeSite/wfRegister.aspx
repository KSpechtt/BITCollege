<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfRegister.aspx.cs" Inherits="wfRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblCourseSelector" runat="server" Text="Course Selector: "></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCourseTitle" runat="server" Height="26px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblRegNotes" runat="server" Text="Registration Notes: "></asp:Label>
    <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtNotes" ErrorMessage="Text is required."></asp:RequiredFieldValidator>
    <br />
    <asp:LinkButton ID="lbRegister" runat="server" onclick="lbRegister_Click">Register</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbReturn" runat="server" onclick="lbReturn_Click">Return to Registration Listing</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="lblException" runat="server" Text="Exception" Visible="False"></asp:Label>
</asp:Content>

