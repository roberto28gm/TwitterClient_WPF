// Roberto Garcia Marcos
// Proyecto Desarrollo Interfaces
// Capa de Negocio

using System.Collections;
using Tweetinvi;
using capa_datos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace capa_negocio
{
    public class Negocio
    {
        public UserApp usuario { get; set; }
        private BD _bd;
        private List<UserApp> listaUsuarios;
        private List<MiTweet> listaTweets;
        private List<Follower> listaFollowers;
        private List<Mencion> listaMenciones;
        private List<TweetMencion> listaTweetsMenciones;

        public List<MiTweet> obtenerTweets
        {
            get
            {
                return listaTweets;
            }
        }

        public List<UserApp> users
        {
            get
            {
                return listaUsuarios;
            }
        }

        public List<Follower> obtenerFollowers
        {
            get
            {
                return listaFollowers;
            }
        }

        public List<Mencion> obtenerMenciones
        {
            get
            {
                return listaMenciones;
            }
        }

        public List<TweetMencion> obtenerTweetsMenciones
        {
            get
            {
                return listaTweetsMenciones;
            }
        }

        public Negocio()
        {
            _bd = new BD();
            listaUsuarios = _bd.LeerUsuarios();
            listaTweets = _bd.LeerTweets();
            listaFollowers = _bd.LeerFollowers();
            listaMenciones = _bd.LeerMenciones();
            listaTweetsMenciones = _bd.LeerTweetsMenciones();
        }

        public void ActualizarBd()
        {
            listaTweets = _bd.LeerTweets();
            listaUsuarios = _bd.LeerUsuarios();
            listaFollowers = _bd.LeerFollowers();
            listaMenciones = _bd.LeerMenciones();
            listaTweetsMenciones = _bd.LeerTweetsMenciones();
        }

        public void AnyadirTweets()
        {
            Auth.SetUserCredentials(usuario.consumerKey, usuario.consumerSecret,
                        usuario.accessToken, usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();
            var tweets = user.GetUserTimeline();

            foreach (var t in tweets)
            {
                _bd.AnyadirTweet(new MiTweet(t.Id, t.Text, t.CreatedAt.ToString(), 
                    t.RetweetCount, t.FavoriteCount, 0, usuario.idUsuario));
            }
        }

        public int AnyadirTweet(MiTweet tweet)
        {
            int filasAlmacenadas;
            filasAlmacenadas = _bd.AnyadirTweet(tweet);
            listaTweets = _bd.LeerTweets();

            return filasAlmacenadas;
        }

        public int AnyadirUsuario(string usuario, string password, string email,
            string nombre, string apellidos, long twitterID, string consumerKey,
            string consumerSecret, string accesToken, string accesTokenSecret)
        {
            int filasAlmacenadas;

            for (int i = 0; i < users.Count; i++)
            {
                if (usuario == users[i].usuario)
                {
                    return -500;
                }
                password = CodificaMD5(password);
            }
            UserApp p = new UserApp(usuario, password, email, nombre, 
                apellidos, twitterID, consumerKey, consumerSecret, accesToken, 
                accesTokenSecret);
            filasAlmacenadas = _bd.AnyadirUsuario(p);
            listaUsuarios = _bd.LeerUsuarios();

            return filasAlmacenadas;
        }
        

        public string CodificaMD5(string password)
        {
            int i;
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            password = "";
            for (i = 0; i < data.Length; i++)
            {
                password = password + data[i];
            }

            return password;
        }

        public void AnyadirFollowers()
        {
            Auth.SetUserCredentials(usuario.consumerKey, usuario.consumerSecret,
                        usuario.accessToken, usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();
            
            foreach (var f in user.GetFollowers())
            {
                _bd.AnyadirFollower(new Follower(f.Id, f.ScreenName, f.Name,
                    f.Description, f.CreatedAt, f.ProfileImageUrl400x400,
                    f.FollowersCount, f.FriendsCount, f.Location, f.Following));
            }
        }

        public void AnyadirMenciones()
        {
            Auth.SetUserCredentials(usuario.consumerKey, usuario.consumerSecret,
                        usuario.accessToken, usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();

            foreach (var m in user.GetMentionsTimeline()){
                _bd.AnyadirMencion(new Mencion(m.Id, m.Text));
            }
        }

        public void EliminarMenciones()
        {
            Auth.SetUserCredentials(usuario.consumerKey, usuario.consumerSecret,
                        usuario.accessToken, usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();

            foreach (var m in user.GetMentionsTimeline())
            {
                _bd.EliminarMencion(new Mencion(m.Id, m.Text));
            }
        }

        public void EliminarTweets()
        {
            Auth.SetUserCredentials(usuario.consumerKey, usuario.consumerSecret,
                        usuario.accessToken, usuario.accessTokenSecret);
            var user = User.GetAuthenticatedUser();
            var tweets = user.GetUserTimeline();

            foreach (var t in tweets)
            {
                _bd.EliminarTweet(new MiTweet(t.Id, t.Text, t.CreatedAt.ToString(),
                    t.RetweetCount, t.FavoriteCount, 0, usuario.idUsuario));
            }
        }

    }
}
