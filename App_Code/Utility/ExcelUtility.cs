using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.Util;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.Util;

/// <summary>
/// poi產生/讀取excel檔的常用涵式
/// </summary>
public class ExcelUtility
{
	public const short ALIGN_CENTER = (short)CellHorizontalAlignment.CENTER;
    public const short ALIGN_LEFT = (short)CellHorizontalAlignment.LEFT;
    public const short ALIGN_RIGHT = (short)CellHorizontalAlignment.RIGHT;
    public const short A3 = (short)PaperSizeType.A3;
    public const short A4 = (short)PaperSizeType.A4;
	
	private HSSFWorkbook wb = null;
	private HSSFSheet sheet = null;
	private HSSFRow row = null;

    private HSSFPatriarch patriarch = null;
    private HSSFPicture pict = null;

    /// <summary>
    ///宣告一個新的excel檔
    /// </summary>  
	public ExcelUtility(){
		wb = new HSSFWorkbook();
	}

    /// <summary>
    ///讀取實體excel檔
    /// </summary>
    /// <param name="templateFilePath">excel檔路徑</param>
	public ExcelUtility(String templateFilePath){
		try{
            POIFSFileSystem fileSystem = new POIFSFileSystem(new System.IO.FileStream(templateFilePath, FileMode.Open));
			wb = new HSSFWorkbook(fileSystem);
		}
		catch(Exception e){
			//System.out.println("ExcelUtility error:\n" + e);
		}
	}
	
    /// <summary>
    /// 取得HSSFWorkbook
    /// </summary>
    /// <returns>HSSFWorkbook</returns>
	public HSSFWorkbook GetHSSFWorkbook(){
		return wb;
	}	
	
    /// <summary>
    /// 設定字型
    /// </summary>
    /// <param name="size">字體大小</param>
    /// <param name="fontName">字體名稱</param>
    /// <param name="isBold">是否粗體</param>
    /// <returns>HSSFFont</returns>
	public HSSFFont CreateFont(int size, String fontName, Boolean isBold){
		HSSFFont font = wb.CreateFont();
		font.FontHeightInPoints = (short) size;//字體大小
		font.FontName = fontName;//字體
		
		if(isBold){
			font.Boldweight = HSSFFont.BOLDWEIGHT_BOLD;
		}
		
		return font;
	}	
	
    /// <summary>
    /// 設定文字style
    /// </summary>
    /// <param name="font">字型</param>
    /// <param name="align">水平對齊</param>
    /// <param name="hasBorder">是否顯示邊框</param>
    /// <param name="wrapText">是否自動換行 (合併儲存格後將失效)</param>
    /// <returns>HSSFCellStyle</returns>
	public HSSFCellStyle CreateWordStyle(HSSFFont font, short align, Boolean hasBorder, Boolean wrapText){
		HSSFCellStyle wordStyle = wb.CreateCellStyle();
		wordStyle.SetFont(font);
		wordStyle.VerticalAlignment = CellVerticalAlignment.CENTER;
        wordStyle.Alignment = (CellHorizontalAlignment)align;

		if(hasBorder){
            wordStyle.BottomBorderColor = HSSFColor.BLACK.index;
			wordStyle.BorderBottom = CellBorderType.THIN;
            wordStyle.BorderLeft = CellBorderType.THIN;
            wordStyle.BorderRight = CellBorderType.THIN;
            wordStyle.BorderTop = CellBorderType.THIN;
		}

        wordStyle.WrapText = wrapText;
		
		return wordStyle;
	}	
	
