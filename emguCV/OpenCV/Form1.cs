using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV
{
    public partial class Form1 : Form
    {


        // Load training data into CascadeClassifier
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, Filter = "JPG|*.jpg" })
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picBox.Image = Image.FromFile(ofd.FileName); // Can be from stream...

                    Bitmap bitmap = new Bitmap(picBox.Image);


                    // Mat m = bitmap.ToMat();
                    // Mat m = new Mat(bitmap);
                    // var image = new Image<Bgr, Byte>(new Bitmap(picBox.Image));
                    // var IMG = new Image<Bgr, byte>((Bitmap)picBox.Image);
                    // Image<Bgr, Byte> IMG = new Image<Bgr, byte>((Bitmap)picBox.Image);
                    // Image<Bgr, Byte> img1 = new Image<Bgr, Byte>("MyImage.jpg"); //From file
                    // Image<Bgr, Byte> img = mat.ToImage<Bgr, Byte>();
                    // Image<Bgr, Byte> myImg = new Image<Bgr, Byte>.AsBitmap();
                    //  Mat img = CvInvoke.Imread("myimage.jpg", Emgu.CV.CvEnum.ImreadModes.AnyColor);
                    //Image<Gray, Byte> image = new Image<Gray, Byte>(600, 300); //(width, height)

                    Image<Bgr, byte> myImg = new Image<Bgr, byte>(bitmap); // Original
                    Rectangle[] recs = cascadeClassifier.DetectMultiScale(myImg, 1.4, 0);

                    foreach (Rectangle rectangle in recs)
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (Pen pen = new Pen(Color.Red, 1))
                            {
                                graphics.DrawRectangle(pen, rectangle);
                            }
                        }
                    }
                    picBox.Image = bitmap;
                }
            }
        }

        //public static byte[] ToByteArray(this Image image, ImageFormat format)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        image.Save(ms, format);
        //        return ms.ToArray();
        //    }
        //}
    }
}
