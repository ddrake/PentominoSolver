using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pentomino;

namespace PentominoSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new Board(10,6));
            Owl owl = new Owl();
            game.AddPiece(owl);
            game.AddPiece(new Worm());
            game.AddPiece(new Ram());
            game.AddPiece(new Bat());
            game.AddPiece(new Bird());
            game.AddPiece(new Squirrel());
            game.AddPiece(new Snail());
            game.AddPiece(new Moose());
            game.AddPiece(new Crab());
            game.AddPiece(new Fish());
            game.AddPiece(new Whale());
            game.AddPiece(new Rabbit());

            game.PlayPiece(new Placement(owl.GetShape(Owl.Orientation.Any), new Location(2,1)));
            
            game.Solve();
            Console.WriteLine("Processing Complete");
            foreach (List<Placement> placements in game.Solutions)
            {
                game.WriteSolution(placements);
                Console.ReadKey();
            }
            
        }
    }
}

//game.AddPiece(new Snail());
//game.AddPiece(new Moose());
//game.AddPiece(new Crab());
//game.AddPiece(new Fish());
//game.AddPiece(new Rabbit());
//game.AddPiece(new Ram());
//game.AddPiece(new Worm());

//game.AddPiece(new Snail());
//game.AddPiece(new Crab());
//game.AddPiece(new Whale());
//game.AddPiece(new Squirrel());
//game.AddPiece(new Rabbit());
//game.AddPiece(new Owl());