    /// <summary>
    /// 設定數字style
    /// </summary>
    /// <param name="font">字型</param>
    /// <param name="align">水平對齊</param>
    /// <param name="hasBorder">是否顯示邊框</param>
    /// <param name="formatStr">數字格式字串 (EX:#,##0.0 => 整數位三位一撇，小數點僅一位、#0.00% =>小數點第2位百分比)</param>
    /// <returns>HSSFCellStyle</returns>
	public HSSFCellStyle CreateNumberStyle(HSSFFont font, short align, Boolean hasBorder, String formatStr){
		HSSFCellStyle numberStyle = wb.CreateCellStyle();
		numberStyle.SetFont(font);
        numberStyle.VerticalAlignment = CellVerticalAlignment.CENTER;
        numberStyle.Alignment = (CellHorizontalAlignment)align;
		
		if(hasBorder){
            numberStyle.BottomBorderColor = HSSFColor.BLACK.index;
            numberStyle.BorderBottom = CellBorderType.THIN;
            numberStyle.BorderLeft = CellBorderType.THIN;
            numberStyle.BorderRight = CellBorderType.THIN;
            numberStyle.BorderTop = CellBorderType.THIN;
		}
		
		HSSFDataFormat format = wb.CreateDataFormat();
		numberStyle.DataFormat = format.GetFormat(formatStr);
		
		return numberStyle;
	}	

    /// <summary>
    /// 設定日期style
    /// </summary>
    /// <param name="font">字型</param>
    /// <param name="align">水平對齊</param>
    /// <param name="hasBorder">是否顯示邊框</param>
    /// <param name="formatStr">日期格式字串(西元格式)
	///		EX: 2010/01/02 03:04:05
	///		yyyy = 2010
	/// 	yy = 10
	/// 	[$-404]e = 99 (民國年，但是無法補足3位)
	///		mm = 01
	///		dd = 02
	///		hh = 03 (24小時制)
	///		mm = 04
	///		dd = 05
    ///		註：【月】跟【分】皆是mm，似乎是以最靠近的參數做區別，無法分辨時，以【月】為主。</param>
    /// <returns>HSSFCellStyle</returns>
	public HSSFCellStyle CreateDateStyle(HSSFFont font, short align, Boolean hasBorder, String formatStr){
		HSSFCellStyle dateStyle = wb.CreateCellStyle();
		dateStyle.SetFont(font);
        dateStyle.VerticalAlignment = CellVerticalAlignment.CENTER;
        dateStyle.Alignment = (CellHorizontalAlignment)align;
		
		if(hasBorder){
            dateStyle.BottomBorderColor = HSSFColor.BLACK.index;
            dateStyle.BorderBottom = CellBorderType.THIN;
            dateStyle.BorderLeft = CellBorderType.THIN;
            dateStyle.BorderRight = CellBorderType.THIN;
            dateStyle.BorderTop = CellBorderType.THIN;
		}
		
		HSSFDataFormat format = wb.CreateDataFormat();
		dateStyle.DataFormat = format.GetFormat(formatStr);
		
		return dateStyle;
	}

    /// <summary>
    /// Cell底色樣式
    /// </summary>
    /// <param name="style">HSSFCellStyle</param>
    /// <param name="foreColor">色碼</param>   
    public void fillCellColor(HSSFCellStyle style, short foreColor)
    {
        style.FillForegroundColor = foreColor;
        style.FillPattern = CellFillPattern.SOLID_FOREGROUND;
    }
   
    /// <summary>
    /// Cell底色樣式
    /// </summary>
    /// <param name="style">HSSFCellStyle</param>
    /// <param name="backColor">背景色碼</param>   
    /// <param name="foreColor">前景色碼</param>   
    /// <param name="pattern">填色樣式</param>   
    public void fillCellColor(HSSFCellStyle style, short backColor, short foreColor, CellFillPattern pattern)
    {
        style.FillBackgroundColor = backColor;
        style.FillForegroundColor = foreColor;
        style.FillPattern = pattern;
    }	
	
    /// <summary>
    /// 產生Sheet
    /// </summary>
	public void CreateSheet(){
		sheet = wb.CreateSheet();
	}

    /// <summary>
    /// 產生Sheet
    /// </summary>
    /// <param name="sheetName">sheet名稱</param>
	public void CreateSheet(String sheetName){
		sheet = wb.CreateSheet(sheetName);
	}
   
