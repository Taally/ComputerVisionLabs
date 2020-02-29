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
            //var imagePath = System.IO.Path.Combine(path.ToString(), "test.png");
            originalImage = new Bitmap(Bitmap.FromFile(imagePath));
            pictureBoxOrig.Image = originalImage;
        }
        
        private void buttonB1_Click(object sender, EventArgs e)
        {
            pictureBoxResult.Image = DataHandler.Test(originalImage);
        }

        private void buttonB2_Click(object sender, EventArgs e)
        {
            pictureBoxResult.Image = DataHandler.Test1(originalImage);
        }
    }
}
