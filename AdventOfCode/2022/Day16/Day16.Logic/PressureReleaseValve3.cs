namespace Day16.Logic;

public class PressureReleaseValve3
{
    private readonly string _input;
    private readonly string[] _lines;
    private int _elapsedTime;
    private int _maximumReleasedPressure;
    private readonly List<List<int>> _routes;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly Dictionary<string, int> _namesToIndex;
    private readonly List<int> _visitedValves;
    private readonly List<Valve> _valves;
    private readonly int[][] _graph;

    private readonly int[] _orderedFlow;
    private readonly string[] _indexToNames;

    private readonly Elephant[] _elephants;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public PressureReleaseValve3(string input, int[][] graph, string[] orderedNodes, int[] orderedFlow)
    {
        _input = input;
        _lines = input.Split("\n");
        _elapsedTime = 0;
        _pipeSystem = new Dictionary<string, Valve>();
        _graph = graph;
        _namesToIndex = orderedNodes.Select((p, i) => new { p, i }).ToDictionary(a => a.p, a => a.i);
        _indexToNames = orderedNodes;
        _orderedFlow = orderedFlow;
        _visitedValves = new List<int>();
        _valves = new List<Valve>();

        var order = 0;
        foreach (var line in _lines.Order())
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var flowRate = int.Parse(sections[0].Split("=")[1]);

            var createdValve = new Valve(order++, valve, flowRate);
            _pipeSystem.Add(valve, createdValve);
            _valves.Add(createdValve);
        }

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var others = new string(sections[1].AsSpan()[23..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
            }
        }

        var root = _pipeSystem["AA"];
        var maximumTime = 30;
        var routes = new HashSet<string>();
        var currentPath = new List<int>();
        GenerateRoutesRecursively(root, routes, currentPath, 0, maximumTime);
        var longestRoutes = routes.Max(p => p.Length);
        _routes = routes
            .Select(r => r.Split(",")
            .ToList().ConvertAll(r => int.Parse(r)))
            .ToList();

        var visitedValves = new HashSet<int>();
        for (var routeIndex = 0; routeIndex < _routes.Count; routeIndex++)
        {
            var name = "AA";

            _elephants = new Elephant[]
            {
                new Elephant(_pipeSystem[name], _pipeSystem, _graph, _indexToNames, routeIndex, _routes)
            };

            _elapsedTime = 0;
            visitedValves.Clear();
            foreach (var valve in _pipeSystem.Values)
            {
                valve.Close();
                valve.Unvisit();
            }

            while (_elapsedTime < maximumTime)
            {
                _elephants[0].Act(_elapsedTime, visitedValves);
                _elapsedTime++;
            }

            var currentPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure(maximumTime));
            if (currentPressure > _maximumReleasedPressure)
            {
                _maximumReleasedPressure = currentPressure;
            }
        }
    }

    public PressureReleaseValve3(string input, int[][] graph, string[] orderedNodes, int[] orderedFlow, int scavengerCount)
    {
        _input = input;
        _lines = input.Split("\n");
        _elapsedTime = 0;
        _pipeSystem = new Dictionary<string, Valve>();
        _graph = graph;
        _namesToIndex = orderedNodes.Select((p, i) => new { p, i }).ToDictionary(a => a.p, a => a.i);
        _indexToNames = orderedNodes;
        _orderedFlow = orderedFlow;
        _visitedValves = new List<int>();
        _valves = new List<Valve>();

        var order = 0;
        foreach (var line in _lines.Order())
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var flowRate = int.Parse(sections[0].Split("=")[1]);

            var createdValve = new Valve(order++, valve, flowRate);
            _pipeSystem.Add(valve, createdValve);
            _valves.Add(createdValve);
        }

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var others = new string(sections[1].AsSpan()[23..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
            }
        }

        var name = "AA";
        var root = _pipeSystem[name];
        var maximumTime = 26;
        var routes = new HashSet<string>();
        var currentPath = new List<int>();
        GenerateRoutesRecursively(root, routes, currentPath, 0, maximumTime);
        var longestRoutes = routes.Max(p => p.Length);
        _routes = routes
            .Select(r => r.Split(",")
            .ToList().ConvertAll(r => int.Parse(r)))
            .ToList();

        _elephants = new Elephant[]
        {
            new Elephant(root, _pipeSystem, _graph, _indexToNames, 0, _routes),
            new Elephant(root, _pipeSystem, _graph, _indexToNames, 0, _routes)
        };

        var visitedValves = new HashSet<int>();
        for (var firstElephant = 0; firstElephant < _routes.Count - 1; firstElephant++)
        {
            for (var secondElephant = firstElephant + 1; secondElephant < _routes.Count; secondElephant++)
            {
                _elephants[0].ResetFor(firstElephant);
                _elephants[1].ResetFor(secondElephant);

                _elapsedTime = 0;

                visitedValves.Clear();
                foreach (var valve in _pipeSystem.Values)
                {
                    valve.Close();
                    valve.Unvisit();
                }

                while (_elapsedTime < maximumTime && !(_elephants[0].Action == Elephant.ScavengeActions.Rest && _elephants[1].Action == Elephant.ScavengeActions.Rest))
                {
                    _elephants[0].Act(_elapsedTime, visitedValves);
                    _elephants[1].Act(_elapsedTime, visitedValves);
                    _elapsedTime++;
                }

                var currentPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure(maximumTime));
                if (currentPressure > _maximumReleasedPressure)
                {
                    _maximumReleasedPressure = currentPressure;
                }
            }

            if (firstElephant % 100 == 0)
            {
                Console.WriteLine($"{firstElephant} - {_maximumReleasedPressure}");
            }
        }
    }


    private void GenerateRoutesRecursively(Valve currentValve, HashSet<string> visited, List<int> currentPath, int distance, int maximumTime)
    {
        if (distance >= maximumTime)
        {
            return;
        }

        currentPath.Add(currentValve.Order);
        for (var index = 0; index < _graph[currentValve.Order].Length; index++)
        {
            if (_graph[currentValve.Order][index] > 0)
            {
                var valve = _valves[index];
                if (valve.FlowRate > 0 && !currentPath.Contains(valve.Order))
                {
                    var visitedAmount = visited.Count;
                    GenerateRoutesRecursively(valve, visited, currentPath, distance + _graph[currentValve.Order][index] + 1, maximumTime);
                    if (visitedAmount != visited.Count)
                    {
                        currentPath.RemoveAt(currentPath.Count - 1);
                    }
                }
            }
        }

        var path = string.Join(",", currentPath);
        if (!visited.Contains(path))
        {
            visited.Add(path);
        }
    }
}

