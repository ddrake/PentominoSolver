using Xunit;
using Moq;
using Pentomino;
using System;
using System.Collections.Generic;


public class BoardTests
{
    [Fact]
    public void EmptyBoardShouldHavePlacementsForMoose()
    {
        //var mock = new Mock<Game>();
        //mock.Setup(game => game.FreePieces()).Returns(new IPiece[0]);

        Board board = new Board(10, 6);
        Moose moose = new Moose();
        Placement[] placements = board.PossiblePlacementsFor(moose);
        Assert.Equal(3 * 9 * 4 + 5 * 7 * 4, placements.Length);
    }

    [Fact]
    public void MoosePlacementsCanDisplayAsStrings()
    {
        Board board = new Board(10, 6);
        Moose moose = new Moose();
        Placement[] placements = board.PossiblePlacementsFor(moose);
        Assert.Equal<string>("Moose, Feet South, facing West at (0,0,0)", placements[0].ToString());
    }

    [Fact]
    public void PlacingMooseAddsItToBoardPlacements()
    {
        Board board = new Board(10, 6);
        Moose moose = new Moose();
        Placement placement = new Placement(moose.Shapes[0], new Pt(0, 0));
        board.Add(placement);
        Assert.Contains<Placement>(placement, board.Placements);
    }

    [Fact]
    public void BoardShouldBeAbleToClearItself()
    {
        Board board = new Board(10, 6);
        Moose moose = new Moose();
        Placement placement = new Placement(moose.Shapes[0], new Pt(0, 0));
        board.Add(placement);
        board.Clear();
        Assert.Equal(0, board.Placements.Count);
    }

    [Fact]
    public void RectangularBoardShouldRaiseExceptionIffSizeIsWrong()
    {
        Assert.Throws<ArgumentException>(() => new Board(3, 4));
        Assert.DoesNotThrow(() => new Board(3, 5));
    }
    [Fact]
    public void NonRectangularBoardShouldRaiseExceptionIffSizeIsWrong()
    {
        Assert.Throws<ArgumentException>(() => new Board(new HashSet<Pt>(){new Pt(1,1), new Pt(1,2)}));
        Assert.DoesNotThrow(() => new Board(new HashSet<Pt>() { new Pt(1, 1), new Pt(1, 2), new Pt(0,1), new Pt(1,0), new Pt(2,1) }));
    }
}
