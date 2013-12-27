using Xunit;
using Moq;
using Pentomino;

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
        Assert.Equal(3*9*4 + 5*7*4, placements.Length);
        Assert.Equal<string>("Moose, Facing left at (0,0)", placements[0].ToString());
    }

}


