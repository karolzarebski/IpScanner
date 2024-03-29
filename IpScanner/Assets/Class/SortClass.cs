﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace IpScanner
{
    public class User
    {
        public int Lp { get; set; }
        public string Ip { get; set; }
        public string Nazwa { get; set; }
        public string Mac { get; set; }
        public string Stan { get; set; }
    }

    public class PortClass
    {
        public int Lp { get; set; }
        public string Numer { get; set; }
        public string Nazwa { get; set; }
        public string Status { get; set; }
    }

    public class ListaStacjiLista
    {
        public int LP { get; set; }
        public string Radio { get; set; }
        public string Stream { get; set; }
        public string Link { get; set; }
    }

    public class ZapisaneUtworyLista
    {
        public int LP { get; set; }
        public string Radio { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
    }

    public class CoJestGraneLista
    {
        public int LP { get; set; }
        public string Stacja { get; set; }
        public string Tytul { get; set; }
    }

    public class SortAdorner : Adorner
    {
        private static readonly Geometry ascGeometry =
            Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

        private static readonly Geometry descGeometry =
            Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection dir)
            : base(element)
        {
            Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform
                (
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5) / 2
                );
            drawingContext.PushTransform(transform);

            Geometry geometry = ascGeometry;
            if (this.Direction == ListSortDirection.Descending)
                geometry = descGeometry;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }
    }
}