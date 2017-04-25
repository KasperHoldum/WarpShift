namespace WarpShift
{
    public static class OfficialMaps
    {
        public class Chapter1 { 
        public static (StringMap, int limit) S1(IMapShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0),
            Field.Closed,Field.Left,
            Field.Right,Field.Closed);

            return (m,2);
        }

        public static (StringMap, int limit) S2(IMapShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 0),
            Field.Closed,Field.Right,
            Field.Left, Field.Closed);

            return (m, 3);
        }

        public static (StringMap, int limit) S3(IMapShifter shifter)
        {
            var m = new StringMap(shifter, 2, (1, 0), (0, 1),
             Field.Closed,Field.Top,
             Field.Bottom,Field.Closed);

            return (m, 3);
        }

        public static (StringMap, int limit) S4(IMapShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 1), (1, 1),
                Field.RightBottom, Field.Left,
                Field.TopLeft, Field.RightTop);

            return (m, 2);
        }

        public static (StringMap, int limit) S5(IMapShifter shifter)
        {
            var m = new StringMap(shifter, 2, (0, 0), (1, 1),
                Field.Bottom, Field.Closed,
                Field.Top, Field.Bottom);

            return (m, 4);
        }

        public static (StringMap, int limit) S6(IMapShifter shifter)
        {
            var m = new StringMap(shifter, 2, (1, 0), (1, 1),
                Field.Right, Field.Left,
                Field.RightTop, Field.Right);

            return (m, 3);
        }

        public static (StringMap, int limit) S7(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3,2), (0, 1), (2, 1),
                Field.Closed, Field.Bottom, Field.Closed,
                Field.Top, Field.Closed, Field.Top);

            return (m, 4);
        }

        public static (StringMap, int limit) S8(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 0),
                Field.Right, Field.Bottom, Field.Closed,
                Field.Closed, Field.Closed, Field.TopLeft);

            return (m, 4);
        }

        public static (StringMap, int limit) S9(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                Field.RightTop, Field.RightLeft, Field.BottomLeft,
                Field.Closed, Field.RightBottom, Field.TopLeft);

            return (m, 3);
        }

        public static (StringMap, int limit) S10(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                Field.Right, Field.Closed, Field.BottomLeft,
                Field.RightLeft, Field.Top, Field.RightLeft);

            return (m, 5);
        }

        public static (StringMap, int limit) S11(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (2, 0), (0, 0),
                Field.Bottom, Field.TopLeft, Field.Bottom,
                Field.Top, Field.Top, Field.Bottom);

            return (m, 4);
        }

        public static (StringMap, int limit) S12(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 2), (2, 0), (0, 1),
                Field.Closed, Field.Right, Field.Left,
                Field.Top, Field.RightBottom, Field.Top);

            return (m, 4);
        }

        public static (StringMap, int limit) S13(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 3), (2, 0), (0, 2),
                Field.Closed, Field.TopBottomLeft, Field.Left,
                Field.RightBottom, Field.TopLeft, Field.Closed,
                Field.RightTop, Field.Closed, Field.Closed);

            return (m, 3);
        }


        public static (StringMap, int limit) S14(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 3), (0, 1), (1, 1),
                Field.RightBottom, Field.RightLeft, Field.BottomLeft,
                Field.TopBottom, Field.Right, Field.TopBottom,
                Field.RightTop, Field.RightLeft, Field.TopLeft);

            return (m, 4);
        }

        public static (StringMap, int limit) S15(IMapShifter shifter)
        {
            var m = new StringMap(shifter, (3, 3), (0, 0), (2, 1),
                Field.Left, Field.Closed, Field.RightBottom,
                Field.TopBottom, Field.Closed, Field.Bottom,
                Field.RightTop, Field.Top, Field.Closed);

            return (m, 5);
        }
        }
        public class Chapter2
        {
            public static (StringMap, int limit) S1(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (2, 2), (0, 1), (1, 0),
                    Field.RightBottom, new Field((O.Left, C.P)),
                    new Field((O.Right, C.P)), Field.Closed);

                return (m, 2);
            }

            public static (StringMap, int limit) S2(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 2), (0, 0), (0, 1),
                    Field.Bottom, new Field((O.Left, C.P), (O.Right, C.N)), Field.Left,
                    new Field((O.Right, C.P)), Field.Closed, Field.TopLeft);

                return (m, 5);
            }

            public static (StringMap, int limit) S3(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 2), (0, 0), (1, 1),
                    Field.Bottom, Field.Right, new Field((O.Bottom, C.P), (O.Right, C.P)),
                    Field.Closed, new Field((O.Top, C.P)), new Field((O.Left, C.P), (O.Top, C.N)));

                return (m, 5);
            }

            public static (StringMap, int limit) S4(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 2), (0, 1), (2, 1),
                    new Field((O.Left, C.P), (O.Bottom, C.P)), Field.Right, new Field((O.Left, C.N), (O.Right, C.P), (O.Bottom, C.N)),
                    Field.RightTop, Field.Left, new Field((O.Top, C.P)));

                return (m, 5);
            }

            public static (StringMap, int limit) S5(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 2), (1, 0), (1, 1),
                    new Field((O.Left, C.P), (O.Bottom, C.P)), Field.Right, new Field((O.Left, C.N), (O.Right, C.P)),
                    new Field((O.Left, C.N), (O.Bottom, C.P)), Field.PinkTop, Field.Closed);

                return (m, 4);
            }

            public static (StringMap, int limit) S6(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0, 0), (2, 0),
                    Field.Right, Field.BottomLeft, Field.PinkBottom,
                    new Field((O.Top, C.P), (O.Right, C.N), (O.Bottom, C.N)), Field.TopLeft, new Field((O.Top, C.P), (O.Bottom, C.N)),
                    Field.RightTop, Field.RightLeft, Field.TopLeft);

                return (m, 5);
            }

            public static (StringMap, int limit) S7(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0, 2), (1, 1),
                    new Field((O.Bottom, C.N), (O.Right, C.P)), Field.Closed, Field.Closed,
                    Field.Closed, new Field((O.Left, C.P), (O.Right, C.P)), new Field((O.Right, C.P), (O.Bottom, C.N)),
                    Field.Right, Field.TopLeft, Field.RightTop);

                return (m, 5);
            }

            public static (StringMap, int limit) S8(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (2, 2), (0, 1),
                    new Field((O.Top, C.N), (O.Bottom, C.P)), Field.Closed, Field.Closed,
                    Field.PinkLeft, Field.RightLeft, new Field((O.Left, C.N), (O.Top, C.P), (O.Right, C.P)),
                    Field.RightBottom, Field.RightLeft, Field.Left);

                return (m, 5);
            }

            public static (StringMap, int limit) S9(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (1, 1), (0, 1),
                    Field.RightTop, Field.RightLeft, Field.BottomLeft,
                    Field.PinkRight, Field.Right, Field.TopLeft,
                    Field.Closed, Field.Closed, new Field((O.Top, C.N), (O.Left, C.P), (O.Bottom, C.N)));
                return (m, 6);
            }


            public static (StringMap, int limit) S10(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0,0), (0, 2),
                    Field.Right, Field.BottomLeft, Field.Closed,
                    Field.PinkLeft, Field.RightTop, new Field((O.Left, C.N), (O.Right, C.P), (O.Bottom, C.N)),
                    Field.PinkRight, Field.Right, Field.TopLeft);
                m.AddChip((0, 1));
                return (m, 7);
            }

            public static (StringMap, int limit) S11(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0, 0), (2, 2),
                    Field.PinkRight,Field.Closed,Field.PinkLeft,
                    Field.PinkLeft, new Field((O.Left, C.P),(O.Right, C.N)), Field.PinkRight,
                    Field.PinkRight, Field.Closed, Field.Left);
                m.AddChip((0, 2));
                return (m, 6);
            }

            public static (StringMap, int limit) S12(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (2, 0), (1, 2),
                    Field.RightBottom, Field.RightLeft, new Field((O.Left, C.N), (O.Bottom, C.P)),
                    Field.RightTopBottom, new Field((O.Left, C.N), (O.Top, C.P)), Field.Closed,
                    new Field((O.Left, C.P), (O.Top, C.N)), new Field((O.Top, C.P), (O.Right, C.P)), new Field((O.Left, C.P), (O.Right, C.P)));
                m.AddChip((1, 1));
                return (m, 6);
            }

            public static (StringMap, int limit) S13(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (1, 1), (0, 1),
                    Field.Right, Field.RightLeftBottom, Field.Left,
                    Field.PinkLeft, new Field((O.Left, C.P), (O.Right, C.P), (O.Top, C.N), (O.Bottom, C.N)), Field.PinkRight,
                    Field.Right, Field.RightLeftTop, Field.Left);
                m.AddChip((2, 1));
                return (m, 6);
            }

            public static (StringMap, int limit) S14(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0, 0), (2, 0),
                    new Field((O.Left, C.P), (O.Right, C.P)), Field.Closed, Field.Left,
                    new Field((O.Top, C.P), (O.Right, C.N)), Field.Closed, new Field((O.Top, C.P), (O.Bottom, C.P)),
                    new Field((O.Right, C.P), (O.Bottom, C.P)), Field.Closed, Field.Closed);
                m.AddChip((0, 2));
                return (m, 7);
            }

            public static (StringMap, int limit) S15(IMapShifter shifter)
            {
                var m = new StringMap(shifter, (3, 3), (0, 0), (2, 1),
                    Field.PinkRight,
                    new Field((O.Left, C.P), (O.Bottom, C.N), (O.Right, C.P)),
                    new Field((O.Left, C.P), (O.Bottom, C.P)),
                    new Field((O.Top, C.P), (O.Right, C.N)),
                    new Field((O.Top, C.P), (O.Bottom, C.P)),
                    Field.Bottom,
                    new Field((O.Top, C.N), (O.Bottom, C.P)),
                    new Field((O.Top, C.N), (O.Right, C.P)),
                    new Field((O.Left, C.N), (O.Top, C.P)));


                m.AddChip((1, 1));
                return (m, 9);
            }
        }
    }
}
