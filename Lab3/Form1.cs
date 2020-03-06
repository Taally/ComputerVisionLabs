using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        Bitmap originalImage = null;
        Bitmap processedImage = null;

        public Form1()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            var path = System.Environment.CurrentDirectory;
            path = System.IO.Directory.GetParent(path).FullName;
            path = System.IO.Directory.GetParent(path).FullName;

            var imagePath = System.IO.Path.Combine(path.ToString(), "Шестеренки.png");
            //var imagePath = System.IO.Path.Combine(path.ToString(), "hole_ring1.png");
            originalImage = new Bitmap(Bitmap.FromFile(imagePath));
            pictureBoxOrig.Image = originalImage;
        }
        
        private void buttonB1_Click(object sender, EventArgs e)
        {
            var arr = DataHandler.Step1(DataHandler.GetArray(originalImage));
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);
        }

        private void buttonB2_Click(object sender, EventArgs e)
        {

            var arr = DataHandler.Step1(DataHandler.GetArray(originalImage));
            arr = DataHandler.Step2(arr);
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);
        }

        private void buttonB7_Click(object sender, EventArgs e)
        {
            var arr = DataHandler.Step4(DataHandler.GetArray(originalImage));
            arr = DataHandler.Step5(arr);
            arr = DataHandler.Step6(arr);
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);
        }

        private void buttonB3_Click(object sender, EventArgs e)
        {
            var arr = DataHandler.Step1(DataHandler.GetArray(originalImage));
            arr = DataHandler.Step2(arr);
            arr = DataHandler.Step3(DataHandler.GetArray(originalImage), arr);
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);

        }

        private void buttonB8_Click(object sender, EventArgs e)
        {
            var arr = DataHandler.Step1(DataHandler.GetArray(originalImage));
            arr = DataHandler.Step2(arr);
            arr = DataHandler.Step3(DataHandler.GetArray(originalImage), arr);
            arr = DataHandler.Step4(arr);
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);
        }

        private void buttonB9_Click(object sender, EventArgs e)
        {
            var arr = DataHandler.Step1(DataHandler.GetArray(originalImage));
            arr = DataHandler.Step2(arr);
            arr = DataHandler.Step3(DataHandler.GetArray(originalImage), arr);
            arr = DataHandler.Step4(arr);
            arr = DataHandler.Step5(arr);
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);
        }

        private void buttonRes_Click(object sender, EventArgs e)
        {
            var arr = DataHandler.Step1(DataHandler.GetArray(originalImage));
            arr = DataHandler.Step2(arr);
            arr = DataHandler.Step3(DataHandler.GetArray(originalImage), arr);
            arr = DataHandler.Step4(arr);
            arr = DataHandler.Step5(arr);
            arr = DataHandler.Step6(arr);
            pictureBoxResult.Image = DataHandler.GetBitmap(arr);
        }
    }
}
