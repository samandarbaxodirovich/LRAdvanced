using LRAdvanced.Domain.Dtos;
using LRAdvanced.Service.Common.Attributes;
using LRAdvanced.Service.Dtos;
using LRAdvanced.Service.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRAdvanced.UI
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            ValuesDrive();

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
                eyeButton.Visible = true;
            else eyeButton.Visible = false;
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void eyeButton_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
            if (textBox2.Text.Length > 0)
            {
                hideButton.Visible = true;
                eyeButton.Visible = false;
            }
            else hideButton.Visible = false;
        }
        private void hideButton_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            if (textBox2.Text.Length > 0)
            {
                eyeButton.Visible = true;
                hideButton.Visible = false;
            }
            else eyeButton.Visible = false;
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            UserService _user = new UserService();
            var result = EmailAttribute.IsValid(textBox1.Text);
            if (result.Item1)
            {
                if (await _user.IsValid(textBox1.Text, textBox2.Text))
                {
                    if(rememberMe.Checked)
                    {
                        var user = new Domain.Dtos.LoginDto() { Email = textBox1.Text, Password = textBox2.Text };
                        File.WriteAllText(@"../../../Assets/Memory/localAccountsHistory.json", JsonConvert.SerializeObject(user));
                    }
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
                else MessageBox.Show("Email or Password wrong");
            }
            else MessageBox.Show(result.Item2);
        }

        private void register_Click(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Hide();
        }

        private void rememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ValuesDrive()
        {
            try
            {
                string adress = "../../../Assets/Memory/localAccountsHistory.json";
                var user = JsonConvert.DeserializeObject<Domain.Dtos.LoginDto>(File.ReadAllText(adress));
                textBox1.Text = user.Email;
                textBox2.Text = user.Password;
            }
            catch { }
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
