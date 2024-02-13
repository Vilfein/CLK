using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CLK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Clock? clk;

        public MainWindow()
        {
            InitializeComponent();
            Colorize();
            clk = DataContext as Clock;
            (Content as Grid)!.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        void ChangeColor(object? sender, RoutedEventArgs e)
        {
            string? value = (sender as MenuItem)?.Header.ToString();
            Effect.Color = FromText(value!);
        }

        private System.Windows.Media.Color FromText(string color)
        {
            return color switch
            {
                "White" => Colors.White,
                "Red" => Colors.Red,
                "Green" => Colors.LimeGreen,
                "Blue" => Colors.Blue,
                "Yellow" => Colors.Yellow,
                "Orange" => Colors.Orange,
                "Purple" => Colors.MediumOrchid,
                "Azure" => Colors.Cyan,
                "Gray" => Colors.Silver,
                "Pink" => Colors.Pink,
                "Magenta" => Colors.Magenta,
                _ => Colors.White
            };
        }

        private void Colorize()
        {
            MenuItem? mainItem = (((Content as Grid)?.Children[0] as Viewbox)?.Child as TextBlock)?.ContextMenu.Items[0] as MenuItem;

            foreach (MenuItem item in mainItem!.Items)
            {
                item.Icon =
                    new Ellipse
                    {
                        Fill = new SolidColorBrush(FromText(item.Header.ToString()!)),
                        Stroke = Brushes.Black,
                        StrokeThickness = 1
                    };
            }
        }

        void AmericanTime(object s, EventArgs e) => clk!.Pattern = TimePattern.US;
        void EUTime(object s, EventArgs e) => clk!.Pattern = TimePattern.EU;
        void EndClock(object sender, EventArgs e) => this.Close();
    }
}