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
using System.Windows.Threading;

namespace Donkey_Kong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum GameState {Title, SplashScreen, GameOn, GameOver, WinScreen }
        GameState gameState;

        DispatcherTimer GameTimer = new DispatcherTimer();
        int score = 0;
        int level = 1;
        
        public MainWindow()
        {
            InitializeComponent();
            Map map = new Map(canvas, this);
            gameState = GameState.Title;
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(170000);
            GameTimer.Start();
            map.drawMap();
            

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == GameState.Title)
            {
                this.Title = "Title Screen";
            }
            if (gameState == GameState.SplashScreen)
            {
                //map.generate();
                this.Title = "SplashScreen";
                btn_start.Visibility = Visibility.Hidden;
                
            }
            if (gameState == GameState.GameOn)
            {

            }
            if (gameState == GameState.GameOver)
            {

            }
            if (gameState == GameState.WinScreen)
            {

            }
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            gameState = GameState.SplashScreen;
        }
    }
}
