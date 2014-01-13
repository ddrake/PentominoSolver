using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pentomino;
using System.IO;


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

            List<Placement> presets = new List<Placement>();
//            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 0, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 1, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 2, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 3, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 4, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 5, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 6, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 0, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 1, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 2, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 3, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 4, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 5, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 6, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 7, 1));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 0, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 1, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 2, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 3, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 4, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 5, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 6, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 7, 2));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 1, 3));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 2, 3));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 3, 3));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 4, 3));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 5, 3));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 6, 3));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 7, 3));
            SolveWithPresetPlacements(game, presets);
        }

        private static void SolveWithPresetPlacements(Game game, List<Placement> presets)
        {
            int totalSolutions = 0;
            foreach (Placement preset in presets)
            {
                game.AddPresetPlacement(preset);
                game.Solve();
                totalSolutions += game.Solutions.Count;
                LogResults(game);
                Console.WriteLine("*********************************");
                game.Board.ResetCache();
                game.RemovePresetPlacement(preset);
            }
            Console.WriteLine(String.Format("Total solutions found: {0}", totalSolutions));
            Console.ReadKey();
        }

        private static void LogResults(Game game)
        {
            Console.WriteLine(String.Format("Processing Complete.  Found {0} solutions.", game.Solutions.Count()));
            using (StreamWriter writer = new StreamWriter("results.txt", true))
            {
                foreach (List<Placement> placements in game.Solutions)
                {
                    game.WriteSolution(placements, writer);
                }
            }
        }

    }
}
