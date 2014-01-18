using Xunit;
using Moq;
using Pentomino;
using System;
using System.Collections.Generic;

public class PlacementTests
{
    [Fact]
    public void PlacementCanUpdateBoardsBitmap()
    {
        var open = new HashSet<Pt> {   
            new Pt(0, 0), new Pt(0, 1), new Pt(0,2),
            new Pt(1, 0), new Pt(1, 1), new Pt(1,2),
            new Pt(2, 0), new Pt(2, 1), new Pt(2,2),
            new Pt(3, 0), new Pt(3, 1), new Pt(3,2)
        };
        var closed = new HashSet<Pt>();
        Moose moose = new Moose();
        Placement placement = new Placement(moose.Shapes[0], new Pt(0, 0));
        var expectedClosed = new HashSet<Pt> {
            new Pt(0, 1), new Pt(1, 0), new Pt(1,1), new Pt(2, 0), new Pt(3, 0)
        };
        var expectedOpen = new HashSet<Pt> {
            new Pt(0, 0), new Pt(0,2), new Pt(1,2), new Pt(2, 1), new Pt(2,2),
            new Pt(3,1), new Pt(3,2)
        };
        placement.UpdateBitmap(open, closed, true);
        Assert.Equal(expectedClosed, closed);
    }
}
