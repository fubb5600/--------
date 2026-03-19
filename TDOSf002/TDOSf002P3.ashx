<%@ WebHandler Language="C#" Class="TDOSf002P3" %>

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
/// 完工接車單轉出PDF檔
/// </summary>
public class TDOSf002P3 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        Mediator med = new Mediator();
        ArrayList al = new ArrayList();
        ArrayList al_junk = new ArrayList();
        try
        {
            string repair_id = context.Request.QueryString["repair_id"].ToString();

            if (repair_id != string.Empty)
            {
                RepairModel model = new RepairModel();
                DBDAO dao = new DBDAO();
                model.dao = dao;

                try
                {
                    dao.open();
                    Form form = new Form();
                    form.setValue("repair_id", repair_id.Trim());
                    al = model.printRepairPDF3(form);
                    al_junk = model.printRepairPDF3Junk(form);
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
                ht.Add("JUNK_NUMBER", "");
                ht.Add("MEMO", "");
                al.Add(ht);
            }
            var doc = new Document(PageSize.A4, 50, 50, 50, 50);

            MemoryStream memory = new MemoryStream();
            PdfWriter.GetInstance(doc, memory);
            string path = context.Server.MapPath("./");
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path + "完工接車單.pdf", FileMode.Create));

            //字型設定
            BaseFont bfChilese = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChTitleFont = new Font(bfChilese, 24);
            Font ChLargeFont = new Font(bfChilese, 16);
            Font ChFont = new Font(bfChilese, 13);
            Font ChLineFont = new Font(bfChilese, 14, Font.UNDERLINE);

            doc.Open();

            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                Chunk cTitle = new Chunk("臺北市政府環境保護局 \n 車輛送修完工接車單", ChTitleFont);
                Phrase pTitle = new Phrase(cTitle);
                Paragraph pg = new Paragraph(pTitle);
                pg.Alignment = Element.ALIGN_CENTER;
                doc.Add(pg);
                doc.Add(new Paragraph(Environment.NewLine, ChFont));

                //表格
                PdfPTable table = new PdfPTable(new float[] { 2, 1, 1, 3, 1 });
                table.TotalWidth = 470f;
                table.LockedWidth = true;

                PdfPCell cellTitle = new PdfPCell(new Phrase("車屬單位：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);
                PdfPCell cellContent = new PdfPCell(new Phrase(med.lookupParamName("CRS_ORG", ht["CRS_ORG"].ToString(), 0), ChFont));
                cellContent.Colspan = 4;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("局編車號：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);
                cellContent = new PdfPCell(new Phrase(ht["DEP_NO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("派工號碼：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);
                cellContent = new PdfPCell(new Phrase(ht["WORK_NO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("接車日期：", ChLargeFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 35f;
                table.AddCell(cellTitle);

                String sPickupDateTime = " ";

                if (ht["PICKUP_DATE"].ToString() != string.Empty)
                {
                    sPickupDateTime += ht["PICKUP_DATE"].ToString().Substring(0, 3) + "  年  ";
                    sPickupDateTime += ht["PICKUP_DATE"].ToString().Substring(4, 2) + "  月  ";
                    sPickupDateTime += ht["PICKUP_DATE"].ToString().Substring(7, 2) + "  日  ";

                    if (!ht["PICKUP_DATE"].ToString().Substring(10, 5).Equals("00:00"))
                    {
                        sPickupDateTime += ht["PICKUP_DATE"].ToString().Substring(10, 2) + "  時  ";
                        sPickupDateTime += ht["PICKUP_DATE"].ToString().Substring(13, 2) + "  分  ";
                    }
                }

                cellContent = new PdfPCell(new Phrase(sPickupDateTime.Length > 0 ? sPickupDateTime : "     年      月      日      時      分", ChFont));
                cellContent.Colspan = 4;
                cellContent.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                cellTitle = new PdfPCell(new Phrase("廠商註記事項(說\n明或建議): ", ChFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 70f;
                table.AddCell(cellTitle);
                cellContent = new PdfPCell(new Phrase(ht["MEMO"].ToString(), ChFont));
                cellContent.Colspan = 4;
                cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                table.AddCell(cellContent);

                Boolean isJunk = false;
                //if (ht["JUNK_NUMBER"].ToString() != string.Empty && !ht["JUNK_NUMBER"].ToString().Equals("0"))

                isJunk = true;
                string garbage = "";
                    //1080513修改
                for (int j = 0; j < al_junk.Count; j++)
                {
                    Hashtable ht_junk = (Hashtable)al_junk[j];

                    if (ht_junk["REPAIR_ID"].ToString().Equals(ht["REPAIR_ID"].ToString()) && !ht_junk["JUNK_NAME"].ToString().Equals(""))
                    {
                        garbage = "1";
                    }

                }
                
                if (garbage != "")
                {
                    cellTitle = new PdfPCell(new Phrase("■有廢品(名稱/數量)              □無廢品（原因說明）： ", ChFont));
                }


                else
                {
                    cellTitle = new PdfPCell(new Phrase("□有廢品(名稱/數量)              ■無廢品（原因說明）： ", ChFont));

                }
                if (garbage != "")
                {
                    cellTitle.Colspan = 8;
                    cellTitle.MinimumHeight = 40f;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cellTitle.FixedHeight = 35f;
                    table.AddCell(cellTitle);

                    cellTitle = new PdfPCell(new Phrase("廢品名稱", ChFont));
                    cellTitle.MinimumHeight = 26f;
                    cellTitle.Colspan = 2;
                    cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellTitle);
                    cellContent = new PdfPCell(new Phrase("數量", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellContent = new PdfPCell(new Phrase("廢品名稱", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellContent = new PdfPCell(new Phrase("數量", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                }

                if (garbage == "")
                {
                    cellTitle.Colspan = 8;
                    cellTitle.MinimumHeight = 40f;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cellTitle.FixedHeight = 35f;
                    table.AddCell(cellTitle);

                    cellTitle = new PdfPCell(new Phrase("廢品名稱", ChFont));
                    cellTitle.MinimumHeight = 26f;
                    cellTitle.Colspan = 2;
                    cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellTitle);
                    cellContent = new PdfPCell(new Phrase("數量", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellContent = new PdfPCell(new Phrase("廢品名稱", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellContent = new PdfPCell(new Phrase("數量", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellTitle = new PdfPCell(new Phrase("", ChFont));
                    cellTitle.MinimumHeight = 26f;
                    cellTitle.Colspan = 2;
                    cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellTitle);
                    cellContent = new PdfPCell(new Phrase("", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellContent = new PdfPCell(new Phrase("", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                    cellContent = new PdfPCell(new Phrase("", ChFont));
                    cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellContent);
                }
                ArrayList al_junk_list = new ArrayList();//全部廢品清單

                for (int j = 0; j < al_junk.Count; j++)
                {
                    Hashtable ht_junk = (Hashtable)al_junk[j];

                    if (ht_junk["REPAIR_ID"].ToString().Equals(ht["REPAIR_ID"].ToString()) && !ht_junk["JUNK_NAME"].ToString().Equals(""))
                    {
                        al_junk_list.Add(ht_junk);
                    }
                }
                int junkRows = 0;//廢品兩欄共幾列
                if (al_junk_list.Count % 2 == 0)
                {
                    junkRows = al_junk_list.Count / 2;
                }
                else
                {
                    junkRows = al_junk_list.Count / 2 + 1;
                }
                String junk_name_even = "";
                String junk_count_even = "";
                String junk_name_odd = "";
                String junk_count_odd = "";
                int r = 0; int k = 0;
                    //1080513修改
                while (r < junkRows)
                {
                    while (k < al_junk_list.Count)
                    {
                        Hashtable ht_junk = (Hashtable)al_junk_list[k];

                        if ((k % 2 == 0))
                        {
                            junk_name_even = ht_junk["JUNK_NAME"].ToString();
                            junk_count_even = ht_junk["JUNK_COUNT"].ToString();

                            k++;
                        }
                        else if ((k % 2 == 1))
                        {
                            junk_name_odd = ht_junk["JUNK_NAME"].ToString();
                            junk_count_odd = ht_junk["JUNK_COUNT"].ToString();
                            k++;
                            break;
                        }
                    }
                    //1080513修改

                    if (r != junkRows && k % 2 != 1)
                    {
                        cellTitle = new PdfPCell(new Phrase(junk_name_even, ChFont));
                        cellTitle.Colspan = 2;
                        cellTitle.FixedHeight = 25f;
                        cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellTitle);

                        cellContent = new PdfPCell(new Phrase(junk_count_even, ChFont));
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cellContent);
                        cellContent = new PdfPCell(new Phrase(junk_name_odd, ChFont));
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellContent);

                        cellContent = new PdfPCell(new Phrase(junk_count_odd, ChFont));
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cellContent);
                    }

                    else
                    {
                        cellTitle = new PdfPCell(new Phrase(junk_name_even, ChFont));
                        cellTitle.Colspan = 2;
                        cellTitle.FixedHeight = 25f;
                        cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellTitle);
                        cellContent = new PdfPCell(new Phrase(junk_count_even, ChFont));
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cellContent);
                        cellContent = new PdfPCell(new Phrase("", ChFont));
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellContent);

                        cellContent = new PdfPCell(new Phrase("", ChFont));
                        cellContent.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        cellContent.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        table.AddCell(cellContent);

                    }
                    r++;

                }

                cellTitle = new PdfPCell(new Phrase("廠商簽章:              駕駛簽章:               接收人簽章:", ChFont));
                cellTitle.Colspan = 5;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 50f;
                table.AddCell(cellTitle);
                doc.Add(table);
                doc.NewPage();

            }


            doc.Close();

            context.Response.Clear();
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("完工接車單", System.Text.Encoding.UTF8) + ".pdf");
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