    /// <summary>
    /// 取得Sheet名稱
    /// </summary>
    /// <param name="sheetName">sheet編號</param>
    public String GetSheetName(int sheet_num)
    {
        return wb.GetSheetName(sheet_num);
    }
   
    /// <summary>
    /// 取得Sheet數量
    /// </summary>
    /// <returns>Sheet數量</returns>
    public int GetSheetNumber()
    {
        return wb.NumberOfSheets;
    }	
	
    /// <summary>
    /// 依據sheet編號取得Sheet
    /// </summary>
    /// <param name="sheet_num">要取得的sheet編號</param>
	public void GetSheet(int sheet_num){
		sheet = wb.GetSheetAt(sheet_num);
	}

    /// <summary>
    /// 依據sheet名稱取得Sheet
    /// </summary>
    /// <param name="sheetName">要取得的sheet名稱</param>
	public void GetSheet(String sheetName){
		sheet = wb.GetSheet(sheetName);        
	}	
	
    /// <summary>
    /// 產生row
    /// </summary>
    /// <param name="row_num">第幾列</param>
	public void CreateRow(int row_num){
		row = sheet.CreateRow(row_num);
        row.Height = sheet.DefaultRowHeight;
	}	
	
    /// <summary>
    /// 取得row
    /// </summary>
    /// <param name="row_num">第幾列</param>
	public void GetRow(int row_num){
		row = sheet.GetRow(row_num);
	}

    /// <summary>
    /// 取得最後一個row
    /// </summary>
    public int GetLastRow()
    {
        return sheet.LastRowNum;
    }	
	
    /// <summary>
    /// 設定預設欄寬
    /// </summary>
    /// <param name="width">寬度(像素)</param>
	public void SetDefaultColumnWidth(int width){
		sheet.DefaultColumnWidth = 256 * width / 7;
	}	
	
    /// <summary>
    /// 設定預設行高
    /// </summary>
    /// <param name="height">高度(像素)</param>
	public void SetDefaultRowHeight(int height){
        sheet.DefaultRowHeight = (short)(300 * ((short)height) / 20);
	}
		
    /// <summary>
    /// 設定欄寬
    /// </summary>
    /// <param name="column">column編號</param>
    /// <param name="width">寬度(像素)</param>
	public void SetColumnWidth(int column, int width){
		sheet.SetColumnWidth(column, 256 * width / 7);
	}
		
    /// <summary>
    /// 設定行高 (主要用於合併儲存格時)
    /// </summary>
    /// <param name="height">高度(像素)</param>  
	public void SetRowHeight(int height){
        row.Height = (short)(300 * ((short)height) / 20);
	}	
	
    /// <summary>
    /// 產生cell
    /// </summary>
    /// <param name="wordStyle">文字style</param>
    /// <param name="cell_num">cell_num cell編號 (由0開始)</param>  
    /// <param name="value">內容(文字)</param>  
	public void CreateCell(HSSFCellStyle wordStyle, int cell_num, String value){
		HSSFCell cell = row.CreateCell(cell_num);
		cell.CellStyle = wordStyle;
		//cell.setCellValue(value);
		cell.SetCellValue(new HSSFRichTextString(value));
	}	
	
    /// <summary>
    /// 產生cell
    /// </summary>
    /// <param name="numberStyle">數字style</param>
    /// <param name="cell_num">cell_num cell編號 (由0開始)</param>  
    /// <param name="value">內容(數字)</param>  
	public void CreateCell(HSSFCellStyle numberStyle, int cell_num, double value){
		HSSFCell cell = row.CreateCell(cell_num);
        cell.CellStyle = numberStyle;
		cell.SetCellValue(value);
	}
    
    /// <summary>
    /// 產生cell
    /// </summary>
    /// <param name="dateStyle">日期style</param>
    /// <param name="cell_num">cell_num cell編號 (由0開始)</param>  
    /// <param name="value">內容(DateTime)</param>  
    public void CreateCell(HSSFCellStyle dateStyle, int cell_num, DateTime value){
		HSSFCell cell = row.CreateCell(cell_num);
        cell.CellStyle = dateStyle;
		cell.SetCellValue(value);
	}	
	
