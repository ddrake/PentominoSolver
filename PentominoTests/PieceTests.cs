using Xunit;
using Moq;
using Pentomino;
using System;
using System.Collections.Generic;

public class PieceTests
{
    [Fact]
    public void PieceShapesCanDisplayAsString()
    {
        Moose moose = new Moose();
        Assert.Equal<string>("Moose, Feet South, facing West", moose.Shapes[0].ToString());
    }

    [Fact]
    public void PieceShapesAreEqualIfTheirValuesAre()
    {
        Moose moose = new Moose();
        Assert.True(moose.Equals(new Moose()));
    }

    [Fact]
    public void BitmapCanBeFlippedHorizontally()
    {
        var closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(0, 2), new Pt(0, 3), new Pt(1, 0), new Pt(1, 1) };
        var flipped = new HashSet<Pt>() { new Pt(0, 0), new Pt(0, 1), new Pt(1, 1), new Pt(1, 2), new Pt(1, 3) };
        var result = Shape.FlipBitmapHorizontally(closed);
        Assert.True(flipped.IsSubsetOf(result) && result.IsSubsetOf(flipped));
    }
    [Fact]
    public void BitmapCanBeFlippedVertically()
    {
        var closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(0, 2), new Pt(0, 3), new Pt(1, 0), new Pt(1, 1) };
        var flipped = new HashSet<Pt>() { new Pt(0, 0), new Pt(0, 1), new Pt(0, 2), new Pt(1, 2), new Pt(1, 3) };
        var result = Shape.FlipBitmapVertically(closed);
        Assert.True(flipped.IsSubsetOf(result) && result.IsSubsetOf(flipped));
    }
    [Fact]
    public void BitmapCanBeRotatedClockwise()
    {
        var closed = new HashSet<Pt>() { new Pt(0, 1), new Pt(0, 2), new Pt(0, 3), new Pt(1, 0), new Pt(1, 1) };
        var rotated = new HashSet<Pt>() { new Pt(0, 0), new Pt(1, 0), new Pt(1, 1), new Pt(2, 1), new Pt(3, 1) };
        var result = Shape.RotateBitmapClockwise(closed);
        Assert.True(rotated.IsSubsetOf(result) && result.IsSubsetOf(rotated));
    }
}
