using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Unidad_3.ViewModels
{
    public enum Vistas { Menú, ImageBrush, VisualBrush, Arcoíris, Colores, Corbata, CorbataConPuntos, Foco, Ojo, PacMan, Paleta, Sonaja }
    public class CambiosDeVista : INotifyPropertyChanged
    {
        public ICommand CambioVista { get; set; }
        public Vistas Vista { get; set; }
        public CambiosDeVista()
        {
            CambioVista = new RelayCommand<Vistas>(CambiarVista);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void CambiarVista(Vistas v)
        {
            Vista = v;
            PropertyChanged?.Invoke(this, new(nameof(Vista)));
        }
    }
}
