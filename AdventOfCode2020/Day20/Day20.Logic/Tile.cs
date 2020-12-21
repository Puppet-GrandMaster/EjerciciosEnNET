using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day20.Logic
{
    public class Tile
    {
        public enum CurrentPosition
        {
            Normal = 0,
            Rotated90 = 1,
            Rotated180 = 2,
            Rotated270 = 3,
            FlippedVertically = 4,
            FlippedVerticallyRotated90 = 5,
            FlippedVerticallyRotated180 = 6,
            FlippedVerticallyRotated270 = 7,
            FlippedHorizontally = 8,
            FlippedHorizontallyRotated90 = 9,
            FlippedHorizontallyRotated180 = 10,
            FlippedHorizontallyRotated270 = 11,
            FlippedVerticallyAndHorizontally = 12,
            FlippedVerticallyAndHorizontallyRotated90 = 13,
            FlippedVerticallyAndHorizontallyRotated180 = 14,
            FlippedVerticallyAndHorizontallyRotated270 = 15
        }

        private const int Size = 10;
        private readonly string _data;

        public bool IsCorner { get; private set; }
        public bool IsBorder { get; private set; }
        public Dictionary<string, Tile> InnerSide { get; private set; }
        public int Id { get; private set; }
        public string Image { get; private set; }
        public CurrentPosition Position { get; private set; }
        public List<Tile> Transformations { get; }
        private readonly List<string> _borders;
        public string Top { get; private set; }
        public string Left { get; private set; }
        public string Right { get; private set; }
        public string Bottom { get; private set; }

        public Tile(string data)
        {
            _data = data;
            _borders = new List<string>();
            Position = CurrentPosition.Normal;
            Transformations = new List<Tile>();

            ParseTile();
        }

        private Tile(Tile tile)
        {
            _data = tile._data;
            Image = tile.Image;

            Top = tile.Top;
            Left = tile.Left;
            Right = tile.Right;
            Bottom = tile.Bottom;

            _borders = new List<string>(tile._borders);
        }

        private void ParseTile()
        {
            GetIdFromData();
            GetImageFromData();
            GetBordersFromImage();
            ComputeVariants();
        }

        private void ComputeVariants()
        {
            _borders.Clear();

            // TODO: Optimization: Borders have repeated values (Normal.Top == FlippedHorizontally.Bottom)
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            FlipVertically(); // ↑V
            RotateAQuarterToTheRight();
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←V
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            FlipVertically();
            RotateAQuarterToTheRight();
            FlipHorizontally(); // ↑H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←H
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight();
            FlipVertically(); // ↑ VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // →VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ↓VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            RotateAQuarterToTheRight(); // ←VH
            Transformations.Add(new Tile(this));
            _borders.AddRange(new string[] { Top, Right, Bottom, Left });

            // Restore
            RotateAQuarterToTheRight();
            FlipVertically();
            FlipHorizontally();
        }

        private void GetIdFromData() =>
            Id = int.Parse(_data.Replace("\n", string.Empty).Split(":")[0].Replace("Tile ", string.Empty));

        private void GetImageFromData() =>
            Image = _data.Replace("\n", string.Empty).Split(":")[1];

        private void GetBordersFromImage()
        {
            Top = Image[0..Size];
            Right = new string(Image.Where((_, i) => (i + 1) % Size == 0).ToArray());
            Bottom = Image[((Size * Size) - Size)..(Size*Size)];
            Left = new string(Image.Where((_, i) => i % Size == 0).ToArray());
        }

        private void RotateAQuarterToTheRight()
        {
            var newImage = new char[Size*Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    newImage[((x + 1) * Size) - (y + 1)] = Image[(y * Size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();
            ReadjustInnerSide();

            var currentRotation = (int)Position & 3;
            currentRotation = (currentRotation + 1) & 3;
            Position = (CurrentPosition)(((int)Position & 1100) | currentRotation);
        }

        public void RotateRight(int degrees)
        {
            switch (degrees)
            {
                case 90:
                    RotateAQuarterToTheRight();
                    break;

                case 180:
                    RotateAQuarterToTheRight();
                    RotateAQuarterToTheRight();
                    break;

                case 270:
                    RotateAQuarterToTheRight();
                    RotateAQuarterToTheRight();
                    RotateAQuarterToTheRight();
                    break;
            }
        }

        public void RotateLeft(int degrees)
        {
            switch (degrees)
            {
                case 90: RotateRight(270); break;
                case 180: RotateRight(180); break;
                case 270: RotateRight(90); break;
            }
        }

        public bool IsAdjacentOf(Tile adjacentTile)
        {
            var sameSides = GetBorders().Join(adjacentTile.GetBorders(),
                p => p,
                q => q,
                (r, s) => r == s).Count();

            return sameSides > 0;
        }

        private List<string> GetBorders() => new() { Top, Right, Bottom, Left };

        public void FlipHorizontally()
        {
            var newImage = new char[Size*Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    newImage[((Size - 1 - y) * Size) + x] = Image[(y * Size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();
            ReadjustInnerSide();

            Position ^= CurrentPosition.FlippedHorizontally;
        }

        public void FlipVertically()
        {
             var newImage = new char[Size*Size];

            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    newImage[(y * Size) + (Size - 1 - x)] = Image[(y * Size) + x];
                }
            }

            Image = new string(newImage);
            GetBordersFromImage();
            ReadjustInnerSide();

            Position ^= CurrentPosition.FlippedVertically;
        }

        public bool CouldBeAdjacentOf(Tile possibleAdjacentTile)
        {
            var sameSides = _borders.Join(possibleAdjacentTile._borders,
                p => p,
                q => q,
                (r, s) => r == s).Count();

            return sameSides > 0;
        }

        public void MarkAsCorner(List<Tile> adjacentTiles)
        {
            IsCorner = true;
            InnerSide = new Dictionary<string, Tile>();

            var adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Top));
            if (adjacentTile != null)
            {
                InnerSide.Add(Top, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Right));
            if (adjacentTile != null)
            {
                InnerSide.Add(Right, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Bottom));
            if (adjacentTile != null)
            {
                InnerSide.Add(Bottom, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Left));
            if (adjacentTile != null)
            {
                InnerSide.Add(Left, adjacentTile);
            }
        }

        public void MarkAsBorder(List<Tile> adjacentTiles)
        {
            IsBorder = true;
            InnerSide = new Dictionary<string, Tile>();

            var adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Top));
            if (adjacentTile != null)
            {
                InnerSide.Add(Top, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Right));
            if (adjacentTile != null)
            {
                InnerSide.Add(Right, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Bottom));
            if (adjacentTile != null)
            {
                InnerSide.Add(Bottom, adjacentTile);
            }

            adjacentTile = adjacentTiles.SingleOrDefault(t => t._borders.Contains(Left));
            if (adjacentTile != null)
            {
                InnerSide.Add(Left, adjacentTile);
            }
        }

        public void MarkAsInsidePiece(List<Tile> adjacentTiles)
        {
            InnerSide = new Dictionary<string, Tile>();

            InnerSide.Add(Top, adjacentTiles.Single(t => t._borders.Contains(Top)));
            InnerSide.Add(Right, adjacentTiles.Single(t => t._borders.Contains(Right)));
            InnerSide.Add(Bottom, adjacentTiles.Single(t => t._borders.Contains(Bottom)));
            InnerSide.Add(Left, adjacentTiles.Single(t => t._borders.Contains(Left)));
        }

        private void ReadjustInnerSide()
        {
            if (InnerSide != null)
            {
                var oldInnerSide = new Dictionary<string, Tile>(InnerSide);
                Tile temp = null;
                InnerSide.Clear();

                if (oldInnerSide.ContainsKey(Top))
                {
                    InnerSide.Add(Top, oldInnerSide[Top]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Top));
                    if (temp != null)
                    {
                        InnerSide.Add(Top, temp);
                    }
                }

                if (oldInnerSide.ContainsKey(Right))
                {
                    InnerSide.Add(Right, oldInnerSide[Right]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Right));
                    if (temp != null)
                    {
                        InnerSide.Add(Right, temp);
                    }
                }

                if (oldInnerSide.ContainsKey(Bottom))
                {
                    InnerSide.Add(Bottom, oldInnerSide[Bottom]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Bottom));
                    if (temp != null)
                    {
                        InnerSide.Add(Bottom, temp);
                    }
                }

                if (oldInnerSide.ContainsKey(Left))
                {
                    InnerSide.Add(Left, oldInnerSide[Left]);
                }
                else
                {
                    temp = oldInnerSide.Values.SingleOrDefault(q => q._borders.Contains(Left));
                    if (temp != null)
                    {
                        InnerSide.Add(Left, temp);
                    }
                }
            }
        }

        public bool MakeLeftSideBe(string side)
        {
            var undo = new List<Action<Tile>>();
            ComputeVariants();

            foreach (var index in _borders.Select((p,i) => new { Index = i, Side = p }).Where(p => p.Side == side).Select(p => p.Index))
            {
                var rotation = (CurrentPosition)(index & 3);
                var flippedHorizontally = (index & (int)CurrentPosition.FlippedHorizontally) == (int)CurrentPosition.FlippedHorizontally;
                var flippedVertically = (index & (int)CurrentPosition.FlippedVertically) == (int)CurrentPosition.FlippedVertically;

                if (flippedHorizontally)
                {
                    FlipHorizontally(); // unverified
                    undo.Add(t => t.FlipHorizontally());
                }

                if (flippedVertically)
                {
                    FlipVertically(); // unverified
                    undo.Add(t => t.FlipVertically());
                }

                switch (rotation)
                {
                    case CurrentPosition.Normal:
                        RotateLeft(90); // unverified
                        undo.Add(t => t.RotateRight(90));
                        break;

                    case CurrentPosition.Rotated90:
                        RotateLeft(180); // unverified
                        undo.Add(t => t.RotateLeft(180));
                        break;

                    case CurrentPosition.Rotated180:
                        RotateRight(90); // verified
                        undo.Add(t => t.RotateLeft(90));
                        break;

                    case CurrentPosition.Rotated270:
                        // ok
                        break;
                }

                if (Left == side)
                {
                    break;
                }
                else
                {
                    undo.ForEach(a => a(this));
                    undo.Clear();
                }
            }

/*
            switch ((CurrentPosition)index)
            {
                case CurrentPosition.Normal:
                    RotateLeft(90); // unverified
                    break;

                case CurrentPosition.Rotated90:
                    RotateLeft(180); // unverified
                    break;

                case CurrentPosition.Rotated180:
                    RotateRight(90); // verified
                    break;

                case CurrentPosition.Rotated270:
                    // ok
                    break;

                case CurrentPosition.FlippedVertically:
                    FlipVertically(); // unverified
                    RotateLeft(90);
                    break;

                case CurrentPosition.FlippedVerticallyRotated90:
                    FlipVertically();
                    RotateLeft(180); // unverified
                    break;

                case CurrentPosition.FlippedVerticallyRotated180:
                    FlipVertically(); // unverified
                    RotateRight(90);
                    break;

                case CurrentPosition.FlippedVerticallyRotated270:
                    FlipVertically(); // unverified
                    break;

                case CurrentPosition.FlippedHorizontally:
                    FlipHorizontally(); // unverified
                    RotateLeft(90);
                    break;

                case CurrentPosition.FlippedHorizontallyRotated90:
                    FlipHorizontally(); // unverified
                    RotateLeft(180);
                    break;

                case CurrentPosition.FlippedHorizontallyRotated180:
                    FlipHorizontally(); // unverified
                    RotateRight(90);
                    break;

                case CurrentPosition.FlippedHorizontallyRotated270:
                    FlipHorizontally(); // unverified
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontally:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    RotateLeft(90);
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontallyRotated90:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    RotateLeft(180);
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontallyRotated180:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    RotateRight(90);
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontallyRotated270:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    break;
            }*/

            return Left == side;
        }

        public bool MakeTopSideBe(string side)
        {
            var undo = new List<Action<Tile>>();

            ComputeVariants();
            foreach (var index in _borders.Select((p,i) => new { Index = i, Side = p }).Where(p => p.Side == side).Select(p => p.Index))
            {
                var rotation = (CurrentPosition)(index & 3);
                var flippedHorizontally = (index & (int)CurrentPosition.FlippedHorizontally) == (int)CurrentPosition.FlippedHorizontally;
                var flippedVertically = (index & (int)CurrentPosition.FlippedVertically) == (int)CurrentPosition.FlippedVertically;

                if (flippedHorizontally)
                {
                    FlipHorizontally(); // unverified
                    undo.Add(t => t.FlipHorizontally());
                }

                if (flippedVertically)
                {
                    FlipVertically(); // unverified
                    undo.Add(t => t.FlipVertically());
                }

                switch (rotation)
                {
                    case CurrentPosition.Normal:
                        // ok
                        break;

                    case CurrentPosition.Rotated90:
                        RotateLeft(90); // unverified
                        undo.Add(t => t.RotateRight(90));
                        break;

                    case CurrentPosition.Rotated180:
                        RotateRight(180); // unverified
                        undo.Add(t => t.RotateRight(180));
                        break;

                    case CurrentPosition.Rotated270:
                        RotateRight(90); // unverified
                        undo.Add(t => t.RotateLeft(90));
                        break;
                }

                if (Top == side)
                {
                    break;
                }
                else
                {
                    undo.ForEach(a => a(this));
                    undo.Clear();
                }
            }

            return Top == side;

            /*
            ComputeVariants();
            var index = _borders.IndexOf(side) / 4;

            switch ((CurrentPosition)index)
            {
                case CurrentPosition.Normal:
                    // ok
                    break;

                case CurrentPosition.Rotated90:
                    RotateLeft(90); // unverified
                    break;

                case CurrentPosition.Rotated180:
                    RotateRight(180); // unverified
                    break;

                case CurrentPosition.Rotated270:
                    RotateRight(90); // unverified
                    break;

                case CurrentPosition.FlippedVertically:
                    FlipVertically(); // unverified
                    break;

                case CurrentPosition.FlippedVerticallyRotated90:
                    FlipVertically();
                    RotateLeft(90); // unverified
                    break;

                case CurrentPosition.FlippedVerticallyRotated180:
                    FlipVertically(); // unverified
                    RotateRight(180);
                    break;

                case CurrentPosition.FlippedVerticallyRotated270:
                    FlipVertically(); // unverified
                    RotateRight(90);
                    break;

                case CurrentPosition.FlippedHorizontally:
                    FlipHorizontally(); // unverified
                    break;

                case CurrentPosition.FlippedHorizontallyRotated90:
                    FlipHorizontally(); // unverified
                    RotateLeft(90);
                    break;

                case CurrentPosition.FlippedHorizontallyRotated180:
                    FlipHorizontally(); // unverified
                    RotateRight(180);
                    break;

                case CurrentPosition.FlippedHorizontallyRotated270:
                    FlipHorizontally(); // unverified
                    RotateRight(90);
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontally:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontallyRotated90:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    RotateLeft(90);
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontallyRotated180:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    RotateRight(180);
                    break;

                case CurrentPosition.FlippedVerticallyAndHorizontallyRotated270:
                    FlipHorizontally(); // unverified
                    FlipVertically();
                    RotateRight(90);
                    break;
            }*/
        }
    }
}
