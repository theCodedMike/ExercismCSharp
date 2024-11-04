using System;
using System.Collections;

public struct Coord : IEquatable<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public bool Equals(Coord other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coord other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

public struct Plot
{
    // Complete implementation of the Plot struct
    private Coord[] _coord;

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        _coord = [coord1, coord2, coord3, coord4];
    }
    
    private int GetArea() => _coord.Sum(coord => coord.X * coord.Y);

    public static bool operator >(Plot p1, Plot p2) => p1.GetArea() > p2.GetArea();

    public static bool operator <(Plot p1, Plot p2) => !(p1 > p2);

    public bool Equal(Plot other)
    {
        for (int i = 0; i < _coord.Length; i++)
            if (!_coord[i].Equals(other._coord[i]))
                return false;
        
        return true;
    }
}


public class ClaimsHandler
{
    private readonly List<Plot> _plots;
    private Plot? _longestPlot;

    public ClaimsHandler()
    {
        _plots = new List<Plot>(10);
    }

    public void StakeClaim(Plot plot)
    {
        _plots.Add(plot);
        if (_longestPlot is null)
        {
            _longestPlot = plot;
            return;
        }

        if (plot > _longestPlot)
            _longestPlot = plot;
    }

    public bool IsClaimStaked(Plot plot)
    {
        foreach (var p in _plots)
            if (p.Equal(plot))
                return true;
        
        return false;
    }

    public bool IsLastClaim(Plot plot) => _plots[^1].Equal(plot);

    public Plot GetClaimWithLongestSide() => _longestPlot ?? _plots[0];
}
