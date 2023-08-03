// Roberto Garcia Marcos
// Proyecto Desarrollo Interfaces
// Capa de Datos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace capa_datos
{
    public class BD
    {
        private SQLiteConnection _bd;

        public BD()
        {
            _bd = new SQLiteConnection("BaseDatos_Twitter_WPF.db");
            _bd.CreateTable<UserApp>();
            //_bd.CreateTable<TweetProgramado>();
            _bd.CreateTable<MiTweet>();
            _bd.CreateTable<Follower>();
            _bd.CreateTable<Mencion>();
            _bd.CreateTable<TweetMencion>();
        }

        public int AnyadirTweet(MiTweet tweet)
        {
            try
            {
                _bd.Insert(tweet);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public int EliminarTweet(MiTweet tweet)
        {
            try
            {
                _bd.Delete(tweet);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public List<MiTweet> LeerTweets()
        {
            List<MiTweet> c = new List<MiTweet>(); ;

            // De esta forma leemos toda la tabla
            TableQuery<MiTweet> aux = _bd.Table<MiTweet>();

            for (int i = 0; i < aux.Count(); i++)
            {
                c.Add(aux.ElementAt(i));
            }

            return c;
        }

        public List<UserApp> LeerUsuarios()
        {
            List<UserApp> c = new List<UserApp>(); ;
            TableQuery<UserApp> aux = _bd.Table<UserApp>();

            for (int i = 0; i < aux.Count(); i++)
            {
                c.Add(aux.ElementAt(i));
            }

            return c;
        }

        public List<Follower> LeerFollowers()
        {
            List<Follower> c = new List<Follower>(); ;
            TableQuery<Follower> aux = _bd.Table<Follower>();

            for (int i = 0; i < aux.Count(); i++)
            {
                c.Add(aux.ElementAt(i));
            }

            return c;
        }

        public int AnyadirUsuario(UserApp usuario)
        {
            try
            {
                _bd.Insert(usuario);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public int AnyadirFollower(Follower follower)
        {
            try
            {
                _bd.Insert(follower);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        // Menciones
        public int AnyadirMencion(Mencion mencion)
        {
            try
            {
                _bd.Insert(mencion);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public List<Mencion> LeerMenciones()
        {
            List<Mencion> c = new List<Mencion>(); ;
            TableQuery<Mencion> aux = _bd.Table<Mencion>();

            for (int i = 0; i < aux.Count(); i++)
            {
                c.Add(aux.ElementAt(i));
            }

            return c;
        }

        public int EliminarMencion(Mencion mencion)
        {
            try
            {
                _bd.Delete(mencion);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        // Tweet Menciones
        public int AnyadirTweetMencion(TweetMencion twMencion)
        {
            try
            {
                _bd.Insert(twMencion);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }

        public List<TweetMencion> LeerTweetsMenciones()
        {
            List<TweetMencion> c = new List<TweetMencion>(); ;
            TableQuery<TweetMencion> aux = _bd.Table<TweetMencion>();

            for (int i = 0; i < aux.Count(); i++)
            {
                c.Add(aux.ElementAt(i));
            }

            return c;
        }

        public int EliminarTweetMencion(TweetMencion twMencion)
        {
            try
            {
                _bd.Delete(twMencion);
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }
        
    }

}
