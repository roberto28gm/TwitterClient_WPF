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

namespace Twitter_WPF
{
    /// <summary>
    /// Lógica de interacción para FollowersSiguiendoWindow.xaml
    /// </summary>
    public partial class FollowersSiguiendoWindow : Window
    {
        Negocio negocio;
        List<Follower> followers;

        public FollowersSiguiendoWindow(ref Negocio negocio)
        {
            InitializeComponent();
            this.negocio = negocio;
            negocio.ActualizarBd();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            negocio.AnyadirFollowers();
            negocio.ActualizarBd();
            followers = obtenerFollowersSiguiendo();
            btn_seguir.Visibility = Visibility.Hidden;

            dataGrid_Followers.ItemsSource = followers;
        }

        private List<Follower> obtenerFollowersSiguiendo()
        {
            List<Follower> followersSiguiendo = new List<Follower>();
            List<Follower> followersAux = new List<Follower>();

            followersAux = negocio.obtenerFollowers;

            foreach(Follower f in followersAux)
            {
                if(f.siguiendo == false)
                {
                    followersSiguiendo.Add(f);
                }
            }


            return followersSiguiendo;
        }

        private void dataGrid_Followers_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Follower f = (Follower)dataGrid_Followers.SelectedItem;
            img_foto.Source = new BitmapImage(new Uri(f.imagen));
            label_nombre.Content = f.nombre;
            label_usuario.Content = "@" + f.nombreUsuario;
            label_seguidores.Content = f.seguidores + " Seguidores";
            label_descripcion.Content = f.descripcion;
            label_localizacion.Content = f.localizacion;
            label_fecha.Content = f.fechaCreacion;
            btn_seguir.Visibility = Visibility.Visible;
        }

        private void btn_seguir_Click(object sender, RoutedEventArgs e)
        {
            Follower nuevoFollower = (Follower)dataGrid_Followers.SelectedItem;

            Auth.SetUserCredentials(negocio.usuario.consumerKey, negocio.usuario.consumerSecret,
                        negocio.usuario.accessToken, negocio.usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();
            user.FollowUser(nuevoFollower.id);

            negocio.ActualizarBd();
        }
    }
}
