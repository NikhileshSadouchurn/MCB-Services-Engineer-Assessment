using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace WindowsFormsApp2
{

    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();

            if (fdb.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                string[] files = DirectoryEntry.GetFiles(fdb.SelectedPath);
                string[] dirs = Directory.GetDirectories(fdb.SelectedPath);

                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file));
                }
                foreach (string dir in dirs)
                {
                    listBox1.Items.Add(Path.GetFileName(dir));
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            PaperSize paperSize = new PaperSize("papersize", 150, 500);//set the paper size
            int totalnumber = 0;//this is for total number of items of the list or array
            int itemperpage = 0;

            itemperpage = totalnumber = 0;
            printDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

            PaperSize paperSize = new PaperSize("papersize", 150, 500);//set the paper size
            int totalnumber = 0;//this is for total number of items of the list or array
            int itemperpage = 0;
            //here we are printing 50 numbers sequentially by using loop. 
            //For each button click event we have to reset below two variables to 0     
            // because every time  PrintPage event fires automatically. 

            itemperpage = totalnumber = 0;
            printPreviewDialog1.Document = printDocument1;

            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
            = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            PaperSize paperSize = new PaperSize("papersize", 150, 500);//set the paper size
            int totalnumber = 0;//this is for total number of items of the list or array
            int itemperpage = 0;

            float currentY = 10;// declare  one variable for height measurement
            e.Graphics.DrawString("Print in Multiple Pages", DefaultFont, Brushes.Black, 10, currentY);//this will print one heading/title in every page of the document
            currentY += 15;

            while (totalnumber <= 50) // check the number of items
            {
                e.Graphics.DrawString(totalnumber.ToString(), DefaultFont, Brushes.Black, 50, currentY);//print each item
                currentY += 20; // set a gap between every item
                totalnumber += 1; //increment count by 1
                if (itemperpage < 20) // check whether  the number of item(per page) is more than 20 or not
                {
                    itemperpage += 1; // increment itemperpage by 1
                    e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added

                }

                else // if the number of item(per page) is more than 20 then add one page
                {
                    itemperpage = 0; //initiate itemperpage to 0 .
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                    return;//It will call PrintPage event again
                }
            }
        }
    }
}
