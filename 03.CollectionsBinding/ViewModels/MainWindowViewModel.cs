namespace _03.CollectionsBinding.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using _03.CollectionsBinding.Models;
    using Prism.Commands;
    using Prism.Mvvm;

    public class MainWindowViewModel : BindableBase
    {
        private string firstName;
        private string lastName;
        private Person selectedPerson;

        public string FirstName
        {
            get { return this.firstName; }
            set { this.SetProperty(ref this.firstName, value); }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.SetProperty(ref this.lastName, value); }
        }

        public Person SelectedPerson
        {
            get { return this.selectedPerson; }
            set { this.SetProperty(ref this.selectedPerson, value); }
        }

        public ObservableCollection<Person> PeopleList { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public MainWindowViewModel()
        {
            this.PeopleList = new ObservableCollection<Person>
            {
                new Person{ FirstName = "Dimitar", LastName = "Radenkov" },
                new Person{ FirstName = "Alexander", LastName = "Radenkov"},
            };
            this.SelectedPerson = this.PeopleList.FirstOrDefault();

            this.AddCommand = new DelegateCommand(() =>
            {
                if (!string.IsNullOrWhiteSpace(this.FirstName) &&
                    !string.IsNullOrWhiteSpace(this.LastName))
                {
                    this.PeopleList.Add(new Person
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName
                    });
                    this.FirstName = string.Empty;
                    this.LastName = string.Empty;
                }
            });

            this.DeleteCommand = new DelegateCommand(() =>
            {
                if (this.SelectedPerson != null)
                {
                    this.PeopleList.Remove(this.SelectedPerson);
                    this.SelectedPerson = this.PeopleList.FirstOrDefault();
                }
            });
        }
    }
}
