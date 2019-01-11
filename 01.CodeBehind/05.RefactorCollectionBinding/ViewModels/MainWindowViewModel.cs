namespace _05.RefactorCollectionBinding
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using _04.Utils;
    using _04.Utils.EventArguments;
    using Prism.Commands;
    public class MainWindowViewModel
    {
        public TextVM FirstName { get; set; }
        public TextVM LastName { get; set; }
        public CollectionVM<Person> PeopleList { get; set; }

        public ButtonVM ButtonAdd { get; set; }
        public ButtonVM ButtonDelete { get; set; }
        public MainWindowViewModel()
        {
            this.FirstName = new TextVM { IsEnabled = true, Text = "John" };
            this.FirstName.TextChanged += OnTextChanged;

            this.LastName = new TextVM { IsEnabled = true, Text = "Smith" };
            this.LastName.TextChanged += OnTextChanged;

            this.PeopleList = new CollectionVM<Person>(new List<Person> 
            {
                new Person{ FirstName = "Dimitar", LastName = "Radenkov" },
                new Person{ FirstName = "Alexander", LastName = "Radenkov"},
            });
            this.PeopleList.Selected = this.PeopleList.Items.FirstOrDefault();

            this.ButtonAdd = new ButtonVM { Command = new DelegateCommand(OnButtonAddClicked) };
            this.ButtonDelete = new ButtonVM { Command = new DelegateCommand(OnButtonDeleteClicked) };
        }

        private void OnTextChanged(object sender, ValueChangedEventArgs<string> e)
        {
            if (sender is TextVM textVM)
            {
                if (string.IsNullOrWhiteSpace(e.CurrentValue))
                {
                    textVM.Tooltip = "Cannot be empty";
                    textVM.Background = Brushes.Pink;
                    this.ButtonAdd.IsEnabled = false;
                }
                else
                {
                    textVM.Tooltip = null;
                    textVM.Background = Brushes.White;
                    this.ButtonAdd.IsEnabled = true;
                }
            }
        }

        private void OnButtonAddClicked()
        {
            if (!string.IsNullOrWhiteSpace(this.FirstName.Text) &&
                !string.IsNullOrWhiteSpace(this.LastName.Text))
            {
                this.PeopleList.Items.Add(new Person
                {
                    FirstName = this.FirstName.Text,
                    LastName = this.LastName.Text
                });
                this.FirstName.Text = string.Empty;
                this.LastName.Text = string.Empty;
            }
        }

        private void OnButtonDeleteClicked()
        {
            if (this.PeopleList.Selected != null)
            {
                this.PeopleList.Items.Remove(this.PeopleList.Selected);
                this.PeopleList.Selected = this.PeopleList.Items.FirstOrDefault();

                if (!this.PeopleList.Items.Any())
                {
                    this.ButtonDelete.IsEnabled = false;
                }
            }
        }
    }
}
