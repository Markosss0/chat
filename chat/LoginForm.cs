using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace chat
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameLogin.Text;

            try
            {
                string connectionString = "Data Source=DESKTOP-4U04D5N\\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        MessageBox.Show("Вход выполнен успешно!");

                        // Переход на форму Contacts
                        Contacts contactsForm = new Contacts(username);
                        contactsForm.SetCurrentUsername(username); // Устанавливаем текущий логин в Label на форме Contacts
                        contactsForm.Show();
                        this.Hide(); // Скрываем текущую форму
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

    }
}
