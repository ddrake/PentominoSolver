using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class Game
    {
        private const int AllPieces = 12;
        public Board Board { get; private set; }
        private List<Piece> OriginalFreePieces { get; set; }
        private List<Placement> PresetPlacements { get; set; }
        public List<Piece> FreePieces { get; private set; }
        public List<List<Placement>> Solutions { get; private set; }

        public Game(Board board)
        {
            Board = board;
            OriginalFreePieces = new List<Piece>();
            PresetPlacements = new List<Placement>();
            ResetFreePieces();
            ClearSolutions();
        }

        private void ClearSolutions()
        {
            this.Solutions = new List<List<Placement>>(100);
        }

        private void ResetFreePieces()
        {
            FreePieces = new List<Piece>(OriginalFreePieces);
        }

        public void AddPiece(Piece piece)
        {
            FreePieces.Add(piece);
            OriginalFreePieces.Add(piece);
        }

        public void AddPresetPlacement(Placement placement)
        {
            this.PresetPlacements.Add(placement);
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
            FreePieces = new List<Piece>(OriginalFreePieces);
            ReplayPresetPlacements();
        }

        private void ReplayPresetPlacements()
        {
            foreach (Placement placement in PresetPlacements) PlayPiece(placement);
        }
        
        public void Solve()
        {
            ClearSolutions();
            ResetPieces(); 
            SolveRecursively(1);
        }

        public void SolveRecursively(int level)
        {
            foreach (Placement placement in Board.PossiblePlacementsFor(FreePieces.First()))
            {
                ShowProgress(level, placement);
                PlayPiece(placement);
                if (FreePieces.Count == 0) AddSolution();
                else if (!Board.InvalidRegions()) SolveRecursively(level + 1);
                
                UnPlayPiece(placement);
            }
        }

        private void AddSolution()
        {
            Solutions.Add(Board.Placements.ToList<Placement>());
            ShowSuccess(Solutions.Count);
        }

        private void ShowProgress(int level, Placement placement)
        {
            if (level == 1) Console.WriteLine(String.Format("{0}", placement)); 
        }

        private void ShowSuccess(int solutionCount)
        {
            Console.WriteLine(String.Format("Found solution #{0}!", solutionCount));
        }

        public void WriteSolution(List<Placement> placements)
        {
            Console.WriteLine("\nSolution");
            foreach (Placement placement in placements)
            {
                Console.WriteLine(String.Format("{0}\n",placement));
            }
        }
    }
}
