using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
    [Table("TweetPromocion")]
    class TweetPromocion
    {
        public long idTweet { get; set; }
        public long idPromocion { get; set; }

        public TweetPromocion()
        {

        }

        public TweetPromocion(long idTweet, long idPromocion)
        {
            this.idTweet = idTweet;
            this.idPromocion = idPromocion;
        }
    }
}
