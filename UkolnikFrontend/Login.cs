using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace UkolnikFrontend
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Hide();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            bool loginSuccess = await LoginUserAsync(username, password);

            if (loginSuccess)
            {
                Ukolnik ukolnik = new Ukolnik();
                ukolnik.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            try
            {
                var apiUrl = "http://localhost:5000/api/controller/login";

                var requestData = new
                {
                    username,
                    password
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        IsLoggedIn = true;
                        return true;
                    }
                    else
                    {
                        IsLoggedIn = false;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public bool IsLoggedIn { get; set; }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();

            this.Hide();
        }
    }
}
