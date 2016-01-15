namespace ilbeDetector
{
    partial class frmilbeDetector
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmilbeDetector));
            this.originalText = new System.Windows.Forms.RichTextBox();
            this.ilbeWords = new System.Windows.Forms.RichTextBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIlbeWordCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // originalText
            // 
            this.originalText.Location = new System.Drawing.Point(12, 12);
            this.originalText.Name = "originalText";
            this.originalText.Size = new System.Drawing.Size(515, 580);
            this.originalText.TabIndex = 0;
            this.originalText.Text = resources.GetString("originalText.Text");
            // 
            // ilbeWords
            // 
            this.ilbeWords.Location = new System.Drawing.Point(535, 30);
            this.ilbeWords.Name = "ilbeWords";
            this.ilbeWords.Size = new System.Drawing.Size(219, 283);
            this.ilbeWords.TabIndex = 1;
            this.ilbeWords.Text = "고무통\n고무현\n해상방위대\n해상방위대 2중대\n선비\n땅크\n^오^\n감성팔이\n갈베\n간철수\n간민정음\n같은 실수를 반복한다\n개쌍도\n게이\n강간충\n패륜충\n감자도" +
    "\n노무노무\n노부엉\n노시계\n노알라";
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(760, 30);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(97, 31);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "일베 사전 등록";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(535, 345);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(219, 244);
            this.listBox1.TabIndex = 4;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "찾아보기";
            // 
            // lblIlbeWordCount
            // 
            this.lblIlbeWordCount.Location = new System.Drawing.Point(535, 592);
            this.lblIlbeWordCount.Name = "lblIlbeWordCount";
            this.lblIlbeWordCount.Size = new System.Drawing.Size(219, 25);
            this.lblIlbeWordCount.TabIndex = 7;
            this.lblIlbeWordCount.Text = "0";
            this.lblIlbeWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmilbeDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 656);
            this.Controls.Add(this.lblIlbeWordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.ilbeWords);
            this.Controls.Add(this.originalText);
            this.Name = "frmilbeDetector";
            this.Text = "일베 탐지기";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox originalText;
        private System.Windows.Forms.RichTextBox ilbeWords;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIlbeWordCount;
    }
}

