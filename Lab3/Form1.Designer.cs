namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxOrig = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.buttonB1 = new System.Windows.Forms.Button();
            this.buttonB2 = new System.Windows.Forms.Button();
            this.buttonRes = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonB3 = new System.Windows.Forms.Button();
            this.buttonB7 = new System.Windows.Forms.Button();
            this.buttonB8 = new System.Windows.Forms.Button();
            this.buttonB9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOrig
            // 
            this.pictureBoxOrig.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxOrig.Name = "pictureBoxOrig";
            this.pictureBoxOrig.Size = new System.Drawing.Size(380, 290);
            this.pictureBoxOrig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOrig.TabIndex = 0;
            this.pictureBoxOrig.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Location = new System.Drawing.Point(408, 12);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(380, 290);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 1;
            this.pictureBoxResult.TabStop = false;
            // 
            // buttonB1
            // 
            this.buttonB1.Location = new System.Drawing.Point(12, 321);
            this.buttonB1.Name = "buttonB1";
            this.buttonB1.Size = new System.Drawing.Size(75, 35);
            this.buttonB1.TabIndex = 2;
            this.buttonB1.Text = "hole_ring (B1)";
            this.buttonB1.UseVisualStyleBackColor = true;
            this.buttonB1.Click += new System.EventHandler(this.buttonB1_Click);
            // 
            // buttonB2
            // 
            this.buttonB2.Location = new System.Drawing.Point(93, 321);
            this.buttonB2.Name = "buttonB2";
            this.buttonB2.Size = new System.Drawing.Size(75, 35);
            this.buttonB2.TabIndex = 3;
            this.buttonB2.Text = "hole_mask (B2)";
            this.buttonB2.UseVisualStyleBackColor = true;
            this.buttonB2.Click += new System.EventHandler(this.buttonB2_Click);
            // 
            // buttonRes
            // 
            this.buttonRes.Location = new System.Drawing.Point(364, 308);
            this.buttonRes.Name = "buttonRes";
            this.buttonRes.Size = new System.Drawing.Size(75, 35);
            this.buttonRes.TabIndex = 4;
            this.buttonRes.Text = "Result";
            this.buttonRes.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonB3
            // 
            this.buttonB3.Location = new System.Drawing.Point(174, 321);
            this.buttonB3.Name = "buttonB3";
            this.buttonB3.Size = new System.Drawing.Size(75, 35);
            this.buttonB3.TabIndex = 5;
            this.buttonB3.Text = "B or B2 (B3)";
            this.buttonB3.UseVisualStyleBackColor = true;
            // 
            // buttonB7
            // 
            this.buttonB7.Location = new System.Drawing.Point(12, 377);
            this.buttonB7.Name = "buttonB7";
            this.buttonB7.Size = new System.Drawing.Size(75, 35);
            this.buttonB7.TabIndex = 6;
            this.buttonB7.Text = "B7";
            this.buttonB7.UseVisualStyleBackColor = true;
            // 
            // buttonB8
            // 
            this.buttonB8.Location = new System.Drawing.Point(93, 377);
            this.buttonB8.Name = "buttonB8";
            this.buttonB8.Size = new System.Drawing.Size(75, 35);
            this.buttonB8.TabIndex = 7;
            this.buttonB8.Text = "B8";
            this.buttonB8.UseVisualStyleBackColor = true;
            // 
            // buttonB9
            // 
            this.buttonB9.Location = new System.Drawing.Point(174, 377);
            this.buttonB9.Name = "buttonB9";
            this.buttonB9.Size = new System.Drawing.Size(75, 35);
            this.buttonB9.TabIndex = 8;
            this.buttonB9.Text = "B9";
            this.buttonB9.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.buttonB9);
            this.Controls.Add(this.buttonB8);
            this.Controls.Add(this.buttonB7);
            this.Controls.Add(this.buttonB3);
            this.Controls.Add(this.buttonRes);
            this.Controls.Add(this.buttonB2);
            this.Controls.Add(this.buttonB1);
            this.Controls.Add(this.pictureBoxResult);
            this.Controls.Add(this.pictureBoxOrig);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOrig;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button buttonB1;
        private System.Windows.Forms.Button buttonB2;
        private System.Windows.Forms.Button buttonRes;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonB3;
        private System.Windows.Forms.Button buttonB7;
        private System.Windows.Forms.Button buttonB8;
        private System.Windows.Forms.Button buttonB9;
    }
}

