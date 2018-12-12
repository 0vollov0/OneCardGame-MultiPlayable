namespace CardGameLand
{
    partial class OneCard
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
            this.textBoxChattingList = new System.Windows.Forms.TextBox();
            this.textBoxChatting = new System.Windows.Forms.TextBox();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentPersonCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaxPersonCount = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPlayerTurn = new System.Windows.Forms.Label();
            this.buttonOneCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxChattingList
            // 
            this.textBoxChattingList.Location = new System.Drawing.Point(517, 68);
            this.textBoxChattingList.Multiline = true;
            this.textBoxChattingList.Name = "textBoxChattingList";
            this.textBoxChattingList.ReadOnly = true;
            this.textBoxChattingList.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxChattingList.Size = new System.Drawing.Size(271, 247);
            this.textBoxChattingList.TabIndex = 0;
            // 
            // textBoxChatting
            // 
            this.textBoxChatting.Location = new System.Drawing.Point(517, 321);
            this.textBoxChatting.Name = "textBoxChatting";
            this.textBoxChatting.Size = new System.Drawing.Size(205, 21);
            this.textBoxChatting.TabIndex = 1;
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Location = new System.Drawing.Point(729, 321);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(59, 21);
            this.buttonTransfer.TabIndex = 2;
            this.buttonTransfer.Text = "전송";
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕코딩", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "방제목:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕코딩", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(572, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "인원:";
            // 
            // labelCurrentPersonCount
            // 
            this.labelCurrentPersonCount.AutoSize = true;
            this.labelCurrentPersonCount.Font = new System.Drawing.Font("나눔고딕코딩", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCurrentPersonCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCurrentPersonCount.Location = new System.Drawing.Point(683, 13);
            this.labelCurrentPersonCount.Name = "labelCurrentPersonCount";
            this.labelCurrentPersonCount.Size = new System.Drawing.Size(33, 35);
            this.labelCurrentPersonCount.TabIndex = 4;
            this.labelCurrentPersonCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕코딩", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(709, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 35);
            this.label4.TabIndex = 4;
            this.label4.Text = "/";
            // 
            // labelMaxPersonCount
            // 
            this.labelMaxPersonCount.AutoSize = true;
            this.labelMaxPersonCount.Font = new System.Drawing.Font("나눔고딕코딩", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMaxPersonCount.Location = new System.Drawing.Point(737, 13);
            this.labelMaxPersonCount.Name = "labelMaxPersonCount";
            this.labelMaxPersonCount.Size = new System.Drawing.Size(33, 35);
            this.labelMaxPersonCount.TabIndex = 4;
            this.labelMaxPersonCount.Text = "0";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("나눔고딕코딩", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelTitle.Location = new System.Drawing.Point(151, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(87, 35);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "내용";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(661, 349);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(127, 61);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "시작";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕코딩", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(663, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "차례:";
            // 
            // labelPlayerTurn
            // 
            this.labelPlayerTurn.AutoSize = true;
            this.labelPlayerTurn.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPlayerTurn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelPlayerTurn.Location = new System.Drawing.Point(725, 422);
            this.labelPlayerTurn.Name = "labelPlayerTurn";
            this.labelPlayerTurn.Size = new System.Drawing.Size(64, 16);
            this.labelPlayerTurn.TabIndex = 5;
            this.labelPlayerTurn.Text = "UNKNOWN";
            // 
            // buttonOneCard
            // 
            this.buttonOneCard.Enabled = false;
            this.buttonOneCard.Location = new System.Drawing.Point(599, 349);
            this.buttonOneCard.Name = "buttonOneCard";
            this.buttonOneCard.Size = new System.Drawing.Size(56, 23);
            this.buttonOneCard.TabIndex = 7;
            this.buttonOneCard.Text = "원카드!";
            this.buttonOneCard.UseVisualStyleBackColor = true;
            this.buttonOneCard.Click += new System.EventHandler(this.buttonOneCard_Click);
            // 
            // OneCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 561);
            this.Controls.Add(this.buttonOneCard);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelPlayerTurn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelMaxPersonCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCurrentPersonCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.textBoxChatting);
            this.Controls.Add(this.textBoxChattingList);
            this.Name = "OneCard";
            this.Text = "OneCard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OneCard_FormClosing);
            this.Load += new System.EventHandler(this.OneCard_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OneCard_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OneCard_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxChattingList;
        private System.Windows.Forms.TextBox textBoxChatting;
        private System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentPersonCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMaxPersonCount;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPlayerTurn;
        private System.Windows.Forms.Button buttonOneCard;
    }
}