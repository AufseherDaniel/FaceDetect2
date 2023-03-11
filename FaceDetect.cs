using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FaceDetect2
{
    class FaceDetect
    {
        private string _dataPath = Path.Combine(Application.StartupPath, @"WorkData\");
        public Bitmap TemplateMatching(string original, string template)
        {
            Mat src = CvInvoke.Imread(original);
            Mat result = src.Clone();
            Mat tempImg = CvInvoke.Imread(template);
            int rows_dst = src.Rows - tempImg.Rows + 1;
            int cols_dst = src.Cols - tempImg.Cols + 1;
            Mat dst = new Mat(rows_dst, cols_dst, DepthType.Cv32F, 1);
            CvInvoke.MatchTemplate(src, tempImg, dst, TemplateMatchingType.CcoeffNormed);
            CvInvoke.Normalize(dst, dst, 0, 1, NormType.MinMax, dst.Depth);
            double minValue = 1000, maxvalue = -1;
            Point minLoc = new Point(0, 0);
            Point maxLoc = new Point(0, 0);
            CvInvoke.MinMaxLoc(dst, ref minValue, ref maxvalue, ref minLoc, ref maxLoc);
            CvInvoke.Rectangle(result, new Rectangle(maxLoc.X, maxLoc.Y, tempImg.Width, tempImg.Height), new MCvScalar(255, 0, 0), 2);
            return result.ToBitmap();
        }

        public Bitmap TemplateMatching(string original, string template, string rez)
        {
            Mat src = CvInvoke.Imread(original);
            Mat result = CvInvoke.Imread(rez);
            Mat tempImg = CvInvoke.Imread(template);
            int rows_dst = src.Rows - tempImg.Rows + 1;
            int cols_dst = src.Cols - tempImg.Cols + 1;
            Mat dst = new Mat(rows_dst, cols_dst, DepthType.Cv32F, 1);
            CvInvoke.MatchTemplate(src, tempImg, dst, TemplateMatchingType.CcoeffNormed);
            CvInvoke.Normalize(dst, dst, 0, 1, NormType.MinMax, dst.Depth);
            double minValue = 0, maxvalue = 0;
            Point minLoc = new Point(0, 0);
            Point maxLoc = new Point(0, 0);
            CvInvoke.MinMaxLoc(dst, ref minValue, ref maxvalue, ref minLoc, ref maxLoc);
            CvInvoke.Rectangle(result, new Rectangle(maxLoc.X, maxLoc.Y, tempImg.Width, tempImg.Height), new MCvScalar(255, 0, 0), 2);
            return result.ToBitmap();
        }

        private Point FindCenter(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }


        public Bitmap ViolaJones(string original)
        {
            string name = Path.Combine(_dataPath, "tempHaarasFaceForFD2.xml");
            File.Create(name).Dispose();
            File.WriteAllText(name, Properties.Resources.haarcascade_frontalface_alt); 
            CascadeClassifier face_cascade = new CascadeClassifier(name);
            File.Delete(name);
            Mat result = CvInvoke.Imread(original);
            Mat gray = new Mat();
            CvInvoke.CvtColor(result, gray, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(gray, gray);
            Rectangle[] faceDetect = face_cascade.DetectMultiScale(gray, 1.1, 2, new Size(50, 50));
            foreach (var i in faceDetect)
            {
                CvInvoke.Rectangle(result, i, new MCvScalar(255, 0, 0), 2);
            }
            return result.ToBitmap();
        }

        public Bitmap LinesOfSymmetry(string original)
        {
            string nameF = Path.Combine(_dataPath, "tempHaarasFaceForFD2.xml");
            string nameE = Path.Combine(_dataPath, "tempHaarasEyeForFD2.xml");
            File.Create(nameF).Dispose();
            File.Create(nameE).Dispose();
            List<int> _YBot = new List<int>();
            List<int> _YTop = new List<int>();
            List<int> _X = new List<int>();
            int k = 0;
            File.WriteAllText(nameF, Properties.Resources.haarcascade_frontalface_alt);
            CascadeClassifier face_cascade = new CascadeClassifier(nameF);
            File.Delete(nameF);
            File.WriteAllText(nameE, Properties.Resources.haarcascade_eye);
            CascadeClassifier eye_cascade = new CascadeClassifier(nameE);
            File.Delete(nameE);
            Mat result = CvInvoke.Imread(original);
            Mat gray = new Mat();
            CvInvoke.CvtColor(result, gray, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(gray, gray);
            Rectangle[] faceDetect = face_cascade.DetectMultiScale(gray, 1.1, 2, new Size(50, 50));
            foreach (var i in faceDetect)
            {
                _YTop.Add(i.Top);
                _YBot.Add(i.Bottom);
                Mat eyeImg = new Mat(gray, i);
                Rectangle[] eyeDetect = eye_cascade.DetectMultiScale(eyeImg, 1.1, 2, new Size(20, 20));
                if (eyeDetect.Length > 1)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        Rectangle rect = new Rectangle(i.X + eyeDetect[j].X, i.Y + eyeDetect[j].Y, eyeDetect[j].Width, eyeDetect[j].Height);
                        _X.Add(FindCenter(rect).X);
                    }
                }
            }

            for (int j = 0; j <= _X.Count-1; j++ )
            {
                CvInvoke.Line(result, new Point(_X[j], _YBot[k]), new Point(_X[j], _YTop[k]), new MCvScalar(255, 0, 0), 2);
                if (j % 2 != 0)
                {
                    CvInvoke.Line(result, new Point((_X[j] + _X[j-1])/2 , _YBot[k]), new Point((_X[j] + _X[j - 1]) / 2, _YTop[k]), new MCvScalar(255, 0, 0), 2);
                    k++;
                }
            }
            return result.ToBitmap();
        }

        public void SaveImage(Image _savedFile)
        {
            SaveFileDialog SFD = new SaveFileDialog
            {
                Title = "Сохранить как...",
                OverwritePrompt = true,
                CheckPathExists = true,
                Filter = ".PNG|*.PNG|.JPG|*.JPG|Все файлы(*.*)|*.*"
            };
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    _savedFile.Save(SFD.FileName);
                }
                catch 
                {
                    MessageBox.Show("Не удалось сохранить изображение","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            SFD.Dispose();
        }

        public void FileDelete(string _path)
        {
            if (File.Exists(_path) == true)
            {
                File.Delete(_path);
            }
        }
    }
}
