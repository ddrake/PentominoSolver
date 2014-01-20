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
            Board board = new Board(4, 4, 4);
            board.RemoveSpace(new Pt(1, 1, 3));
            board.RemoveSpace(new Pt(1, 2, 3));
            board.RemoveSpace(new Pt(2, 1, 3));
            board.RemoveSpace(new Pt(2, 2, 3));
            board.RemoveSpace(new Pt(1, 1, 2));
            board.RemoveSpace(new Pt(1, 2, 2));
            board.RemoveSpace(new Pt(2, 1, 2));
            board.RemoveSpace(new Pt(2, 2, 2));
            board.RemoveSpace(new Pt(1, 1, 1));
            Game game = new Game(board);
            
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

            var presetGroups = new List<List<Placement>>();
            //var presets = new List<Placement>();
            //presets.Add(new Placement(Bat.Orientation.HeadTopLeft, 0, 0));
            //presets.Add(new Placement(Worm.Orientation.Horizontal, 1, 0));
            //presets.Add(new Placement(Bird.Orientation.UpsideDownFacingLeft, 0, 2));
            //presetGroups.Add(presets);
            SolveWithPresetPlacements(game, presetGroups);
        }

        private static void SolveWithPresetPlacements(Game game, List<List<Placement>> presetGroups)
        {
            int totalSolutions = 0;
            DateTime start = DateTime.Now;
            if (presetGroups.Count > 0)
            {
                foreach (List<Placement> presetGroup in presetGroups)
                {
                    foreach (Placement preset in presetGroup) game.AddPresetPlacement(preset);
                    totalSolutions += SolveAndDisplay(game, totalSolutions);
                    foreach (Placement preset in presetGroup) game.RemovePresetPlacement(preset);
                }

            }
            else totalSolutions = SolveAndDisplay(game, totalSolutions);
            Console.WriteLine(String.Format("Found all {0} solutions in {1} seconds.", totalSolutions, DateTime.Now.Subtract(start).TotalSeconds));
            Console.ReadKey();
        }

        private static int SolveAndDisplay(Game game, int totalSolutions)
        {
            game.Solve();
            LogResults(game);
            Console.WriteLine("*********************************");
            game.Board.ResetCache();
            return game.Solutions.Count;
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
