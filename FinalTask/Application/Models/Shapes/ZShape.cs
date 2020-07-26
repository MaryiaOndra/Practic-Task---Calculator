﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Shapes
{
    class ZShape : Shapes
    {
        public List<Point> NewTetr { get; private set; }

        public ZShape()
        {
            ChooseRandomChar();
            CreateShape();
        }

        internal override void CreateShape()
        {
            List<Point> points = new List<Point>
            {
                new Point(x, y, ch),
                new Point(x - 1, y, ch),
                new Point(x, y + 1, ch),
                new Point(x + 1, y + 1, ch)
            };

            foreach (Point p in points)
            {
                p.DrawPoint();
            }

            NewTetr = points;
        }
    }
}
