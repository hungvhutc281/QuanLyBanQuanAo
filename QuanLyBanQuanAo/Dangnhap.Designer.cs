namespace QuanLyBanQuanAo
{
    partial class Dangnhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dangnhap));
            label1 = new Label();
            label2 = new Label();
            txt_tkhoan = new TextBox();
            txt_matkhau = new TextBox();
            btn_dangnhap = new Button();
            pictureBox1 = new PictureBox();
            btn_thoat = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(449, 173);
            label1.Name = "label1";
            label1.Size = new Size(76, 19);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(449, 206);
            label2.Name = "label2";
            label2.Size = new Size(75, 19);
            label2.TabIndex = 0;
            label2.Text = "Mật khẩu";
            // 
            // txt_tkhoan
            // 
            txt_tkhoan.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txt_tkhoan.Location = new Point(552, 163);
            txt_tkhoan.Name = "txt_tkhoan";
            txt_tkhoan.Size = new Size(152, 26);
            txt_tkhoan.TabIndex = 1;
            // 
            // txt_matkhau
            // 
            txt_matkhau.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            txt_matkhau.Location = new Point(552, 198);
            txt_matkhau.Name = "txt_matkhau";
            txt_matkhau.Size = new Size(152, 26);
            txt_matkhau.TabIndex = 1;
            // 
            // btn_dangnhap
            // 
            btn_dangnhap.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_dangnhap.Location = new Point(449, 258);
            btn_dangnhap.Name = "btn_dangnhap";
            btn_dangnhap.Size = new Size(102, 38);
            btn_dangnhap.TabIndex = 2;
            btn_dangnhap.Text = "Đăng nhập";
            btn_dangnhap.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(543, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(90, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btn_thoat
            // 
            btn_thoat.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_thoat.Location = new Point(597, 258);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(107, 38);
            btn_thoat.TabIndex = 4;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(2, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(418, 450);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 458);
            Controls.Add(btn_thoat);
            Controls.Add(pictureBox1);
            Controls.Add(btn_dangnhap);
            Controls.Add(txt_matkhau);
            Controls.Add(txt_tkhoan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang đăng nhập quản lý";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txt_tkhoan;
        private TextBox txt_matkhau;
        private Button btn_dangnhap;
        private PictureBox pictureBox1;
        private Button btn_thoat;
        private PictureBox pictureBox2;
    }
}
