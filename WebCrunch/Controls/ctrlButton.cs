﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CButtonLib;
using Extensions;

namespace Controls
{
    public partial class CtrlButton : CButton
    {
        private static Font _normalFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

        public CtrlButton() : base()
        {
            base.Font = _normalFont;
            base.BackColor = Color.Transparent;
            base.ForeColor = Colors.uiColorOrange;
            base.Cursor = Cursors.Hand;
            base.MaximumSize = new Size(1000, 30);
            base.MinimumSize = new Size(0, 30);
            Size = new Size(30, 30);
            TextAlign = ContentAlignment.MiddleCenter;
            Corners = new CornersProperty(2);
            TextMargin = new Padding(2, 2, 2, 2);
            BorderColor = Colors.uiColorOrange;
            ColorFillSolid = Color.Transparent;
            FillType = eFillType.Solid;
            TextShadowShow = false;
            ShowFocus = eFocus.None;
            Margin = new Padding(3,3,3,3);
            BorderShow = true;
            DimFactorClick = 0;
            DimFactorHover = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int increaseBy = 20;
            if (Image != null) { increaseBy = 40; }
            Font myFont = _normalFont;
            SizeF mySize = base.CreateGraphics().MeasureString(base.Text, myFont);
            base.Width = (((int)(Math.Round(mySize.Width, 0))) + increaseBy);
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        Bitmap tmpButtonImage = null;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            tmpButtonImage = (Bitmap)Image;
            if (Image != null) { Image = ImageExtensions.ChangeColor((Bitmap)Image, Color.White); }
            base.ForeColor = Color.White;
            BorderColor = Colors.uiColorOrange;
            ColorFillSolid = Colors.uiColorOrange;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.ForeColor = Colors.uiColorOrange;
            Image = tmpButtonImage;
            BorderColor = Colors.uiColorOrange;
            ColorFillSolid = Color.Transparent;
        }
    }
}
