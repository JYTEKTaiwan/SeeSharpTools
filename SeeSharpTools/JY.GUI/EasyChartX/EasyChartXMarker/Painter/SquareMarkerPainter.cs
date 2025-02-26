﻿using SeeSharpTools.JY.GUI.TabCursorUtility;
using System.Drawing;
using System.Windows.Forms;

namespace SeeSharpTools.JY.GUI.EasyChartXMarker.Painters
{
    internal class SquareMarkerPainter : MarkerPainter
    {
        private SolidBrush _brush;
        private Rectangle _rectangle;

        public SquareMarkerPainter(PositionAdapter adapter, Color color, Control.ControlCollection container) :
            base(DataMarkerType.Square, adapter, color, container)
        {
            this._rectangle = new Rectangle(0, 0, 0, 0);
        }

        protected override void InitializePaintComponent(Color color)
        {
            if (null == _brush || !color.Equals(_brush.Color))
            {
                this._brush = new SolidBrush(color);
            }
            this._rectangle.X = 0;
            this._rectangle.Y = 0;
            this._rectangle.Height = MarkerSize;
            this._rectangle.Width = MarkerSize;
        }

        public override void PaintMarker(object sender, PaintEventArgs args)
        {
            args.Graphics.FillRectangle(_brush, _rectangle);
        }

        public override void Dispose()
        {
            base.Dispose();
            this._brush.Dispose();
        }
    }
}