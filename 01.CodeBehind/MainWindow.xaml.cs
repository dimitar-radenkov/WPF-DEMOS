namespace _01.CodeBehind
{
    using System.Windows;
    using System.Windows.Media;

    public partial class MainWindow : Window
    {
        private const int WARNING_LIMIT = 10;
        private const int DANGER_LIMIT = 20;

        private int counter;

        public MainWindow()
        {
            this.InitializeComponent();
            this.TextCounter.Text = this.counter.ToString();
        }

        private void ButtonIncrement_Click(object sender, RoutedEventArgs e)
        {
            ++this.counter;
            this.TextCounter.Text = this.counter.ToString();

            if (this.counter >= DANGER_LIMIT)
            {
                this.TextCounter.Background = Brushes.Red;
            }
            else if (this.counter >= WARNING_LIMIT)
            {
                this.TextCounter.Background = Brushes.Yellow;
            }
        }
    }
}
