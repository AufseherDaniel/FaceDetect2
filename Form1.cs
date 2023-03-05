using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FaceDetect2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FaceDetect FD = new FaceDetect();
        OpenFileDialog _opf = new OpenFileDialog();
        private string _templatePath;

        private void File_Click(object sender, EventArgs e)
        {
            _opf.ShowDialog();
            if (_opf.ShowDialog() != DialogResult.OK)
            {
                return;
            }
        }

        private void FindB_Click(object sender, EventArgs e)
        {
            if (Methods.SelectedIndex == 0) //tm
            {
                ResBox.Image = FD.TemplateMatching(_opf.FileName, _templatePath);
            }
            if (Methods.SelectedIndex == 1) //vj
            {
                ResBox.Image = FD.ViolaJones(_opf.FileName);
            }
            if (Methods.SelectedIndex == 2) //ls
            {
                ResBox.Image = FD.LinesOfSymmetry(_opf.FileName);
            }
        }

        private void Templates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TemplateBox.SelectedIndex == 0) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Brows.png"); }
            if (TemplateBox.SelectedIndex == 1) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "browL.png"); }
            if (TemplateBox.SelectedIndex == 2) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "browR.png"); }
            if (TemplateBox.SelectedIndex == 3) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "eyes.png"); }
            if (TemplateBox.SelectedIndex == 4) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "EyeL.png"); }
            if (TemplateBox.SelectedIndex == 5) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "EyeR.png"); }
            if (TemplateBox.SelectedIndex == 6) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Nouse.png"); }
            if (TemplateBox.SelectedIndex == 7) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Mouth.png"); }
        }
    }
}
