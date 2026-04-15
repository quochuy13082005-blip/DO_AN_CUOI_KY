using System;
using System.Drawing;
using System.Windows.Forms;

namespace DO_AN_CUOI_KY
{
    public partial class CCCD : Form
    {
        private dynamic _user;

        public CCCD(dynamic user)
        {
            InitializeComponent();


            this.Size = new Size(700, 650);

            if (pnlCard != null)
            {
                pnlCard.Width = 650;

                pnlCard.Height = 300;

                pnlCard.Left = (this.ClientSize.Width - pnlCard.Width) / 2;
            }
            this.Icon = Properties.Resources.logo;
            this._user = user;

            RegisterEvents();
            LoadData();
            DisplayIdentityInfo();
        }

        private void RegisterEvents()
        {
            btnBack.Click += (s, e) => this.Close();

            // Nếu bạn có TextBox nào kéo tay trong Designer thì hàm này sẽ format chúng
            foreach (Control c in pnlCard.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.None;
                    txt.BackColor = Color.FromArgb(240, 240, 240);
                    txt.ReadOnly = true;
                    txt.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

        private void LoadData()
        {
            pnlFooter.Controls.Clear(); 
            pnlFooter.Controls.Add(CreateMenuOption("→ Căn cước điện tử"));
            pnlFooter.Controls.Add(CreateMenuOption("→ Lịch sử cấp thẻ CC/CCCD/CMND"));
        }

        private Label CreateMenuOption(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 0, 0),
                Size = new Size(400, 40),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand
            };
        }

        private void DisplayIdentityInfo()
        {
            if (_user == null) return;

            pnlCard.Controls.Clear();
            Label lblHeaderCard = new Label
            {
                Text = "CĂN CƯỚC ĐIỆN TỬ",
                Font = new Font("Time New Roman", 12F, FontStyle.Bold),
                ForeColor = Color.Red, 
                AutoSize = false,
                Width = pnlCard.Width, 
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 5), 
                BackColor = Color.Transparent
            };
            pnlCard.Controls.Add(lblHeaderCard);

            PictureBox picAvatar = new PictureBox
            {
                Size = new Size(110, 140),
                Location = new Point(25, 90), 
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(230, 230, 230),
                BorderStyle = BorderStyle.FixedSingle
            };

            
            // Thử load ảnh nếu class Citizen có trường Image
            try { picAvatar.Image = _user.Avatar; } catch { /* Không có ảnh thì thôi */ }
            pnlCard.Controls.Add(picAvatar);

            // 2. Render Thông tin
            float startX = 145;

            // Số CCCD
            AddInfoLabel("Số / No.: " + (_user.CitizenID ?? ""), new Point((int)startX, 65), true, 11);

            // Họ tên
            AddInfoLabel("Họ và tên / Full name:", new Point((int)startX, 95), false, 8);
            string name = _user.FullName ?? "";
            AddInfoLabel(name.ToUpper(), new Point((int)startX, 110), true, 11);

            // Ngày sinh 
            string dob = "";
            try
            {
                if (_user.DateOfBirth is DateTime) dob = _user.DateOfBirth.ToString("dd/MM/yyyy");
                else dob = _user.DateOfBirth.ToString();
            }
            catch { dob = "01/01/2000"; }

            AddInfoLabel("Ngày sinh / Date of birth: " + dob, new Point((int)startX, 140), true, 9);

            // Giới tính & Quốc tịch
            AddInfoLabel("Giới tính / Sex: " + (_user.Gender ?? "Nam"), new Point((int)startX, 160), true, 9);
            AddInfoLabel("Quốc tịch / Nationality: Việt Nam", new Point(275, 160), true, 9);

            // Quê quán 
            AddInfoLabel("Quê quán / Place of origin:", new Point((int)startX, 185), false, 8);
            AddInfoLabel(_user.Address ?? "", new Point((int)startX, 200), true, 9);

            // Thường trú
            AddInfoLabel("Nơi thường trú / Place of residence:", new Point((int)startX, 225), false, 8);
            AddInfoLabel(_user.Address ?? "", new Point((int)startX, 240), true, 9);
        }

        private void AddInfoLabel(string text, Point location, bool isBold, int fontSize)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = location,
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", fontSize, isBold ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = Color.Black
            };
            pnlCard.Controls.Add(lbl);
            lbl.BringToFront();
        }
    }
}