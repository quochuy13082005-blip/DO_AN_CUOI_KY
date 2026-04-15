using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUOI_KY
{
    internal class UIHelper
    {
        // Placeholder cho TextBox
        public static void SetPlaceholder(TextBox txt, string placeholder, bool isPassword = false)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            if (isPassword) txt.PasswordChar = '\0';

            txt.Enter += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    if (isPassword) txt.PasswordChar = '*';
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    if (isPassword) txt.PasswordChar = '\0';
                }
            };
        }

        // Hover button
        public static void AddHoverEffect(Button btn, Color normalColor, Color hoverColor)
        {
            btn.BackColor = normalColor;
            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = normalColor;
        }

        // Tạo CAPTCHA
        public static string GenerateCaptchaImage(PictureBox pic)
        {
            Random rnd = new Random();

            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            string captcha = "";

            for (int i = 0; i < 4; i++)
                captcha += chars[rnd.Next(chars.Length)];

            Bitmap bmp = new Bitmap(pic.Width, pic.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            string[] fonts = { "Times New Roman", "Arial", "Tahoma", "Calibri", "Verdana", "Georgia", "Comic Sans MS" };

            for (int i = 0; i < captcha.Length; i++)
            {
                string fontName = fonts[rnd.Next(fonts.Length)];

                Font font = new Font(fontName, rnd.Next(18, 24), FontStyle.Bold);

                Brush brush = new SolidBrush(Color.FromArgb(
                    rnd.Next(20, 150),
                    rnd.Next(20, 150),
                    rnd.Next(20, 150)));

                int x = 5 + i * 20;
                int y = rnd.Next(0, 10);

                g.DrawString(captcha[i].ToString(), font, brush, x, y);
            }

            // vẽ đường nhiễu
            for (int i = 0; i < 5; i++)
            {
                Pen pen = new Pen(Color.Gray);

                g.DrawLine(
                    pen,
                    rnd.Next(pic.Width),
                    rnd.Next(pic.Height),
                    rnd.Next(pic.Width),
                    rnd.Next(pic.Height));
            }

            // vẽ chấm nhiễu
            for (int i = 0; i < 30; i++)
            {
                bmp.SetPixel(
                    rnd.Next(pic.Width),
                    rnd.Next(pic.Height),
                    Color.Gray);
            }

            pic.Image = bmp;

            return captcha;
        }

        // Rung khi đăng nhập sai
        public static async Task ShakeFormAsync(Form form, int intensity = 10, int delay = 15, int times = 8)
        {
            if (form == null) return;

            Point originalLocation = form.Location;
            Random rnd = new Random();

            for (int i = 0; i < times; i++)
            {
                int offsetX = rnd.Next(-intensity, intensity);
                int offsetY = rnd.Next(-intensity, intensity);
                form.Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY);
                await Task.Delay(delay);
            }

            form.Location = originalLocation;
        }

        public static Bitmap CreateAvatar(string name)
        {
            Bitmap bmp = new Bitmap(80, 80);
            Graphics g = Graphics.FromImage(bmp);

            Random rnd = new Random();

            g.Clear(Color.FromArgb(
                rnd.Next(50, 200),
                rnd.Next(50, 200),
                rnd.Next(50, 200)));

            char firstChar = name[0];

            Font font = new Font("Arial", 24, FontStyle.Bold);
            Brush brush = Brushes.White;

            g.DrawString(firstChar.ToString(), font, brush, 20, 20);

            return bmp;
        }

        //
        public static Bitmap CreateFakeQR()
        {
            Bitmap bmp = new Bitmap(60, 60);
            Graphics g = Graphics.FromImage(bmp);

            Random rnd = new Random();

            for (int i = 0; i < 60; i += 5)
            {
                for (int j = 0; j < 60; j += 5)
                {
                    if (rnd.Next(2) == 0)
                        g.FillRectangle(Brushes.Black, i, j, 5, 5);
                }
            }

            return bmp;
        }
    }
}