    /// <summary>
    /// 設定cell
    /// </summary>
    /// <param name="wordStyle">文字style</param>
    /// <param name="cell_num">cell編號(由0開始)</param>  
    /// <param name="value">內容(文字)</param>  
    public void SetCell(HSSFCellStyle wordStyle, int cell_num, String value)
    {
		HSSFCell cell = row.GetCell(cell_num);
        cell.CellStyle = wordStyle;
		//cell.setCellValue(value);
		cell.SetCellValue(new HSSFRichTextString(value));
        
	}


    /// <summary>
    /// 設定cell
    /// </summary>
    /// <param name="wordStyle">文字style</param>
    /// <param name="cell_num">cell編號(由0開始)</param>  
    /// <param name="value">內容(文字)</param>  
    public void SetMathCell(HSSFCellStyle numberStyle, int cell_num, String formula)
    {
        HSSFCell cell = row.GetCell(cell_num);
        cell.CellStyle = numberStyle;
        //cell.setCellValue(value);
        //cell.SetCellValue(new HSSFRichTextString(value));
        cell.SetCellFormula(formula);
    }

    /// <summary>
    /// 設定cell
    /// </summary>   
    /// <param name="cell_num">cell編號(由0開始)</param>  
    /// <param name="value">內容(文字)</param>  
    public void SetCell(int cell_num, String value)
    {
        HSSFCell cell = row.GetCell(cell_num);
        //cell.setCellValue(value);
        cell.SetCellValue(new HSSFRichTextString(value));

    }

    /// <summary>
    /// 設定cell
    /// </summary>
    /// <param name="numberStyle">數字style</param>
    /// <param name="cell_num">cell_num cell編號 (由0開始)</param>  
    /// <param name="value">內容(數字)</param>  
    public void SetCell(HSSFCellStyle numberStyle, int cell_num, double value)
    {
        HSSFCell cell = row.GetCell(cell_num);
        cell.CellStyle = numberStyle;
        cell.SetCellValue(value);
    }

    /// <summary>
    /// 取得cell的值
    /// </summary>   
    /// <param name="n">cell編號</param>  
    /// <returns>cell的值</returns>   
    public String getCellValue(int n)
    {
        HSSFCell cell = row.GetCell(n);
        return cell.ToString();        
    }


    /// <summary>
    /// 取得cell的型別
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public HSSFCellType GetCellType(int n)
    {
        HSSFCell cell = row.GetCell(n);
        return cell.CellType;
    }


    /// <summary>
    /// 設定CellType為字串
    /// </summary>
    /// <param name="n"></param>
    public void SetCellType(int n)
    {
        HSSFCell cell = row.GetCell(n);
        cell.SetCellType(HSSFCellType.STRING); 
    }

    /// <summary>
    /// 設定cell
    /// </summary>   
    /// <param name="cell_num">cell編號 (由0開始)</param>  
    /// <param name="value">內容(數字)</param>  
	public void SetCell(int cell_num, double value){
		HSSFCell cell = row.GetCell(cell_num);
		cell.SetCellValue(value);
	}

    /// <summary>
    /// 設定cell
    /// </summary>   
    /// <param name="cell_num">cell編號 (由0開始)</param>  
    /// <param name="value">內容(DateTime)</param>  
    public void SetCell(int cell_num, DateTime value)
    {
		HSSFCell cell = row.GetCell(cell_num);
		cell.SetCellValue(value);
	}	
	
