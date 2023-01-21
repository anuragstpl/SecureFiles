using SecureFileSender.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFileSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PgpEncrypt Pgp = new PgpEncrypt();
                string EncryptedFileName = txtEncryptedFileName.Text != "" ? txtEncryptedFileName.Text : "output.enc";
                Pgp.EncryptFile(txtOutputDirectory.Text + "/" + EncryptedFileName, txtFileToEncrypt.Text, txtPublicKeyFile.Text, true, true);
                MessageBox.Show("File Encrypted Successfully.Please check the output directory for encrypted file.", "Decryption Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Some error occcured.Please check your entries.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PgpDecrypt Pgp = new PgpDecrypt();
                Pgp.DecryptFile(txtFileToDecrypt.Text, txtPrivateKeyFile.Text, txtPassPhrase.Text.ToCharArray(), txtDecryptedFileOutput.Text);
                MessageBox.Show("File Decrypted Successfully.Please check the output directory for decrypted file.","Decryption Completed",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Some error occcured.Please check your entries.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileToEncrypt.Text = openFileDialog1.FileName;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            txtPublicKeyFile.Text = openFileDialog2.FileName;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutputDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            txtFileToDecrypt.Text = openFileDialog3.FileName;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog4.ShowDialog();
        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {
            txtPrivateKeyFile.Text = openFileDialog4.FileName;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                txtDecryptedFileOutput.Text = folderBrowserDialog2.SelectedPath;
            }
        }
    }
}
