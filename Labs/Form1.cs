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
        byFunction,
        histNorm,
        histEq,
        grayScale,
        binarization,
        quantization
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
            comboBoxFunction.SelectedIndex = 0;
            comboBoxBinarization.SelectedIndex = 0;
            setElementsActive(false);
            activateRefColor(false);
            activateByFunction(false);
            panelBinHier.Visible = false;
            labelBin2.Visible = false;
            trackBarBin2.Visible = false;
        }

        private void setElementsActive(bool active = true)
        {
            buttonExecute.Enabled = active;
            comboBox1.Enabled = active;
        }

        private void deactivateAll()
        {
            activateRefColor(false);
            activateByFunction(false);
            activateGreyWorld(false);
            activateHistNorm(false);
            activateHistEq(false);
            activateGrayscale(false);
            activateBinarization(false);
            activateQuantization(false);
        }

        private void activateRefColor(bool active = true)
        {            
            if (active)
            {
                deactivateAll();                
                this.srcColor = Color.Empty;
                this.dstColor = Color.Empty;
                this.current = Type.refColor;
            }
            panelRefColor.Visible = active;
        }

        private void activateGreyWorld(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.grayWorld;
            }
        }
        
        private void activateByFunction(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.byFunction;
                //comboBoxBinarization.SelectedIndex = 0;
            }
            panelFunctions.Visible = active;
        }

        private void activateHistNorm(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.histNorm;
            }
        }

        private void activateHistEq(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.histEq;
            }
        }

        private void activateGrayscale(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.grayScale;
            }
        }

        private void activateBinarization(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.binarization;
            }
            panelBinarization.Visible = active;
        }

        private void activateQuantization(bool active = true)
        {
            if (active)
            {
                deactivateAll();
                this.current = Type.quantization;
            }
            panelQuant.Visible = active;
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
                    activateRefColor();
                    checkColors();
                    break;
                case 1:
                    activateGreyWorld();
                    break;
                case 2:
                    activateByFunction();
                    break;
                case 3:
                    activateHistNorm();
                    break;
                case 4:
                    activateHistEq();
                    break;
                case 5:
                    activateGrayscale();
                    break;
                case 6:
                    activateBinarization();
                    break;
                case 7:
                    activateQuantization();
                    break;

                default:
                    activateGreyWorld();
                    break;
            }

        }

        // --- Execute button ---//
        private void buttonExecute_Click(object sender, EventArgs e)
        {
            pictureBoxProcessed.Image = null;
            switch (this.current)
            {
                case Type.grayWorld:
                    this.processedImage = DataHandler.grayWorld(this.originalImage);
                    break;
                case Type.refColor:
                    this.processedImage = DataHandler.refColor(this.originalImage, this.srcColor, this.dstColor);
                    break;
                case Type.byFunction:
                    executeByFunction();
                    break;
                case Type.histNorm:
                    this.processedImage = DataHandler.histNorm(this.originalImage);
                    break;
                case Type.histEq:
                    this.processedImage = DataHandler.histEq(this.originalImage);
                    break;
                case Type.grayScale:
                    this.processedImage = DataHandler.toGrayscale(this.originalImage);
                    break;
                case Type.quantization:
                    this.processedImage = DataHandler.quantization(this.originalImage, trackBarLevels.Value);
                    break;
                case Type.binarization:
                    executeBinarization();
                    break;

            }
            pictureBoxProcessed.Image = this.processedImage;
        }

        // --- Опорный цвет --- //
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
            if (panelRefColor.Visible)
            {
                Bitmap bmp = new Bitmap(pictureBoxOriginal.ClientSize.Width, pictureBoxOriginal.ClientSize.Height);
                pictureBoxOriginal.DrawToBitmap(bmp, pictureBoxOriginal.ClientRectangle);
                this.srcColor = bmp.GetPixel(e.X, e.Y);
                this.dstColor = this.srcColor;
                setColorToPictureBox(this.srcColor, pictureBoxSrcColor);
                setColorToPictureBox(this.dstColor, pictureBoxDstColor);
                checkColors();
            }
        }

        private void buttonColorSelect_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.dstColor.IsEmpty ? Color.White : this.dstColor;
            setColorToPictureBox(this.dstColor, pictureBoxDstColor);
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.dstColor = colorDialog1.Color;
                setColorToPictureBox(this.dstColor, pictureBoxDstColor);
                checkColors();
            }
        }

        // --- Функции преобразования --- //
        private void executeByFunction()
        {
            switch (comboBoxFunction.SelectedIndex)
            {
                case 0:
                    this.processedImage = DataHandler.linearCorrection(this.originalImage);
                    break;
                case 1:
                    this.processedImage = DataHandler.gammaCorrection(this.originalImage, trackBarGamma.Value / 100.0);
                    break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            if (this.processedImage != null)
            {
                saveFileDialog1.Title = "Save";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        this.processedImage.Save(saveFileDialog1.FileName);
                    }
                }
            }
        }

        private void setTrackbarVisibitily(bool visible = true)
        {
            trackBarGamma.Visible = visible;
            label3.Visible = visible;
            label4.Visible = visible;
            label6.Visible = visible;
            labelGamma.Visible = visible;
        }

        private void comboBoxFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFunction.SelectedIndex)
            {
                case 0:
                    setTrackbarVisibitily(false);
                    break;
                case 1:
                    setTrackbarVisibitily(true);
                    break;
                default:
                    setTrackbarVisibitily(false);
                    break;
            }
        }

        private void trackBarGamma_Scroll(object sender, EventArgs e)
        {
            labelGamma.Text = "Gamma = " + trackBarGamma.Value / 100.0;
        }

        // --- Quantization --- //
        private void trackBarLevels_Scroll(object sender, EventArgs e)
        {
            labelLevels.Text = trackBarLevels.Value.ToString();
        }

        // --- Binarization --- //
        private void executeBinarization()
        {
            switch (comboBoxBinarization.SelectedIndex)
            {
                case 0:
                    if (!radioButtonRange.Checked) {
                        this.processedImage = DataHandler.binarizationWithThreshold(this.originalImage, trackBarBin1.Value, radioButtonBinTop.Checked);
                    } else
                    {
                        this.processedImage = DataHandler.binarizationWithRange(this.originalImage, trackBarBin1.Value, trackBarBin2.Value);
                    }
                    break;
                case 1:
                    this.processedImage = DataHandler.OtsuGlobal(this.originalImage);
                    break;
                case 2:
                    this.processedImage = DataHandler.OtsuLocal(this.originalImage);
                    break;
                case 3:
                    this.processedImage = DataHandler.OtsuHierarchy(this.originalImage, (int)numericUpDownFragSize.Value);
                    break;
                default: break;
            }
        }

        private void comboBoxBinarization_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxBinarization.SelectedIndex)
            {
                case 0:
                    panelBin1.Visible = true;
                    panelBinHier.Visible = false;
                    break;
                case 1:
                    panelBin1.Visible = false;
                    panelBinHier.Visible = false;
                    break;
                case 2:
                    panelBin1.Visible = false;
                    panelBinHier.Visible = false;
                    break;
                case 3:
                    panelBin1.Visible = false;
                    panelBinHier.Visible = true;
                    break;
                default:
                    panelBin1.Visible = false;
                    panelBinHier.Visible = false;
                    break;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            labelBin2.Text = "- " + trackBarBin2.Value.ToString();
        }

        private void radioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRange.Checked)
            {
                trackBarBin2.Visible = true;
                labelBin2.Visible = true;
            } else
            {
                trackBarBin2.Visible = false;
                labelBin2.Visible = false;
            }
        }

        private void trackBarBin1_Scroll(object sender, EventArgs e)
        {
            labelBin1.Text = trackBarBin1.Value.ToString();
        }
    }
}