    /// <summary>
    /// 取得Column的英文代號(A、B、C~ZX、ZY、ZZ)
    /// </summary>   
    /// <param name="loc">cell編號 (由0開始)</param>  
    /// <returns>Column的英文代號(A、B、C~ZX、ZY、ZZ)</returns>
	public String GetColumnWord(int loc){
	    String str = "";
		
		if(loc < 26){
		    str = ((char)(65 + loc)).ToString();
	    }
	    else{
	  	    int num1 = loc / 26 - 1;
	  	    int num2 = loc % 26;
	  	    
	  	    str = ((char)(65 + num1)).ToString() +
            ((char)(65 + num2)).ToString();
	    }
		
		return str;
	}	
	
    /// <summary>
    /// 產生運算式Cell
    /// </summary>   
    /// <param name="numberStyle">數字style</param> 
    /// <param name="cell_num">cell編號</param> 
    /// <param name="formula">運算式</param> 
	public void CreateMathCell(HSSFCellStyle numberStyle, int cell_num, String formula){
		HSSFCell cell = row.CreateCell(cell_num);
		cell.CellStyle = numberStyle;
		cell.SetCellFormula(formula);
	}
	
    /// <summary>
    /// 合併儲存格
	/// 註：若需要邊框時，需將合併的所有cell都設定border
    /// </summary>   
    /// <param name="startRow">start row編號</param> 
    /// <param name="endRow">end row編號</param> 
    /// <param name="startColumn">start column編號</param> 
    /// <param name="endColumn">end column編號</param> 
	public void AddMergedRegion(int startRow, int endRow, int startColumn, int endColumn){
		sheet.AddMergedRegion(new CellRangeAddress(startRow, endRow, startColumn, endColumn));
	}

    /// <summary>
    /// 合併儲存格
    /// 註：若需要邊框時，需將合併的所有cell都設定border
    /// </summary>   
    /// <param name="startRow">start row編號</param> 
    /// <param name="endRow">end row編號</param> 
    /// <param name="startColumn">start column編號</param> 
    /// <param name="endColumn">end column編號</param> 
	public void AddMergedRegion2(int startRow, int endRow, int startColumn, int endColumn){
		HSSFRow tempRow = sheet.GetRow(startRow);
		HSSFCell tempCell = tempRow.GetCell(startColumn);
		HSSFCellStyle style = tempCell.CellStyle;
		
		for(int i = startRow; i <= endRow; i++){
			tempRow = sheet.GetRow(i);
			
			if(i == startRow || i == endRow){
				for(int j = startColumn; j <= endColumn; j++){
					if(!(i == startRow && j == startColumn)){
						tempCell = tempRow.CreateCell(j);
						tempCell.CellStyle = style;
						tempCell.SetCellValue(new HSSFRichTextString(""));
					}
				}
			}
			else{
				tempCell = tempRow.CreateCell(startColumn);
				tempCell.CellStyle = style;
				tempCell.SetCellValue(new HSSFRichTextString(""));

                if (startColumn != endColumn)
                {
                    tempCell = tempRow.CreateCell(endColumn);
                    tempCell.CellStyle = style;
                    tempCell.SetCellValue(new HSSFRichTextString(""));
                }
			}
		}
		
		sheet.AddMergedRegion(new CellRangeAddress(startRow, endRow, startColumn, endColumn));
	}	
	
    /// <summary>
    ///設定Repeat Region 
	///註：Column或Row設定-1表示不Repeat，且start、end皆要為-1
    /// </summary>   
    /// <param name="sheet_num">sheet編號</param> 
    /// <param name="startRow">start row編號</param> 
    /// <param name="endRow">end row編號</param> 
    /// <param name="startColumn">start column編號</param> 
    /// <param name="endColumn">end column編號</param> 
	public void SetRepeatRegion(int sheet_num, int startColumn, int endColumn, 
			int startRow, int endRow)
    {
		wb.SetRepeatingRowsAndColumns(sheet_num, startColumn, endColumn, startRow, endRow);
	}

    /// <summary>
    /// /設定Repeat Region 
    /// </summary>
    /// <param name="sheet_name">sheet名稱</param> 
    /// <param name="startRow">start row編號</param> 
    /// <param name="endRow">end row編號</param> 
    /// <param name="startColumn">start column編號</param> 
    /// <param name="endColumn">end column編號</param> 
    public void SetRepeatRegion(string sheet_name, int startColumn, int endColumn,
            int startRow, int endRow)
    {
        SetRepeatRegion(wb.GetSheetIndex(sheet_name), startColumn, endColumn, startRow, endRow);
    }
	
