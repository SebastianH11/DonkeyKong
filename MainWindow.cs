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
        Player player;
        Point mouse_pos = new Point();

        Rectangle player_sprite = new Rectangle();
        DispatcherTimer GameTimer = new DispatcherTimer();
        int score = 0;
        int level = 1;
        int counter = 0;
        bool playerisgenerated = false;
        
        public MainWindow()
        {
            
            InitializeComponent();
            
            Map map = new Map(canvas, this);
            gameState = GameState.SplashScreen;
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(170000);
            GameTimer.Start();
            map.drawMap();
            player = new Player(this, canvas);
            
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            
            for (int i = canvas.Children.Count -13; i >= 13; i--)
            {
                canvas.Children.RemoveAt(i);
            }      
            if (gameState == GameState.Title)
            {
                this.Title = "Title Screen";
            }
            if (gameState == GameState.SplashScreen)
            {
                
                this.Title = "SplashScreen";
                counter++;
                
                if (playerisgenerated == false)
                {
                    player.generate(player_sprite);
                    playerisgenerated = true;
                    canvas.Children.Add(player_sprite);
                }
                if (playerisgenerated == true)
                {
                    player.fall();
                    player.update(player_sprite);
                    
                }
                
                
                
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(".");
            player.move();
            player.jump();
            
        }       
    }
}

