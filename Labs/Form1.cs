using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Labs
{
    enum Type {
        refColor,
        grayWorld,
        byFunction
    }

    public partial class Form1 : Form
    {
        Bitmap originalImage = null;
        Bitmap processedImage = null;
        Type current = Type.grayWorld;
        Color srcColor;
        Color dstColor;


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            setElementsActive(false);
            activateRefColor(false);
        }

        private void setElementsActive(bool active = true)
        {
            buttonExecute.Enabled = active;
            comboBox1.Enabled = active;
        }

        private void activateRefColor(bool active = true)
        {
            if (active)
            {
                this.srcColor = Color.Empty;
                this.dstColor = Color.Empty;
            }
            labelColorSelect.Visible = active;
            buttonColorSelect.Visible = active;
            pictureBoxSrcColor.Visible = active;
            pictureBoxDstColor.Visible = active;

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            var path = System.Environment.CurrentDirectory;
            path = System.IO.Directory.GetParent(path).FullName;
            path = System.IO.Directory.GetParent(path).FullName;
            path = System.IO.Directory.GetParent(path).FullName;

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = path;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                var imagePath = openFile.FileName;
                originalImage = new Bitmap(Bitmap.FromFile(imagePath));
                pictureBoxOriginal.Image = originalImage;
                setElementsActive();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    this.current = Type.refColor;
                    activateRefColor();
                    checkColors();
                    break;
                case 1:
                    this.current = Type.grayWorld;
                    activateRefColor(false);
                    break;
                case 2:
                    this.current = Type.byFunction;
                    activateRefColor(false);
                    break;
                default:
                    this.current = Type.grayWorld;
                    activateRefColor(false);
                    break;
            }

        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            switch (this.current)
            {
                case Type.grayWorld:
                    this.processedImage = DataHandler.grayWorld(this.originalImage);
                    break;
                case Type.refColor:
                    this.processedImage = DataHandler.refColor(this.originalImage, this.srcColor, this.dstColor);
                    break;
                case Type.byFunction:
                    this.processedImage = DataHandler.byFunction(this.originalImage);
                    break;
            }
            pictureBoxProcessed.Image = this.processedImage;
        }

        private void setColorToPictureBox(Color c, PictureBox pb)
        {
            var bmp = new Bitmap(pb.Width, pb.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            SolidBrush brush = new SolidBrush(c);
            gfx.FillRectangle(brush, 0, 0, bmp.Width, bmp.Height);
            pb.Image = bmp;
        }

        private void checkColors()
        {
            if (!this.srcColor.IsEmpty && !this.dstColor.IsEmpty)
            {
                buttonExecute.Enabled = true;
            } else
            {
                buttonExecute.Enabled = false;
            }
        }

        private void pictureBoxOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBoxSrcColor.Visible)
            {
                Bitmap bmp = new Bitmap(pictureBoxOriginal.ClientSize.Width, pictureBoxOriginal.ClientSize.Height);
                pictureBoxOriginal.DrawToBitmap(bmp, pictureBoxOriginal.ClientRectangle);
                this.srcColor = bmp.GetPixel(e.X, e.Y);
                setColorToPictureBox(this.srcColor, pictureBoxSrcColor);
                checkColors();
            }
        }

        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.White;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.dstColor = colorDialog1.Color;
                setColorToPictureBox(this.dstColor, pictureBoxDstColor);
                checkColors();
            }
        }
    }
}
