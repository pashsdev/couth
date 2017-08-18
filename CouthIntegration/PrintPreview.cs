using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CouthIntegration
{
    public partial class PrintPreview : Form
    {
        private DataGridView _grid;
        private List<string> _templateText = new List<string>();
        private int _index = 0;
        public PrintPreview(DataGridView grid, string templateText)
        {
            InitializeComponent();
            _grid = grid;

            _templateText = GetTemplateText(templateText);
            rtfPreview.Text = _templateText[0];
        }

        private void Print(string template)
        {
            string fileName = "text.txt";
            string _filePath = Path.Combine(Application.StartupPath, fileName);
            template = template.Replace("\n", Environment.NewLine);

            try
            {
                File.WriteAllText(_filePath, template.ToString());
            }
            catch
            {
                throw new Exception("Path not valid");
            }

            Process process = new Process();
            ProcessWindowStyle windowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo = new ProcessStartInfo(Path.Combine(Application.StartupPath, "COMMT2_2.exe"))
            {
                WorkingDirectory = Path.GetDirectoryName(Application.StartupPath),
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WindowStyle = windowStyle,
                //Verb = "runas",
                CreateNoWindow = (windowStyle == ProcessWindowStyle.Hidden)
            };
            process.Start();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            string templateText = rtfPreview.Text;
            Print(templateText);
            _index++;
            if (_templateText.Count <= _index)
            {
                this.Close();
            }
            else
            {
                rtfPreview.Text = _templateText[_index];
            }
        }

        private List<string> GetTemplateText(string templateFormat)
        {
            List<string> templateText = new List<string>();
            //StringBuilder template = new StringBuilder();
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.Cells["DgvColJobno"] != null && row.Cells["DgvColMark"].Value != null && Convert.ToBoolean(row.Cells["DgvColMark"].Value))
                {
                    StringBuilder jobnos = new StringBuilder(templateFormat);
                    jobnos = jobnos.Replace("[@jobno@]", GetValue(row.Cells["DgvColJobno"]));
                    jobnos = jobnos.Replace("[@serialno@]", GetValue(row.Cells["DgvColSerialNo"]));
                    jobnos = jobnos.Replace("[@model@]", GetValue(row.Cells["DgvColR01_PUMP_MODEL"]));
                    jobnos = jobnos.Replace("[@volts@]", GetValue(row.Cells["DgvColR01_VOLTS"]));
                    jobnos = jobnos.Replace("[@icl@]", GetValue(row.Cells["DgvcolCATEGORY"]));
                    jobnos = jobnos.Replace("[@kw/hp@]", GetValue(row.Cells["DgvColkwhp"]));
                    jobnos = jobnos.Replace("[@amps@]", GetValue(row.Cells["DgvColAMPS"]));
                    jobnos = jobnos.Replace("[@ph@]", GetValue(row.Cells["DgvColPHASE"]));
                    jobnos = jobnos.Replace("[@n@]", GetValue(row.Cells["DgvColRPM"]));
                    jobnos = jobnos.Replace("[@h@]", GetValue(row.Cells["DgvColHead"]));
                    jobnos = jobnos.Replace("[@disch@]", GetValue(row.Cells["DgvColDISCHARGE"]));
                    jobnos = jobnos.Replace("[@h-max@]", GetValue(row.Cells["DgvColHEAD_MAX"]));
                    jobnos = jobnos.Replace("[@deliverysize@]", GetValue(row.Cells["DgvColC_SIZE"]));
                    jobnos = jobnos.Replace("[@current@]", GetValue(row.Cells["DgvColR01_AMPS"]));
                    jobnos = jobnos.Replace("[@discharge@]", GetValue(row.Cells["DgvColDISCHARGE"]));
                    jobnos = jobnos.Replace("[@rated@]", GetValue(row.Cells["DgvColHead"]));
                    jobnos = jobnos.Replace("[@range@]", GetValue(row.Cells["DgvColHead"]));
                    jobnos = jobnos.Replace("[@over all efficency@]", GetValue(row.Cells["DgvColPerfomance"]));
                    //jobnos = jobnos.Replace("[@range@]", row.Cells["DgvColSerialNo"].Value.ToString());
                    //jobnos = jobnos.Replace("[@speed@]", row.Cells["DgvColSerialNo"].Value.ToString());
                    //jobnos = jobnos.Replace("[@over all efficency@]", row.Cells["DgvColSerialNo"].Value.ToString());
                    //template.Append(jobnos.ToString());
                    //template.Append(Environment.NewLine);
                    templateText.Add(jobnos.ToString());
                }
            }

            return templateText;
        }

        private string GetValue(DataGridViewCell cell)
        {
            return Common.GetValue(cell);
        }


    }
}
