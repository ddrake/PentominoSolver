using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pentomino
{
    public class Game
    {
        private List<Piece> originalFreePieces;
        private List<Placement> presetPlacements;
        private List<Piece> freePieces;
        private Board board;
        private List<List<Placement>> solutions;

        public List<Piece> FreePieces { get { return freePieces; } }
        public Board Board { get { return board; } }
        public List<List<Placement>> Solutions { get { return solutions; } }

        public Game(Board board)
        {
            this.board = board;
            this.originalFreePieces = new List<Piece>(12);
            this.presetPlacements = new List<Placement>(4);
            this.freePieces = new List<Piece>(12);
            ClearSolutions();
        }

        private void ClearSolutions()
        {
            this.solutions = new List<List<Placement>>(10);
        }

        public void AddPiece(Piece piece)
        {
            this.freePieces.Add(piece);
            this.originalFreePieces.Add(piece);
        }

        public void AddPresetPlacement(Placement placement)
        {
            this.presetPlacements.Add(placement);
        }

        public void PlayPiece(Placement placement)
        {
            this.board.Add(placement);
            placement.RemovePieceFromList(ref freePieces);
        }

        public void UnPlayPiece(Placement placement)
        {
            this.board.Remove(placement);
            placement.AddPieceToList(ref freePieces);
        }

        public void Solve()
        {
            ClearSolutions();
            if (freePieces.Count == 0) return;
            ResetPieces(); 
            Piece piece = freePieces[0];
            Placement[] placements = board.PossiblePlacementsFor(piece);
            if (placements.Length == 0) return;
            foreach (Placement placement in placements)
            {
                if (HasSolution(placement,1))
                {
                    solutions.Add(new List<Placement>(board.Placements));
                    WriteSolution(board.Placements);
                }
                else
                {
                    Console.WriteLine(String.Format("No solution for {0}", placement));
                }
                ResetPieces();
            }
        }

        public bool HasSolution(Placement placement, int level)
        {
            // Play the piece, removing it from free pieces.
            if (level <= 1) Console.WriteLine(String.Format("{0} {1}", level, placement));
            PlayPiece(placement);
            if (freePieces.Count == 0) return true;
            Piece piece = freePieces[0];
            Placement[] placements = board.PossiblePlacementsFor(piece);
            foreach (Placement nextPlacement in placements)
            {
                if (HasSolution(nextPlacement, level+1)) return true;
            }
            // Un-play the piece, adding it back to free pieces.
            UnPlayPiece(placement);
            return false;
        }


        public void ResetPieces()
        {
            board.Clear();
            freePieces = new List<Piece>(12);
            freePieces.AddRange(originalFreePieces);
            foreach( Placement placement in presetPlacements)
            {
                PlayPiece(placement);
            }
        }

        public void WriteSolution(List<Placement> placements)
        {
            Console.WriteLine("Solution");
            foreach (Placement placement in placements)
            {
                Console.WriteLine(placement.ToString());
            }
            Console.WriteLine();
        }
    }
}
