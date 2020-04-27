using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Austin Hauglid MIS 3033
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Deck newDeck = new Deck();

            newDeck.getDeck();
            lsttest.Items.Add(newDeck.getDeck());
            lsttest.Items.Add(newDeck.remaining);


           // Card newCard = new Card();

            //lsttest.Items.Add(newCard.drawCard(newDeck.getDeck()));

        }
    }
}