    /// <summary>
    ///設定Row手動分頁  
    /// </summary>   
    /// <param name="row_num">row行數</param> 
	public void SetRowBreak(int row_num){
		sheet.SetRowBreak(row_num);
	}	
	
    /// <summary>
    ///設定Column手動分頁
    /// </summary>   
    /// <param name="column_num">column_num 欄數</param> 
	public void SetColumnBreak(int column_num){
		sheet.SetColumnBreak((short) column_num);
	}	
	
    /// <summary>
    ///設定隱藏欄
    /// </summary>   
    /// <param name="column_num">column_num</param> 
	public void SetColumnHidden(int column_num){
		sheet.SetColumnHidden(column_num, true);
	}
   
    /// <summary>
    ///設定隱藏欄
    /// </summary>   
    /// <param name="column_num">column_num</param> 
    /// <param name="boolean">Boolean</param> 
    public void SetColumnHidden(int column_num,Boolean boolean)
    {
        sheet.SetColumnHidden(column_num, boolean);
    }	
	
    /// <summary>
    ///設定表頭 (左)(left-top)
    /// </summary>   
    /// <param name="font">字型</param> 
    /// <param name="value">內容</param> 
	public void SetLeftHeader(HSSFFont font, String value){
		HSSFHeader header = sheet.Header;
		header.Left = HSSFHeader.Font(font.FontName, "regular") + 
				HSSFHeader.FontSize(font.FontHeightInPoints) + 
				value;
	}	
	
    /// <summary>
    ///設定表頭 (中)(center-middle)
    /// </summary>   
    /// <param name="font">字型</param> 
    /// <param name="value">內容</param> 
	public void SetCenterHeader(HSSFFont font, String value){
        HSSFHeader header = sheet.Header;
        header.Center = HSSFHeader.Font(font.FontName, "regular") +
                HSSFHeader.FontSize(font.FontHeightInPoints) +
                value;
	}	
	
    /// <summary>
    ///設定表頭 (右)(right-top)
    /// </summary>   
    /// <param name="font">字型</param> 
    /// <param name="value">內容</param> 
	public void SetRightHeader(HSSFFont font, String value){
        HSSFHeader header = sheet.Header;
        header.Right = HSSFHeader.Font(font.FontName, "regular") +
                HSSFHeader.FontSize(font.FontHeightInPoints) +
                value;
	}	
	
    /// <summary>
    ///設定表尾 (左)(left-bottom)
    /// </summary>   
    /// <param name="font">字型</param> 
    /// <param name="value">內容</param> 
	public void SetLeftFooter(HSSFFont font, String value){
		HSSFFooter footer = sheet.Footer;
		footer.Left = HSSFFooter.Font(font.FontName, "regular") + 
				HSSFFooter.FontSize(font.FontHeightInPoints) + 
				value;
	}	
	
    /// <summary>
    ///設定表尾 (中)(center-middle)
    /// </summary>   
    /// <param name="font">字型</param> 
    /// <param name="value">內容</param> 
	public void SetCenterFooter(HSSFFont font, String value){
        HSSFFooter footer = sheet.Footer;
        footer.Center = HSSFFooter.Font(font.FontName, "regular") +
                HSSFFooter.FontSize(font.FontHeightInPoints) +
                value;
	}	
	