/*
public class PressureReleaseValve2
{
    private readonly string[] _lines;
    private int _elapsedTime;
    private int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly Dictionary<string, Valve> _pipeSystem2;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public PressureReleaseValve2(string input)
    {
        _lines = input.Split("\n");
        _elapsedTime = 0;
        _pipeSystem = new Dictionary<string, Valve>();
        _pipeSystem2 = new Dictionary<string, Valve>();

        var order = 0;
        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var flowRate = int.Parse(sections[0].Split("=")[1]);
            _pipeSystem.Add(valve, new Valve(order, valve, flowRate));
            _pipeSystem2.Add(valve, new Valve(order++, valve, flowRate));
        }

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var others = new string(sections[1].AsSpan()[23..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
                _pipeSystem[valve].AddConnectedValve(_pipeSystem2[other]);
            }
        }

        var name = "AA";
        _elapsedTime = 0;
        for (var index = 0; index < _pipeSystem[name].ConnectedValves.Count - 1; index++)
        {
            var humanValve = _pipeSystem[name].ConnectedValves[index];
            for (var subIndex = index + 1; subIndex < _pipeSystem2[name].ConnectedValves.Count; subIndex++)
            {
                var elephantValve = _pipeSystem2[name].ConnectedValves[subIndex];

                var oldElapsedTime = _elapsedTime;
                _elapsedTime++;
                var walker = new Walker(humanValve, elephantValve, _elapsedTime, _pipeSystem, 30);

                var pressure = walker.ReleasedPressure;
                if (pressure > _maximumReleasedPressure)
                {
                    _maximumReleasedPressure = pressure;
                }

                elephantValve.Close();
                humanValve.Close();

                _elapsedTime = oldElapsedTime;

            }
        }


//        var name = "AA";
//        _elapsedTime = 0;
//
//        for (var index = 0; index < _pipeSystem[name].ConnectedValves.Count - 1; index++)
//        {
//            var humanValve = _pipeSystem[name].ConnectedValves[index];
//            for (var subIndex = index + 1; subIndex < _pipeSystem[name].ConnectedValves.Count; subIndex++)
//            {
//                var elephantValve = _pipeSystem[name].ConnectedValves[subIndex];
//
//                var oldElapsedTime = _elapsedTime;
//                _elapsedTime++;
//                var walker = new Walker2(humanValve, elephantValve, _elapsedTime, _pipeSystem, 30);
//
//                var pressure = walker.ReleasedPressure;
//                if (pressure > _maximumReleasedPressure)
//                {
//                    _maximumReleasedPressure = pressure;
//                }
//
//                elephantValve.Close();
//                humanValve.Close();
//
//                _elapsedTime = oldElapsedTime;
//            }
//        }
    }
}*/