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

            bool keepRunning = true;
            while (keepRunning)
            {
                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        Citizen user = login.AuthenticatedUser;

                        using (DashboardForm dashboard = new DashboardForm(user))
                        {
                            if (dashboard.ShowDialog() != DialogResult.OK)
                            {
                                keepRunning = false;
                            }
                        }
                    }
                    else
                    {
                        keepRunning = false;
                    }
                }
            }
        }
    }
}

