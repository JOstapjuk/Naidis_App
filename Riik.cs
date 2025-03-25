using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Naidis_App
{
    //https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-9.0
    //https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
    public class Riik : INotifyPropertyChanged
    {
        private string _nimi;
        private string _pealinn;
        private int _rahvaarv;
        private string _lipp;

        public string Nimi
        {
            get => _nimi;
            set
            {
                if (_nimi != value)
                {
                    _nimi = value;
                    OnPropertyChanged(nameof(Nimi));
                }
            }
        }

        public string Pealinn
        {
            get => _pealinn;
            set
            {
                if (_pealinn != value)
                {
                    _pealinn = value;
                    OnPropertyChanged(nameof(Pealinn));
                }
            }
        }

        public int Rahvaarv
        {
            get => _rahvaarv;
            set
            {
                if (_rahvaarv != value)
                {
                    _rahvaarv = value;
                    OnPropertyChanged(nameof(Rahvaarv));
                }
            }
        }

        public string Lipp
        {
            get => _lipp;
            set
            {
                if (_lipp != value)
                {
                    _lipp = value;
                    OnPropertyChanged(nameof(Lipp));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}