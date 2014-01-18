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
        Assert.Equal<string>("Moose, Facing left at (0,0)", placements[0].ToString());
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
}
