using LRAdvanced.DataAccess.Repositories;
using LRAdvanced.Service.Common.Attributes;
using LRAdvanced.Service.Common.EmailService;
using LRAdvanced.Service.Services;
using LRAdvanced.Service.Singeltons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRAdvanced.UI
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            if (textBox3.Text.Length > 0)
            {
                button1.Visible = true;
                button2.Visible = false;
            }
            else button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '\0';
            if (textBox3.Text.Length > 0)
            {
                button2.Visible = true;
                button1.Visible = false;
            }
            else button2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
                eyeButton.Visible = true;
            else eyeButton.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
                button1.Visible = true;
            else button1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void thatsAll_Click(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            var result = EmailAttribute.IsValid(textBox1.Text);
            if (result.Item1&&InputAtributes.IsValid(textBox2.Text)&&InputAtributes.IsValid(textBox3.Text))
            {
                if (textBox2.Text != textBox3.Text)
                    MessageBox.Show("Passwords aren't same");
                else
                {
                    if (await userRepository.GetByEmailAsync(textBox1.Text) == null)
                    {
                        var emailResult = EmailService.VerifMail(textBox1.Text);
                        if (emailResult.rand != "0")
                        {
                            CurrentUserSingelton.Instance = new Service.Dtos.RegisterDto() { Email = textBox1.Text, Password = textBox2.Text, VerifyCode = emailResult.rand };
                            VerifyEmailPage verifyEmail = new VerifyEmailPage();
                            verifyEmail.Show();
                            this.Hide();
                        }
                        else MessageBox.Show(emailResult.status);
                    }
                    else
                        MessageBox.Show("User with this email already exists");
                }
            }
            else
                MessageBox.Show("You should input valid email and only Latin - Cyrillic letters with number minimum 8 charackters contains one uppercase letter and a number");

        }
    }
}
