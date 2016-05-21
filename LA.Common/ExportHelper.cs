using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LA.Common
{
    public class ExportHelper
    {
        #region 导出到Excel
        /// <summary>
        /// 功能： 导出到Excel
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="title">表头标题</param>
        /// <param name="dt">导出的数据</param>
        /// <param name="sheetname">sheet表格的名字</param>
        public static bool CreateExcel(NPOI.SS.UserModel.IWorkbook workbook, List<string> title, List<int> iColumns, DataTable dt, string sheetname, string sheetTitle, string subTitle)
        {
            if (iColumns.Count() != title.Count() || iColumns.Max() >= dt.Columns.Count)
            {
                return false;
            }
            int rowRecord = 0;

            ISheet sheet = workbook.CreateSheet(sheetname);
            #region 定义Sheet标题及子标题
            IRow titleRow = sheet.CreateRow(0);
            ICell titleCell = titleRow.CreateCell(0);
            titleCell.SetCellValue(sheetTitle);
            //ICellStyle titleStyle = workbook.CreateCellStyle();
            //titleStyle.Alignment = HorizontalAlignment.Center;
            //IFont titleFont = workbook.CreateFont();
            //titleFont.Boldweight = 200;
            //titleFont.FontHeight = 16 * 16;
            //titleStyle.SetFont(titleFont);
            //titleCell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, title.Count));
            IRow subTitleRow = sheet.CreateRow(1);
            ICell subTitleCell = subTitleRow.CreateCell(0);
            subTitleCell.SetCellValue(subTitle);
            //ICellStyle subTitleStyle = workbook.CreateCellStyle();
            //subTitleStyle.Alignment = HorizontalAlignment.Center;
            //IFont subTitleFont = workbook.CreateFont();
            //subTitleFont.Boldweight = 100;
            //subTitleFont.FontHeight = 15 * 15;
            //subTitleFont.Color = HSSFColor.Grey80Percent.Index;
            //subTitleStyle.SetFont(subTitleFont);
            //subTitleCell.CellStyle = subTitleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, title.Count));
            #endregion
            #region 初始化表格标题
            ICellStyle headerStyle = workbook.CreateCellStyle();
            headerStyle.Alignment = HorizontalAlignment.Center;
            headerStyle.BorderBottom = BorderStyle.Thin;
            headerStyle.BorderLeft = BorderStyle.Thin;
            headerStyle.BorderRight = BorderStyle.Thin;
            headerStyle.BorderTop = BorderStyle.Thin;
            headerStyle.FillForegroundColor = HSSFColor.Grey50Percent.Index;
            headerStyle.FillBackgroundColor = HSSFColor.Grey50Percent.Index;
            headerStyle.FillPattern = FillPattern.Squares;
            IFont headerFont = workbook.CreateFont();
            //headerFont.Boldweight = 200;
            //headerFont.FontHeight = 15 * 15;
            headerFont.Color = HSSFColor.White.Index;
            headerStyle.SetFont(headerFont);

            ICellStyle valueStyle = workbook.CreateCellStyle();
            //valueStyle.Alignment = HorizontalAlignment.Center;
            valueStyle.BorderBottom = BorderStyle.Thin;
            valueStyle.BorderLeft = BorderStyle.Thin;
            valueStyle.BorderRight = BorderStyle.Thin;
            valueStyle.BorderTop = BorderStyle.Thin;
            //IFont valueFont = workbook.CreateFont();
            //valueFont.FontHeight = 15 * 15;
            //valueStyle.SetFont(valueFont);
            int rowIndex = 3;
            IRow headerRow = sheet.CreateRow(rowIndex);
            for (int j = 0; j <= title.Count; j++)
            {
                ICell headerCell = headerRow.CreateCell(j);
                if (j == 0)
                {
                    headerCell.SetCellValue("序号");
                }
                else
                {
                    headerCell.SetCellValue(title[j - 1]);
                }
                headerCell.CellStyle = headerStyle;
            }
            #endregion
            if (dt.Rows.Count > 0)
            {
                #region 数据写入
                rowIndex += 1;

                for (int k = rowRecord; k < dt.Rows.Count; k++)
                {
                    rowRecord = k;
                    if (rowIndex > 65535)
                    {
                        break;
                    }
                    IRow dtRow = sheet.CreateRow(rowIndex);
                    DataRow dr = dt.Rows[k];
                    for (int l = 0; l <= dt.Columns.Count; l++)
                    {
                        for (int cl = 0; cl <= iColumns.Count(); cl++)
                        {
                            ICell valueCell = dtRow.CreateCell(cl);
                            if (cl == 0)
                            {
                                valueCell.SetCellValue(k + 1);
                            }
                            else
                            {
                                string columnValue = dr[iColumns[cl - 1]].ConvertTo<string>();
                                columnValue = columnValue.IsNullOrEmpty() || dt.Columns[iColumns[cl - 1]].DataType.Name != "DateTime" ? columnValue : DateTime.Parse(columnValue).ToString("yyyy-MM-dd");
                                valueCell.SetCellValue(columnValue);
                            }
                            valueCell.CellStyle = valueStyle;
                        }

                    }
                    rowIndex += 1;
                }
                #endregion
            }
            else
            {
                rowIndex += 1;
                IRow dtRow = sheet.CreateRow(rowIndex);
                for (int colIndex = 0; colIndex <= title.Count; colIndex++)
                {
                    ICell valueCell = dtRow.CreateCell(colIndex);
                    if (colIndex == 0)
                    {
                        valueCell.SetCellValue("没有数据");
                    }
                    else
                    {
                        valueCell.SetCellValue("");
                    }
                    valueCell.CellStyle = valueStyle;
                }
                sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, title.Count));
            }
            #region 自动伸展列宽
            for (int colIndex = 0; colIndex <= title.Count; colIndex++)
            {
                sheet.AutoSizeColumn(colIndex);
            }
            #endregion
            //}

            return true;
        }

        #endregion
    }
}
