<%@ Control Language="C#" AutoEventWireup="true" CodeFile="jQueryLightBoxPlugin.ascx.cs"
    Inherits="Common_jQueryLightBoxPlugin" %>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/jquery.lightbox-0.5.js"></script>
<link rel="stylesheet" type="text/css" href="../css/jquery.lightbox-0.5.css" media="screen" />
<script type="text/javascript">
    $(function () {
        $('#gallery a').lightBox();
    });
</script>
<style type="text/css">
    /* jQuery lightBox plugin - Gallery style */
    #gallery
    {
        /*background-color: #444;*/
        padding: 10px;
        width: 860px;
        float: left;
    }
    #gallery ul
    {
        list-style: none;
    }
    #gallery ul li
    {
        display: inline;
    }
    #gallery ul img
    {
        border: 5px solid #3e3e3e;
        border-width: 5px 5px 5px;
    }
    #gallery ul a:hover img
    {
        border: 5px solid #EEEEEE;
        border-width: 5px 5px 5px;
        color: #fff;
    }
    #gallery ul a:hover
    {
        color: #fff;
    }
</style>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
<a name="attach"></a>
<asp:Panel ID="pnlMain" runat="server">
    <div id="gallery">
        <ul>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <%-- <li>
            <a href="../Attach_File/IMG_0929.PNG" title="是否支持中文">
                <img src="../Attach_File/IMG_0929.PNG" width="72" height="72" alt="" />
            </a>
        </li>
        <li>
            <a href="jquery-lightbox-0.5/photos/image2.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="jquery-lightbox-0.5/photos/thumb_image2.jpg" width="72" height="72" alt="" />
            </a>
        </li>
        <li>
            <a href="jquery-lightbox-0.5/jquery-lightbox-0.5/photos/image3.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="jquery-lightbox-0.5/photos/thumb_image3.jpg" width="72" height="72" alt="" />
            </a>
        </li>
        <li>
            <a href="jquery-lightbox-0.5/photos/image4.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="jquery-lightbox-0.5/photos/thumb_image4.jpg" width="72" height="72" alt="" />
            </a>
        </li>
        <li>
            <a href="jquery-lightbox-0.5/photos/image5.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="jquery-lightbox-0.5/photos/thumb_image5.jpg" width="72" height="72" alt="" />
            </a>
        </li>
         <li>
            <a href="jquery-lightbox-0.5/photos/image5.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="jquery-lightbox-0.5/photos/thumb_image5.jpg" width="72" height="72" alt="" />
            </a>
        </li>
         <li>
            <a href="jquery-lightbox-0.5/photos/image5.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="photos/thumb_image5.jpg" width="72" height="72" alt="" />
            </a>
        </li>
         <li>
            <a href="jquery-lightbox-0.5/photos/image5.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="photos/thumb_image5.jpg" width="72" height="72" alt="" />
            </a>
        </li>
         <li>
            <a href="jquery-lightbox-0.5/photos/image5.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="photos/thumb_image5.jpg" width="72" height="72" alt="" />
            </a>
        </li>
         <li>
            <a href="jquery-lightbox-0.5/photos/image5.jpg" title="Utilize a flexibilidade dos seletores da jQuery e crie um grupo de imagens como desejar. $('#gallery a').lightBox();">
                <img src="photos/thumb_image5.jpg" width="72" height="72" alt="" />
            </a>
        </li>--%>
        </ul>
    </div>
    <div style="display: inherit; float: right; width: 90px">
        <asp:Button ID="btnEdit" runat="server" Text="編輯" CssClass="btn_grey" OnClick="btnEdit_Click" />
    </div>
</asp:Panel>
<asp:Panel ID="pnlEdit" runat="server" Visible="false">
    <div style="float: left; width: 860px;">
        <fieldset style="width: 98%;">
            <legend>
                <asp:Image ID="Image1" runat="server" BorderStyle="None" ImageUrl="~/images/1341303209_folder_up.png"
                    ImageAlign="AbsMiddle" Width="25px" />&nbsp;<span class="font_title">新增 / 編輯檔案：</span>
            </legend>
            <div style="padding: 5px; padding-left: 30px;">
                附件名稱：<asp:TextBox ID="attach_name" runat="server"></asp:TextBox>&nbsp; 附件說明：<asp:TextBox
                    ID="attach_desc" runat="server"></asp:TextBox>
                <br />
                選擇附件檔案：
                <asp:FileUpload ID="uplfiles" runat="server" Width="430px" />
                <asp:Button ID="btnUpload" runat="server" Text="儲存" CssClass="btn_grey" OnClick="btnUpload_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn_grey" OnClick="btnCancel_Click" />
                <asp:HiddenField ID="hfAction" runat="server" />
            </div>
        </fieldset>
        <div style="padding-top: 10px; padding-bottom: 10px;">
            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" CssClass="table_mt table_border"
                OnRowDataBound="GridView1_RowDataBound" BorderWidth="1px" CellPadding="0" Width="98%"
                DataKeyNames="attach_id" EnableModelValidation="True" OnRowDeleting="gvMain_RowDeleting">
                <Columns>
                    <asp:BoundField HeaderText="序號" DataField="ROW_NUM" ItemStyle-CssClass="td_cont3 td_center">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" Width="6%" CssClass="td_center td_headhrz td_headmulti"
                            Height="20px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="附件名稱" DataField="attach_name" ItemStyle-CssClass="td_cont3 td_left">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="附件說明" DataField="attach_desc" ItemStyle-CssClass="td_cont3 td_left">
                        <ItemStyle HorizontalAlign="Left" CssClass="td_cont3 td_left" />
                        <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="檔案名稱" DataField="file_name" ItemStyle-CssClass="td_cont3 td_left">
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="td_center td_headhrz td_headmulti" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="建檔人員" DataField="create_user" ItemStyle-CssClass="td_cont3 td_center">
                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_left" />
                        <HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="td_center td_headhrz td_headmulti" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="建檔日期" DataField="create_date" ItemStyle-CssClass="td_cont3 td_center">
                        <ItemStyle HorizontalAlign="Center" CssClass="td_cont3 td_center" />
                        <HeaderStyle HorizontalAlign="Center" Width="13%" CssClass="td_center td_headhrz td_headmulti" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="刪除">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/images/del.png"
                                OnClientClick="return confirm('確定刪除?')" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="td_center td_headhrz td_headmulti" Width="5%" />
                        <ItemStyle CssClass="td_cont3 td_center" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#E2E2DC" ForeColor="GhostWhite" />
                <HeaderStyle CssClass="td_headmulti" />
                <RowStyle CssClass="td_cont3" />
                <EmptyDataTemplate>
                    無資料</EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <div style="float: left;">
        <asp:Button ID="btnBack" runat="server" Text="返回預覽" CssClass="btn_grey" OnClick="btnBack_Click" />
    </div>
</asp:Panel>
<asp:HiddenField ID="hfAttachType" runat="server" />
<asp:HiddenField ID="hfMainId" runat="server" />
<%--</ContentTemplate>
                            </asp:UpdatePanel>--%>