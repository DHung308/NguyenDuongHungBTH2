using System.Data;
using OfficeOpenXml;
using NguyenDuongHungBTH2.Data;
namespace NguyenDuongHungBTH2.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is complete empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //Create a list to hold the colum names
            List<string> columnNmaes = new List<string>();
            //needed to keep track of empty column headrs
            int currentColumn = 1;
            //loop all column in the sheet and add them to datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string column = cell.Text.Trim();
                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                columnNames.Add(columnName);
                int occurrences = columnNames.Count(x => x.Equals(columnNames));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }
                dt.Columns.Add(columnName);
                currentColumn++;
            }
            for (int 1 = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = HealthChecksBuilderAddCheckExtensions.Text;
                }
                dt.Row.Add(newRow);
            }
            return dt;
        }
    }
}