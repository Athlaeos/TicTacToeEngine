using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEngine
{
    public class TicTacToeEngine
    {
        public enum GameStatus { PlayerOPlays, PlayerXPlays, Tie, PlayerOWins, PlayerXWins };
        private String[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private int turn = 1;

        private GameStatus status = GameStatus.PlayerOPlays;

        public GameStatus Status
        {
            get { return status; }
            private set { status = value; }
        }

        public String[] Board
        {
            get { return board; }
            private set { board = value; }
        }

        public int Turn
        {
            get { return turn; }
        }

        public TicTacToeEngine()
        {
            
        }

        public Boolean ChooseCell(int cell)
        {
            string player = "O";
            if (status == GameStatus.PlayerOPlays) player = "O";
            if (status == GameStatus.PlayerXPlays) player = "X";
            if (!(cell <= board.Length) || cell < 1) { return false; }
            if ((board[cell - 1] == "X" || board[cell - 1] == "O") == false)
            {
                board[cell - 1] = player;
                if (Won(board[0], board[1], board[2]) ||
                    Won(board[3], board[4], board[5]) ||
                    Won(board[6], board[7], board[8]) ||
                    Won(board[0], board[3], board[6]) ||
                    Won(board[1], board[4], board[7]) ||
                    Won(board[2], board[5], board[8]) ||
                    Won(board[0], board[4], board[8]) ||
                    Won(board[2], board[4], board[6]))
                {
                    if (status == GameStatus.PlayerOPlays) status = GameStatus.PlayerOWins;
                    if (status == GameStatus.PlayerXPlays) status = GameStatus.PlayerXWins;
                }
                if (turn >= 9) { status = GameStatus.Tie; return true; }
                if (status == GameStatus.PlayerOPlays)
                {
                    status = GameStatus.PlayerXPlays;
                } else if (status == GameStatus.PlayerXPlays)
                {
                    status = GameStatus.PlayerOPlays;
                }
                turn++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Won(String c1, String c2, String c3)
        {
            if ((c1 == "X" || c1 == "O") && c1 == c2 && c1 == c3)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            turn = 1;
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = "" + (i + 1);
            }
            if (status == GameStatus.PlayerOWins)
            {
                status = GameStatus.PlayerXPlays;
            }
            else if (status == GameStatus.PlayerXWins)
            {
                status = GameStatus.PlayerOPlays;
            }
        }

        public void Quit()
        {
            System.Environment.Exit(0);
        }
    }
}
