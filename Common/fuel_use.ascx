<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fuel_use.ascx.cs" Inherits="Common_fuel_use" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
    GridLines="None" ShowHeader="False" DataKeyNames="fuel_id,data_source,work_id"
    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:BoundField DataField="mchn_name" />
        <asp:TemplateField>
            <ItemTemplate>
                <%--<asp:LinkButton ID="lbAttach" runat="server" Text='<%# Eval("OrignalFileName") %>'
                    CommandName="Download" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                    CausesValidation="False"></asp:LinkButton>--%>
                <asp:ImageButton ID="ibDel" runat="server" ImageUrl="~/images/del.png" Width="12"
                    ImageAlign="AbsMiddle" CommandName="DelAttach" AlternateText="移除" CausesValidation="False"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ibDel_Command" />
            </ItemTemplate>
            <ItemStyle Font-Size="Smaller" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btnSelect" runat="server" Text="選擇勤務" CssClass="btn_grey" CausesValidation="False"
    OnClick="btnSelect_Click" />
<asp:HiddenField ID="fuel_id" runat="server" />
<asp:HiddenField ID="card_id" runat="server" />
<asp:HiddenField ID="data_source" runat="server" />
<asp:HiddenField ID="deal_date" runat="server" />
<asp:HiddenField ID="work_id" runat="server" />
 <script language="JavaScript" type="text/JavaScript">
     function openPage() {
         var card_id = document.getElementById("MasterPage_ContentPlaceHolder1_fuel_use1_card_id").value;  
         var data_source = document.getElementById("MasterPage_ContentPlaceHolder1_fuel_use1_data_source").value; 
         var deal_date = document.getElementById("MasterPage_ContentPlaceHolder1_fuel_use1_deal_date").value;

         deal_date = deal_date.substr(0, 3) + deal_date.substr(4, 2) + deal_date.substr(7, 2);

         var openWin = window.open("../Common/select_work.aspx?card_id=" + card_id + "&data_source=" + data_source + 
         "&deal_date=" + deal_date, "選擇勤務記錄", "height=510, width=600, top=100, " +
         "left=100, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=yes");
         openWin.focus();
         return false;
     }    
</script>