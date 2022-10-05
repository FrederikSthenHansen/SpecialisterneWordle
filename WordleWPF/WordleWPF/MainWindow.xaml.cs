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


        /// <summary>
        /// Updates the table displaying bprevious
        /// </summary>
        /// <param name="clear"> If true, will erase all content form table</param>
        /// <returns></returns>
        private async Task<bool> updateLetterTable(bool clear)
        {
            List<Object> modelValues = myViewModel.GuessSubmitted();

            Dictionary<string, bool> bools = (Dictionary<string, bool>)modelValues[0];
            int[,] colours = (int[,])modelValues[1];

            getAllTextboxes();
            if (clear == false)
            {
                
                if (bools["validity"] == true)
                {
                    _displayedGuesses.Add(myGuess);
                    updateKeyBoardLetters();

                    loopTable(_displayedGuesses, boxList,colours);

                    if (bools["gameOver"] == true)
                    {
                        if (bools["victory"] == true) { MessageBox.Show("Congratulations! You Guessed the word!"); }
                        else { MessageBox.Show("Sorry, you lose.."); }
                    }
                }
                else { MessageBox.Show("Wrong input. Please use only english 5 lettter words in the singlular!"); }
            }
            else
            { // reset the game table
                //Quickly fill colour table with light grey 
                for (int i = 0; i < 6; i++)
                {
                    _displayedGuesses.Add( " "); 
                
                    for (int s = 0; s < 5; s++) 
                    { 
                        colours[i,s] = 4;
                    }
                }
                loopTable(_displayedGuesses, boxList,colours);
                updateKeyBoardLetters();
            }
            //remove the blank string
            _displayedGuesses.Remove(_displayedGuesses[_displayedGuesses.Count()-1]);
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
                            else { button.Background = Brushes.LightGray; } 
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

