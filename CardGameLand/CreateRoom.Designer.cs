namespace CardGameLand
{
    partial class CreateRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttoncreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonprivate = new System.Windows.Forms.RadioButton();
            this.radioButtonpublic = new System.Windows.Forms.RadioButton();
            this.comboBoxGameID = new System.Windows.Forms.ComboBox();
            this.comboBoxPersons = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(119, 84);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 21);
            this.textBoxPassword.TabIndex = 10;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(119, 39);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 21);
            this.textBoxTitle.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "방 만들기";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttoncreate
            // 
            this.buttoncreate.Location = new System.Drawing.Point(252, 125);
            this.buttoncreate.Name = "buttoncreate";
            this.buttoncreate.Size = new System.Drawing.Size(159, 63);
            this.buttoncreate.TabIndex = 9;
            this.buttoncreate.Text = "방 만들기";
            this.buttoncreate.UseVisualStyleBackColor = true;
            this.buttoncreate.Click += new System.EventHandler(this.buttoncreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "인원 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "방 비밀번호 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "방 제목 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "게임선택 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonprivate);
            this.groupBox1.Controls.Add(this.radioButtonpublic);
            this.groupBox1.Location = new System.Drawing.Point(252, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "공개 여부";
            // 
            // radioButtonprivate
            // 
            this.radioButtonprivate.AutoSize = true;
            this.radioButtonprivate.Location = new System.Drawing.Point(81, 30);
            this.radioButtonprivate.Name = "radioButtonprivate";
            this.radioButtonprivate.Size = new System.Drawing.Size(59, 16);
            this.radioButtonprivate.TabIndex = 0;
            this.radioButtonprivate.Text = "비공개";
            this.radioButtonprivate.UseVisualStyleBackColor = true;
            this.radioButtonprivate.CheckedChanged += new System.EventHandler(this.radioButtonprivate_CheckedChanged);
            // 
            // radioButtonpublic
            // 
            this.radioButtonpublic.AutoSize = true;
            this.radioButtonpublic.Checked = true;
            this.radioButtonpublic.Location = new System.Drawing.Point(7, 30);
            this.radioButtonpublic.Name = "radioButtonpublic";
            this.radioButtonpublic.Size = new System.Drawing.Size(47, 16);
            this.radioButtonpublic.TabIndex = 0;
            this.radioButtonpublic.TabStop = true;
            this.radioButtonpublic.Text = "공개";
            this.radioButtonpublic.UseVisualStyleBackColor = true;
            this.radioButtonpublic.CheckedChanged += new System.EventHandler(this.radioButtonpublic_CheckedChanged);
            // 
            // comboBoxGameID
            // 
            this.comboBoxGameID.FormattingEnabled = true;
            this.comboBoxGameID.Items.AddRange(new object[] {
            "원카드"});
            this.comboBoxGameID.Location = new System.Drawing.Point(119, 125);
            this.comboBoxGameID.Name = "comboBoxGameID";
            this.comboBoxGameID.Size = new System.Drawing.Size(100, 20);
            this.comboBoxGameID.TabIndex = 13;
            this.comboBoxGameID.SelectedIndexChanged += new System.EventHandler(this.GamecomboBox_SelectedIndexChanged);
            // 
            // comboBoxPersons
            // 
            this.comboBoxPersons.FormattingEnabled = true;
            this.comboBoxPersons.Location = new System.Drawing.Point(119, 168);
            this.comboBoxPersons.Name = "comboBoxPersons";
            this.comboBoxPersons.Size = new System.Drawing.Size(100, 20);
            this.comboBoxPersons.TabIndex = 14;
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 227);
            this.Controls.Add(this.comboBoxPersons);
            this.Controls.Add(this.comboBoxGameID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttoncreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateRoom_FormClosing);
            this.Load += new System.EventHandler(this.CreateRoom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttoncreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonprivate;
        private System.Windows.Forms.RadioButton radioButtonpublic;
        private System.Windows.Forms.ComboBox comboBoxGameID;
        private System.Windows.Forms.ComboBox comboBoxPersons;
    }
}