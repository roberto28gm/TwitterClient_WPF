using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace capa_datos
{
    [Table("MiTweet")]
    public class MiTweet
    {
        [PrimaryKey]
        public long id { get; set; }
        [MaxLength(280)]
        public string text { get; set; }
        public string time { get; set; }
        public int retweets { get; set; }
        public int favourites { get; set; }
        public int quote { get; set; }
        public long user { get; set; }

        public MiTweet()
        {

        }

        public MiTweet(long id, string text, string time,
            int retweets, int favourites, int quote, long user)
        {
            this.id = id;
            this.text = text;
            this.time = time;
            this.retweets = retweets;
            this.favourites = favourites;
            this.quote = quote;
            this.user = user;
        }
    }
}
