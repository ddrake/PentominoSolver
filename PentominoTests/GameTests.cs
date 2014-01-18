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
        Board board = new Board(5, 3);
        Game game = new Game(board);

        Assert.Equal(0, game.Solutions.Count);
    }

    [Fact]
    public void GameShouldBeAbleToResetItsPieces()
    {
        Board board = new Board(5, 3);
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
        // Solutions are:

        // moose facing right at 0,0
        // crab claws left at 3,0
        // snail upside down facing right at 0,1

        // snail facing right at 0,0
        // crab claws left at 3,0
        // moose upside down facing right at 0,1

        // crab claws right at 0,0
        // moose facing left at 1,0
        // snail upside down facing left at 2,1

        // crab claws right at 0,0
        // snail facing left at 2,0
        // moose upside down facing left at 1,1
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
        Board board = new Board(5, 3);
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
        Board board = new Board(5, 3);
        Game game = new Game(board);
        Piece moose = new Moose();
        game.AddPiece(moose);
        Placement placement = game.Board.PossiblePlacementsFor(moose)[0];
        game.PlayPiece(placement);
        Assert.Equal(0, game.FreePieces.Count);
        Assert.Equal(placement, game.Board.Placements[0]);
    }

    [Fact]
    public void GameShouldSolveNonRectangularPuzzles()
    {
        var spaces = new HashSet<Pt> {
            new Pt(0,0), new Pt(0,1), new Pt(0,2), new Pt(1,0), new Pt(1,1), new Pt(1,2), new Pt(1,3),
            new Pt(2,0), new Pt(2,1), new Pt(2,2), new Pt(2,3), new Pt(3,0), new Pt(3,1), new Pt(3,2), new Pt(3,3),
            new Pt(4,0), new Pt(4,1), new Pt(4,2), new Pt(5,0), new Pt(5,1)
        };
        Board board = new Board(spaces);
        Game game = new Game(board);
        game.AddPiece(new Owl());
        game.AddPiece(new Crab());
        game.AddPiece(new Snail());
        game.AddPiece(new Moose());
        game.Solve();
        Assert.Equal(1, game.Solutions.Count);
    }
    [Fact]
    public void SolveShouldThrowExceptionIffNotEnoughFreePiecesAreProvided()
    {
        Board board = new Board(3, 5);
        Game game = new Game(board);
        game.AddPiece(new Owl());
        Assert.Throws<ArgumentException>(() => game.Solve());
    }

    [Fact]
    public void SolveShouldHandleExtraPieces()
    {
        Board board = new Board(5, 3);
        Game game = new Game(board);
        game.AddPiece(new Ram());
        game.AddPiece(new Crab());
        game.AddPiece(new Moose());
        game.AddPiece(new Snail());
        game.AddPiece(new Fish());
        game.AddPiece(new Rabbit());
        game.Solve();
        Assert.True(game.Solutions.Count == 12);
    }

}
