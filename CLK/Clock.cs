using System.ComponentModel;
using System.Windows.Threading;

namespace CLK
{
    public class Clock : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private DispatcherTimer timer;
        private TimePattern pattern;
        private string? strPattern;
        private string? time;
        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public Clock()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Tick += (s, e) => Timing(); 
            timer.Start();
            Pattern = TimePattern.EU;
        }
        /// <summary>
        /// Time pattern
        /// </summary>
        public TimePattern Pattern
        {
            get => pattern;
            set
            {
                pattern = value;
                strPattern = value == TimePattern.EU ? "{0:HH:mm:ss}" : "{0:hh:mm:ss}";
            }
        }
        /// <summary>
        /// Public Time
        /// </summary>
        public string Time
        {
            get => time ?? ""; 
            set
            {
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
            }
        }
        /// <summary>
        /// Sets actual time by Pattern
        /// </summary>
        private void Timing()
        {
            this.Time = string.Format(strPattern!, DateTime.Now);
        }
    }
}
