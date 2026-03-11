using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt8
{
    public class Priem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    
        DateTime lastP;
        int lastdoc = 0;
        string diagnos = "";
        string recomendation = "";

        public DateTime LastP
        {
            get => lastP;
            set
            {
                if (lastP != value)
                {
                    lastP = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Lastdoc
        {
            get => lastdoc;
            set
            {
                if (lastdoc != value)
                {
                    lastdoc = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Diagnos
        {
            get => diagnos;
            set
            {
                if (diagnos != value)
                {
                    diagnos = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Recomendation
        {
            get => recomendation;
            set
            {
                if (recomendation != value)
                {
                    recomendation = value;
                    OnPropertyChanged();
                }
            }
        } 
    }
}
