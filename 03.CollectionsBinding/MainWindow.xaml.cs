namespace _03.CollectionsBinding
{
    using System.Windows;
    using _03.CollectionsBinding.ViewModels;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
}
