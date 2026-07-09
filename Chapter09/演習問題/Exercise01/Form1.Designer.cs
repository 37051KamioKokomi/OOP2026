namespace Exercise01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btButton1 = new Button();
            tbOut1 = new TextBox();
            btButton2 = new Button();
            btButton3 = new Button();
            tbOut2 = new TextBox();
            tbOut3 = new TextBox();
            SuspendLayout();
            // 
            // btButton1
            // 
            btButton1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btButton1.Location = new Point(109, 134);
            btButton1.Name = "btButton1";
            btButton1.Size = new Size(167, 48);
            btButton1.TabIndex = 0;
            btButton1.Text = "①";
            btButton1.UseVisualStyleBackColor = true;
            btButton1.Click += button1_Click;
            // 
            // tbOut1
            // 
            tbOut1.Location = new Point(348, 122);
            tbOut1.Name = "tbOut1";
            tbOut1.Size = new Size(364, 23);
            tbOut1.TabIndex = 1;
            // 
            // btButton2
            // 
            btButton2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btButton2.Location = new Point(109, 219);
            btButton2.Name = "btButton2";
            btButton2.Size = new Size(167, 48);
            btButton2.TabIndex = 0;
            btButton2.Text = "②";
            btButton2.UseVisualStyleBackColor = true;
            btButton2.Click += button1_Click;
            // 
            // btButton3
            // 
            btButton3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btButton3.Location = new Point(109, 297);
            btButton3.Name = "btButton3";
            btButton3.Size = new Size(167, 48);
            btButton3.TabIndex = 0;
            btButton3.Text = "③";
            btButton3.UseVisualStyleBackColor = true;
            btButton3.Click += button1_Click;
            // 
            // tbOut2
            // 
            tbOut2.Location = new Point(335, 219);
            tbOut2.Name = "tbOut2";
            tbOut2.Size = new Size(364, 23);
            tbOut2.TabIndex = 1;
            // 
            // tbOut3
            // 
            tbOut3.Location = new Point(335, 316);
            tbOut3.Name = "tbOut3";
            tbOut3.Size = new Size(364, 23);
            tbOut3.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbOut3);
            Controls.Add(tbOut2);
            Controls.Add(tbOut1);
            Controls.Add(btButton3);
            Controls.Add(btButton2);
            Controls.Add(btButton1);
            Name = "Form1";
            Text = "問題9.1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btButton1;
        private TextBox tbOut1;
        private Button btButton2;
        private Button btButton3;
        private TextBox tbOut2;
        private TextBox tbOut3;
    }
}
