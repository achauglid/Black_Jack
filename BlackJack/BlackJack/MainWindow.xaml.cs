using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Deck newDeck = new Deck();
        public static String adjustedUrl;
        public static double NumberCount = 0;
        public static double dealerCount = 0;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Card newCard = new Card();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(@"https://deckofcardsapi.com/api/deck/new/").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    newCard = JsonConvert.DeserializeObject<Card>(content);

                }
            }


            lst.Items.Add(newCard.deck_id);
            lst.Items.Add(newCard.remaining);
            lst.Items.Add(newCard.success);
            lst.Items.Add(newCard.shuffled);

            string deckID = newCard.deck_id;

            string url = "https://deckofcardsapi.com/api/deck//draw/?count=1";
            adjustedUrl = url.Insert(36, deckID);


            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(adjustedUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    newDeck = JsonConvert.DeserializeObject<Deck>(content);

                }
            }

            lst.Items.Add(newDeck.deck_id);


            String newCardUrl = newDeck.displayImg();

            lst.Items.Add(newCardUrl);



            var fullFilePath = newCardUrl;
            card.Source = (new ImageSourceConverter()).ConvertFromString(fullFilePath) as ImageSource;          // loading first player card

            dealerCardOne.Source = (new ImageSourceConverter()).ConvertFromString(getNewDealerCard()) as ImageSource;          // loading DEALER player card

            dealerCardTwo.Source = (new ImageSourceConverter()).ConvertFromString(getNewDealerCard()) as ImageSource;          // loading DEALER player card
            lst.Items.Add("dealer count: " + dealerCount);
        }

        private void btnNewCard_Click(object sender, RoutedEventArgs e)
        {

            var image = new Image();
            var fullFilePath = getNewCard();
            lst.Items.Add(fullFilePath);


            cardTwo.Source = (new ImageSourceConverter()).ConvertFromString(getNewCard()) as ImageSource;  // loading 2nd player card




            lst.Items.Add("num ct: " + NumberCount);

        }

        private void btnHold_Click(object sender, RoutedEventArgs e)
        {

        }

        public static String getNewCard() // gives a new card
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(adjustedUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    newDeck = JsonConvert.DeserializeObject<Deck>(content);

                }
            }

            String newCardUrl = newDeck.displayImg();

            NumberCount += Convert.ToDouble(newDeck.getValue());


            return newCardUrl;

        }
        public static String getNewDealerCard() // gives a new card
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(adjustedUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    newDeck = JsonConvert.DeserializeObject<Deck>(content);

                }
            }

            String newCardUrl = newDeck.displayImg();
            dealerCount += Convert.ToDouble(newDeck.getValue());


            return newCardUrl;

        }
    }
}