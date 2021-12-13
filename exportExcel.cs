using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace RetoCntWinforms
{
    class exportExcel
    {
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        public void exportaraexcel(DataGridView tabla)
        {
            int filastotales = tabla.Rows.Count;


            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns) // Columnas
            {

                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.Name;

            }

            int IndeceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows) // Filas
            {
                IndeceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    IndiceColumna++;
                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                }
                //progress.Value = (IndeceFila * 100) / filastotales;
            }
            excel.Visible = true;
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            worksheet.Activate();
            MessageBox.Show("Exportación Exitosa", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //progress.Value = 0; 
        }        
    }
}
