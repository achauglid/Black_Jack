using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Deck
    {
        public String success { get; set; }
        public String deck_id { get; set; }

        public cards[] cards = new cards[1];
        public int remaining { get; set; }



        public string displayImg()
        {
            String msg = "";

            foreach (var item in cards)
            {
                msg += $"\n{item.image}";
            }
            return msg;

        }

        public string getValue()
        {
            string val = "";
            foreach (var item in cards)
            {
                if (item.value == "ACE")
                {
                    val = "2000";
                }
                else if (item.value == "JACK")
                {
                    val = "10";

                }
                else if (item.value == "QUEEN")
                {
                    val = "10";
                }
                else if (item.value == "KING")
                {
                    val = "10";
                }
                else
                {
                    val += $"\n{item.value}";
                }


            }
            return val;

        }

        public string getSuit()
        {
            string suit = "";
            foreach (var item in cards)
            {
                suit += $"\n{item.suit}";
            }
            return suit;

        }



    }


    public class cards
    {
        public string code { get; set; }
        public String image { get; set; }
        public images imagesO { get; set; }
        public String value { get; set; }
        public String suit { get; set; }


    }

    public class images
    {
        public String svg { get; set; }
        public String png { get; set; }

    }

}