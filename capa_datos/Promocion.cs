using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
    [Table("Promocion")]
    class Promocion
    {
        [PrimaryKey]
        public long idPromocion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaDese { get; set; }
        public DateTime fechaHasta { get; set; }
        public long idUsu1Follow { get; set; }
        public long idTweetRetweet { get; set; }
        public bool finalizada { get; set; }

        public Promocion()
        {

        }

        public Promocion(long idPromocion, string nombre, string descripcion, 
            DateTime fechaDese, DateTime fechaHasta, long idUsu1Follow, 
            long idTweetRetweet, bool finalizada)
        {
            this.idPromocion = idPromocion;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaDese = fechaDese;
            this.fechaHasta = fechaHasta;
            this.idUsu1Follow = idUsu1Follow;
            this.idTweetRetweet = idTweetRetweet;
            this.finalizada = finalizada;
        }
    }
}
