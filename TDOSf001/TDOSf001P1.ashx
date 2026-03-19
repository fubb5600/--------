<%@ WebHandler Language="C#" Class="TDOSf001P1" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

/// <summary>
/// 車輛派修單轉出PDF檔
/// </summary>
public class TDOSf001P1 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        Mediator med = new Mediator();
        ArrayList al = new ArrayList();

        try
        {
            string notify_id = context.Request.QueryString["notify_id"].ToString();

            if (notify_id != string.Empty)
            {
                NotifyModel model = new NotifyModel();
                DBDAO dao = new DBDAO();
                model.dao = dao;

                try
                {
                    dao.open();
                    Form form = new Form();
                    form.setValue("notify_id", notify_id.Trim());
                    al = model.printNotifyPDF(form);

                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    dao.close();
                }
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("WORK_NO", "");
                ht.Add("NOTIFY_DATE", "");
                ht.Add("DEP_NO", "");
                ht.Add("CAR_NO", "");
                ht.Add("BRAND_NO", "");
                ht.Add("MILEAGE", "");
                ht.Add("CRS_ORG", "");
                ht.Add("NOTIFY_ITEM", "");
                ht.Add("WORK_MAN", "");
                ht.Add("MEMO", "");
                ht.Add("REPAIR_TYPE1", "");
                ht.Add("REPAIR_TYPE2", "");
                ht.Add("REPAIR_TYPE3", "");
                ht.Add("REPAIR_VENDER", "");
                ht.Add("PICKUP_DATE", "");
                al.Add(ht);
            }

            var doc = new Document(PageSize.A4, 50, 50, 50, 50);

            MemoryStream memory = new MemoryStream();
            PdfWriter.GetInstance(doc, memory);
            string path = context.Server.MapPath("./");
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path + "車輛派修單.pdf", FileMode.Create));

            //字型設定
            BaseFont bfChilese = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChTitleFont = new Font(bfChilese, 24);
            Font ChLargeFont = new Font(bfChilese, 16);
            Font ChFont = new Font(bfChilese, 14);
            Font ChFont1 = new Font(bfChilese, 8);

            Font ChLineFont = new Font(bfChilese, 14, Font.UNDERLINE);

            doc.Open();

            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                Chunk cTitle = new Chunk("臺北市政府環境保護局車輛派修單", ChTitleFont);
                Phrase pTitle = new Phrase(cTitle);
                Paragraph pg = new Paragraph(pTitle);
                pg.Alignment = Element.ALIGN_CENTER;
                doc.Add(pg);
                doc.Add(new Paragraph(Environment.NewLine, ChFont));

                //表格
                PdfPTable notify_mst = new PdfPTable(new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                notify_mst.TotalWidth = 500f;
                notify_mst.LockedWidth = true;

                #region 第1列
                PdfPCell cellTitle = new PdfPCell(new Phrase("派工號碼：", ChLargeFont));
                cellTitle.Colspan = 3;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                PdfPCell cellContent = new PdfPCell(new Phrase(ht["WORK_NO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("派工日期：", ChLargeFont));
                cellTitle.Colspan = 3;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                string sNotifyDate = ht["NOTIFY_DATE"].ToString();
                if (sNotifyDate != string.Empty)
                {
                    sNotifyDate = ht["NOTIFY_DATE"].ToString().Substring(0, 9);
                    if (!ht["NOTIFY_DATE"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        sNotifyDate += " " + ht["NOTIFY_DATE"].ToString().Substring(10, 5);
                    }
                }

                cellContent = new PdfPCell(new Phrase(sNotifyDate, ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);
                #endregion

                #region 第2列
                cellTitle = new PdfPCell(new Phrase("局編車號：", ChLargeFont));
                cellTitle.Colspan = 3;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(ht["DEP_NO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("牌照號碼：", ChLargeFont));
                cellTitle.Colspan = 3;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(ht["CAR_NO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);
                #endregion

                #region 第3列
                cellTitle = new PdfPCell(new Phrase("廠牌型式：", ChLargeFont));
                cellTitle.Colspan = 3;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(ht["BRAND_NO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("里程數(或使用時數)：", ChLargeFont));
                cellTitle.Colspan = 5;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(ht["MILEAGE"].ToString(), ChFont));
                cellContent.Colspan = 2;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);
                #endregion

                #region 第4列
                cellTitle = new PdfPCell(new Phrase("車屬單位：", ChLargeFont));
                cellTitle.Colspan = 3;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0), ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("", ChLargeFont));
                cellTitle.Colspan = 1;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 30f;
                cellTitle.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChFont));
                cellContent.Colspan = 1;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);
                #endregion

                cellContent = new PdfPCell(new Phrase("", ChFont));
                cellContent.Colspan = 5;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Border = Rectangle.NO_BORDER;
                notify_mst.AddCell(cellContent);

                doc.Add(notify_mst);
                doc.Add(new Paragraph(Environment.NewLine, ChFont));


                //故障(修護)項目 表格
                PdfPTable table = new PdfPTable(new float[] { 1, 1, 1, 1, 1, 1, 1, 1 });
                table.TotalWidth = 500f;
                table.LockedWidth = true;

                cellTitle = new PdfPCell(new Phrase("項次", ChLargeFont));
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("故障(修護)項目", ChLargeFont));
                cellContent.Colspan = 7;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                string[] notify_item = ht["NOTIFY_ITEM"].ToString().Split('|');

                for (int j = 1; j < 8; j++)
                {
                    String sNotifyItem = "";

                    if ((j - 1) < notify_item.Length)
                    {
                        sNotifyItem = notify_item[j - 1];
                    }
                    cellTitle = new PdfPCell(new Phrase(j.ToString(), ChLargeFont));
                    cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cellTitle.FixedHeight = 28f;
                    table.AddCell(cellTitle);
                    cellContent = new PdfPCell(new Phrase(sNotifyItem, ChLargeFont));
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cellContent.Colspan = 7;
                    table.AddCell(cellContent);
                }

                cellTitle = new PdfPCell(new Phrase("派\n工\n人\n員", ChFont));
                cellTitle.FixedHeight = 80f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellTitle);
                cellContent = new PdfPCell(new Phrase(ht["WORK_MAN"].ToString(), ChFont));
                cellContent.Colspan = 2;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);
                cellContent = new PdfPCell(new Phrase("備\n\n\n註", ChFont));
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);
                cellContent = new PdfPCell(new Phrase(ht["MEMO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("維修方式: ", ChLargeFont));
                cellTitle.MinimumHeight = 30f;
                cellTitle.Colspan = 8;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_TOP;
                table.AddCell(cellTitle);

                Boolean isRepairTypeOut = false;
                Boolean isRepairSelfMaterial = false;
                Boolean isRepairSelfTune = false;
                Boolean isRepairSelfMaintenance = false;
                Boolean isRepairOutRepair = false;
                Boolean isRepairOutMaintanence = false;
                Boolean isRepairSubTypeOut = false;
                Boolean isRepairSubTypeIn = false;

                if (ht["REPAIR_TYPE1"].ToString() != string.Empty && ht["REPAIR_TYPE2"].ToString() != string.Empty)
                {
                    if (ht["REPAIR_TYPE1"].ToString().Trim().Equals("SELF"))
                    {
                        switch (ht["REPAIR_TYPE2"].ToString().Trim())
                        {
                            case "TUNE":
                                isRepairSelfTune = true;
                                break;
                            case "MATERIAL":
                                isRepairSelfMaterial = true;
                                break;
                            case "MAINTENANCE":
                                isRepairSelfMaintenance = true;
                                break;
                        }
                    }
                    else
                    {
                        isRepairTypeOut = true;
                        isRepairOutRepair = true;
                        isRepairOutMaintanence = true;
                        isRepairSubTypeOut = true;
                        isRepairSubTypeIn = true;

                        if (ht["REPAIR_TYPE2"].ToString().Equals("BOTHMR"))
                        {
                        }
                        else if (ht["REPAIR_TYPE2"].ToString().Equals("MAINTENANCE"))
                            isRepairOutRepair = false;
                        else
                            isRepairOutMaintanence = false;

                        if (ht["REPAIR_TYPE3"].ToString().Equals("IN"))
                            isRepairSubTypeOut = false;
                        else
                            isRepairSubTypeIn = false;
                    }
                }

                if (sNotifyDate != string.Empty)
                {






                }
                string MAINTENANCE = "";
                string MATERIAL = "";
                string REPAIR = "";
                string TUNE = "";
                string IN = "";
                string OUT = "";



                string a = ht["REPAIR_TYPE2"].ToString();
                string[] a_result = a.Split(',');
                for (int j = 0; j < a_result.Length; j++)
                {
                    if (a_result[j] == "BOTHMR")
                    {
                        MAINTENANCE = "true";
                        REPAIR = "true";
                    }
                    if (a_result[j] == "MAINTENANCE")
                    {
                        MAINTENANCE = "true";

                    }
                    if (a_result[j] == "MATERIAL")
                    {
                        MATERIAL = "true";
                    }
                    if (a_result[j] == "REPAIR")
                    {
                        REPAIR = "true";
                    }
                    if (a_result[j] == "TUNE")
                    {
                        TUNE = "true";
                    }




                }


                if (ht["REPAIR_TYPE3"].ToString().Trim() == "IN")
                {

                    IN = "true";
                }
                if (ht["REPAIR_TYPE3"].ToString().Trim() == "OUT")
                {

                    OUT = "true";
                }



                if (sNotifyDate != string.Empty)
                {

                    if (IN != "")
                    {


                        cellContent = new PdfPCell(new Phrase(("■") + "合約內", ChFont));
                        cellContent.Colspan = 2;
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellContent);
                    }

                    else
                    {
                        cellContent = new PdfPCell(new Phrase(("□") + "合約內", ChFont));
                        cellContent.Colspan = 2;
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellContent);

                    }

                    if (OUT != "")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "合約外", ChFont));
                        cellContent.Colspan = 2;
                        cellContent.FixedHeight = 26f;
                        cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellContent);
                    }

                    else
                    {
                        cellContent = new PdfPCell(new Phrase(("□") + "合約外", ChFont));
                        cellContent.Colspan = 2;
                        cellContent.FixedHeight = 26f;
                        cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellContent);

                    }



                    cellContent = new PdfPCell(new Phrase("維修人員簽章", ChFont));
                    cellContent.Colspan = 2;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("自修人員簽章", ChFont1));
                    cellContent.Colspan = 2;
                    cellTitle.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                    table.AddCell(cellContent);

                    if (ht["REPAIR_TYPE1"].ToString() == "SELF")
                    {
                        cellContent = new PdfPCell(new Phrase(("■") + "自修", ChFont));

                    }
                    else
                    {
                        cellContent = new PdfPCell(new Phrase(("□") + "自修", ChFont));

                    }

                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    if (ht["REPAIR_TYPE1"].ToString() == "OUT")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "委外", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "委外", ChFont));

                    }
                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("維修廠商", ChFont));
                    cellContent.Colspan = 2;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);


                    cellContent = new PdfPCell(new Phrase(ht["REPAIR_VENDER"].ToString(), ChFont));
                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    if (REPAIR == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "維修", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "維修", ChFont));

                    }




                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);



                    if (MAINTENANCE == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "保養", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "保養", ChFont));

                    }

                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("車輛管理員簽章 ", ChFont));
                    cellContent.Rowspan = 2;
                    cellContent.Colspan = 2;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("可2人以上簽章", ChFont1));
                    cellContent.Rowspan = 2;
                    cellContent.Colspan = 2;
                    cellTitle.FixedHeight = 16f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                    table.AddCell(cellContent);
                    if (MATERIAL == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "需換料", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "需換料", ChFont));

                    }
                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    if (TUNE == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "調校", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "調校", ChFont));

                    }
                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    MAINTENANCE = "";
                    MATERIAL = "";
                    REPAIR = "";
                    TUNE = "";
                }



                if (sNotifyDate == string.Empty)
                {
                    cellContent = new PdfPCell(new Phrase((isRepairSubTypeIn ? "■" : "□") + "合約內", ChFont));
                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase((isRepairSubTypeOut ? "■" : "□") + "合約外", ChFont));
                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);


                    cellContent = new PdfPCell(new Phrase("維修人員簽章", ChFont));
                    cellContent.Colspan = 2;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("自修人員簽章", ChFont1));
                    cellContent.Colspan = 2;
                    cellTitle.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                    table.AddCell(cellContent);
                    if (ht["REPAIR_TYPE1"].ToString() == "SELF")
                    {
                        cellContent = new PdfPCell(new Phrase(("■") + "自修", ChFont));

                    }
                    else
                    {
                        cellContent = new PdfPCell(new Phrase(("□") + "自修", ChFont));

                    }

                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    if (ht["REPAIR_TYPE1"].ToString() == "OUT")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "委外", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "委外", ChFont));

                    }
                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("維修廠商", ChFont));
                    cellContent.Colspan = 2;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);


                    cellContent = new PdfPCell(new Phrase(ht["REPAIR_VENDER"].ToString(), ChFont));
                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    if (REPAIR == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "維修", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "維修", ChFont));

                    }




                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);



                    if (MAINTENANCE == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "保養", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "保養", ChFont));

                    }

                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("車輛管理員簽章 ", ChFont));
                    cellContent.Rowspan = 2;
                    cellContent.Colspan = 2;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);

                    cellContent = new PdfPCell(new Phrase("可2人以上簽章", ChFont1));
                    cellContent.Rowspan = 2;
                    cellContent.Colspan = 2;
                    cellTitle.FixedHeight = 16f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_BOTTOM;
                    table.AddCell(cellContent);
                    if (MATERIAL == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "需換料", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "需換料", ChFont));

                    }
                    cellContent.Colspan = 2;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    if (TUNE == "true")
                    {

                        cellContent = new PdfPCell(new Phrase(("■") + "調校", ChFont));

                    }
                    else
                    {

                        cellContent = new PdfPCell(new Phrase(("□") + "調校", ChFont));

                    }
                    cellContent.Colspan = 2;
                    cellContent.FixedHeight = 26f;
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    MAINTENANCE = "";
                    MATERIAL = "";
                    REPAIR = "";
                    TUNE = "";

                }

                doc.Add(table);

                //分頁
                if (i != al.Count - 1)
                    doc.NewPage();
            }

            doc.Close();

            context.Response.Clear();
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("車輛派修單", System.Text.Encoding.UTF8) + ".pdf");
            context.Response.ContentType = "application/octet-steam";
            context.Response.OutputStream.Write(memory.GetBuffer(), 0, memory.GetBuffer().Length);
            context.Response.OutputStream.Flush();
            context.Response.OutputStream.Close();
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
            context.Response.Write(ex.Message + "\n" + ex.StackTrace);
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}