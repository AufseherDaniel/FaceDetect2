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

namespace FaceDetect2
{
    class FaceDetect
    {
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
            CvInvoke.Rectangle(result, new Rectangle(maxLoc.X, maxLoc.Y, tempImg.Width, tempImg.Height), new MCvScalar(0, 255, 0), 2);
            return result.ToBitmap();
        }
        private Point FindTopCenter(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2, rect.Top);
        }

        private Point FindBotCenter(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2, rect.Bottom);
        }

        public Bitmap ViolaJones(string original)
        {
            CascadeClassifier face_cascade = new CascadeClassifier(Path.Combine(Environment.CurrentDirectory, @"Templates\", "haarcascade_frontalface_alt.xml")); 
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
            List<Point> _pointsBot = new List<Point>();
            List<Point> _pointsTop = new List<Point>();
            Point _nBot;
            Point _nTop;
            CascadeClassifier face_cascade = new CascadeClassifier(Path.Combine(Environment.CurrentDirectory, @"Templates\", "haarcascade_frontalface_alt.xml"));
            CascadeClassifier eye_cascade = new CascadeClassifier(Path.Combine(Environment.CurrentDirectory, @"Templates\", "haarcascade_eye.xml")); 
            Mat result = CvInvoke.Imread(original);
            Mat gray = new Mat();
            CvInvoke.CvtColor(result, gray, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(gray, gray);
            Rectangle[] faceDetect = face_cascade.DetectMultiScale(gray, 1.1, 2, new Size(50, 50));
            foreach (var i in faceDetect)
            {
                Mat eyeImg = new Mat(gray, i);
                Rectangle[] eyeDetect = eye_cascade.DetectMultiScale(eyeImg, 1.1, 2, new Size(20, 20));
                foreach (var j in eyeDetect)
                {
                    Rectangle rect = new Rectangle(i.X + j.X, i.Y + j.Y, j.Width, j.Height);
                    _pointsTop.Add(FindTopCenter(rect));
                    _pointsBot.Add(FindBotCenter(rect));
                }
            }

            for (int j = 0; j <= _pointsTop.Count-1; j++ )
                {
                    CvInvoke.Line(result, _pointsTop[j], _pointsBot[j], new MCvScalar(255, 0, 0), 2);
                    CvInvoke.Line(result, _pointsTop[j+1], _pointsBot[j+1], new MCvScalar(255, 0, 0), 2);
                    if(_pointsTop[j].Y < _pointsTop[j+1].Y)
                    {
                        _nTop = new Point((_pointsTop[j].X + _pointsTop[j+1].X)/2, _pointsTop[j + 1].Y);
                    }
                    else
                    {
                        _nTop = new Point((_pointsTop[j].X + _pointsTop[j + 1].X) / 2, _pointsTop[j].Y);
                    }

                    if (_pointsBot[j].Y < _pointsBot[j + 1].Y)
                    {
                        _nBot = new Point((_pointsBot[j].X + _pointsBot[j + 1].X) / 2, _pointsBot[j].Y);
                    }
                    else
                    {
                        _nBot = new Point((_pointsBot[j].X + _pointsBot[j + 1].X) / 2, _pointsBot[j+1].Y);
                    }
                    CvInvoke.Line(result, _nTop, _nBot, new MCvScalar(255, 0, 0), 2);
                    j++;
                }

            return result.ToBitmap();
        }
    }
}
