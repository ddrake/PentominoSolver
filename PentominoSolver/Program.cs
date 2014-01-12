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

            game.AddPiece(new Squirrel());
            game.AddPiece(new Bird());
            game.AddPiece(new Bat());
            game.AddPiece(new Owl());
            game.AddPiece(new Crab());
            game.AddPiece(new Ram());
            game.AddPiece(new Snail());
            game.AddPiece(new Moose());
            game.AddPiece(new Whale());
            game.AddPiece(new Fish());
            game.AddPiece(new Worm());
            game.AddPiece(new Rabbit());

            game.AddPresetPlacement(new Placement(Bat.Orientation.HeadTopLeft, 0, 0));
//            game.AddPresetPlacement(new Placement(Moose.Orientation.UpsideDownFacingLeft, 1, 0));
//            game.AddPresetPlacement(new Placement(Bird.Orientation.UpsideDownFacingRight, 3, 0));
//            game.AddPresetPlacement(new Placement(Worm.Orientation.Horizontal, 1,0));

            game.Solve();
            Console.WriteLine(String.Format("Processing Complete.  Found {0} solutions.", game.Solutions.Count()));
            foreach (List<Placement> placements in game.Solutions)
            {
                game.WriteSolution(placements);
            }
            Console.ReadKey();
        }
    }
}
