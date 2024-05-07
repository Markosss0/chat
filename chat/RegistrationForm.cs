using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat
{
    public partial class RegistrationForm : Form
    {

        public RegistrationForm()
        {
            InitializeComponent();
        }


        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Закрытие всего приложения
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string username = Username.Text;

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName) && !string.IsNullOrWhiteSpace(username))
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-4U04D5N\\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string checkUsernameQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                        SqlCommand checkUsernameCommand = new SqlCommand(checkUsernameQuery, connection);
                        checkUsernameCommand.Parameters.AddWithValue("@Username", username);

                        int usernameCount = (int)checkUsernameCommand.ExecuteScalar();

                        if (usernameCount > 0)
                        {
                            MessageBox.Show("Этот юзернейм уже используется. Пожалуйста, выберите другой.");
                        }
                        else
                        {
                            string insertQuery = "INSERT INTO Users (FirstName, LastName, Username) VALUES (@FirstName, @LastName, @Username)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                            insertCommand.Parameters.AddWithValue("@LastName", lastName);
                            insertCommand.Parameters.AddWithValue("@Username", username);

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Регистрация успешно завершена!");
                                this.Hide();
                                Contacts contacts = new Contacts(username); // Передаем логин нового пользователя
                                contacts.SetCurrentUsername(username); // Устанавливаем логин в Label на форме Contacts
                                contacts.Show();
                                UserManager.CurrentUsername = username;
                            }


                            else
                            {
                                MessageBox.Show("Ошибка при регистрации!");
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
        }











        private void ToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
