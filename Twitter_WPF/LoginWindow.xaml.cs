using capa_datos;
using capa_negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Twitter_WPF
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private int intentos;
        Negocio negocio;

        public LoginWindow()
        {
            InitializeComponent();
            negocio = new Negocio();
            // mensaje de error
            label_error.Content = "Error: El usuario no es correcto";
            label_error.Visibility = Visibility.Hidden;

            // intentos iniciales
            intentos = 2;
            label_intentos.Content = "Intentos " + intentos;
            label_intentos.Visibility = Visibility.Hidden;
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
            label_intentos.Content = "Intentos " + intentos;
            string usuarioStr = textBox_usuario.Text;
            string passwordStr = passBox_password.Password;

            if (usuarioStr == "administrador" && passwordStr == "admin")
            {
                MainWindow mainWindow = new MainWindow(ref negocio);
                this.Hide();
                mainWindow.Show();
            }
            else if (ComprobarUsuario())
            {
                MainWindow mainWindow = new MainWindow(ref negocio);
                this.Hide();
                mainWindow.Show();
            }
            else
            {
                // mostrar error
                intentos--;
                label_error.Visibility = Visibility.Visible;
                label_intentos.Visibility = Visibility.Visible;

                // textBox_usuario.Text = "";
                passBox_password.Password = "";
            }

            if (intentos < 0)
            {
                Environment.Exit(0);
            }
            
        }
        
        private bool ComprobarUsuario()
        {
            bool correcto = false;
            foreach (UserApp user in negocio.users)
            {
                if (textBox_usuario.Text.Equals(user.usuario) &&
                    passBox_password.Password.Equals(user.password))
                {
                    negocio.usuario = user;
                    correcto = true;
                }
            }
            return correcto;
        }
    }
}
