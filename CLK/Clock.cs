using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
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

        public Clock()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Tick += (s, e) => Timing(); 
            timer.Start();
            Pattern = TimePattern.EU;
        }
        public TimePattern Pattern
        {
            get => pattern;
            set
            {
                pattern = value;
                strPattern = value == TimePattern.EU ? "{0:HH:mm:ss}" : "{0:hh:mm:ss}";
            }
        }

        public string Time
        {
            get => time ?? ""; 
            set
            {
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
            }
        }



        private void Timing()
        {
            this.Time = string.Format(strPattern, DateTime.Now);
        }
    }
}
