using LRAdvanced.Domain.Dtos;
using LRAdvanced.Service.Services;
using LRAdvanced.Service.Singeltons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LRAdvanced.UI
{
    public partial class VerifyEmailPage : Form
    {
        public VerifyEmailPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void thatsAll_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            if (textBox1.Text == CurrentUserSingelton.Instance.VerifyCode)
            {
                if (await userService.CreateUser(CurrentUserSingelton.Instance))
                {
                    var sing = CurrentUserSingelton.Instance;
                    var user = new LoginDto() { Email = sing.Email, Password = sing.Password };
                    File.WriteAllText(@"../../../Assets/Memory/localAccountsHistory.json", JsonConvert.SerializeObject(user));
                    LoginPage main = new LoginPage();
                    main.Show();
                    this.Hide();
                }
                else MessageBox.Show("Something went wrong");
            }
        }

        private void VerifyEmailPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
