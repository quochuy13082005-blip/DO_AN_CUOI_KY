using System;
using System.Linq;
using System.Windows.Forms;

namespace DO_AN_CUOI_KY
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            // Gán sự kiện Click cho các nút
            btnRegister.Click += BtnRegister_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) ||
                cbGender.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc (*)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra trùng ID trong cây BST
            if (Program.Tree.Search(txtID.Text) != null)
            {
                MessageBox.Show("Số CCCD này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Tạo đối tượng Citizen mới
            Citizen newCitizen = new Citizen
            {
                CitizenID = txtID.Text.Trim(),
                FullName = txtName.Text.Trim(),
                DateOfBirth = dtpDOB.Value,
                Gender = cbGender.SelectedItem.ToString(),
                Address = txtAddress.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                FatherID = string.IsNullOrWhiteSpace(txtFatherID.Text) ? "null" : txtFatherID.Text.Trim(),
                MotherID = string.IsNullOrWhiteSpace(txtMotherID.Text) ? "null" : txtMotherID.Text.Trim(),
                Occupation = "Tự do"
            };

            // Quy tắc mật khẩu: Tên cuối + @ + 3 số cuối CCCD
            string[] nameParts = newCitizen.FullName.Split(' ');
            string lastName = nameParts.Last();
            string idSuffix = newCitizen.CitizenID.Length >= 3 ? newCitizen.CitizenID.Substring(newCitizen.CitizenID.Length - 3) : "123";
            newCitizen.Password = lastName + "@" + idSuffix;

            // 4. Chèn vào cây BST
            Program.Tree.Insert(newCitizen);

            MessageBox.Show($"Đăng ký thành công!\nMật khẩu của bạn là: {newCitizen.Password}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}