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
using WordleWPF.ViewModel;

namespace WordleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WordleViewModel myViewModel;
        public string myGuess;
        public MainWindow()
        {
            InitializeComponent();
            myViewModel=new WordleViewModel();
            myGuess = "";
            guessDisplay.Text = myGuess;
        }

        

        private void Letterbutton_Click(object sender, RoutedEventArgs e)
        {
            //Comment sender.ToString().Split(':')[1] is the name of the letter 
            string letter=sender.ToString().Split(':')[1];
            string returnMessage= myViewModel.LetterPressed(letter);
            myGuess = returnMessage;
            guessDisplay.Text = returnMessage;
            //MessageBox.Show(returnMessage);

        }

    }
}
