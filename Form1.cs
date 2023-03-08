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
            if (Templates.SelectedIndex == 0) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Brows.png"); }
            if (Templates.SelectedIndex == 1) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "browL.png"); }
            if (Templates.SelectedIndex == 2) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "browR.png"); }
            if (Templates.SelectedIndex == 3) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "eyes.png"); }
            if (Templates.SelectedIndex == 4) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "EyeL.png"); }
            if (Templates.SelectedIndex == 5) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "EyeR.png"); }
            if (Templates.SelectedIndex == 6) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Nouse.png"); }
            if (Templates.SelectedIndex == 7) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Mouth.png"); }
            if (Templates.SelectedIndex == 8) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\", "Face.png"); }
        }
    }
}
