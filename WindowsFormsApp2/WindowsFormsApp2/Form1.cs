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
    public partial class Form1 : Form
    {
        public object Response { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String UName = "UName=" + txtUName.Text + ",ou=MCB,dc=LOCAL";//depending on organisation, use of LDAP
            String Password = txtPassword.Text;

            DirectoryEntry root = new DirectoryEntry("LDAP://MCB.LOCAL", UName, Password);//directory for organisation

            try
            {

                object connected = root.Nativeobject;
                Console.WriteLine("Login successful");
                Form3 formMain = new Form3();
                formMain.Show();//redirect once login successful
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed");
                
            }

            Console.WriteLine("<p/>");

        }
    }
}
