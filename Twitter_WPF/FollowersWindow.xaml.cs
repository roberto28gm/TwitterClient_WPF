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
using capa_datos;

namespace Twitter_WPF
{
    /// <summary>
    /// Lógica de interacción para FollowersWindow.xaml
    /// </summary>
    public partial class FollowersWindow : Window
    {
        Negocio negocio;
        List<Follower> followers;
        

        public FollowersWindow(ref Negocio negocio)
        {
            InitializeComponent();
            this.negocio = negocio;
            negocio.ActualizarBd();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            negocio.AnyadirFollowers();
            negocio.ActualizarBd();
            followers = negocio.obtenerFollowers;
            
            dataGrid_Followers.ItemsSource = followers;
        }

        private void dataGrid_Followers_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Follower f = (Follower) dataGrid_Followers.SelectedItem;
            img_foto.Source = new BitmapImage(new Uri(f.imagen));
            label_nombre.Content = f.nombre;
            label_usuario.Content = "@" + f.nombreUsuario;
            label_seguidores.Content = f.seguidores + " Seguidores";
            label_descripcion.Content = f.descripcion;
            label_localizacion.Content = f.localizacion;
            label_fecha.Content = f.fechaCreacion;
        }
    }
}
