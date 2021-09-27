using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurKLoJeN_Whois_V1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            // richTextBox1.SelectedText.Replace(richTextBox1.SelectedText, "");
            iTalk_RichTextBox1.Text = "";
            string siteUrl = iTalk_TextBox_Small1.Text;
            if (siteUrl == "")
            {
                MessageBox.Show("Lütfen bir url giriniz");
            }
            else
            {
                string txtResponse = String.Empty;
                string strResponse = String.Empty;
                TcpClient tcpWhois = new TcpClient("whois.internic.net", 43);
                NetworkStream nsWhois = tcpWhois.GetStream();
                BufferedStream bfWhois = new BufferedStream(nsWhois);
                StreamWriter swSend = new StreamWriter(bfWhois);
                swSend.WriteLine(siteUrl);
                swSend.Flush();
                StreamReader srReceive = new StreamReader(bfWhois);
                while ((strResponse = srReceive.ReadLine()) != null)
                {
                    txtResponse += strResponse + "\r\n";
                }
                tcpWhois.Close();
                iTalk_RichTextBox1.Text = txtResponse;
            }
            
        }

        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iTalk_Button_12_Click(object sender, EventArgs e)
        {

            TextWriter writer = new StreamWriter("domain.txt");

            writer.Write(iTalk_RichTextBox1.Text);

            writer.Close();

            MessageBox.Show("File saved successfully");
        }

        private void iTalk_Button_13_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(iTalk_RichTextBox1.Text);
            MessageBox.Show("Data successfully copied to clipboard");
        }

        private void iTalk_TextBox_Small1_Enter(object sender, EventArgs e)
        {
            if (iTalk_TextBox_Small1.Text == "turklojenofficial.com")
            {
                iTalk_TextBox_Small1.Text = "";

                iTalk_TextBox_Small1.ForeColor = Color.Black;
            }

        }

        private void iTalk_TextBox_Small1_Leave(object sender, EventArgs e)
        {
            if (iTalk_TextBox_Small1.Text == "")
            {
                iTalk_TextBox_Small1.Text = "turklojenofficial.com";

                iTalk_TextBox_Small1.ForeColor = Color.Silver;
            }
        }
    }
}
