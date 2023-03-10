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
            try
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
            catch
            {
                MessageBox.Show("Убедитесь все ли вы выбрали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            /*if (Templates.SelectedIndex == 0) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "Brows.jpg"); }
            if (Templates.SelectedIndex == 1) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "browL.jpg"); }
            if (Templates.SelectedIndex == 2) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "browR.jpg"); }
            if (Templates.SelectedIndex == 3) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "eyes.jpg"); }
            if (Templates.SelectedIndex == 4) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "EyeL.jpg"); }
            if (Templates.SelectedIndex == 5) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "EyeR.jpg"); }
            if (Templates.SelectedIndex == 6) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "Nouse.jpg"); }
            if (Templates.SelectedIndex == 7) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "Mouth.jpg"); }
            if (Templates.SelectedIndex == 8) { _templatePath = Path.Combine(Environment.CurrentDirectory, @"Templates\Show\", "Face.jpg"); }*/
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            FD.SaveImage(ResBox.Image);
        }

        private void Methods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Methods.SelectedIndex == 0) //tm
            {
                Templates.Visible = true;
                ContinueWithThisB.Visible = true;
            }
            else
            {
                Templates.Visible = false;
                ContinueWithThisB.Visible = false;
            }
        }
        private void ContinueWithThisB_Click(object sender, EventArgs e)
        {
            try
            {
                string name = Path.Combine(Environment.CurrentDirectory, @"Temp\", "img.jpg");
                ResBox.Image.Save(name);
                ResBox.Image = FD.TemplateMatching(_opf.FileName, _templatePath, name);
                FD.FileDelete(name);
            }
            catch
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int _max = Methods.Width;
            int _width;
            Font _font = Methods.Font;
            foreach(var s in Methods.Items)
            {
                _width = TextRenderer.MeasureText(s.ToString(), _font).Width + 20;
                if (_max < _width)
                {
                    _max = _width;
                }    
            }
            Methods.Width = _max;
        }
    }
}
