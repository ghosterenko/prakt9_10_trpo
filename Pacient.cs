using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace prakt8
{
    public class Pacient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
        public int Id { get; set; } 
        string name = "";
        string surname = "";
        string middlename = "";
        DateTime bday;
        string phoneNumber = "";

        ObservableCollection<Priem> priem = new();
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Middlename
        {
            get => middlename;
            set
            {
                if (middlename != value)
                {
                    middlename = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Bday
        {
            get => bday;
            set
            {
                if(bday != value)
                {
                    bday = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if(phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<Priem> Priems
        {
            get => priem;
            set
            {
                if (priem != value)
                {
                    priem = value;
                    OnPropertyChanged( );
                }
            }
        }
        
    }
}