    /// <summary>
    ///設定表尾 (右)(right-bottom)
    /// </summary>   
    /// <param name="font">字型</param> 
    /// <param name="value">內容</param> 
	public void SetRightFooter(HSSFFont font, String value){
        HSSFFooter footer = sheet.Footer;
        footer.Right = HSSFFooter.Font(font.FontName, "regular") +
                HSSFFooter.FontSize(font.FontHeightInPoints) +
                value;
	}
	
	
    /// <summary>
    ///  設定列印紙張大小
    ///  註：註印表機的設定會造成影響，有可能發生設定A3，列印設定也是A3，結果卻用A4輸出的狀況
    /// </summary>   
    /// <param name="page_size">紙張大小</param>
	public void SetPagesize(short page_size){
		HSSFPrintSetup ps = sheet.PrintSetup;
		ps.PaperSize = page_size;
	}	
	
    /// <summary>
    /// 設定橫式列印
    /// </summary>   
    /// <param name="landscape">是否橫式列印</param>
	public void SetLandscape(Boolean landscape){
        HSSFPrintSetup ps = sheet.PrintSetup;
		ps.Landscape = landscape;
	}	

    /// <summary>
    /// 置中對齊方式:  水平
    /// </summary>
    /// <param name="flag"></param>
    public void SetHorizontallyCenter(Boolean flag){
        sheet.HorizontallyCenter = flag;
    }


    /// <summary>
    /// 置中對齊方式：垂直
    /// </summary>
    /// <param name="flag"></param>
    public void SetVerticallyCenter(Boolean flag)
    {
        sheet.VerticallyCenter = flag;
    }
	
    /// <summary>
    /// 設定邊寬 (單位：公分)
    /// </summary>   
    /// <param name="leftSize">左邊寬</param>
    /// <param name="reightSize">右邊寬</param>
    /// <param name="topSize">上邊寬</param>
    /// <param name="bottomSize">下邊寬</param>
	public void SetMargin(double leftSize, double reightSize, double topSize, double bottomSize){
		sheet.SetMargin(MarginType.LeftMargin, leftSize * 0.3937); //1 cm = 0.3937 in.
        sheet.SetMargin(MarginType.RightMargin, reightSize * 0.3937);
        sheet.SetMargin(MarginType.TopMargin, topSize * 0.3937);
        sheet.SetMargin(MarginType.BottomMargin, bottomSize * 0.3937);
	}	
	
    /// <summary>
    /// 設定表頭高度 (單位：公分)
    /// </summary>   
    /// <param name="size">表頭高度(單位：公分)</param>
	public void SetHeaderMargin(double size){
		HSSFPrintSetup ps = sheet.PrintSetup;
		ps.HeaderMargin = size * 0.3937;
	}	
	
    /// <summary>
    /// 設定表尾高度 (單位：公分)
    /// </summary>   
    /// <param name="size">表尾高度(單位：公分)</param>
	public void SetFooterMargin(double size){
		HSSFPrintSetup ps = sheet.PrintSetup;
		ps.FooterMargin = size * 0.3937;
	}	

    /// <summary>
    ///取得目前頁數
    /// </summary>   
    /// <returns>目前頁數</returns>
	public static String GetNowPage(){
		//HSSFHeader.page() = HSSFFooter.page()
		return HSSFHeader.Page;
	}	
	
    /// <summary>
    ///取得總頁數
    /// </summary>   
    /// <returns>總頁數</returns>
    public static String GetTotalPages()
    {
		//HSSFHeader.numPages(0 = HSSFFooter.numPages()
		return HSSFHeader.NumPages;
	}	

    /// <summary>
    ///取得目前日期 (EX:2010/1/1)
    /// </summary>   
    /// <returns>目前日期 (EX:2010/1/1)</returns>
    public static String GetNowDate()
    {
		return HSSFHeader.Date;
	}
   
