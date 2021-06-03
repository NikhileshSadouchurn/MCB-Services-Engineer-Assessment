using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btngettext_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string filePath;
            dlg.Filter = "PDF Files(*.PDF)|*.PDF|ALL Files(*.*)|*.*";//list all files with extension PDF

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName.ToString();
            }

            string strText = string.Empty;
            try
            {
                PdfReader reader = new PdfReader();

                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    strText = strText + s + "|";//concatenate file with pipe
                    richTextBox1.Text = strText;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private class PdfTextExtractor
        {
            internal static string GetTextFromPage(PdfReader reader, int page, ITextExtractionStrategy its)
            {
                throw new NotImplementedException();
            }
        }
    }
}
