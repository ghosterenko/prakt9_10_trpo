using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt8
{
    public class Doctor : INotifyPropertyChanged
    {
        int id;
        string name = "";
        string surname = "";
        string middlename = "";
        string spec = "";
        string pass = "";


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
        public int Id { get => id; set => id = value; }
        public string Name
        {
            get => name;
            set
            {
                if(name != value)
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
        public string Spec
        {
            get => spec;
            set
            {
                if (spec != value)
                {
                    spec = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Pass
        {
            get => pass;
            set
            {
                if (pass != value)
                {
                    pass = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
