using System.Drawing;
using System.Windows.Forms;

namespace DO_AN_CUOI_KY
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtFatherID = new System.Windows.Forms.TextBox();
            this.txtMotherID = new System.Windows.Forms.TextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // picLogo
            // 
            this.picLogo.Image = global::DO_AN_CUOI_KY.Properties.Resources.logo_du_an;
            this.picLogo.Location = new System.Drawing.Point(170, 5); 
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(0,102,204);
            this.lblHeaderTitle.Location = new System.Drawing.Point(0, 55);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(400, 30);
            this.lblHeaderTitle.Text = "ĐĂNG KÝ ĐỊNH DANH ĐIỆN TỬ";
            this.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Số CCCD
            this.label1.Text = "Số CCCD (*):";
            this.label1.Location = new System.Drawing.Point(30, 113);
            this.txtID.Location = new System.Drawing.Point(150, 110);
            this.txtID.Size = new System.Drawing.Size(200, 22);

            // Họ Tên
            this.label2.Text = "Họ Tên (*):";
            this.label2.Location = new System.Drawing.Point(30, 153);
            this.txtName.Location = new System.Drawing.Point(150, 150);
            this.txtName.Size = new System.Drawing.Size(200, 22);

            // Ngày Sinh
            this.label3.Text = "Ngày Sinh (*):";
            this.label3.Location = new System.Drawing.Point(30, 193);
            this.dtpDOB.Location = new System.Drawing.Point(150, 190);
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Giới Tính
            this.label4.Text = "Giới Tính (*):";
            this.label4.Location = new System.Drawing.Point(30, 233);
            this.cbGender.Location = new System.Drawing.Point(150, 230);
            this.cbGender.Size = new System.Drawing.Size(200, 24);
            this.cbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Địa Chỉ
            this.label5.Text = "Địa Chỉ (*):";
            this.label5.Location = new System.Drawing.Point(30, 273);
            this.txtAddress.Location = new System.Drawing.Point(150, 270);
            this.txtAddress.Size = new System.Drawing.Size(200, 22);

            // SĐT
            this.label6.Text = "SĐT (*):";
            this.label6.Location = new System.Drawing.Point(30, 313);
            this.txtPhone.Location = new System.Drawing.Point(150, 310);
            this.txtPhone.Size = new System.Drawing.Size(200, 22);

            // ID Cha
            this.label7.Text = "ID Cha:";
            this.label7.Location = new System.Drawing.Point(30, 353);
            this.txtFatherID.Location = new System.Drawing.Point(150, 350);
            this.txtFatherID.Size = new System.Drawing.Size(200, 22);

            // ID Mẹ
            this.label8.Text = "ID Mẹ:";
            this.label8.Location = new System.Drawing.Point(30, 393);
            this.txtMotherID.Location = new System.Drawing.Point(150, 390);
            this.txtMotherID.Size = new System.Drawing.Size(200, 22);

            // --- Nút bấm ---
            this.btnRegister.BackColor = System.Drawing.Color.LightGreen; 
            this.btnRegister.Location = new System.Drawing.Point(80, 450); 
            this.btnRegister.Size = new System.Drawing.Size(100, 35); 
            this.btnRegister.Text = "Đăng Ký"; 
            
            this.btnCancel.Location = new System.Drawing.Point(210, 450); 
            this.btnCancel.Size = new System.Drawing.Size(100, 35); 
            this.btnCancel.Text = "Hủy";

            // --- Form Settings ---
            this.ClientSize = new System.Drawing.Size(400, 520);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtFatherID);
            this.Controls.Add(this.txtMotherID);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Công Dân";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtFatherID;
        private System.Windows.Forms.TextBox txtMotherID;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        // Thêm các dòng này vào:
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblHeaderTitle;
    }
}