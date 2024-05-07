using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using chat;

public class SimpleChatClient : Form
{

    public SimpleChatClient()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        

    }



    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        RegistrationForm registrationForm = new RegistrationForm();
        registrationForm.FormClosed += new FormClosedEventHandler(registrationForm_FormClosed);
        registrationForm.Show();


        Application.Run();
    }

    private static void registrationForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }
}