    /// <summary>
    ///取得圖檔檔案類型，轉換為PictureType格式
    /// </summary>
    /// <param name="fileName">圖片檔名</param>
    /// <returns>PictureType</returns>
    public PictureType getPictureType(String fileName)
    {
        String type = fileName.Substring(fileName.LastIndexOf('.') + 1).ToUpper();

        if (type.Equals("PNG"))
        {
            return PictureType.PNG;
        }
        else if (type.Equals("JPEG"))
        {
            return PictureType.JPEG;
        }
        else if (type.Equals("JPG"))
        {
            return PictureType.JPEG;
        }
        else if (type.Equals("GIF"))
        {
            return PictureType.JPEG;
        }
        else if (type.Equals("BMP"))
        {
            return PictureType.JPEG;
        }
        else if (type.Equals("EMF"))
        {
            return PictureType.EMF;
        }
        else if (type.Equals("PICT"))
        {
            return PictureType.PICT;
        }
        else if (type.Equals("WMF"))
        {
            return PictureType.WMF;
        }
        else if (type.Equals("DIB"))
        {
            return PictureType.DIB;
        }
        else
        {
            return PictureType.JPEG;
        }
    }
    
    /// <summary>
    ///加入圖片，預設縮放大小，包含範圍為x = start_column ~ end_column，y = start_row底 ~ end_row底(根據實際Cell狀況縮放)
    /// </summary>
    /// <param name="filePath">圖片檔案路徑</param>
    /// <param name="start_column">欄編號</param>
    /// <param name="start_row">列編號</param>
    /// <param name="end_column">欄編號</param>
    /// <param name="end_row">列編號</param>
    public void addPicture(String filePath, int start_column, int start_row, int end_column, int end_row)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
        int pictureIdx = wb.AddPicture(bytes, getPictureType(filePath));

        //Create the drawing patriarch.  This is the top level container for all shapes
        if (patriarch == null)
        {
            patriarch = sheet.CreateDrawingPatriarch();
        }

        //add a picture
        HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 1023, 0, start_column, start_row, end_column, end_row);//前四碼尚不清楚功用

        pict = patriarch.CreatePicture(anchor, pictureIdx);
    }
  
    /// <summary>
    ///加入圖片(直接顯示原始大小)
    /// </summary>
    /// <param name="filePath">圖片檔案路徑</param>
    /// <param name="column_num">欄編號</param>
    /// <param name="row_num">列編號</param>
    public void addPicture(String filePath, int column_num, int row_num)
    {
        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
        int pictureIdx = wb.AddPicture(bytes, getPictureType(filePath));

        //Create the drawing patriarch.  This is the top level container for all shapes
        if (patriarch == null)
        {
            patriarch = sheet.CreateDrawingPatriarch();
        }

        //add a picture
        HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 1023, 0, column_num, row_num, column_num, row_num);//前四碼尚不清楚功用
        pict = patriarch.CreatePicture(anchor, pictureIdx);

        //顯示原始大小
        pict.Resize();
    }
   
    /// <summary>
    ///顯示圖片原始大小
    /// </summary>
    public void picResize()
    {
        //顯示原始大小
        pict.Resize();
    }

    /// <summary>
    ///設定列印縮放大小
    /// </summary>
    /// <param name="scale"></param>
    public void setScale(short scale)
    {
        HSSFPrintSetup ps = sheet.PrintSetup;
        ps.Scale = scale;
    }

    /// <summary>
    ///回傳colunm所代表的欄位名稱 範圍(0,59)
    ///例: 0 -> A, 1->B
    /// </summary>
    /// <param name="n">col</param>   
    /// <returns>欄位名稱</returns>
    public String col_name(int n)
    {        
        String[] s_ret = new String[60] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH" };
        if (n < 0 || n > 59)
        {
            return "?";
        }
        else
        {
            return s_ret[n];
        }
    }
    /// <summary>
    ///回傳(m,n)所代表的欄位名稱 
    ///例: (0,0) -> A1, (2,3)->D2
    /// </summary>
    /// <param name="m">col</param>
    /// <param name="n">row</param>
    /// <returns>欄位名稱</returns>
    public String cell_name(int m,int n)
    {
        if (n < 0 || n > 59)
            return "?";
        else
            return col_name(n) + (m + 1);
    }

    /// <summary>
    /// 要求公式重算結果
    /// </summary>
    public void Recalculation()
    {
        sheet.ForceFormulaRecalculation = false;
    }
}

