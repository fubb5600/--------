<%@ WebHandler Language="C#" Class="TDOSf002P2" %>

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
/// 交車簽收單轉出PDF檔
/// </summary>
public class TDOSf002P2 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        Mediator med = new Mediator();
        ArrayList al = new ArrayList();
        
        try
        {
            string repair_id = context.Request.QueryString["repair_id"].ToString();

            RepairModel model = new RepairModel();
            DBDAO dao = new DBDAO();
            model.dao = dao;

            if (repair_id != string.Empty)
            {
                try
                {
                    dao.open();

                    Form form = new Form();
                    form.setValue("repair_id", repair_id.Trim());
                    al = model.printRepairPDF2(form);
                }
                catch (Exception ex)
                {
                    context.Response.Write(ex.Message);
                }
                finally
                {
                    dao.close();
                }
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("CRS_ORG", "");
                ht.Add("DEP_NO", "");
                ht.Add("WORK_NO", "");
                ht.Add("PICKUP_DATE", "");    
                al.Add(ht);
            }

            var doc = new Document(PageSize.A4, 50, 50, 50, 50);

            MemoryStream memory = new MemoryStream();
            PdfWriter.GetInstance(doc, memory);
            string path = context.Server.MapPath("./");
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path + "交車簽收單.pdf", FileMode.Create));

            //字型設定
            BaseFont bfChilese = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChTitleFont = new Font(bfChilese, 24);
            Font ChLargeFont = new Font(bfChilese, 16);
            Font ChFont = new Font(bfChilese, 14);
            Font ChLineFont = new Font(bfChilese, 14, Font.UNDERLINE);

            doc.Open();

            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                Chunk cTitle = new Chunk("臺北市政府環境保護局\n車輛送修交車簽收單", ChTitleFont);
                Phrase pTitle = new Phrase(cTitle);
                Paragraph pg = new Paragraph(pTitle);
                pg.Alignment = Element.ALIGN_CENTER;
                doc.Add(pg);

                doc.Add(new Paragraph(Environment.NewLine, ChFont));
                
                //表格
                PdfPTable table = new PdfPTable(new float[] { 1, 1, 1, 1 });
                table.TotalWidth = 450f;
                table.LockedWidth = true;

                PdfPCell cellTitle = new PdfPCell(new Phrase("車屬單位：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                PdfPCell cellContent = new PdfPCell(new Phrase(med.lookupParamName("DEP_ORG", ht["CRS_ORG"].ToString(), 0), ChFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("局編車號：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(ht["DEP_NO"].ToString(), ChFont));
                cellContent.Colspan = 3;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("派工單號：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase(ht["WORK_NO"].ToString(), ChFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("交車地點：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("交車日期：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                String sPickup_YYY = "     ";
                String sPickup_MM = "     ";
                String sPickup_dd = "      ";
                String sPickup_HH = "      ";
                String sPickup_mm = "      ";

                if (ht["PICKUP_DATE"].ToString().Length > 0)
                {
                    String sPickupDate = ht["PICKUP_DATE"].ToString(); 
                    sPickup_YYY = " " + sPickupDate.Substring(0, 3) + " ";
                    sPickup_MM = " " + sPickupDate.Substring(4, 2) + " ";
                    sPickup_dd = " " + sPickupDate.Substring(7,2) + " ";
                    sPickup_HH = " " + sPickupDate.Substring(10,2) + " ";
                    sPickup_mm = " " + sPickupDate.Substring(13, 2) + " ";      
                }
                
                cellContent = new PdfPCell(new Phrase(sPickup_YYY + " 年 " +sPickup_MM + " 月 " +  sPickup_dd + " 日 " + sPickup_HH + " 時 " + sPickup_mm + " 分", ChFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("備    註", ChFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 80f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChLargeFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellContent.Colspan = 3;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("駕駛簽名", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 100f;
                table.AddCell(cellTitle);

                cellContent = new PdfPCell(new Phrase("", ChFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellContent = new PdfPCell(new Phrase("廠商簽章", ChLargeFont));
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellContent = new PdfPCell(new Phrase("", ChFont));
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                doc.Add(table);

                Chunk cFooter = new Chunk("附註：本單於廠商簽章後，請交回車輛管理員存查。", ChFont);
                Phrase pFooter = new Phrase(cFooter);
                Paragraph pgFooter = new Paragraph(pFooter);
                pgFooter.IndentationLeft = 20f;
                doc.Add(pgFooter);

                doc.NewPage();
            }

            doc.Close();

            context.Response.Clear();
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("交車簽收單", System.Text.Encoding.UTF8) + ".pdf");
            context.Response.ContentType = "application/octet-steam";
            context.Response.OutputStream.Write(memory.GetBuffer(), 0, memory.GetBuffer().Length);
            context.Response.OutputStream.Flush();
            context.Response.OutputStream.Close();
            context.Response.Flush();
            context.Response.End();
        }
        catch (Exception ex)
        {
            context.Response.Write(ex.Message);
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