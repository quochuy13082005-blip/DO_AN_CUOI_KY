using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUOI_KY
{
    internal static class Program
    {
        public static BinarySearchTree Tree = new BinarySearchTree();

        [STAThread]
        static void Main()
        {
            CitizenSeeder.Seed(Tree);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                LoginForm login = new LoginForm();
                DialogResult loginResult = login.ShowDialog();

                if (loginResult == DialogResult.OK)
                {
                    Citizen user = login.AuthenticatedUser;
                    login.Dispose(); 

                    // Mở Dashboard
                    DashboardForm dashboard = new DashboardForm(user);
                    DialogResult dashResult = dashboard.ShowDialog();

                    if (dashResult == DialogResult.OK)
                    {
                        dashboard.Dispose();
                        continue;
                    }
                    else
                    {
                        dashboard.Dispose();
                        break;
                    }
                }
                else
                {
                    login.Dispose();
                    break;
                }
            }
        }
    }
}
