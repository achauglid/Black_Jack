using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  /*  class Card
    {
        public string deckID { get; set; }
        public string value { get; set; }
        public string png { get; set; }
        public int remaining { get; set; }





        public string drawCard(string deckID)
        {
            this.deckID = deckID;

            String url = "https://deckofcardsapi.com/api/deck//draw/?count=1";
            String adjustedUrl = url.Insert(35, deckID);

            string json = new WebClient().DownloadString(adjustedUrl);

            Card newCard = new Card();

            newCard = JsonConvert.DeserializeObject<Card>(json);


            return png;
        }

   
    } */
}
