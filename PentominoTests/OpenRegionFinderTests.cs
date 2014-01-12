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
        bool[,] bitmap = { { true, false }, { false, true } };
        var ca = new OpenRegionFinder(bitmap);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(2, connectedRegions.Count);
    }
    [Fact]
    void ShouldGetOneListOfconnectedRegionsForCrossShapedRegion()
    {
        bool[,] bitmap = { { true, false, true }, { false, false, false }, { true, false, true } };
        var ca = new OpenRegionFinder(bitmap);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(1, connectedRegions.Count);
        Assert.Equal(5, connectedRegions.First().Count);
    }
    [Fact]
    void ShouldGetTwoListsOfconnectedRegionsForTwoDistinctRegions()
    {
        bool[,] bitmap = { {true, true, true, true, true, true }, 
                           {true, false, false, true, true, true }, 
                           {true, false, true, false, false, true }, 
                           {true, false, true, true, false, true }, 
                           {true, false, true, false, false, true }, 
                           {true, true, true, true, true, true } };
        var ca = new OpenRegionFinder(bitmap);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(2, connectedRegions.Count);
        Assert.Equal(5, connectedRegions.First().Count);
        Assert.Equal(5, connectedRegions.Last().Count);
    }

}

