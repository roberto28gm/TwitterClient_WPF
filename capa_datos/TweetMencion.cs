using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capa_datos
{
    [Table("TweetMencion")]
    public class TweetMencion
    {
        public long idTweet { get; set; }
        public long idMencion { get; set; }

        public TweetMencion()
        {

        }

        public TweetMencion(long idTweet, long idMencion)
        {
            this.idTweet = idTweet;
            this.idMencion = idMencion;
        }
    }
}
