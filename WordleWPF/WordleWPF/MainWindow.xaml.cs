using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
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
        WordleViewModel myViewModel;

        public string myGuess;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            myViewModel = new WordleViewModel();
            myGuess = "";
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            updateGuessDisplay("");

            //Attempt at error prevention: if you click submit when the game is over, it causes a crash by indexing outside of all collections
            if (_displayedGuesses.Count() >= 6 && !_displayedGuesses.Contains(" ")) { MessageBox.Show("The game is over. Click 'New Game' to play again."); }
            else { await updateLetterTable(false); }

        }


        private async void newGame(object sender,RoutedEventArgs e)
        {
            _displayedGuesses.Clear();
           await myViewModel.NewGame();
            await updateLetterTable(true);
        }


        /// <summary>
        /// Updates the table displaying bprevious
        /// </summary>
        /// <param name="clear"> If true, will erase all content form table</param>
        /// <returns></returns>
        private async Task<bool> updateLetterTable(bool clear)
        {
            ViewModel.GuessHandlingResultList myResults = myViewModel.GuessSubmitted();

            
            int[,] colours = myResults.colours;

            getAllTextboxes();
            if (clear == false)
            {
                
                if (myResults.GameStates["validity"] == true)
                {
                    _displayedGuesses.Add(myGuess);
                    updateKeyBoardLetters(clear);

                    loopTable(_displayedGuesses, boxList,colours);

                    if (myResults.GameStates["gameOver"] == true)
                    {
                        if (myResults.GameStates["victory"] == true) { MessageBox.Show("Congratulations! You Guessed the word!"); }
                        else { MessageBox.Show($"Sorry, you lose... The word you were trying to guess was '{myViewModel.DisplayAnswer.ToLower()}'."); }
                    }
                }
                else { MessageBox.Show("Wrong input. Please use only english 5 lettter words in the singlular!"); }
            }
            else
            { // reset the game table
              //Quickly fill colour table with light grey 
              //for (int i = 0; i < 6; i++)
              //{
              //    _displayedGuesses.Add("     "); // kig på den her

                //    for (int s = 0; s < 5; s++) 
                //    { 
                //        colours[i,s] = 4;
                //    }
                //}
                _displayedGuesses.Clear();
                loopTable(_displayedGuesses, boxList,colours);
                updateKeyBoardLetters(clear);
            }
            //remove the blank string
            
            if (_displayedGuesses.Count == 0) { return true; }
           int indexToRemove = _displayedGuesses.Count-1; 
            _displayedGuesses.Remove(_displayedGuesses[indexToRemove]);
            return true;
        }


        private void loopTable(List<string> content, List<TextBox> target, int[,] colours)
        {
            int box = 0;
            for (int y = 0; y < content.Count; y++)
            {
                char[] guess = content[y].ToCharArray();
                for (int x = 0; x < guess.Length; x++)
                {
                    fillBox(boxList[box], guess[x]);
                    ColourBox(boxList[box], colours[y, x]);

                    box++;
                }
            }
            if (content.Count < 6)
            {
                content.Add(" ");
                for (int y = content.Count; y < 6;y++)
                {       
                    for (int x = 0; x < 5; x++)
                    {
                            fillBox(boxList[box], content[content.Count()-1].ToCharArray()[0]);
                            ColourBox(boxList[box], 4);

                            box++;
                    } 
                    
                }
            }
        }

        private void fillBox(TextBox box, char letter)
        {

            box.Text = $"{letter}";
        }

        private void getAllTextboxes()
        {
            foreach (var child in myGui.Children)
            {
                if (child is TextBox && boxList.Contains(child)== false) { boxList.Add((TextBox)child); }
            }
        }

        private void updateKeyBoardLetters(bool clear)
        {
            foreach (var child in myGui.Children)
            {
                if (child is not Button) { continue; }


                if (clear == true) { (child as Button).Background = Brushes.LightGray; }

                if ((child as Button).Name != "Backspace")
                {
                    foreach (var guess in _displayedGuesses)
                    {
                        if (guess.Contains((child as Button).Name))
                        {
                            (child as Button).Background = Brushes.DarkGray;
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
                    case 4: box.Background = Brushes.LightGray;break;
                    case 3: box.Background = Brushes.DarkGray; break;
                    case 1: box.Background = Brushes.Yellow; break;
                    case 2: box.Background = Brushes.Green; break;
                    default: break;
                }
            }



            private void updateGuessDisplay(string text) { guessDisplay.Text = text; }
    }
} 

