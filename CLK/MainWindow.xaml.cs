using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CLK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool colorized;
        Clock? clk;
        DispatcherTimer clrTimmer;

        public MainWindow()
        {
            InitializeComponent();
            clk = DataContext as Clock;

            clrTimmer = new DispatcherTimer();
            
            clrTimmer.Tick += (s, e) => Colored();
            clrTimmer.Interval = TimeSpan.FromSeconds(1);
            clrTimmer.Start();

            (Content as Grid)!.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Colored()
        {
            if (colorized)
            {
                byte R = (byte)new Random().Next(0, 255);
                byte G = (byte)new Random().Next(0, 255);
                byte B = (byte)new Random().Next(0, 255);
                MyTime.Foreground = new SolidColorBrush(Color.FromRgb(R, G, B));
            }

            else
            {
                MyTime.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        void NoColors(object s, EventArgs e) => colorized = false;
        void WithColors(object s, EventArgs e) => colorized = true;
        void AmericanTime(object s, EventArgs e) => clk!.Pattern = TimePattern.US;
        void EUTime(object s, EventArgs e) => clk!.Pattern = TimePattern.EU;
        void EndClock(object sender, EventArgs e) => this.Close();
    }
}