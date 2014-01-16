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
            Game game = new Game(new Board(20,3));

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
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 0, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 1, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 2, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 3, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 4, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 5, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 6, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 7, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 8, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 9, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 10, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 11, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 12, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 13, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 14, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 15, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 16, 0));
            presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 17, 0));
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
