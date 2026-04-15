namespace DO_AN_CUOI_KY
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlInputID;
        private System.Windows.Forms.Panel pnlInputPass;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.TextBox txtCitizenID;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.ProgressBar loadingBar;
        private System.Windows.Forms.PictureBox picShowPass;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInputID = new System.Windows.Forms.Panel();
            this.txtCitizenID = new System.Windows.Forms.TextBox();
            this.pnlInputPass = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.picShowPass = new System.Windows.Forms.PictureBox();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.loadingBar = new System.Windows.Forms.ProgressBar();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.pnlInputID.SuspendLayout();
            this.pnlInputPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.logo);
            this.pnlContainer.Controls.Add(this.lblTitle);
            this.pnlContainer.Controls.Add(this.pnlInputID);
            this.pnlContainer.Controls.Add(this.pnlInputPass);
            this.pnlContainer.Controls.Add(this.picCaptcha);
            this.pnlContainer.Controls.Add(this.txtCaptcha);
            this.pnlContainer.Controls.Add(this.BtnLogin);
            this.pnlContainer.Controls.Add(this.BtnRegister);
            this.pnlContainer.Controls.Add(this.loadingBar);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(420, 520);
            this.pnlContainer.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.Image = global::DO_AN_CUOI_KY.Properties.Resources.logo_du_an;
            this.logo.Location = new System.Drawing.Point(160, 30);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(100, 100);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 140);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ĐỊNH DANH ĐIỆN TỬ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInputID
            // 
            this.pnlInputID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlInputID.Controls.Add(this.txtCitizenID);
            this.pnlInputID.Location = new System.Drawing.Point(50, 200);
            this.pnlInputID.Name = "pnlInputID";
            this.pnlInputID.Size = new System.Drawing.Size(320, 45);
            this.pnlInputID.TabIndex = 2;
            // 
            // txtCitizenID
            // 
            this.txtCitizenID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtCitizenID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCitizenID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCitizenID.Location = new System.Drawing.Point(15, 12);
            this.txtCitizenID.Name = "txtCitizenID";
            this.txtCitizenID.Size = new System.Drawing.Size(290, 25);
            this.txtCitizenID.TabIndex = 0;
            // 
            // pnlInputPass
            // 
            this.pnlInputPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlInputPass.Controls.Add(this.txtPass);
            this.pnlInputPass.Controls.Add(this.picShowPass);
            this.pnlInputPass.Location = new System.Drawing.Point(50, 260);
            this.pnlInputPass.Name = "pnlInputPass";
            this.pnlInputPass.Size = new System.Drawing.Size(320, 45);
            this.pnlInputPass.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPass.Location = new System.Drawing.Point(15, 12);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(250, 25);
            this.txtPass.TabIndex = 0;
            // 
            // picShowPass
            // 
            this.picShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShowPass.Image = global::DO_AN_CUOI_KY.Properties.Resources.eye_close;
            this.picShowPass.Location = new System.Drawing.Point(280, 10);
            this.picShowPass.Name = "picShowPass";
            this.picShowPass.Size = new System.Drawing.Size(25, 25);
            this.picShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShowPass.TabIndex = 1;
            this.picShowPass.TabStop = false;
            // 
            // picCaptcha
            // 
            this.picCaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCaptcha.Location = new System.Drawing.Point(50, 320);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(150, 45);
            this.picCaptcha.TabIndex = 4;
            this.picCaptcha.TabStop = false;
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCaptcha.Location = new System.Drawing.Point(210, 320);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(160, 34);
            this.txtCaptcha.TabIndex = 5;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(50, 380);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(320, 45);
            this.BtnLogin.TabIndex = 6;
            this.BtnLogin.Text = "ĐĂNG NHẬP";
            this.BtnLogin.UseVisualStyleBackColor = false;
            // 
            // BtnRegister
            // 
            this.BtnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.BtnRegister.Location = new System.Drawing.Point(50, 440);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(320, 35);
            this.BtnRegister.TabIndex = 7;
            this.BtnRegister.Text = "Chưa có tài khoản? Đăng ký ngay";
            // 
            // loadingBar
            // 
            this.loadingBar.Location = new System.Drawing.Point(50, 425);
            this.loadingBar.Name = "loadingBar";
            this.loadingBar.Size = new System.Drawing.Size(320, 5);
            this.loadingBar.TabIndex = 8;
            this.loadingBar.Visible = false;
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 520);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.pnlInputID.ResumeLayout(false);
            this.pnlInputID.PerformLayout();
            this.pnlInputPass.ResumeLayout(false);
            this.pnlInputPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
