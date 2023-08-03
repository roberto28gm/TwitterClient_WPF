using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace capa_datos
{
    [Table("TweetProgramado")]
    public class TweetProgramado
    {
        [PrimaryKey, AutoIncrement]
        public long id { get; set; }
        public string usuario { get; set; }
        [NotNull]
        public string titulo { get; set; }
        public string texto { get; set; }
        [NotNull]
        public int programado { get; set; }
        public DateTime fechaProgramacion { get; set; }
        public string imagen { get; set; }
        
        public TweetProgramado()
        {

        }

        public TweetProgramado(string usuario, string titulo, string texto, 
            int programado, DateTime fechaProgramacion, string imagen)
        {
            this.usuario = usuario;
            this.titulo = titulo;
            this.texto = texto;
            this.programado = programado;
            this.fechaProgramacion = fechaProgramacion;
            this.imagen = imagen;
        }
    }
}
