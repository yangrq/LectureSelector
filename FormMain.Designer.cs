namespace LectureSelector
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelHigh = new System.Windows.Forms.Label();
            this.labelLow = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMaxiumum = new System.Windows.Forms.Button();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.buttonRun = new System.Windows.Forms.Button();
            this.timerFade = new System.Windows.Forms.Timer(this.components);
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHigh
            // 
            this.labelHigh.AutoSize = true;
            this.labelHigh.Font = new System.Drawing.Font("微软雅黑", 42F);
            this.labelHigh.ForeColor = System.Drawing.Color.Transparent;
            this.labelHigh.Location = new System.Drawing.Point(269, 162);
            this.labelHigh.Name = "labelHigh";
            this.labelHigh.Size = new System.Drawing.Size(65, 75);
            this.labelHigh.TabIndex = 0;
            this.labelHigh.Text = "0";
            this.labelHigh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLow
            // 
            this.labelLow.AutoSize = true;
            this.labelLow.Font = new System.Drawing.Font("微软雅黑", 42F);
            this.labelLow.ForeColor = System.Drawing.Color.Transparent;
            this.labelLow.Location = new System.Drawing.Point(340, 162);
            this.labelLow.Name = "labelLow";
            this.labelLow.Size = new System.Drawing.Size(65, 75);
            this.labelLow.TabIndex = 1;
            this.labelLow.Text = "0";
            this.labelLow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.AutoSize = true;
            this.buttonClose.BackColor = System.Drawing.Color.Tomato;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClose.ForeColor = System.Drawing.Color.Transparent;
            this.buttonClose.Location = new System.Drawing.Point(635, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 29);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMaxiumum
            // 
            this.buttonMaxiumum.AutoSize = true;
            this.buttonMaxiumum.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonMaxiumum.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.buttonMaxiumum.FlatAppearance.BorderSize = 0;
            this.buttonMaxiumum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.buttonMaxiumum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonMaxiumum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaxiumum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMaxiumum.ForeColor = System.Drawing.Color.Transparent;
            this.buttonMaxiumum.Location = new System.Drawing.Point(605, 0);
            this.buttonMaxiumum.Name = "buttonMaxiumum";
            this.buttonMaxiumum.Size = new System.Drawing.Size(30, 29);
            this.buttonMaxiumum.TabIndex = 3;
            this.buttonMaxiumum.Text = "▢";
            this.buttonMaxiumum.UseVisualStyleBackColor = false;
            this.buttonMaxiumum.Click += new System.EventHandler(this.buttonMaxiumum_Click);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 10;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // buttonRun
            // 
            this.buttonRun.BackColor = System.Drawing.Color.Yellow;
            this.buttonRun.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.buttonRun.FlatAppearance.BorderSize = 0;
            this.buttonRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.buttonRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.buttonRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRun.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.ForeColor = System.Drawing.Color.Silver;
            this.buttonRun.Location = new System.Drawing.Point(263, 366);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(150, 30);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "开始";
            this.buttonRun.UseVisualStyleBackColor = false;
            this.buttonRun.Visible = false;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // timerFade
            // 
            this.timerFade.Interval = 1000;
            this.timerFade.Tick += new System.EventHandler(this.timerFade_Tick);
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.BackColor = System.Drawing.Color.White;
            this.richTextBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxMain.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxMain.Location = new System.Drawing.Point(507, 366);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.ReadOnly = true;
            this.richTextBoxMain.ShowSelectionMargin = true;
            this.richTextBoxMain.Size = new System.Drawing.Size(128, 30);
            this.richTextBoxMain.TabIndex = 5;
            this.richTextBoxMain.Text = "测试文本";
            this.richTextBoxMain.Visible = false;
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.numericUpDownFontSize.Location = new System.Drawing.Point(303, 313);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(70, 27);
            this.numericUpDownFontSize.TabIndex = 6;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownFontSize.Visible = false;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.AutoSize = true;
            this.checkBoxDebug.Location = new System.Drawing.Point(3, 392);
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDebug.TabIndex = 7;
            this.checkBoxDebug.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelTime.ForeColor = System.Drawing.Color.Transparent;
            this.labelTime.Location = new System.Drawing.Point(308, 8);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(61, 25);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "00:00";
            this.labelTime.Visible = false;
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPassword.Location = new System.Drawing.Point(263, 371);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(150, 23);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(664, 408);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.checkBoxDebug);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.richTextBoxMain);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonMaxiumum);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelLow);
            this.Controls.Add(this.labelHigh);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "LectureSelector";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.Label labelHigh;
        private System.Windows.Forms.Label labelLow;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMaxiumum;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Timer timerFade;
        private System.Windows.Forms.RichTextBox richTextBoxMain;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}

