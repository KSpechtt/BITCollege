<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfstudent.aspx.cs" Inherits="wfstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <br />
    <asp:Label ID="lblStudentName" runat="server" Text="Student Name"></asp:Label>
    <br />
    <asp:GridView ID="dgvCourses" runat="server" AutoGenerateColumns="False" 
        Width="587px" onselectedindexchanged="dgvCourses_SelectedIndexChanged">
        <Columns>
            <asp:CommandField HeaderText="View/Drop" ShowSelectButton="True" />
            <asp:BoundField DataField="CourseNumber" HeaderText="Course" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="CreditHours" DataFormatString="{0:N0}" 
                HeaderText="Credit Hours" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CourseType" HeaderText="Course Type" />
            <asp:BoundField DataField="TuitionAmount" DataFormatString="{0:C}" 
                HeaderText="Tuition">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:LinkButton ID="lbRegisterForCourse" runat="server" 
        onclick="lbRegisterForCourse_Click">Click here to register for a course</asp:LinkButton>
    <br />
    <asp:Label ID="lblServiceResults" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblExceptionResults" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
</asp:Content>

