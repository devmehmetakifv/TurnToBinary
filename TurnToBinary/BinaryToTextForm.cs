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

namespace TurnToBinary
{
    public partial class BinaryToTextForm : Form
    {
        public FileStream stream;
        public string deserializedBinary;
        public string selectedFolderPath;
        public string fileName;
        public BinaryToTextForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFullPath(openFileDialog1.FileName);
                stream = new FileStream(Path.GetFullPath(openFileDialog1.FileName), FileMode.Open);
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

        private void button2_Click(object sender, EventArgs e)
        {
            fileName = textBox4.Text;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            deserializedBinary = (string)binaryFormatter.Deserialize(stream);
            File.WriteAllText($"{selectedFolderPath}\\{fileName}.txt", deserializedBinary);
            MessageBox.Show($"File {fileName}.txt has been successfully saved at the location {selectedFolderPath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            stream.Close();
        }
    }
}
