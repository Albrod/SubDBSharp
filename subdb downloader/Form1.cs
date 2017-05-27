using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;

namespace SubDBSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (string filePath in files)
                {
                    tb_filepath.Text = filePath.ToString();
                    label1.Text = hacer.getHash(filePath.ToString());
                }
            }
        }

        private void bt_algo_Click(object sender, EventArgs e)
        {
            tb_pruebas.Text = hacer.look_for_subs();
            tb_pruebas.Text = hacer.download_sub();
        }
    }
}
