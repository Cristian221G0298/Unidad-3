using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Unidad_3.Views
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        Ellipse? elipse;
        Point p;
        private void mnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog imp = new();
            if (imp.ShowDialog() == true)
                imp.PrintVisual(Lienzo, "ArchivoLienzoCírculos");
        }

        private void mnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if(elipse != null)
            {
                Point puntoFinal = e.GetPosition(Lienzo);
                elipse.Width = Math.Abs(p.X - puntoFinal.X);
                elipse.Height = Math.Abs(p.Y - puntoFinal.Y);
            }
        }

        private void Lienzo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            elipse = null;
        }

        private void Lienzo_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            elipse = new();
            Random a = new();
            byte r = (byte)a.Next(0, 256);
            byte g = (byte)a.Next(0, 256);
            byte b = (byte)a.Next(0, 256);
            elipse.Stroke = Brushes.Black;
            elipse.StrokeThickness = 1.5;
            elipse.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
            p = e.GetPosition(Lienzo);
            Canvas.SetTop(elipse, p.Y);
            Canvas.SetLeft(elipse, p.X);
            Lienzo.Children.Add(elipse);
        }

        private void mnGuardar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new();
            save.Filter = "Elipses.png";

            if(save.ShowDialog() == true)
            {
                RenderTargetBitmap bitmap = new((int)Lienzo.ActualWidth, (int)Lienzo.ActualHeight, 96, 96, PixelFormats.Default);
                bitmap.Render(Lienzo);

                FileStream fs = new(save.FileName, FileMode.Create);

                PngBitmapEncoder png = new();
                png.Frames.Add(BitmapFrame.Create(bitmap));
                png.Save(fs);
                fs.Close();
            }
        }
    }
}
