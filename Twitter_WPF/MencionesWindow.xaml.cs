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
using Tweetinvi;
using Tweetinvi.Parameters;

namespace Twitter_WPF
{
    /// <summary>
    /// Lógica de interacción para MencionesWindow.xaml
    /// </summary>
    public partial class MencionesWindow : Window
    {
        Negocio negocio;
        List<Mencion> menciones;
        List<MiTweet> tweets;

        public MencionesWindow(ref Negocio negocio)
        {
            InitializeComponent();
            this.negocio = negocio;
            negocio.ActualizarBd();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            negocio.AnyadirMenciones();
            negocio.AnyadirTweets();
            tweets = negocio.obtenerTweets;

            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();

            var menciones = user.GetMentionsTimeline();
            dataGrid_Menciones.ItemsSource = menciones;
        }

        private void dataGrid_Menciones_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            textBlock_mencion.Text = dataGrid_Menciones.SelectedItem.ToString();
        }

        private void btn_Retweet_Click(object sender, RoutedEventArgs e)
        {
            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();

            var tweets = user.GetMentionsTimeline();

            foreach(var t in tweets)
            {
                if(dataGrid_Menciones.SelectedItem.ToString().Contains(t.Text))
                {
                    var retweet = Tweet.PublishRetweet(t.Id);
                    MessageBox.Show("Tweet Retweeteado");
                }
            }

        }

        private void btn_Favorito_Click(object sender, RoutedEventArgs e)
        {
            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();

            var tweets = user.GetMentionsTimeline();

            foreach (var t in tweets)
            {
                if (dataGrid_Menciones.SelectedItem.ToString().Contains(t.Text))
                {
                    var retweet = Tweet.FavoriteTweet(t.Id);
                    MessageBox.Show("Tweet marcado como favorito.");
                }
            }
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {
            textBox_mensaje.Text = "";
        }

        private void btn_contestar_Click(object sender, RoutedEventArgs e)
        {
            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();

            var tweets = user.GetMentionsTimeline();

            foreach (var t in tweets)
            {
                if (dataGrid_Menciones.SelectedItem.ToString().Contains(t.Text))
                {
                    var tweet = Tweet.PublishTweetInReplyTo(
                        textBox_mensaje.Text, t.Id);
                    MessageBox.Show("Tweet Enviado.");
                }
            }
        }


    }
}
