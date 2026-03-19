<%@ WebHandler Language="C#" Class="TDOSf002P1" %>

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
/// 查驗記錄單轉出PDF檔
/// </summary>
public class TDOSf002P1 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        TDOS tdos = new TDOS();
        Mediator med = new Mediator();
        ArrayList al = new ArrayList();
        ArrayList al_component_list = new ArrayList();
        Boolean isBlank = false;

        try
        {
            string repair_id = context.Request.QueryString["repair_id"].ToString();
            //string crs_area = context.Request.QueryString["crs_area"].ToString();

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
                    // form.setValue("crs_area", crs_area.Trim());                 
                    al = model.printRepairPDF1(form);
                    al_component_list = model.printRepairPDF1Component(form);
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
                isBlank = true;
                Hashtable ht = new Hashtable();
                ht.Add("REPAIR_ID", "");
                ht.Add("CASE_NO", "         ");
                ht.Add("CRS_ORG", "TT002I591");
                ht.Add("DEP_NO", "");
                ht.Add("CAR_NO", "");
                ht.Add("WORK_NO", "");
                ht.Add("REPAIR_VENDER", "");
                ht.Add("DELIVERY_UNIT", "");
                ht.Add("CREATE_DATE", "");
                ht.Add("NOTIFY_DATE", "");
                ht.Add("EXEC_DEADLINE", "");
                ht.Add("QUALIFIED_DATE", "");
                ht.Add("FINISH_DATE_OUT", "");
                ht.Add("CHECK_DATE", "");
                ht.Add("DELIVERY_DAYS", "");
                ht.Add("IS_LATE", "");
                ht.Add("CHECK_RESULT", "");
                ht.Add("TOTAL_PRICE1", "");
                ht.Add("TOTAL_PRICE2", "");
                ht.Add("TOTAL_PRICE3", "");
                ht.Add("TOTAL_PRICE4", "");

                al.Add(ht);
            }

            var doc = new Document(PageSize.A4, 50, 50, 50, 50);

            MemoryStream memory = new MemoryStream();
            PdfWriter.GetInstance(doc, memory);
            string path = context.Server.MapPath("./");
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(path + "查驗記錄單.pdf", FileMode.Create));

            //字型設定
            BaseFont bfChilese = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChTitleFont = new Font(bfChilese, 22);
            Font ChLargeFont = new Font(bfChilese, 16);
            Font ChFont = new Font(bfChilese, 14);
            Font ChSmallFont = new Font(bfChilese, 11);

            doc.Open();

            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];

                Chunk cTitle = new Chunk("臺北市政府環境保護局\n車輛維修、材料申請暨查驗紀錄單", ChTitleFont);
                Phrase pTitle = new Phrase(cTitle);
                Paragraph pg = new Paragraph(pTitle);
                pg.Alignment = Element.ALIGN_CENTER;
                doc.Add(pg);

                String sPrintDate = "     年    月    日";

                //if (ht["NOTIFY_DATE"].ToString().Length > 8)
                //{
                //    sPrintDate = ht["NOTIFY_DATE"].ToString().Substring(0, 3) + "年" + ht["NOTIFY_DATE"].ToString().Substring(4, 2) + "月" + ht["NOTIFY_DATE"].ToString().Substring(7, 2) + "日";
                //}

                //if (ht["CREATE_DATE"].ToString().Length > 8)
                //{
                //    sPrintDate = ht["CREATE_DATE"].ToString().Substring(0, 3) + "年" + ht["CREATE_DATE"].ToString().Substring(4, 2) + "月" + ht["CREATE_DATE"].ToString().Substring(7, 2) + "日";
                //}

                String sCaseNo = ht["CASE_NO"].ToString();
                if (isBlank)
                {
                    sPrintDate = "     年    月    日";
                    sCaseNo = "   環勞字第       號";
                }
                Chunk cSubTitle = new Chunk("中華民國" + sPrintDate + "      " + sCaseNo, ChFont);
                Phrase pSubTitle = new Phrase(cSubTitle);
                pg = new Paragraph(pSubTitle);
                pg.Alignment = Element.ALIGN_RIGHT;
                doc.Add(pg);

                //表格
                PdfPTable table = new PdfPTable(new float[] { 1, 2, 3, 2, 1, 1, 2, 2, 2 });
                table.SpacingBefore = 6f;
                table.TotalWidth = 500f;
                table.LockedWidth = true;

                string[] arrTitle = { "項次", "零件編號", "項目名稱", "規格", "單位", "數量", "決標單價", "總價", "備註", };

                PdfPCell cellTitle;
              
                for (int j = 0; j < arrTitle.Length; j++)
                {
                    cellTitle = new PdfPCell(new Phrase(arrTitle[j], ChSmallFont));
                    cellTitle.MinimumHeight = 20f;
                    cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cellTitle);
                }

                PdfPCell cellCont;
                ArrayList al_component = new ArrayList();
                Decimal total_price;
                int ht_total_price = 0;
                   
                for (int j = 0; j < al_component_list.Count; j++)
                {
                    Hashtable ht_component = (Hashtable)al_component_list[j];

                    if (ht["REPAIR_ID"].ToString().Equals(ht_component["REPAIR_ID"].ToString()))
                    {
                        al_component.Add(ht_component);
                    }
                }

                int iRowComponents = 14;

                if (al_component.Count > iRowComponents)
                    iRowComponents = al_component.Count;

                for (int k = 0; k < iRowComponents; k++)
                {
                    if (k < al_component.Count)
                    {
                        Hashtable ht_component = (Hashtable)al_component[k];

                        cellCont = new PdfPCell(new Phrase((k + 1).ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        cellCont = new PdfPCell(new Phrase(ht_component["COMPONENT_NO"].ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        cellCont = new PdfPCell(new Phrase(ht_component["COMPONENT_NAME"].ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        cellCont = new PdfPCell(new Phrase(ht_component["COMPONENT_SPEC"].ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        cellCont = new PdfPCell(new Phrase(ht_component["UNIT"].ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        cellCont = new PdfPCell(new Phrase(ht_component["COUNT"].ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        Decimal budget;
                        try { budget = Convert.ToDecimal(ht_component["BUDGET" + ht["BUDGET_AREA"].ToString()].ToString()); }
                        catch { budget = 0; }
                        //cellCont = new PdfPCell(new Phrase(String.Format("{0:N0}", budget), ChSmallFont));////修正單價為小數點兩位_wennyh_1229_原始碼
                        //cellCont = new PdfPCell(new Phrase(String.Format("{0:N2}", budget), ChSmallFont));//修正單價為小數點兩位_wennyh_1229
                        cellCont = new PdfPCell(new Phrase(String.Format("{0:0.00}", budget), ChSmallFont));//修正單價為小數點兩位_wennyh_1229
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);

                        try { total_price = Convert.ToDecimal(ht_component["TOTAL_PRICE" + ht["BUDGET_AREA"].ToString()].ToString()); }
                        catch { total_price = 0; }
                        //cellCont = new PdfPCell(new Phrase(String.Format("{0:N0}", total_price), ChSmallFont));           
                        cellCont = new PdfPCell(new Phrase(String.Format("{0:0}", total_price), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);
                        ht_total_price +=(Int32)decimal.Round(total_price,0, MidpointRounding.AwayFromZero);
                        cellCont = new PdfPCell(new Phrase(ht_component["MEMO"].ToString(), ChSmallFont));
                        cellCont.MinimumHeight = 20f;
                        cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                        table.AddCell(cellCont);
                    }
                    else
                    {
                        for (int a = 0; a < arrTitle.Length; a++)
                        {
                            cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                            cellCont.MinimumHeight = 20f;
                            cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                            table.AddCell(cellCont);
                        }
                    }
                }

                //try { total_price = Convert.ToDecimal(ht["TOTAL_PRICE" + ht["BUDGET_AREA"].ToString()].ToString()); }
                //catch { total_price = 0; }

                cellCont = new PdfPCell(new Phrase("合   計", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Colspan = 7;
                table.AddCell(cellCont);
                // cellCont = new PdfPCell(new Phrase(isBlank?"":String.Format("{0:N0}", total_price) + "元", ChSmallFont));
               // cellCont = new PdfPCell(new Phrase(isBlank?"":String.Format("{0:0}", total_price) + "元", ChSmallFont));
                cellCont = new PdfPCell(new Phrase(isBlank?"":String.Format("{0:0}", ht_total_price) + "元", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Colspan = 2;
                table.AddCell(cellCont);

                doc.Add(table);

                //表格
                PdfPTable component_table = new PdfPTable(new float[] { 1, 2, 3, 1, 2, 3, 1, 2, 2 });
                component_table.SpacingBefore = 6f;
                component_table.TotalWidth = 500f;
                component_table.LockedWidth = true;

                #region 第一列
                cellTitle = new PdfPCell(new Phrase("申\n請", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Rowspan = 8;
                component_table.AddCell(cellTitle);

                cellTitle = new PdfPCell(new Phrase("共計\n新台幣", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Rowspan = 3;
                component_table.AddCell(cellTitle);
                // cellCont = new PdfPCell(new Phrase(isBlank?"":String.Format("{0:N0}", total_price) + "元整", ChSmallFont));

                cellCont = new PdfPCell(new Phrase(isBlank?"":String.Format("{0:0}", ht_total_price) + "元整", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Rowspan = 3;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("查\n驗", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Rowspan = 8;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase("通知日期", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase(formatDate(ht["NOTIFY_DATE"].ToString()), ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellTitle = new PdfPCell(new Phrase("交貨\n期限", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellTitle = new PdfPCell(new Phrase(ht["DELIVERY_DAYS"].ToString() + "個" + med.lookupParamName("TIME_UNIT", ht["DELIVERY_UNIT"].ToString(), 0), ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Colspan = 2;
                component_table.AddCell(cellTitle);

                #endregion

                #region 第二列
                cellTitle = new PdfPCell(new Phrase("履約期限", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase(formatDate(ht["EXEC_DEADLINE"].ToString()), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("是否\n逾期", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Rowspan = 2;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase((ht["IS_LATE"].ToString().Equals("Y") ? "■" : "□") + "逾期\n" + (ht["IS_LATE"].ToString().Equals("N") ? "■" : "□") + "未逾期", ChSmallFont)); //"■" : "□"
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Rowspan = 2;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("廠商名稱", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);
                #endregion

                #region
                cellTitle = new PdfPCell(new Phrase("完工交車\n(貨)日期", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase(formatDate(ht["FINISH_DATE_OUT"].ToString()), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellCont = new PdfPCell(new Phrase(ht["REPAIR_VENDER"].ToString(), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Rowspan = 3;
                component_table.AddCell(cellCont);


                #endregion

                #region 第四列
                cellTitle = new PdfPCell(new Phrase("局編車號", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase(ht["DEP_NO"].ToString(), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("開始查驗\n日期", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase(formatDate(ht["CHECK_DATE"].ToString()), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("查驗\n結果", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Rowspan = 2;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase((ht["CHECK_RESULT"].ToString().Equals("PASS") ? "■" : "□") + "合格\n" + (ht["CHECK_RESULT"].ToString().Equals("FAIL") ? "■" : "□") + "不合格", ChSmallFont)); //"■" : "□"
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Rowspan = 2;
                component_table.AddCell(cellCont);
                #endregion

                #region 第五列
                cellTitle = new PdfPCell(new Phrase("派工號碼", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase(ht["WORK_NO"].ToString(), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("查驗合格\n日期", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase(formatDate(ht["QUALIFIED_DATE"].ToString()), ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);
                #endregion

                #region 第六列
                cellTitle = new PdfPCell(new Phrase("車輛\n管理員", ChSmallFont));
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 20f;
                cellTitle.Rowspan = 2;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Rowspan = 2;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("協驗人員(無則免)", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Colspan = 2;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Colspan = 3;
                component_table.AddCell(cellCont);
                #endregion

                #region 第七列
                //cellTitle = new PdfPCell(new Phrase("車輛\n管理員", ChSmallFont));
                //cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //cellTitle.FixedHeight = 20f;
                //component_table.AddCell(cellTitle);

                //cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                //cellCont.MinimumHeight = 20f;
                //cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                //cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                //component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("查驗人員", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Colspan = 2;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Colspan = 3;
                component_table.AddCell(cellCont);
                #endregion

                #region 第七列
                cellTitle = new PdfPCell(new Phrase("單位主管", ChSmallFont));
                cellTitle.FixedHeight = 40f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                component_table.AddCell(cellCont);

                cellTitle = new PdfPCell(new Phrase("單位主管", ChSmallFont));
                cellTitle.MinimumHeight = 20f;
                cellTitle.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellTitle.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellTitle.Colspan = 2;
                component_table.AddCell(cellTitle);

                cellCont = new PdfPCell(new Phrase("", ChSmallFont));
                cellCont.MinimumHeight = 20f;
                cellCont.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cellCont.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cellCont.Colspan = 3;
                component_table.AddCell(cellCont);
                #endregion

                doc.Add(component_table);

                doc.NewPage();
            }
            doc.Close();

            context.Response.Clear();
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("查驗記錄單", System.Text.Encoding.UTF8) + ".pdf");
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

    private String formatDate(String sTagetValue)
    {
        String sRetValue = sTagetValue;

        if (sTagetValue != string.Empty)
        {
            if (sTagetValue.Substring(10, 5).Equals("00:00"))
            {
                sTagetValue = sTagetValue.Substring(0, 9);

                sRetValue = sRetValue.Substring(0, 3) + "年" +  sRetValue.Substring(4, 2) + "月" + sRetValue.Substring(7, 2) + "日";
            }
            else
            {
                sRetValue= sRetValue.Substring(0,3) + "年" + sRetValue.Substring(4, 2) + "月" + sRetValue.Substring(7,2) + "日" +
                    sRetValue.Substring(10, 2)  + "時" + sRetValue.Substring(13,2) + "分";
            }
        }

        return sRetValue;
    }


}