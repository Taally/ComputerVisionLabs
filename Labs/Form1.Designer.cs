namespace Labs
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
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxProcessed = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonColorSelect = new System.Windows.Forms.Button();
            this.labelColorSelect = new System.Windows.Forms.Label();
            this.pictureBoxSrcColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxDstColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSrcColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDstColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(350, 350);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 0;
            this.pictureBoxOriginal.TabStop = false;
            this.pictureBoxOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOriginal_MouseClick);
            // 
            // pictureBoxProcessed
            // 
            this.pictureBoxProcessed.Location = new System.Drawing.Point(409, 12);
            this.pictureBoxProcessed.Name = "pictureBoxProcessed";
            this.pictureBoxProcessed.Size = new System.Drawing.Size(350, 350);
            this.pictureBoxProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProcessed.TabIndex = 1;
            this.pictureBoxProcessed.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(368, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "→";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 367);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 31);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Коррекция с опорным цветом",
            "Серый мир",
            "По виду функции преобразования"});
            this.comboBox1.Location = new System.Drawing.Point(106, 374);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(287, 369);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 29);
            this.buttonExecute.TabIndex = 6;
            this.buttonExecute.Text = "Выполнить";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonColorSelect
            // 
            this.buttonColorSelect.Location = new System.Drawing.Point(106, 430);
            this.buttonColorSelect.Name = "buttonColorSelect";
            this.buttonColorSelect.Size = new System.Drawing.Size(211, 23);
            this.buttonColorSelect.TabIndex = 7;
            this.buttonColorSelect.Text = "Выберите целевой цвет";
            this.buttonColorSelect.UseVisualStyleBackColor = true;
            this.buttonColorSelect.Click += new System.EventHandler(this.buttonColorSelect_Click);
            // 
            // labelColorSelect
            // 
            this.labelColorSelect.AutoSize = true;
            this.labelColorSelect.Location = new System.Drawing.Point(103, 414);
            this.labelColorSelect.Name = "labelColorSelect";
            this.labelColorSelect.Size = new System.Drawing.Size(214, 13);
            this.labelColorSelect.TabIndex = 8;
            this.labelColorSelect.Text = "Выберите мышкой цвет на изображении";
            // 
            // pictureBoxSrcColor
            // 
            this.pictureBoxSrcColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxSrcColor.Location = new System.Drawing.Point(320, 404);
            this.pictureBoxSrcColor.Name = "pictureBoxSrcColor";
            this.pictureBoxSrcColor.Size = new System.Drawing.Size(22, 23);
            this.pictureBoxSrcColor.TabIndex = 9;
            this.pictureBoxSrcColor.TabStop = false;
            // 
            // pictureBoxDstColor
            // 
            this.pictureBoxDstColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDstColor.Location = new System.Drawing.Point(320, 430);
            this.pictureBoxDstColor.Name = "pictureBoxDstColor";
            this.pictureBoxDstColor.Size = new System.Drawing.Size(22, 23);
            this.pictureBoxDstColor.TabIndex = 10;
            this.pictureBoxDstColor.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 527);
            this.Controls.Add(this.pictureBoxDstColor);
            this.Controls.Add(this.pictureBoxSrcColor);
            this.Controls.Add(this.labelColorSelect);
            this.Controls.Add(this.buttonColorSelect);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxProcessed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSrcColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDstColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxProcessed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonColorSelect;
        private System.Windows.Forms.Label labelColorSelect;
        private System.Windows.Forms.PictureBox pictureBoxSrcColor;
        private System.Windows.Forms.PictureBox pictureBoxDstColor;
    }
}

