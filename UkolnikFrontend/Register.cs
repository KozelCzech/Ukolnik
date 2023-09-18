using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace UkolnikFrontend
{
    public partial class Register : Form
    {

        public Register()
        {
            InitializeComponent();
            var _client = new HttpClient();
        }
        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string email = EmailBox.Text;
            string password = PasswordBox.Text;

            bool registrationSuccess = await RegisterUserAsync(username, email, password);

            if (registrationSuccess)
            {
                //MessageBox.Show("Registration successful");
                
            }
            else
            {
                MessageBox.Show("Registration failed");
            }
        }
        public async Task<bool> RegisterUserAsync(string username, string email, string password)
        {
            try
            {
                var apiUrl = "http://localhost:5000/api/controller/register";

                var requestData = new
                {
                    username,
                    email,
                    password
                };

                var requestJson = JsonSerializer.Serialize(requestData);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Login login = new Login();
                        await login.LoginUserAsync(username, password);
                        if (login.IsLoggedIn)
                        {
                            Ukolnik ukolnik = new Ukolnik();
                            ukolnik.Show();
                            this.Hide();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        // Handle unsuccessful registration here
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                return false;
            }
        }

        private void LoginRedirect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            this.Hide();
        }
    }
}
