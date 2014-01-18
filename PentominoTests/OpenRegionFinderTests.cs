using Xunit;
using Moq;
using Pentomino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OpenRegionFinderTests
{
    [Fact]
    void ShouldGetListsOfconnectedRegionsForSimpleBitmap()
    {
        var open = new HashSet<Location> { new Location(0, 1), new Location(1, 0) };
        var bitmap = new HashSet<Location> { new Location(0, 0), new Location(1, 1) };
        var ca = new OpenRegionFinder(open, bitmap);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(2, connectedRegions.Count);
    }
    [Fact]
    void ShouldGetOneListOfconnectedRegionsForCrossShapedRegion()
    {
        var open = new HashSet<Location> { new Location(0, 1), new Location(1, 0), new Location(1, 1), new Location(1, 2), new Location(2,1) };
        var bitmap = new HashSet<Location> { new Location(0, 0), new Location(0, 2), new Location(2, 0), new Location(2, 2) };
        var ca = new OpenRegionFinder(open, bitmap);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(1, connectedRegions.Count);
        Assert.Equal(5, connectedRegions.First().Count);
    }
    [Fact]
    void ShouldGetTwoListsOfconnectedRegionsForTwoDistinctRegions()
    {
        var open = new HashSet<Location> { 
            new Location(1, 1), new Location(1, 2), new Location(2, 1), new Location(2,3), new Location(2, 4) ,
            new Location(3, 1), new Location(3,4), new Location(4, 1), new Location(4,3), new Location(4, 4)
        };
        var bitmap = new HashSet<Location> { 
            new Location(0, 0), new Location(0, 1), new Location(0,2), new Location(0,3), new Location(0,4),
            new Location(0,5), new Location(1,0), new Location(1,3), new Location(1,4), new Location(1,5),
            new Location(2,0), new Location(2,2), new Location(2,5), new Location(3,0), new Location(3,2),
            new Location(3,3), new Location(3,5), new Location(4,0), new Location(4,2), new Location(4,5),
            new Location(5,0), new Location(5,1), new Location(5,2), new Location(5,3), new Location(5,4),new Location(5,5)
        };
        var ca = new OpenRegionFinder(open, bitmap);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(2, connectedRegions.Count);
        Assert.Equal(5, connectedRegions.First().Count);
        Assert.Equal(5, connectedRegions.Last().Count);
    }

}

