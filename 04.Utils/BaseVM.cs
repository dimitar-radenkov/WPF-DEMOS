namespace _04.Utils
{
    using System.Windows;
    using System.Windows.Media;
    using Prism.Mvvm;

    public class BaseVM : BindableBase
    {
        private Brush foregroundColor;
        private Brush backgroundColor;
        private Visibility visiblity;
        private string tooltip;
        private bool isEnabled;

        public Brush Foreground
        {
            get => this.foregroundColor;
            set => SetProperty(ref this.foregroundColor, value);
        }

        public Brush Background
        {
            get => this.backgroundColor;
            set => SetProperty(ref this.backgroundColor, value);
        }

        public Visibility Visibility
        {
            get => this.visiblity;
            set => SetProperty(ref this.visiblity, value);
        }

        public string Tooltip
        {
            get => this.tooltip;
            set => SetProperty(ref this.tooltip, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => SetProperty(ref this.isEnabled, value);
        }

        public BaseVM()
        {
            this.Foreground = Brushes.Black;
            this.Background = Brushes.White;
            this.Visibility = Visibility.Visible;
            this.Tooltip = null;
            this.IsEnabled = true;
        }
    }
}
