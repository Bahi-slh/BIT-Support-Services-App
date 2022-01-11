using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BITDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

       

        public int UserId
        {
            get; set;
        }

        public string Position { get; set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select staffId, position from staff where email=@Username and password =@Password";
            SQLHelper _db = new SQLHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Username", DbType.String);
            objParams[0].Value = this.txtUsername.Text;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.txtPassword.Password.ToString();

            DataTable usersTable = _db.ExecuteSQL(sql, objParams);
            if (usersTable.Rows.Count >= 1)
            {
                this.UserId = Convert.ToInt32(usersTable.Rows[0][0].ToString());
                this.Position = usersTable.Rows[0][1].ToString();
                //if (Position == "Admin")
                //{
                //   new MainWindow(true);

                //    this.Close();
                //    //NavigationService.Navigate(new MainWindow(true));
                //}
                //else if (Position == "Coordinator")
                //{
                //    new MainWindow(false);

                //    this.Close();
                //    //NavigationService.Navigate(new MainWindow(true));
                //}

                MainWindow dashboard = new MainWindow(Position);
                dashboard.Show();
                this.Close();


                //return true;
            }
            else
            {
                MessageBox.Show("Username or password is incorrect.");
            }
        }
    }
}
