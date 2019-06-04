using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Renci.SshNet;

namespace SSLdos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            stopButton.Enabled = false;
        }

        private BackgroundWorker _worker = null;

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                do
                {
                    if (_worker.CancellationPending)
                    {
                        break;
                    }

                    using (SshClient client = new SshClient(textBox1.Text, textBox2.Text, textBox3.Text))
                    {
     
                        
                        try
                        {
                            client.Connect();
                            if (Screen.Checked)
                            {
                                client.RunCommand("screen");
                            }
                            client.RunCommand(textBox4.Text);
                            if (!Disconnect.Checked)
                            {
                                client.Disconnect();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error Connecting SSH", "SSH Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        
                    }

                } while (true);
            });

            _worker.RunWorkerAsync();
            SwapButtons();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void SwapButtons()
        {
            if(goButton.Enabled==false)
            {
                goButton.Enabled = true;
                stopButton.Enabled = false;
            } else {
                goButton.Enabled = false;
                stopButton.Enabled = true;
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            SwapButtons();
            _worker.CancelAsync();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

