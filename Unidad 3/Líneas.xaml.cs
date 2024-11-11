using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.Windows.Shapes.Path;

namespace Unidad_3
{
    /// <summary>
    /// Lógica de interacción para Líneas.xaml
    /// </summary>
    public partial class Líneas : Window
    {
        public Líneas()
        {
            InitializeComponent();
        }
        Path path;
        Point p;
        LineGeometry line;
        private void mnGuardar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog Save = new SaveFileDialog();
            Save.Filter = "Imagenes PNG|*.png";
            if (Save.ShowDialog() == true)
            {
                RenderTargetBitmap bitmap = new RenderTargetBitmap(
                    (int)Lienzo.ActualWidth,
                    (int)Lienzo.ActualHeight,
                    96, 96,
                    PixelFormats.Default);
                bitmap.Render(Lienzo);
                FileStream fs = new FileStream(Save.FileName, FileMode.Create);
                BitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(bitmap));
                png.Save(fs);
                fs.Close();
            }
        }

        private void mnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog imp = new();
            if (imp.ShowDialog() == true)
            {
                imp.PrintVisual(Lienzo, "ArchivoLienzo");
            }
        }

        private void mnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Lienzo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            path = new Path();
            line = new LineGeometry();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 5;
            p = e.GetPosition(Lienzo);
            line.StartPoint = p;
            path.Data = line;

            Lienzo.Children.Add(path);
        }

        private void Lienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (path != null)
            {
                Point puntofinal = e.GetPosition(Lienzo);
                line.EndPoint = puntofinal;
                path.Data = line;
            }
        }

        private void Lienzo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            path = null;
        }
    }
}
