using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurnToBinary
{
    public partial class TurnToBinaryMainScreen : Form
    {
        public TurnToBinaryMainScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextToBinaryForm textToBinaryForm= new TextToBinaryForm();
            textToBinaryForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BinaryToTextForm binaryToTextForm= new BinaryToTextForm();
            binaryToTextForm.ShowDialog();
        }
    }
}
