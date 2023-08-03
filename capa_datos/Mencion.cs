using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
    [Table("Mencion")]
    public class Mencion
    {
        [PrimaryKey]
        public long idMencion { get; set; }
        public string texto { get; set; }

        public Mencion()
        {

        }

        public Mencion(long idMencion, string texto)
        {
            this.idMencion = idMencion;
            this.texto = texto;
        }
    }
}
