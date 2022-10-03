using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using WordleWPF.ViewModel;


namespace WordleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, bool> _bools = new Dictionary<string, bool>();
        List<string> _displayedGuesses = new List<string>();
        List<TextBox> boxList = new List<TextBox>();
        List<Button> keyboard = new List<Button>();
        WordleViewModel myViewModel;

        public string myGuess;
        public MainWindow()
        {
            InitializeComponent();
            myViewModel = new WordleViewModel();
            myGuess = "";

        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            updateGuessDisplay("");

            //
            await updateLetterTable(false);

        }


        private async void newGame(object sender,RoutedEventArgs e)
        {
            _displayedGuesses.Clear();
           await myViewModel.NewGame();
            await updateLetterTable(true);
        }

        private async Task<bool> updateLetterTable(bool clear)
        {
            List<Object> modelValues = myViewModel.GuessSubmitted();

            Dictionary<string, bool> bools = (Dictionary<string, bool>)modelValues[0];
            int[,] colours = (int[,])modelValues[1];

            getAllTextboxes();
            if (clear == false)
            {
                int box = 0;
                if (bools["validity"] == true)
                {
                    _displayedGuesses.Add(myGuess);
                    updateKeyBoardLetters();
                    for (int y = 0; y < _displayedGuesses.Count; y++)
                    {


                        char[] guess = _displayedGuesses[y].ToCharArray();
                        for (int x = 0; x < guess.Length; x++)
                        {
                            fillBox(boxList[box], guess[x]);
                            ColourBox(boxList[box], colours[y, x]);

                            box++;
                        }
                    }

                    if (bools["gameOver"] == true)
                    {
                        if (bools["victory"] == true) { MessageBox.Show("Congratulations! You Guessed the word!"); }
                        else { MessageBox.Show("Sorry, you lose.."); }
                    }
                }
                else { MessageBox.Show("Wrong input. Please use only english 5 lettter words in the singlular!"); }
            }
            else
            { //Add Code here to reset the game table
                   
            }

            return true;
        }

        private void fillBox(TextBox box, char letter)
        {

            box.Text = $"{letter}";
        }

        private void getAllTextboxes()
        {
            foreach (var child in myGui.Children)
            {
                if (child is TextBox) { boxList.Add((TextBox)child); }
            }
        }

        private void updateKeyBoardLetters()
        {
            foreach (var child in myGui.Children)
            {
                if (child is Button) { keyboard.Add((Button)child); }
                foreach (var button in keyboard)
                {
                    if (button.Name != "Backspace") 
                    {
                        foreach (var guess in _displayedGuesses)
                        {
                            if (guess.Contains(button.Name))
                            {
                                button.Background = Brushes.DarkGray;
                            }
                        }
                        
                    }
                }
            }
        }

        private void Letterbutton_Click(object sender, RoutedEventArgs e)
        {
                //Comment sender.ToString().Split(':')[1] is the name of the letter 
                string letter = sender.ToString().Split(':')[1];
                string returnMessage = myViewModel.LetterPressed(letter);
                myGuess = returnMessage;
                updateGuessDisplay(returnMessage);
                //MessageBox.Show(returnMessage);

        }
            
            

            private void ColourBox(TextBox box, int colour)
            {
                switch (colour)
                {
                    case 3: box.Background = Brushes.DarkGray; break;
                    case 1: box.Background = Brushes.Yellow; break;
                    case 2: box.Background = Brushes.Green; break;
                    default: break;
                }
            }



            private void updateGuessDisplay(string text) { guessDisplay.Text = text; }
    }
} 

