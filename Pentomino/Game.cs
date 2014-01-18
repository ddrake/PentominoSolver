using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pentomino
{
    public class Game
    {
        public const int PENTOMINO_SIZE = 5; 
        public Board Board { get; private set; }
        private List<Piece> OriginalFreePieces { get; set; }
        private List<Placement> PresetPlacements { get; set; }
        public List<Piece> FreePieces { get; private set; }
        public List<List<Placement>> Solutions { get; private set; }
        private List<HashSet<Piece>> FreePieceSubsets { get; set; }

        public Game(Board board)
        {
            Board = board;
            OriginalFreePieces = new List<Piece>();
            PresetPlacements = new List<Placement>();
            ResetFreePieces();
            ClearSolutions();
        }

        public void AddPiece(Piece piece)
        {
            FreePieces.Add(piece);
            OriginalFreePieces.Add(piece);
        }

        public void AddPresetPlacement(Placement placement)
        {
            PresetPlacements.Add(placement);
        }

        public void RemovePresetPlacement(Placement placement)
        {
            PresetPlacements.Remove(placement);
        }

        public void PlayPiece(Placement placement)
        {
            Board.Add(placement);
            placement.RemovePieceFromList(FreePieces);
        }

        public void UnPlayPiece(Placement placement)
        {
            Board.Remove(placement);
            placement.AddPieceToList(FreePieces);
        }

        public void ResetPieces()
        {
            Board.Clear();
            ResetFreePieces();
            ReplayPresetPlacements();
        }

        public void Solve()
        {
            ClearSolutions();
            ResetPieces();
            List<List<Piece>> subsets = GenerateSubsets();
            foreach (var subset in subsets)
            {
                FreePieces = subset;
                SolveRecursively(1);
            }
        }

        private List<List<Piece>> GenerateSubsets()
        {
            if (FreePieces.Count < PieceCount)
                throw new ArgumentException("Not enough free pieces to fill the board");
            else
                return GenerateSubsetsRecursively(new List<Piece>(FreePieces), PieceCount,0);
        }

        private List<List<Piece>> GenerateSubsetsRecursively(List<Piece> pieces, int size, int skip)
        {
            if (pieces.Count < size) throw new ArgumentException("Can't generate n-element subsets from an set with fewer than n elements");
            if (pieces.Count == size) return new List<List<Piece>>() { new List<Piece>(pieces) };
            else
            {
                List<List<Piece>> subsets = new List<List<Piece>>();
                for (int i = skip; i < pieces.Count; ++i )
                {
                    Piece piece = pieces[i];
                    var newPieces = new List<Piece>(pieces);
                    newPieces.Remove(piece);
                    subsets.AddRange(GenerateSubsetsRecursively(newPieces, size, i));
                }
                return subsets;
            }
        }

        private int PieceCount { get { return Board.Size / PENTOMINO_SIZE; } }

        private void SolveRecursively(int level)
        {
            var possibles = Board.PossiblePlacementsFor(FreePieces.First());
            foreach (Placement placement in possibles)
            {
                ShowProgress(level, placement);
                PlayPiece(placement);
                if (FreePieces.Count == 0) AddSolution();
                else if (!Board.HasInvalidRegions()) SolveRecursively(level + 1);
                
                UnPlayPiece(placement);
            }
        }

        private void AddSolution()
        {
            Solutions.Add(Board.Placements.ToList<Placement>());
            ShowSuccess(Solutions.Count);
        }

        private void ClearSolutions() { Solutions = new List<List<Placement>>(100); }

        private void ResetFreePieces() { FreePieces = new List<Piece>(OriginalFreePieces); }

        private void ReplayPresetPlacements()
        {
            foreach (Placement placement in PresetPlacements) PlayPiece(placement);
        }


        private void ShowProgress(int level, Placement placement)
        {
            if (level == 1) Console.WriteLine(String.Format("{0}", placement)); 
        }

        private void ShowSuccess(int solutionCount)
        {
            Console.WriteLine(String.Format("Found solution #{0}!", solutionCount));
        }

        public void WriteSolution(List<Placement> placements, TextWriter output)
        {
            output.WriteLine("Solution");
            foreach (Placement placement in placements)
            {
                output.WriteLine(placement);
            }
            output.WriteLine();
        }
    }
}
