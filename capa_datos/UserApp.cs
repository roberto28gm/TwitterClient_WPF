using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Security.Cryptography;


/*
IDUsuario (Int autonumérico)
Usuario (String)
Contraseña (almacenada en MD5) (32 caracteres)
Email (String)
Nombre (String)
Apellidos (String)
Twitter_ID
ConsumerKey (String)
ConsumerSecret (String)
AccessToken (String)
AccessTokenSecret (String)
*/

namespace capa_datos
{
    [Table("UserApp")]
    public class UserApp
    {
        [PrimaryKey, AutoIncrement]
        public long idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public long twitterID { get; set; }
        public string consumerKey { get; set; }
        public string consumerSecret { get; set; }
        public string accessToken { get; set; }
        public string accessTokenSecret { get; set; }

        public UserApp()
        {

        }

        public UserApp(string usuario, string password, 
            string email, string nombre, string apellidos, 
            long twitterID, string consumerKey, string consumerSecret, 
            string accessToken, string accessTokenSecret)
        {
            this.usuario = usuario;
            this.password = password;
            this.email = email;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.twitterID = twitterID;
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
        }
    }
}
