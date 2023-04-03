using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security;
using System.Runtime.InteropServices.ComTypes;

namespace TurnToBinary
{
    public partial class TextToBinaryForm : Form
    {
        public string fileContent;
        public string selectedFolderPath;
        public string fileName;
        public TextToBinaryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFullPath(openFileDialog1.FileName);
                fileContent = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileName = textBox4.Text;
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                FileStream stream = new FileStream($"{selectedFolderPath}\\{fileName}.bnry", FileMode.Create, FileAccess.ReadWrite);
                formatter.Serialize(stream, fileContent);
                MessageBox.Show($"File {fileName}.bnry has been successfully saved at the location {selectedFolderPath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                stream.Close();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("It looks like access is denied. Run the program as admin and try again!","Access Denied",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = "C:\\";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFolderPath = folderBrowserDialog.SelectedPath;
                textBox3.Text = selectedFolderPath;
            }
        }
    }
}
