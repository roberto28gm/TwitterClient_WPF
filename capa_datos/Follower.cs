using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace capa_datos
{
    [Table("Follower")]
    public class Follower
    {
        [PrimaryKey]
        public long id { get; set; }
        public string nombreUsuario { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string imagen { get; set; }
        public long seguidores { get; set; }
        public long amigos { get; set; }
        public string localizacion { get; set; }
        public bool siguiendo { get; set; }


        public Follower()
        {

        }

        public Follower(long id, string nombreUsuario, string nombre, 
            string descripcion, DateTime fechaCreacion, string imagen, 
            long seguidores, long amigos, string localizacion, bool siguiendo)
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaCreacion = fechaCreacion;
            this.imagen = imagen;
            this.seguidores = seguidores;
            this.amigos = amigos;
            this.localizacion = localizacion;
            this.siguiendo = siguiendo;
        }

        public Follower(string nombreUsuario, string nombre, string imagen)
        {
            this.nombre = nombre;
            this.nombreUsuario = nombreUsuario;
            this.imagen = imagen;
        }
    }
}
