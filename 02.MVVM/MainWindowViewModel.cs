namespace _02.MVVM
{
    using System.ComponentModel;
    using System.Windows.Input;
    using System.Windows.Media;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const int WARNING_LIMIT = 10;
        private const int DANGER_LIMIT = 20;

        private int counter;

        private string counterText;
        private Brush counterBackground;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CounterText
        {
            get { return this.counter.ToString(); }
            set
            {
                this.counterText = value;
                this.PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(this.CounterText)));
            }
        }

        public Brush CounterBackground
        {
            get { return this.counterBackground; }
            set
            {
                this.counterBackground = value;
                this.PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(this.CounterBackground)));
            }
        }

        public ICommand IncrementCommand { get; set; }

        public MainWindowViewModel()
        {
            this.counter = 0;
            this.counterBackground = Brushes.Transparent;
            this.IncrementCommand = new LambdaCommand(this.OnIncrementClick);
        }

        private void OnIncrementClick()
        {
            ++this.counter;
            this.CounterText = this.counter.ToString();

            if (this.counter >= DANGER_LIMIT)
            {
                this.CounterBackground = Brushes.Red;
            }
            else if (this.counter >= WARNING_LIMIT)
            {
                this.CounterBackground = Brushes.Yellow;
            }
        }
    }
}
