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
using Microsoft.VisualBasic;


namespace chat
{
    public partial class Contacts : Form
    {
        private string currentUser;



        public Contacts()
        {
            InitializeComponent();
        }

        public Contacts(string username) : this()
        {
            currentUser = username;
            SetCurrentUsername(username); // Устанавливаем логин в Label на форме Contacts
            LoadContacts(); // Загружаем контакты после инициализации формы
        }

        public void SetCurrentUsername(string username)
        {
            CurrentUsername.Text = username;
        }


        private void addContactButton_Click(object sender, EventArgs e)
        {
            string contactUsername = Microsoft.VisualBasic.Interaction.InputBox("Введите юзернейм пользователя, которого вы хотите добавить в контакты:", "Добавление контакта", "");
            if (!string.IsNullOrWhiteSpace(contactUsername))
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-4U04D5N\\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string currentUser = CurrentUsername.Text; // Значение из Label CurrentUsername

                        // Проверяем, есть ли уже такой контакт в базе данных
                        string checkContactQuery = "SELECT COUNT(*) FROM UserContacts WHERE ContactUsername = @ContactUsername AND UserId = (SELECT UserId FROM Users WHERE Username = @Username)";
                        SqlCommand checkContactCommand = new SqlCommand(checkContactQuery, connection);
                        checkContactCommand.Parameters.AddWithValue("@ContactUsername", contactUsername);
                        checkContactCommand.Parameters.AddWithValue("@Username", currentUser);
                        int existingCount = Convert.ToInt32(checkContactCommand.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("Такой контакт уже существует!");
                            return; // Прекращаем выполнение метода
                        }

                        // Получаем UserId текущего пользователя по его Username
                        string getUserIdQuery = "SELECT UserId FROM Users WHERE Username = @Username";
                        SqlCommand getUserIdCommand = new SqlCommand(getUserIdQuery, connection);
                        getUserIdCommand.Parameters.AddWithValue("@Username", currentUser);
                        int currentUserId = Convert.ToInt32(getUserIdCommand.ExecuteScalar());

                        // Добавляем контакт в базу данных
                        string insertContactQuery = "INSERT INTO UserContacts (UserId, ContactUsername) VALUES (@UserId, @ContactUsername)";
                        SqlCommand insertContactCommand = new SqlCommand(insertContactQuery, connection);
                        insertContactCommand.Parameters.AddWithValue("@UserId", currentUserId);
                        insertContactCommand.Parameters.AddWithValue("@ContactUsername", contactUsername);
                        int rowsAffected = insertContactCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Контакт успешно добавлен!");
                            LoadContacts(); // Обновляем список контактов после добавления нового контакта
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении контакта!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Введите юзернейм!");
            }
        }





        private void LoadContacts()
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-4U04D5N\\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Загрузка контактов для текущего пользователя
                    string query = "SELECT ContactUsername FROM UserContacts WHERE UserId = (SELECT UserId FROM Users WHERE Username = @Username)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", currentUser);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        contactsListBox.Items.Clear(); // Очищаем список перед загрузкой новых данных

                        while (reader.Read())
                        {
                            string contactUsername = reader.GetString(0);
                            contactsListBox.Items.Add(contactUsername); // Добавление контакта в ListBox
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }






        private void Contacts_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-4U04D5N\\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Загрузка контактов для текущего пользователя
                    string query = "SELECT ContactUsername FROM UserContacts WHERE UserId = (SELECT UserId FROM Users WHERE Username = @Username)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", currentUser);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string contactUsername = reader.GetString(0);
                            contactsListBox.Items.Add(contactUsername); // Добавление контакта в ListBox
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


        private void StartChatButton_Click(object sender, EventArgs e)
        {
            string selectedContact = contactsListBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedContact))
            {
                Chat chatForm = new Chat(selectedContact);
                chatForm.Show();
            }
            else
            {
                MessageBox.Show("Выберите контакт для начала чата.");
            }

        }

        private void DeleteContact_Click(object sender, EventArgs e)
        {
            string selectedContact = contactsListBox.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedContact))
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-4U04D5N\\SQLEXPRESS;Initial Catalog=chat;Integrated Security=True;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string ownerUsername = CurrentUsername.Text; // Получаем юзернейм текущего пользователя

                        // Измененный запрос для удаления контакта
                        string deleteQuery = "DELETE FROM UserContacts WHERE ContactUsername = @ContactUsername AND UserId = (SELECT UserId FROM Users WHERE Username = @Username)";
                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@ContactUsername", selectedContact);
                        command.Parameters.AddWithValue("@Username", ownerUsername);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Контакт успешно удален!");
                            contactsListBox.Items.Remove(selectedContact); // Удаляем контакт из списка
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удалении контакта!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите контакт для удаления.");
            }
        }




    }
}
