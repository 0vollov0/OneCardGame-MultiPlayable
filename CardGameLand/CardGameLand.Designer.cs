namespace CardGameLand
{
    partial class CardGameLand
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelmyIP = new System.Windows.Forms.Label();
            this.buttonjoin = new System.Windows.Forms.Button();
            this.buttoncreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxjoinIP = new System.Windows.Forms.TextBox();
            this.textBoxpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "나의 IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "접속할 IP :";
            // 
            // labelmyIP
            // 
            this.labelmyIP.AutoSize = true;
            this.labelmyIP.Location = new System.Drawing.Point(105, 9);
            this.labelmyIP.Name = "labelmyIP";
            this.labelmyIP.Size = new System.Drawing.Size(41, 12);
            this.labelmyIP.TabIndex = 1;
            this.labelmyIP.Text = "0.0.0.0";
            // 
            // buttonjoin
            // 
            this.buttonjoin.Location = new System.Drawing.Point(242, 76);
            this.buttonjoin.Name = "buttonjoin";
            this.buttonjoin.Size = new System.Drawing.Size(75, 23);
            this.buttonjoin.TabIndex = 2;
            this.buttonjoin.Text = "방 참가";
            this.buttonjoin.UseVisualStyleBackColor = true;
            this.buttonjoin.Click += new System.EventHandler(this.buttonjoin_Click);
            // 
            // buttoncreate
            // 
            this.buttoncreate.Location = new System.Drawing.Point(242, 121);
            this.buttoncreate.Name = "buttoncreate";
            this.buttoncreate.Size = new System.Drawing.Size(75, 23);
            this.buttoncreate.TabIndex = 2;
            this.buttoncreate.Text = "방 만들기";
            this.buttoncreate.UseVisualStyleBackColor = true;
            this.buttoncreate.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "방 비밀번호 :";
            // 
            // textBoxjoinIP
            // 
            this.textBoxjoinIP.Location = new System.Drawing.Point(109, 78);
            this.textBoxjoinIP.Name = "textBoxjoinIP";
            this.textBoxjoinIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxjoinIP.TabIndex = 3;
            // 
            // textBoxpassword
            // 
            this.textBoxpassword.Location = new System.Drawing.Point(109, 123);
            this.textBoxpassword.Name = "textBoxpassword";
            this.textBoxpassword.ReadOnly = true;
            this.textBoxpassword.Size = new System.Drawing.Size(100, 21);
            this.textBoxpassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "나의 닉네임 :";
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.Location = new System.Drawing.Point(109, 38);
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(100, 21);
            this.textBoxNickName.TabIndex = 3;
            // 
            // CardGameLand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 156);
            this.Controls.Add(this.textBoxpassword);
            this.Controls.Add(this.textBoxNickName);
            this.Controls.Add(this.textBoxjoinIP);
            this.Controls.Add(this.buttoncreate);
            this.Controls.Add(this.buttonjoin);
            this.Controls.Add(this.labelmyIP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "CardGameLand";
            this.Text = "CardGameLand";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CardGameLand_FormClosing);
            this.Load += new System.EventHandler(this.CardGameLand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelmyIP;
        private System.Windows.Forms.Button buttonjoin;
        private System.Windows.Forms.Button buttoncreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxjoinIP;
        private System.Windows.Forms.TextBox textBoxpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNickName;
    }
}

