using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUOI_KY
{
    public partial class LoginForm : Form
    {
        private string _captchaText;
        public Citizen AuthenticatedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Icon & Close Logic
            this.Icon = Properties.Resources.logo;

            // 2. Bo góc cho các Panel Input (Dùng GDI+)
            ApplyRegion(pnlInputID, 15);
            ApplyRegion(pnlInputPass, 15);
            ApplyRegion(BtnLogin, 10);

            // 3. Placeholders
            UIHelper.SetPlaceholder(txtCitizenID, "Số định danh");
            UIHelper.SetPlaceholder(txtPass, "Mật khẩu", true);
            UIHelper.SetPlaceholder(txtCaptcha, "Mã xác thực");

            // 4. Events
            picShowPass.Click += TogglePasswordVisibility;
            picCaptcha.Click += (s, e) => GenerateCaptcha();
            BtnLogin.Click += BtnLogin_Click;
            BtnRegister.Click += BtnRegister_Click;

            // Hover effects
            UIHelper.AddHoverEffect(BtnLogin, Color.FromArgb(13, 71, 161), Color.FromArgb(25, 118, 210));
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            _captchaText = UIHelper.GenerateCaptchaImage(picCaptcha);
        }

        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            bool isHidden = txtPass.PasswordChar == '●';
            txtPass.PasswordChar = isHidden ? '\0' : '●';
            picShowPass.Image = isHidden ? Properties.Resources.eye_open : Properties.Resources.eye_close;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            // Logic kiểm tra dữ liệu
            if (!ValidateInputs()) return;

            // Tìm kiếm trong BST
            Citizen user = Program.Tree.Search(txtCitizenID.Text);

            if (user == null || user.Password != txtPass.Text)
            {
                await ShakeFormAsync();
                MessageBox.Show("Thông tin đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GenerateCaptcha();
                return;
            }

            // Hiệu ứng Loading
            BtnLogin.Enabled = false;
            loadingBar.Visible = true;
            for (int i = 0; i <= 100; i += 10)
            {
                loadingBar.Value = i;
                await Task.Delay(50);
            }

            // Chuyển Dashboard
            this.AuthenticatedUser = user; 
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCitizenID.Text) || txtCitizenID.Text.Contains("Số định danh")) return Error("Nhập Citizen ID!");
            if (string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text.Contains("Mật khẩu")) return Error("Nhập mật khẩu!");
            if (txtCaptcha.Text != _captchaText)
            {
                GenerateCaptcha();
                return Error("Mã Captcha sai!");
            }
            return true;
        }

        private bool Error(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        // Helper: Bo góc Control
        private void ApplyRegion(Control control, int radius)
        {
            control.Paint += (s, e) =>
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                control.Region = new Region(path);
            };
        }

        private async Task ShakeFormAsync()
        {
            Point oldLoc = this.Location;
            for (int i = 0; i < 5; i++)
            {
                this.Location = new Point(oldLoc.X + 10, oldLoc.Y);
                await Task.Delay(20);
                this.Location = new Point(oldLoc.X - 10, oldLoc.Y);
                await Task.Delay(20);
            }
            this.Location = oldLoc;
        }
    }
}
