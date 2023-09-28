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
using System.Threading;

namespace GuessingGameProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random RNG = new Random(); //Random number generator (Time seed)
        public int SpecialNumber, tries = 5;
        public string PlayerName = "*Blank*", PlayerNumberStr = "*BLANK*", Hint = "*BLANK*";       
        public int PlayerNumber;
        public MainWindow()
        {
            SpecialNumber = RNG.Next(1, 101);
            InitializeComponent();
        }

        private void GuessInputBttn_Click(object sender, RoutedEventArgs e)
        {
            PlayerNumberStr = GuessInput.Text;            
            if (int.Parse(PlayerNumberStr) <= 100 && int.Parse(PlayerNumberStr) >= 1)
            {
                tries--;
                PlayerNumber = int.Parse(PlayerNumberStr);
                PlayerNumberStr = GuessInput.Text + " (Previous guess)";
                GuessInput.Clear();
                GameContent();
            }
            else 
            {
                GuessInput.Clear();
                MessageBox.Show("Given number is out of bounds", "Warning");
            }
            GuessInput.Clear();

        }
        private void GameContent() {
            

            if (PlayerNumber != SpecialNumber && PlayerNumber < SpecialNumber && tries > 0)
            {
                Hint = "LOW!";                
                UserInfo.Text = "Player: " + PlayerName + "\n" + "Tries: " + tries.ToString() + "\n" + "Hint: Your number is "+ Hint + "\n" + "Number: " + PlayerNumberStr;
            }
            else if (PlayerNumber != SpecialNumber && PlayerNumber > SpecialNumber && tries > 0)
            {
                Hint = "HIGH!";                
                UserInfo.Text = "Player: " + PlayerName + "\n" + "Tries: " + tries.ToString() + "\n" + "Hint: Your number is " + Hint + "\n" + "Number: " + PlayerNumberStr;
            }
            else if (PlayerNumber == SpecialNumber)
            {
                UserInfo.Text = "Congratulations " + PlayerName + " you guessed the number " + "with " + tries.ToString() + " tries  left." + "\n" + "(Hidden number: " + SpecialNumber + ")";
                NameChangeBttn.IsEnabled = false;
                GuessInputBttn.IsEnabled = false;
            }
            else if (tries <= 0) {
                UserInfo.Text = "Player: " + PlayerName + "\n" + "Tries: YOU HAVE RUN OUT OF TRIES!" + "\n" + "Hidden number: " + SpecialNumber;
                NameChangeBttn.IsEnabled = false;
                GuessInputBttn.IsEnabled = false;
            }
            
        }

        private void NameChangeBttn_Click(object sender, RoutedEventArgs e)
        {
            PlayerName = UnameTextBox.Text;
            UnameTextBox.Clear();
            UserInfo.Text = "Player: " + PlayerName + "\n" + "Tries: " + tries.ToString() + "\n" + "Hint: Your number is "+ Hint + "\n" + "Number: " + PlayerNumberStr;
        }
    }
}
