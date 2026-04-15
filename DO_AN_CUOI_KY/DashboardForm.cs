using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace DO_AN_CUOI_KY
{
    public partial class DashboardForm : Form
    {
        private Citizen currentUser;
        private DataGridView currentGrid;

        private TextBox txtCitizenID, txtCitizenName, txtCitizenPass, txtCitizenAddress, txtCitizenGender;
        private TextBox txtCitizenFatherID, txtCitizenMotherID, txtCitizenOccupation, txtCitizenPhone;
        public DashboardForm(Citizen c)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.logo;
            currentUser = c;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (currentUser.CitizenID.StartsWith("admin"))
            {
                ShowAdminUI();
            }
            else
                ShowUserUI();

        }

        // ================= ADMIN =================

        private void ShowAdminUI()
        {
            // --- 1. Tạo Panel Header ---
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 170,
                BackColor = Color.FromArgb(13, 71, 161)
            };

            panelMenu.Controls.Add(pnlHeader);

            // --- 2. Tạo các thành phần nội bộ (Đừng Dock ngay, hãy nạp theo thứ tự) ---

            // Logo 
            PictureBox picLogo = new PictureBox
            {
                Image = Properties.Resources.logo_rm,
                SizeMode = PictureBoxSizeMode.Zoom,
                Height = 90,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 15, 0, 5)
            };

            // Label Hệ thống 
            Label lblSystem = new Label
            {
             Text = "HỆ THỐNG\nĐỊNH DANH ĐIỆN TỬ",
             ForeColor = Color.White,
             Font = new Font("Segoe UI", 10, FontStyle.Regular),
             TextAlign = ContentAlignment.MiddleCenter,
             Dock = DockStyle.Top,
             Height = 50
            };

            // Label Quyền (Nằm dưới Logo và Hệ thống)
            Label lblUser = new Label
            {
                Text = "QUẢN TRỊ VIÊN",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };
            // --- 3. ADD VÀO PANEL THEO THỨ TỰ NGƯỢC (Quan trọng) ---
            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Controls.Add(lblSystem);
            pnlHeader.Controls.Add(picLogo);

            AddButton("🔄 Làm mới", Color.FromArgb(52, 152, 219), (s, e) => { RefreshGrid(); });
            AddButton("➕ Thêm mới", Color.FromArgb(46, 204, 113), AddCitizen);
            AddButton("📝 Chỉnh sửa", Color.FromArgb(241, 196, 15), EditCitizen);
            AddButton("🗑️ Xóa bỏ", Color.FromArgb(231, 76, 60), DeleteCitizen);
            AddButton("👨‍👩‍👧 Phả hệ", Color.FromArgb(155, 89, 182), ViewFamily);
            AddButton("Thoát", Color.FromArgb(44, 62, 80), Logout);

            // --- Khu vực nhập liệu (Input Area) ---
            GroupBox gbInput = new GroupBox
            {
                Text = "📝 THÔNG TIN CÔNG DÂN",
                Dock = DockStyle.Top,
                Height = 180,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                Padding = new Padding(10)
            };

            // Khởi tạo TextBoxes với Style phẳng
            txtCitizenID = new TextBox() { Location = new Point(120, 35), Width = 150 };
            txtCitizenName = new TextBox() { Location = new Point(380, 35), Width = 200 };
            txtCitizenGender = new TextBox() { Location = new Point(650, 35), Width = 100 };

            txtCitizenPass = new TextBox() { Location = new Point(120, 75), Width = 150 };
            txtCitizenAddress = new TextBox() { Location = new Point(380, 75), Width = 200 };
            txtCitizenPhone = new TextBox() { Location = new Point(650, 75), Width = 150 };

            txtCitizenFatherID = new TextBox() { Location = new Point(120, 115), Width = 150 };
            txtCitizenMotherID = new TextBox() { Location = new Point(380, 115), Width = 150 };
            txtCitizenOccupation = new TextBox() { Location = new Point(650, 115), Width = 150 };

            // Thêm Label và TextBox vào GroupBox
            gbInput.Controls.Add(new Label() { Text = "Số CCCD:", Location = new Point(25, 38), AutoSize = true });
            gbInput.Controls.Add(txtCitizenID);
            gbInput.Controls.Add(new Label() { Text = "Họ và Tên:", Location = new Point(290, 38), AutoSize = true });
            gbInput.Controls.Add(txtCitizenName);
            gbInput.Controls.Add(new Label() { Text = "Giới tính:", Location = new Point(590, 38), AutoSize = true });
            gbInput.Controls.Add(txtCitizenGender);

            gbInput.Controls.Add(new Label() { Text = "Mật khẩu:", Location = new Point(25, 78), AutoSize = true });
            gbInput.Controls.Add(txtCitizenPass);
            gbInput.Controls.Add(new Label() { Text = "Quê quán:", Location = new Point(290, 78), AutoSize = true });
            gbInput.Controls.Add(txtCitizenAddress);
            gbInput.Controls.Add(new Label() { Text = "SĐT:", Location = new Point(590, 78), AutoSize = true });
            gbInput.Controls.Add(txtCitizenPhone);

            gbInput.Controls.Add(new Label() { Text = "ID Cha:", Location = new Point(25, 118), AutoSize = true });
            gbInput.Controls.Add(txtCitizenFatherID);
            gbInput.Controls.Add(new Label() { Text = "ID Mẹ:", Location = new Point(290, 118), AutoSize = true });
            gbInput.Controls.Add(txtCitizenMotherID);
            gbInput.Controls.Add(new Label() { Text = "Nghề nghiệp:", Location = new Point(560, 118), AutoSize = true });
            gbInput.Controls.Add(txtCitizenOccupation);

            panelContent.Controls.Add(gbInput);

            // --- Khu vực tìm kiếm (Search Bar) ---
            Panel searchPanel = new Panel() { Dock = DockStyle.Top, Height = 50, Padding = new Padding(10, 5, 10, 5) };
            TextBox txtSearch = new TextBox() { Location = new Point(120, 15), Width = 300, Font = new Font("Segoe UI", 10) };
            Button btnSearch = new Button()
            {
                Text = "🔍 Tìm kiếm",
                Location = new Point(430, 12),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(52, 73, 94),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            searchPanel.Controls.Add(new Label() { Text = "Tra cứu nhanh:", Location = new Point(25, 18), Font = new Font("Segoe UI", 9, FontStyle.Italic) });
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnSearch);

            btnSearch.Click += (s, e) => { SearchCitizen(txtSearch.Text); };
            panelContent.Controls.Add(searchPanel);

            // --- Tùy chỉnh DataGridView ---
            currentGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            currentGrid.RowTemplate.Height = 35;

            // Header Grid Style
            currentGrid.EnableHeadersVisualStyles = false;
            currentGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            currentGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            currentGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            currentGrid.CellClick += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = currentGrid.Rows[e.RowIndex];
                    txtCitizenID.Text = row.Cells["CitizenID"].Value?.ToString();
                    txtCitizenName.Text = row.Cells["FullName"].Value?.ToString();
                    txtCitizenGender.Text = row.Cells["Gender"].Value?.ToString();
                    txtCitizenPass.Text = row.Cells["Password"].Value?.ToString();
                    txtCitizenAddress.Text = row.Cells["Address"].Value?.ToString();
                    txtCitizenFatherID.Text = row.Cells["FatherID"].Value?.ToString();
                    txtCitizenMotherID.Text = row.Cells["MotherID"].Value?.ToString();
                    txtCitizenOccupation.Text = row.Cells["Occupation"].Value?.ToString();
                    txtCitizenPhone.Text = row.Cells["PhoneNumber"].Value?.ToString();
                }
            };

            panelContent.Controls.Add(currentGrid);
            currentGrid.BringToFront();

            RefreshGrid();
        }
        // ================= LOGIC FUNCTIONS =================

        private void RefreshGrid()
        {
            if (currentGrid == null) return;

            List<Citizen> list = GetAll(Program.Tree.Root);

            currentGrid.DataSource = null;
            currentGrid.DataSource = list;

            if (currentGrid.Columns.Count > 0)
            {
                currentGrid.Columns["CitizenID"].HeaderText = "Số CCCD";
                currentGrid.Columns["FullName"].HeaderText = "Họ và Tên";
                currentGrid.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
                currentGrid.Columns["Gender"].HeaderText = "Giới tính";
                currentGrid.Columns["Address"].HeaderText = "Địa chỉ";
                currentGrid.Columns["Password"].HeaderText = "Mật khẩu";
                currentGrid.Columns["Occupation"].HeaderText = "Nghề nghiệp";
                currentGrid.Columns["FatherID"].HeaderText = "ID Cha";
                currentGrid.Columns["MotherID"].HeaderText = "ID Mẹ";
                if (currentGrid.Columns["PhoneNumber"] != null)
                {
                    currentGrid.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
                    currentGrid.Columns["PhoneNumber"].DisplayIndex = 3;
                }

                currentGrid.Columns["FatherID"].DisplayIndex = 7;
                currentGrid.Columns["MotherID"].DisplayIndex = 8;

                // Ẩn các cột quan hệ gia đình cho gọn bảng quản lý
                if (currentGrid.Columns["SpouseID"] != null) currentGrid.Columns["SpouseID"].Visible = false;
                if (currentGrid.Columns["Username"] != null) currentGrid.Columns["Username"].Visible = false;
                if (currentGrid.Columns["Nationality"] != null) currentGrid.Columns["Nationality"].Visible = false;
            }
        }

        private void AddCitizen(object sender, EventArgs e)
        {
            if (!IsInputValid()) return;

            //Kiểm tra trùng
            Citizen existing = Program.Tree.Search(txtCitizenID.Text);
            if (existing != null)
            {
                MessageBox.Show("Số Citizen này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra tồn tại của IDcha và IDme
            string fatherID = txtCitizenFatherID.Text.Trim();
            if (!string.IsNullOrEmpty(fatherID) && fatherID.ToLower() != "null" && fatherID.ToLower() != "n/a")
            {
                if (Program.Tree.Search(fatherID) == null)
                {
                    MessageBox.Show("ID Cha không tồn tại! Để trống nếu không rõ.", "Lỗi quan hệ");
                    return;
                }
            }
            else { fatherID = "N/A"; } 

            // 3. Kiểm tra ID Mẹ (Nếu có nhập mới kiểm tra tồn tại)
            string motherID = txtCitizenMotherID.Text.Trim();
            if (!string.IsNullOrEmpty(motherID) && motherID.ToLower() != "null" && motherID.ToLower() != "n/a")
            {
                if (Program.Tree.Search(motherID) == null)
                {
                    MessageBox.Show("ID Mẹ không tồn tại! Để trống nếu không rõ.", "Lỗi quan hệ");
                    return;
                }
            }
            else { motherID = "N/A"; }

            Citizen c = new Citizen
            {
                CitizenID = txtCitizenID.Text,
                FullName = txtCitizenName.Text,
                Password = txtCitizenPass.Text == "" ? "123@abc" : txtCitizenPass.Text,
                Address = txtCitizenAddress.Text,
                Gender = txtCitizenGender.Text,
                DateOfBirth = DateTime.Now.AddYears(-18),
                FatherID = fatherID,
                MotherID = motherID,
                Occupation = txtCitizenOccupation.Text,
                PhoneNumber = txtCitizenPhone.Text
            };

            Program.Tree.Insert(c);
            MessageBox.Show("Đã thêm công dân:" + c.FullName);
            ClearTextBoxes();

            RefreshGrid();
        }

        private void EditCitizen(object sender, EventArgs e)
        {
            if (!IsInputValid()) return;

            if (currentGrid.CurrentRow == null) return;

            // Lấy ID từ Grid (ID là khóa không nên sửa)
            string id = currentGrid.CurrentRow.Cells["CitizenID"].Value.ToString();

            // Tìm đối tượng trong cây
            Citizen c = Program.Tree.Search(id);
            
            if (c != null)
            {
                bool isChanged = (c.FullName != txtCitizenName.Text ||
                          c.Password != txtCitizenPass.Text ||
                          c.Address != txtCitizenAddress.Text ||
                          c.Gender != txtCitizenGender.Text ||
                          c.FatherID != txtCitizenFatherID.Text ||
                          c.MotherID != txtCitizenMotherID.Text ||
                          c.Occupation != txtCitizenOccupation.Text ||
                          c.PhoneNumber != txtCitizenPhone.Text);
                if (!isChanged)
                {
                    MessageBox.Show("Dữ liệu không thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes(); 
                    return;
                }

                c.FullName = txtCitizenName.Text;
                c.Password = txtCitizenPass.Text;
                c.Address = txtCitizenAddress.Text;
                c.Gender = txtCitizenGender.Text;
                c.FatherID = txtCitizenFatherID.Text;
                c.MotherID = txtCitizenMotherID.Text;
                c.Occupation = txtCitizenOccupation.Text.Trim(); 
                c.PhoneNumber = txtCitizenPhone.Text.Trim();   

                MessageBox.Show("Cập nhật thông tin công dân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCitizenID.ReadOnly = false; 
                RefreshGrid();                 
                ClearTextBoxes();

                RefreshGrid();
            }
        }

        private void DeleteCitizen(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCitizenID.Text))
            {
                MessageBox.Show("Vui lòng chọn công dân cần xóa từ danh sách!");
                return;
            }

            string id = txtCitizenID.Text;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa công dân này?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Program.Tree.Delete(id);

                MessageBox.Show("Đã xóa công dân thành công!");

                RefreshGrid();
                ClearTextBoxes();
            }
        }

        private void SearchCitizen(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) { RefreshGrid(); return; }

            List<Citizen> all = GetAll(Program.Tree.Root);
            List<Citizen> results = new List<Citizen>();

            foreach (Citizen c in all)
            {
                if (c.CitizenID.Contains(keyword) || c.FullName.ToLower().Contains(keyword.ToLower()))
                {
                    results.Add(c);
                }
            }

            currentGrid.DataSource = null;
            currentGrid.DataSource = results;

            // Nếu tìm thấy duy nhất 1 người, hiển thị lên TextBox
            if (results.Count == 1)
            {
                Citizen c = results[0];
                txtCitizenID.Text = c.CitizenID;
                txtCitizenName.Text = c.FullName;
                txtCitizenPass.Text = c.Password;
                txtCitizenAddress.Text = c.Address;
                txtCitizenGender.Text = c.Gender;
                txtCitizenFatherID.Text = c.FatherID;
                txtCitizenMotherID.Text = c.MotherID;
                txtCitizenOccupation.Text = c.Occupation;
            }
        }

        private void ClearTextBoxes()
        {
            txtCitizenID.Clear();
            txtCitizenName.Clear();
            txtCitizenPass.Clear();
            txtCitizenAddress.Clear();
            txtCitizenGender.Clear();
            txtCitizenFatherID.Clear();
            txtCitizenMotherID.Clear();
            txtCitizenOccupation.Clear();
            txtCitizenPhone.Clear();
        }

        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(txtCitizenName.Text) ||
                string.IsNullOrWhiteSpace(txtCitizenAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCitizenGender.Text) ||
                string.IsNullOrWhiteSpace (txtCitizenPhone.Text))
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ các thông tin bắt buộc:\n" +
                                "- Họ tên\n- Quê quán\n- Giới tính\n- Số điện thoại",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ================= Duyệt cây BST =================

        private List<Citizen> GetAll(BSTNode node)
        {
            List<Citizen> list = new List<Citizen>();

            InOrderTraversal(node, list);
            return list;
        }
        private void InOrderTraversal(BSTNode node, List<Citizen> list)
        {
            if (node == null) return;
            InOrderTraversal(node.Left, list);
            list.Add(node.Data);
            InOrderTraversal(node.Right, list);
        }

        // ================= HELPER & UI COMMON  =================
        private void AddButton(string text, Color BackColor,  EventHandler click)
        {
            Button btn = new Button();
            btn.Text = "    " + text;
            btn.Height = 50; 
            btn.Dock = DockStyle.Top; 
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = BackColor;
            btn.ForeColor = Color.Black;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.FlatAppearance.BorderSize = 0;

            btn.Margin = new Padding(0, 2, 0, 0);

            if (text == "Thoát")
            {
                btn.BackColor = Color.Firebrick;
                btn.ForeColor = Color.White;
                btn.Dock = DockStyle.Bottom;
            }

            btn.MouseEnter += (s, e) => {
                btn.Tag = btn.BackColor;
                btn.BackColor = Color.LightGray; 
            };
            btn.MouseLeave += (s, e) => { btn.BackColor = (Color)btn.Tag; };

            btn.Click += click;
            panelMenu.Controls.Add(btn);
        }        

        private void ShowList(object sender, EventArgs e)
        {
            currentGrid = new DataGridView();
            currentGrid.Dock = DockStyle.Fill;

            List<Citizen> list = GetAll(Program.Tree.Root);
            currentGrid.DataSource = list;

            panelContent.Controls.Clear();
            panelContent.Controls.Add(currentGrid);
        }

        private void Logout(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void ViewFamily(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCitizenID.Text)) return;
            Citizen c = Program.Tree.Search(txtCitizenID.Text);
            if (c == null) return;

            Citizen f = Program.Tree.Search(c.FatherID);
            Citizen m = Program.Tree.Search(c.MotherID);

            string relation = $"Công dân: {c.FullName}\n" +
                             $"- Cha: {(f != null ? f.FullName : "Không rõ")}\n" +
                             $"- Mẹ: {(m != null ? m.FullName : "Không rõ")}";
            MessageBox.Show(relation, "Thông tin phả hệ");
        }

        // ================= USER =================
        private void ShowUserUI()
        {
            panelMenu.Controls.Clear();
            panelMenu.BackColor = Color.FromArgb(20, 40, 100); 

            panelContent.Controls.Clear();
            panelContent.BackColor = Color.FromArgb(245, 245, 245);

            // ============================================================
            // LOGO & TÊN HỆ THỐNG
            // ============================================================
            PictureBox picLogo = new PictureBox()
            {
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.logo_rm,
                BackColor = Color.Transparent,
                Location = new Point((panelMenu.Width - 100) / 2, 40)
            };

            Label lblSystemName = new Label()
            {
                Text = "HỆ THỐNG\nQUẢN LÝ DÂN CƯ",
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Width = panelMenu.Width - 20,
                Height = 60,
                Location = new Point(10, 150)
            };


            panelMenu.Controls.Add(picLogo);
            panelMenu.Controls.Add(lblSystemName);

            // ============================================================
            // MAIN DASHBOARD 
            // ============================================================
            // --- A. TOP PANEL ---
            Panel pnlTopInfo = new Panel() { Dock = DockStyle.Top, Height = 100, BackColor = Color.FromArgb(192, 0, 0) };

            // 1. Tên công dân - CĂN GIỮA main dashboard
            Label lblFullName = new Label()
            {
                Text = currentUser.FullName.ToUpper(),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            // 2. Nút thoát - TRÊN BÊN PHẢI
            Button btnExitTop = new Button()
            {
                Text = "Thoát",
                Size = new Size(80, 35),
                Location = new Point(pnlTopInfo.Width - 100, 10), // Vị trí tương đối
                BackColor = Color.White,
                ForeColor = Color.FromArgb(192, 0, 0),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnExitTop.Click += Logout;

            pnlTopInfo.Controls.Add(btnExitTop); 
            pnlTopInfo.Controls.Add(lblFullName); 
            btnExitTop.BringToFront(); 

            // --- B. QR SIMULATION AREA ---

            Panel pnlQR = new Panel() { Dock = DockStyle.Top, Height = 130, BackColor = Color.White, Padding = new Padding(10) };

            pnlQR.Paint += Panel_Paint_BoGoc_Nhe; 

            // Card QR 1: Thẻ CCCD
            Panel cardQR_CCCD = CreateQRCard("Mã QR\nThẻ CCCD", Dummy);
            cardQR_CCCD.Location = new Point(20, 15);

            // Card QR 2: Định danh điện tử
            Panel cardQR_DDDT = CreateQRCard("Mã QR\nĐịnh danh\nđiện tử", Dummy);
            cardQR_DDDT.Location = new Point(cardQR_CCCD.Right + 30, 20);

            pnlQR.Controls.Add(cardQR_CCCD);
            pnlQR.Controls.Add(cardQR_DDDT);

            // --- C. BODY ---
            FlowLayoutPanel flowBody = new FlowLayoutPanel() { Dock = DockStyle.Fill, Padding = new Padding(20), AutoScroll = true };
            panelContent.Controls.Add(flowBody);
            panelContent.Controls.Add(pnlQR);     
            panelContent.Controls.Add(pnlTopInfo); 

            flowBody.BringToFront();

            AddGroupTitle(flowBody, "Tiện ích yêu thích");
            flowBody.Controls.Add(CreateServiceCard("Thẻ CCCD", Properties.Resources.citizen, ShowCCCD));
            flowBody.Controls.Add(CreateServiceCard("GPLX", Properties.Resources.gplx, Dummy));
            flowBody.Controls.Add(CreateServiceCard("BHYT", Properties.Resources.bhyt ,Dummy));
            flowBody.Controls.Add(CreateServiceCard("Thông tin cư trú", Properties.Resources.ttct , Dummy));


            AddGroupTitle(flowBody, "Dịch vụ phổ biến");
            flowBody.Controls.Add(CreateServiceCard("Thủ tục\nhành chính", Properties.Resources.tthc ,Dummy));
            flowBody.Controls.Add(CreateServiceCard("An sinh\nxã hội", Properties.Resources.asxh, Dummy));
            flowBody.Controls.Add(CreateServiceCard("Hồ sơ\nsức khỏe", Properties.Resources.hssk, Dummy));
            flowBody.Controls.Add(CreateServiceCard("Dịch vụ\nkhác", Properties.Resources.khac, Dummy));

            panelContent.Controls.Add(flowBody);
            panelContent.Controls.Add(pnlQR);

            panelContent.Controls.Add(pnlTopInfo);

        }

        // ============================================================
        // CÁC HÀM HỖ TRỢ (HELPER METHODS)
        // ============================================================

        private Panel CreateServiceCard(string title, Image avt, EventHandler clickEvent)
        {
            Panel card = new Panel
            {
                Size = new Size(110, 120),
                BackColor = Color.White,
                Margin = new Padding(12),
                Cursor = Cursors.Hand
            };

            card.Click += clickEvent;

            // Bo góc thủ công cho Card
            card.Paint += (s, e) => {
                int r = 15; // Độ bo góc
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddArc(0, 0, r, r, 180, 90);
                gp.AddArc(card.Width - r, 0, r, r, 270, 90);
                gp.AddArc(card.Width - r, card.Height - r, r, r, 0, 90);
                gp.AddArc(0, card.Height - r, r, r, 90, 90);
                card.Region = new Region(gp);

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawPath(pen, gp);
                }
            };
            PictureBox picAvt = new PictureBox
            {
                Image = avt,
                Size = new Size(45, 45),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point((card.Width - 50) / 2, 15),
                BackColor = Color.Transparent,
                Enabled = false
            };
            picAvt.Click += clickEvent;

            Label lbl = new Label
            {
                Text = title,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 45,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.Black,
                Enabled = false

            };
            lbl.Click += clickEvent;

            card.Controls.Add(picAvt);
            card.Controls.Add(lbl);

            card.MouseEnter += (s, e) => { card.BackColor = Color.FromArgb(245, 245, 245); };
            card.MouseLeave += (s, e) => { card.BackColor = Color.White; };

            return card;


        }

        private Panel CreateQRCard(string text, EventHandler clickEvent)
        {
            Panel card = new Panel { Size = new Size(200, 90), BackColor = Color.FromArgb(250, 240, 210), Cursor = Cursors.Hand };
            card.Click += clickEvent;
            // Bo góc card màu vàng nhạt
            card.Paint += (s, e) => {
                int r = 10;
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddArc(0, 0, r, r, 180, 90);
                gp.AddArc(card.Width - r, 0, r, r, 270, 90);
                gp.AddArc(card.Width - r, card.Height - r, r, r, 0, 90);
                gp.AddArc(0, card.Height - r, r, r, 90, 90);
                card.Region = new Region(gp);
            };

            PictureBox picQR = new PictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(15, 15),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.may_quét_qr,
                BackColor = Color.White,
            };
            picQR.Click += clickEvent;

            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(85, 20),
                AutoSize = true,

            };
            lbl.Click += clickEvent;

            card.Controls.Add(picQR);
            card.Controls.Add(lbl);
            return card;
        }

        private void AddGroupTitle(FlowLayoutPanel container, string text)
        {
            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Width = container.Width - 40,
                Height = 30,
                Margin = new Padding(0, 20, 0, 5)
            };
            container.Controls.Add(lbl);
        }

        // Hàm phụ để bo góc nhẹ panel QR
        private void Panel_Paint_BoGoc_Nhe(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            int r = 15;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(0, 0, r, r, 180, 90);
            gp.AddArc(p.Width - r, 0, r, r, 270, 90);
            gp.AddArc(p.Width - r, p.Height - r, r, r, 0, 90);
            gp.AddArc(0, p.Height - r, r, r, 90, 90);
            p.Region = new Region(gp);
        }

        private void Dummy(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ShowCCCD(object sender, EventArgs e)
        {
            CCCD form = new CCCD(currentUser);
            form.ShowDialog();
        }

    }
}