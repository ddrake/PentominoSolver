using Xunit;
using Moq;
using Pentomino;
using System;
using System.Collections.Generic;

public class GameTests
{
    [Fact]
    public void GameShouldInitiallyHaveAnEmptyListOfSolutions()
    {
        Board board = new Board(4, 3);  // todo: stub board
        Game game = new Game(board);

        Assert.Equal(0, game.Solutions.Count);
    }

    [Fact]
    public void GameShouldBeAbleToResetItsPieces()
    {
        Board board = new Board(4, 3);
        Game game = new Game(board);
        Piece moose = new Moose();
        game.AddPiece(moose);
        Placement placement = game.Board.PossiblePlacementsFor(moose)[0];
        game.PlayPiece(placement);
        game.ResetPieces();
        Assert.Equal(1, game.FreePieces.Count);
        Assert.Equal(0, game.Board.Placements.Count);
    }

    [Fact]
    public void GameShouldFindSolutionFor5x3Puzzle()
    {
        Board board = new Board(5, 3);
        Game game = new Game(board);
        game.AddPiece(new Rabbit());
        game.AddPiece(new Fish());
        game.AddPiece(new Ram());
        game.Solve();
        Assert.Equal(4, game.Solutions.Count);
    }
    [Fact]
    public void GameShouldFindSolutionFor5x3Puzzle2()
    {
        Board board = new Board(5, 3);
        Game game = new Game(board);
        game.AddPiece(new Snail());
        game.AddPiece(new Moose());
        game.AddPiece(new Crab());
        game.Solve();
        Assert.Equal(4, game.Solutions.Count);
    }

    [Fact]
    public void GamePiecesShouldBeStored()
    {
        Board board = new Board(4, 3);
        Game game = new Game(board);

        game.AddPiece(new Moose());
        game.AddPiece(new Bat());

        Assert.Equal(2, game.FreePieces.Count);
        Assert.Equal(new Moose(), game.FreePieces[0]);
        Assert.Equal(new Bat(), game.FreePieces[1]);
    }

    [Fact]
    public void GameShouldBeAbleToPlaceAShapeOnAnEmptyBoard()
    {
        Board board = new Board(4, 3);
        Game game = new Game(board);
        Piece moose = new Moose();
        game.AddPiece(moose);
        Placement placement = game.Board.PossiblePlacementsFor(moose)[0];
        game.PlayPiece(placement);
        Assert.Equal(0, game.FreePieces.Count);
        Assert.Equal(placement, game.Board.Placements[0]);
    }
}

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
        Placement placement = new Placement(moose.Shapes[0], new Location(0, 0));
        board.Add(placement);
        Assert.Contains<Placement>(placement, board.Placements);
    }

    [Fact]
    public void BoardShouldBeAbleToClearItself()
    {
        Board board = new Board(10, 6);
        Moose moose = new Moose();
        Placement placement = new Placement(moose.Shapes[0], new Location(0, 0));
        board.Add(placement);
        board.Clear();
        Assert.Equal(0, board.Placements.Count);
    }

      

}


public class PlacementTests
{
    [Fact]
    public void PlacementCanUpdateBoardsBitmap()
    {
        bool[,] boardMap = new bool[4, 3];
        Array.Clear(boardMap, 0, boardMap.Length);
        Moose moose = new Moose();
        Placement placement = new Placement(moose.Shapes[0], new Location(0, 0));
        bool[,] expected = new bool[,] { { false, true, false }, { true, true, false }, { true, false, false }, { true, false, false } };
        Assert.Equal(expected, placement.UpdateBitmap(boardMap, true));
    }
}

public class ShapeTests
{
    [Fact]
    public void ShapeCanBeConstructedFromAnEnumeration()
    {
        Shape mooseUpsideDown = new Moose().GetShape(Moose.Orientation.FacingLeft);
    }
}

public class PieceTests
{
    [Fact]
    public void PieceShapesCanDisplayAsString()
    {
        Moose moose = new Moose();
        Assert.Equal<string>("Moose, Facing left", moose.Shapes[0].ToString());
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
        bool[,] bitmap = new bool[,] { { false, true, true, true }, { true, true, false, false } };
        bool[,] flipped = new bool[,] { { true, true, false, false }, { false, true, true, true } };
        Assert.Equal(flipped, Shape.FlipBitmapHorizontally(bitmap));
    }
    [Fact]
    public void BitmapCanBeFlippedVertically()
    {
        bool[,] bitmap = new bool[,] { { false, true, true, true }, { true, true, false, false } };
        bool[,] flipped = new bool[,] { { true, true, true, false }, { false, false, true, true } };
        Assert.Equal(flipped, Shape.FlipBitmapVertically(bitmap));
    }
    [Fact]
    public void BitmapCanBeRotatedClockwise()
    {
        bool[,] bitmap = new bool[,] { { false, true, true, true }, { true, true, false, false } };
        bool[,] rotated = new bool[,] { {true, false }, { true, true }, { false, true }, { false, true } };
        Assert.Equal(rotated, Shape.RotateBitmapClockwise(bitmap));
    }
}


