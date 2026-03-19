<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="work_item.aspx.cs" Inherits="Common_work_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div style="padding:10px">   
    <asp:CheckBoxList ID="work_item" runat="server" RepeatDirection="Horizontal" 
        RepeatColumns="3" AutoPostBack="true" 
        onselectedindexchanged="work_item_SelectedIndexChanged" >
    </asp:CheckBoxList></div> 
    <asp:HiddenField ID="work_type" runat="server" />
    <asp:HiddenField ID="work_item_selected" runat="server" />
</asp:Content>
