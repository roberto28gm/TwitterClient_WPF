// Roberto Garcia Marcos

using System.Windows;
using Tweetinvi;
using Tweetinvi.Parameters;
using Tweetinvi.Core.Parameters;
using System.Collections.Generic;
using capa_negocio;
using System;
using System.Windows.Media.Imaging;

namespace Twitter_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Negocio negocio;
        SalirWindow salirWindow;
        FollowersWindow followersWindow;
        FollowersSiguiendoWindow followersSiguiendoWindow;
        MencionesWindow mencionesWindow;

        public MainWindow(ref Negocio negocio)
        {
            InitializeComponent();
            this.negocio = negocio;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cargarTweetsDataGrid();
            cargarDatosUsuario();
        }

        // Archivo - Salir
        private void Click_Salir(object sender, RoutedEventArgs e)
        {
            salirWindow = new SalirWindow();
            salirWindow.Show();
        }



        // -------------------------
        // FOLLOWERS
        private void Click_Followers_Todos(object sender, RoutedEventArgs e)
        {
            // mostrar todos los followers
            followersWindow = new FollowersWindow(ref negocio);
            followersWindow.Show();
        }

        private void Click_Followers_NoSigo(object sender, RoutedEventArgs e)
        {
            // mostrar followers que no sigo
            followersSiguiendoWindow = new FollowersSiguiendoWindow(ref negocio);
            followersSiguiendoWindow.Show();
        }

        private void Click_Followers_NoMeSiguen(object sender, RoutedEventArgs e)
        {
            // mostrar followers que ya no me siguen
        }





        // -------------------------
        // MENCIONES
        private void Click_Menciones_Recibir(object sender, RoutedEventArgs e)
        {
            RecibirMenciones();
        }

        private void Click_Menciones_Gestionar(object sender, RoutedEventArgs e)
        {
            // gestionar menciones
            mencionesWindow = new MencionesWindow(ref negocio);
            mencionesWindow.Show();
        }

        private void Click_Menciones_Eliminar(object sender, RoutedEventArgs e)
        {
            // eliminar menciones
            EliminarMenciones();
        }





        // -------------------------
        // PROMOCIONES
        private void Click_Promociones_Alta(object sender, RoutedEventArgs e)
        {
            // alta en promocion
        }

        private void Click_Promociones_Gestion(object sender, RoutedEventArgs e)
        {
            // gestionar promociones
        }




        // Funciones de apoyo
        private void RecibirMenciones()
        {
            negocio.AnyadirTweets();
            negocio.AnyadirMenciones();
            MessageBox.Show("Menciones guardadas con exito.");
        }

        private void EliminarMenciones()
        {
            negocio.EliminarTweets();
            negocio.EliminarMenciones();
            MessageBox.Show("Menciones eliminadas con exito.");
        }

        private void dataGrid_Tweets_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
        {

        }

        private void cargarTweetsDataGrid()
        {
            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();
            var tweets = user.GetHomeTimeline();

            dataGrid_Tweets.ItemsSource = tweets;
        }

        private void cargarDatosUsuario()
        {
            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();
            label_usuario.Content = "@" + user.ScreenName;
            label_nombre.Content = user.Name;
            img_usuario.Source = new BitmapImage(new Uri(user.ProfileImageUrl400x400));
        }
    }
}
