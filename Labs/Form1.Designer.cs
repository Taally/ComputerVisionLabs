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
            this.panelRefColor = new System.Windows.Forms.Panel();
            this.panelFunctions = new System.Windows.Forms.Panel();
            this.labelGamma = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarGamma = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFunction = new System.Windows.Forms.ComboBox();
            this.panelQuant = new System.Windows.Forms.Panel();
            this.labelLevels = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarLevels = new System.Windows.Forms.TrackBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelBinarization = new System.Windows.Forms.Panel();
            this.comboBoxBinarization = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSrcColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDstColor)).BeginInit();
            this.panelRefColor.SuspendLayout();
            this.panelFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).BeginInit();
            this.panelQuant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLevels)).BeginInit();
            this.panelBinarization.SuspendLayout();
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
            "По виду функции преобразования",
            "Нормализация гистограммы",
            "Эквализация гистограммы",
            "Полутона",
            "Бинаризация",
            "Квантование по яркости"});
            this.comboBox1.Location = new System.Drawing.Point(106, 374);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(214, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(326, 371);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 29);
            this.buttonExecute.TabIndex = 6;
            this.buttonExecute.Text = "Выполнить";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonColorSelect
            // 
            this.buttonColorSelect.Location = new System.Drawing.Point(3, 28);
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
            this.labelColorSelect.Location = new System.Drawing.Point(0, 12);
            this.labelColorSelect.Name = "labelColorSelect";
            this.labelColorSelect.Size = new System.Drawing.Size(214, 13);
            this.labelColorSelect.TabIndex = 8;
            this.labelColorSelect.Text = "Выберите мышкой цвет на изображении";
            // 
            // pictureBoxSrcColor
            // 
            this.pictureBoxSrcColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxSrcColor.Location = new System.Drawing.Point(217, 2);
            this.pictureBoxSrcColor.Name = "pictureBoxSrcColor";
            this.pictureBoxSrcColor.Size = new System.Drawing.Size(22, 23);
            this.pictureBoxSrcColor.TabIndex = 9;
            this.pictureBoxSrcColor.TabStop = false;
            // 
            // pictureBoxDstColor
            // 
            this.pictureBoxDstColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDstColor.Location = new System.Drawing.Point(217, 28);
            this.pictureBoxDstColor.Name = "pictureBoxDstColor";
            this.pictureBoxDstColor.Size = new System.Drawing.Size(22, 23);
            this.pictureBoxDstColor.TabIndex = 10;
            this.pictureBoxDstColor.TabStop = false;
            // 
            // panelRefColor
            // 
            this.panelRefColor.Controls.Add(this.labelColorSelect);
            this.panelRefColor.Controls.Add(this.pictureBoxDstColor);
            this.panelRefColor.Controls.Add(this.buttonColorSelect);
            this.panelRefColor.Controls.Add(this.pictureBoxSrcColor);
            this.panelRefColor.Location = new System.Drawing.Point(106, 404);
            this.panelRefColor.Name = "panelRefColor";
            this.panelRefColor.Size = new System.Drawing.Size(249, 60);
            this.panelRefColor.TabIndex = 11;
            // 
            // panelFunctions
            // 
            this.panelFunctions.Controls.Add(this.labelGamma);
            this.panelFunctions.Controls.Add(this.label6);
            this.panelFunctions.Controls.Add(this.label4);
            this.panelFunctions.Controls.Add(this.label3);
            this.panelFunctions.Controls.Add(this.trackBarGamma);
            this.panelFunctions.Controls.Add(this.label2);
            this.panelFunctions.Controls.Add(this.comboBoxFunction);
            this.panelFunctions.Location = new System.Drawing.Point(83, 401);
            this.panelFunctions.Name = "panelFunctions";
            this.panelFunctions.Size = new System.Drawing.Size(306, 111);
            this.panelFunctions.TabIndex = 12;
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(24, 70);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(0, 13);
            this.labelGamma.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "1";
            // 
            // trackBarGamma
            // 
            this.trackBarGamma.LargeChange = 100;
            this.trackBarGamma.Location = new System.Drawing.Point(163, 27);
            this.trackBarGamma.Maximum = 200;
            this.trackBarGamma.Name = "trackBarGamma";
            this.trackBarGamma.Size = new System.Drawing.Size(134, 45);
            this.trackBarGamma.SmallChange = 10;
            this.trackBarGamma.TabIndex = 2;
            this.trackBarGamma.Value = 100;
            this.trackBarGamma.Scroll += new System.EventHandler(this.trackBarGamma_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Функция для преобразования";
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Items.AddRange(new object[] {
            "Линейная",
            "Степенная"});
            this.comboBoxFunction.Location = new System.Drawing.Point(24, 32);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFunction.TabIndex = 0;
            this.comboBoxFunction.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunction_SelectedIndexChanged);
            // 
            // panelQuant
            // 
            this.panelQuant.Controls.Add(this.labelLevels);
            this.panelQuant.Controls.Add(this.label5);
            this.panelQuant.Controls.Add(this.trackBarLevels);
            this.panelQuant.Location = new System.Drawing.Point(104, 401);
            this.panelQuant.Name = "panelQuant";
            this.panelQuant.Size = new System.Drawing.Size(282, 108);
            this.panelQuant.TabIndex = 1;
            // 
            // labelLevels
            // 
            this.labelLevels.AutoSize = true;
            this.labelLevels.Location = new System.Drawing.Point(113, 6);
            this.labelLevels.Name = "labelLevels";
            this.labelLevels.Size = new System.Drawing.Size(25, 13);
            this.labelLevels.TabIndex = 2;
            this.labelLevels.Text = "255";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Количество уровней:";
            // 
            // trackBarLevels
            // 
            this.trackBarLevels.Location = new System.Drawing.Point(4, 26);
            this.trackBarLevels.Maximum = 255;
            this.trackBarLevels.Minimum = 1;
            this.trackBarLevels.Name = "trackBarLevels";
            this.trackBarLevels.Size = new System.Drawing.Size(193, 45);
            this.trackBarLevels.TabIndex = 0;
            this.trackBarLevels.Value = 255;
            this.trackBarLevels.Scroll += new System.EventHandler(this.trackBarLevels_Scroll);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(684, 368);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelBinarization
            // 
            this.panelBinarization.Controls.Add(this.comboBoxBinarization);
            this.panelBinarization.Location = new System.Drawing.Point(409, 371);
            this.panelBinarization.Name = "panelBinarization";
            this.panelBinarization.Size = new System.Drawing.Size(269, 141);
            this.panelBinarization.TabIndex = 14;
            // 
            // comboBoxBinarization
            // 
            this.comboBoxBinarization.AutoCompleteCustomSource.AddRange(new string[] {
            "Ручной выбор порога",
            "Глобальная",
            "Локальная",
            "Иерархическая"});
            this.comboBoxBinarization.FormattingEnabled = true;
            this.comboBoxBinarization.Items.AddRange(new object[] {
            "Выбор порога",
            "Метод Оцу (глобальная)",
            "Метод Оцу (локальная)",
            "Метод Оцу (иерархическая)"});
            this.comboBoxBinarization.Location = new System.Drawing.Point(4, 4);
            this.comboBoxBinarization.Name = "comboBoxBinarization";
            this.comboBoxBinarization.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBinarization.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 527);
            this.Controls.Add(this.panelQuant);
            this.Controls.Add(this.panelBinarization);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelFunctions);
            this.Controls.Add(this.panelRefColor);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxProcessed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Name = "Form1";
            this.Text = "Яркостные преобразования";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSrcColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDstColor)).EndInit();
            this.panelRefColor.ResumeLayout(false);
            this.panelRefColor.PerformLayout();
            this.panelFunctions.ResumeLayout(false);
            this.panelFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).EndInit();
            this.panelQuant.ResumeLayout(false);
            this.panelQuant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLevels)).EndInit();
            this.panelBinarization.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelRefColor;
        private System.Windows.Forms.Panel panelFunctions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFunction;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TrackBar trackBarGamma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Panel panelBinarization;
        private System.Windows.Forms.ComboBox comboBoxBinarization;
        private System.Windows.Forms.Panel panelQuant;
        private System.Windows.Forms.Label labelLevels;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarLevels;
    }
}

