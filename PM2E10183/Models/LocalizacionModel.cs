using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PM2E10183.Models
{
    public class LocalizacionModel:INotifyPropertyChanged
    {
        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));

        }
        private double longitud { get; set; }
        public double Longitud
        {
            get { return longitud; }
            set { longitud = value;
                OnPropertyChanged();
            }
        }
        private double latitud{ get; set; }
        public double Latitiud
        {
            get { return latitud; }
            set { latitud= value;
            OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
