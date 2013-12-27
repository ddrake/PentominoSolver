using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentomino
{
    public class Game
    {
        private List<Piece> originalPieces;
        private List<Piece> freePieces;
        private Board board;
        private List<List<Placement>> solutions;

        public List<Piece> FreePieces { get { return freePieces; } }
        public Board Board { get { return board; } }
        public List<List<Placement>> Solutions { get { return solutions; } }

        public Game(Board board)
        {
            this.board = board;
            this.originalPieces = new List<Piece>(12);
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
            this.originalPieces.Add(piece);
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
            Piece piece = freePieces[0];
            Placement[] placements = board.PossiblePlacementsFor(piece);
            if (placements.Length == 0) return;
            foreach (Placement placement in placements)
            {
                if (HasSolution(placement))
                {
                    solutions.Add(new List<Placement>(board.Placements));
                }
                ResetPieces();
            }
        }

        public bool HasSolution(Placement placement)
        {
            // Play the piece, removing it from free pieces.
            PlayPiece(placement);
            if (freePieces.Count == 0) return true;
            Piece piece = freePieces[0];
            Placement[] placements = board.PossiblePlacementsFor(piece);
            foreach (Placement nextPlacement in placements)
            {
                if (HasSolution(nextPlacement)) return true;
            }
            // Un-play the piece, adding it back to free pieces.
            UnPlayPiece(placement);
            return false;
        }


        public void ResetPieces()
        {
            freePieces = new List<Piece>(12);
            freePieces.AddRange(originalPieces);
            board.Clear();
        }
    }
}
