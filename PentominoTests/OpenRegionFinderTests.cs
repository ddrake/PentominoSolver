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
        var open = new HashSet<Pt> { new Pt(0, 1), new Pt(1, 0) };
        var closed = new HashSet<Pt> { new Pt(0, 0), new Pt(1, 1) };
        var ca = new OpenRegionFinder(open, closed);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(2, connectedRegions.Count);
    }
    [Fact]
    void ShouldGetOneListOfconnectedRegionsForCrossShapedRegion()
    {
        var open = new HashSet<Pt> { new Pt(0, 1), new Pt(1, 0), new Pt(1, 1), new Pt(1, 2), new Pt(2,1) };
        var closed = new HashSet<Pt> { new Pt(0, 0), new Pt(0, 2), new Pt(2, 0), new Pt(2, 2) };
        var ca = new OpenRegionFinder(open, closed);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(1, connectedRegions.Count);
        Assert.Equal(5, connectedRegions.First().Count);
    }
    [Fact]
    void ShouldGetTwoListsOfconnectedRegionsForTwoDistinctRegions()
    {
        var open = new HashSet<Pt> { 
            new Pt(1, 1), new Pt(1, 2), new Pt(2, 1), new Pt(2,3), new Pt(2, 4) ,
            new Pt(3, 1), new Pt(3,4), new Pt(4, 1), new Pt(4,3), new Pt(4, 4)
        };
        var closed = new HashSet<Pt> { 
            new Pt(0, 0), new Pt(0, 1), new Pt(0,2), new Pt(0,3), new Pt(0,4),
            new Pt(0,5), new Pt(1,0), new Pt(1,3), new Pt(1,4), new Pt(1,5),
            new Pt(2,0), new Pt(2,2), new Pt(2,5), new Pt(3,0), new Pt(3,2),
            new Pt(3,3), new Pt(3,5), new Pt(4,0), new Pt(4,2), new Pt(4,5),
            new Pt(5,0), new Pt(5,1), new Pt(5,2), new Pt(5,3), new Pt(5,4),new Pt(5,5)
        };
        var ca = new OpenRegionFinder(open, closed);
        var connectedRegions = ca.FindRegions();
        Assert.Equal(2, connectedRegions.Count);
        Assert.Equal(5, connectedRegions.First().Count);
        Assert.Equal(5, connectedRegions.Last().Count);
    }

    [Fact]
    void ShouldBeAbleToDetectAnInvalidRegion()
    {
        var open = new HashSet<Pt> {
            new Pt(0,0), new Pt(0,1), new Pt(0,2), new Pt(1,1), new Pt(1,2), new Pt(2,2)
        };
        var closed = new HashSet<Pt> {
            new Pt(0,3), new Pt(1,0), new Pt(1,3), new Pt(2,0), new Pt(2,1), new Pt(2,3),
            new Pt(3,0), new Pt(3,1), new Pt(3,2), new Pt(3,3)
        };
        var ca = new OpenRegionFinder(open, closed);
        Assert.True(ca.HasInvalidRegions());
    }

    [Fact]
    void ShouldNotHaveInvalidRegionsWhenThereIsAnOwlShapedHole()
    {
        var open = new HashSet<Pt> {
            new Pt(1,1), new Pt(2,0), new Pt(2,1), new Pt(2,2), new Pt(3,1)
        };
        var closed = new HashSet<Pt> {
            new Pt(0,0), new Pt(0,1), new Pt(0,2), new Pt(1,0), new Pt(1,2), new Pt(1,3),
            new Pt(2,3), new Pt(3,0), new Pt(3,2), new Pt(3,3), new Pt(4,0), new Pt(4,1),
            new Pt(4,2), new Pt(5,0), new Pt(5,1)
        };
        var ca = new OpenRegionFinder(open, closed);
        Assert.False(ca.HasInvalidRegions());
    }

}

