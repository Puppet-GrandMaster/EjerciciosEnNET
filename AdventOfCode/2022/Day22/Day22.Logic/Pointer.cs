namespace Day22.Logic;

public enum Direction
{
    Right = 0,
    Down,
    Left,
    Up
}

internal class Pointer
{
    private readonly char[,] _map;

    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Facing { get; private set; }
    public Dictionary<(int X, int Y), char> VisitedTiles { get; }
    public List<(int X, int Y, char Direction)> Movements { get; }

    public Pointer(char[,] map, int startingX, int startingY)
    {
        _map = map;
        Facing = Direction.Right;
        X = startingX;
        Y = startingY;
        VisitedTiles = new Dictionary<(int X, int Y), char>();
        Movements = new List<(int X, int Y, char Direction)>();
    }

    public void Move((char Command, int Amount) command)
    {
        switch (command.Command)
        {
            case 'F':
                Action getLocation = Facing switch
                {
                    Direction.Right => () => X = GetLocationRightOfMyself(),
                    Direction.Down => () => Y = GetLocationBelowMyself(),
                    Direction.Left => () => X = GetLocationLeftOfMyself(),
                    _ => () => Y = GetLocationAboveMyself(),
                };

                for (var step = 0; step < command.Amount; step++)
                {
                    getLocation();
                    RecordPosition();
                }
                break;

            case 'R':
                Facing = (Direction)(((int)Facing + 1) % 4);
                RecordPosition();
                break;

            case 'L':
                Facing = (Direction)(((int)Facing + 3) % 4);
                RecordPosition();
                break;

            default:
                throw new ArgumentException();
        }
    }

    private int GetLocationRightOfMyself()
    {
        var newX = X + 1;
        if (_map[Y, newX] == ' ')
        {
            return WrapRight();
        }

        return _map[Y, newX] == '#' ? X : newX;
    }

    private int GetLocationLeftOfMyself()
    {
        var newX = X - 1;
        if (_map[Y, newX] == ' ')
        {
            return WrapLeft();
        }

        return _map[Y, newX] == '#' ? X : newX;
    }

    private int GetLocationBelowMyself()
    {
        var newY = Y + 1;
        if (_map[newY, X] == ' ')
        {
            return WrapDown();
        }

        return _map[newY,X] == '#' ? Y : newY;
    }

    private int GetLocationAboveMyself()
    {
        var newY = Y - 1;
        if (_map[newY, X] == ' ')
        {
            return WrapUp();
        }

        return _map[newY,X] == '#' ? Y : newY;
    }

    private int WrapRight() =>
        WrapHorizontally(() => 1, x => x + 1);

    private int WrapLeft() =>
        WrapHorizontally(() => _map.GetLength(1) - 2, x => x - 1);

    private int WrapHorizontally(Func<int> initializer, Func<int, int> modifier)
    {
        var wrappedX = initializer();
        while (_map[Y, wrappedX] == ' ')
        {
            wrappedX = modifier(wrappedX);
        }

        return _map[Y, wrappedX] == '#' ? X : wrappedX;
    }

    private int WrapDown()
    {
        var y = 0;
        while (_map[y, X] == ' ')
        {
            y++;
        }

        return _map[y, X] == '#' ? Y : y;
    }

    private int WrapUp()
    {
        var y = _map.GetLength(0)- 1;
        while (_map[y, X] == ' ')
        {
            y--;
        }

        if (_map[y, X] == '#')
        {
            return Y;
        }

        return y;
    }

    public long Decode() => 1000 * Y + 4 * X + (int)Facing;

    private void RecordPosition()
    {
        var direction = Facing switch {
            Direction.Down => 'v',
            Direction.Up => '^',
            Direction.Left => '<',
            _ => '>'
        };

        Movements.Add((X, Y, direction));
        if (VisitedTiles.ContainsKey((X, Y)))
        {
            VisitedTiles[(X, Y)] = direction;
        }
        else
        {
            VisitedTiles.Add((X, Y), direction);
        }
    }
}
