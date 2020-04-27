using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        public int remaining { get; set; }
        public Boolean sucess { get; set; }
        public string deckID { get; set; }
        public Boolean shuffled { get; set; }
        


        public string getDeck()
        {
            string url = "https://deckofcardsapi.com/api/deck/new/";
            string json = new WebClient().DownloadString(url);

            Deck newDeck = new Deck();

            newDeck = JsonConvert.DeserializeObject<Deck>(json);


            return deckID;
        }


    }
}
