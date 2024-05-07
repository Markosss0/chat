using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat
{
    public partial class Chat : Form
    {
        private string contactName;

        public Chat(string contactName)
        {
            InitializeComponent();
            this.contactName = contactName;
            this.Text = "Чат с " + contactName;

            sendButton.Click += sendButton_Click;
            messageBox.KeyDown += messageBox_KeyDown;
        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Отправляем сообщение, если пользователь нажимает Enter
            if (e.KeyCode == Keys.Enter)
            {
                sendButton_Click(sender, e);
                // Отмечаем событие как обработанное, чтобы не возникала лишняя обработка нажатия клавиши Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public Chat()
        {
            InitializeComponent();
        }

        private void chatBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = messageBox.Text;
            if (!string.IsNullOrEmpty(message))
            {
                // Добавляем сообщение в окно чата
                chatBox.Items.Add($"Вы: {message}");
                // Очищаем текстовое поле после отправки сообщения
                messageBox.Clear();
            }
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
