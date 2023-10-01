using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        //Properties for controling and tracking the game
        char[,] board = new char[3, 3];
        bool gameOn = true;
        bool isWinner = false;
        char token = 'X';
        bool replay = true;
        string display = "";
        int turnCount = 0;
        Random rnd = new Random();

        static void Main(string[] args)
        {
            new Program().Run();
        }

        //Main method for running the program
        void Run()
        {
            while (replay)
            {
                Intro();
                DisplayBoard();
                do
                {

                    PlayerTurn();
                    CheckGame();
                    if (!gameOn) { break; }

                    AITurn();
                    CheckGame();
                }
                while (gameOn);
                Replay();
            }
            Console.ReadLine();
        }

        void Intro()
        {
            Help();
            Console.WriteLine("Use numbers 1-9 to the related square to place a 'X'.");
            Console.WriteLine("First to create 3 in a row, wins!");
            Console.WriteLine("Press 0 to see board layout");
            Console.WriteLine("-----------------------");
            Console.WriteLine("");
        }

        //Method displaying board squares with related number
        void Help()
        {
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" 7 | 8 | 9 ");
        }

        //Method for displaying the board
        void DisplayBoard()
        {
            display = "";
            for (int row = 0; row < 3; row++)
            {

                for (int col = 0; col < 3; col++)
                {
                    display += " " + board[row, col];
                    if (col != 2) { display += " |"; }
                }
                display += "\n";
                if (row != 2) { display += "---|---|---\n"; }

            }

            Console.WriteLine(display);
        }

        //Resets board for new game or exits
        void Replay()
        {
            Console.WriteLine("Play again? Y=Yes  N=Exit: ");
            string input = Console.ReadLine().ToUpper();

            if (input == "Y")
            {
                board = new char[3, 3];
                turnCount = 0;
                gameOn = true;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Game ending...");
                replay = false;
            }

        }

        //Tracks player's turn
        void PlayerTurn()
        {
            token = 'X';
            Console.WriteLine("Player's turn...");
            Console.WriteLine("Press 0 to see board layout");
            //DisplayBoard();
            bool playerTurn = true;
            while (playerTurn)
            {
                try
                {
                    //Valuates input for either displaying help or setting token
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                    {
                        Console.WriteLine("\nBoard Layout");
                        Help();
                        Console.WriteLine("\n");
                    }

                    else if (SetPiece(input))
                    {
                        turnCount++;
                        playerTurn = false;
                    }
                    else
                    {
                        Console.WriteLine("Select an open square");
                    }

                    DisplayBoard();
                }

                catch
                {
                    Console.WriteLine("Invalid input. Select from 1-9");
                }
            }

        }

        //Simple method for Computer's turn
        void AITurn()
        {
            token = 'O';
            bool computerTurn = true;
            //Loops until random generated number to board array is properly place
            while (computerTurn)
            {
                int num = rnd.Next(1, 9);
                if (SetPiece(num))
                {
                    computerTurn = false;
                    Console.WriteLine("AI's turn...");
                    DisplayBoard();

                    turnCount++;
                }
            }
        }

        //Checks if location on board is availble to place token
        bool SetPiece(int input)
        {
            bool isSet = false;
            switch (input)
            {
                case 1:
                    if (((byte)board[0, 0]).Equals(0))
                    {
                        board[0, 0] = token;
                        isSet = true;
                    }
                    break;
                case 2:
                    if (((byte)board[0, 1]).Equals(0))
                    {
                        board[0, 1] = token;
                        isSet = true;
                    }
                    break;
                case 3:
                    if (((byte)board[0, 2]).Equals(0))
                    {
                        board[0, 2] = token;
                        isSet = true;
                    }
                    break;
                case 4:
                    if (((byte)board[1, 0]).Equals(0))
                    {
                        board[1, 0] = token;
                        isSet = true;
                    }
                    break;
                case 5:
                    if (((byte)board[1, 1]).Equals(0))
                    {
                        board[1, 1] = token;
                        isSet = true;
                    }
                    break;
                case 6:
                    if (((byte)board[1, 2]).Equals(0))
                    {
                        board[1, 2] = token;
                        isSet = true;
                    }
                    break;
                case 7:
                    if (((byte)board[2, 0]).Equals(0))
                    {
                        board[2, 0] = token;
                        isSet = true;
                    }
                    break;
                case 8:
                    if (((byte)board[2, 1]).Equals(0))
                    {
                        board[2, 1] = token;
                        isSet = true;
                    }
                    break;
                case 9:
                    if (((byte)board[2, 2]).Equals(0))
                    {
                        board[2, 2] = token;
                        isSet = true;
                    }
                    break;
            }

            return isSet;
        }

        //Method to check game is over by tie or either player wins
        void CheckGame()
        {
            if (turnCount == 9)
            {
                gameOn = false;
                Console.WriteLine("Game over. Ended in a tie");
            }

            // check rows
            if (board[0, 0] == token && board[0, 1] == token && board[0, 2] == token) { gameOn = false; isWinner = true; }
            if (board[1, 0] == token && board[1, 1] == token && board[1, 2] == token) { gameOn = false; isWinner = true; }
            if (board[2, 0] == token && board[2, 1] == token && board[2, 2] == token) { gameOn = false; isWinner = true; }

            // check columns
            if (board[0, 0] == token && board[1, 0] == token && board[2, 0] == token) { gameOn = false; isWinner = true; }
            if (board[0, 1] == token && board[1, 1] == token && board[2, 1] == token) { gameOn = false; isWinner = true; }
            if (board[0, 2] == token && board[1, 2] == token && board[2, 2] == token) { gameOn = false; isWinner = true; }

            // check diags
            if (board[0, 0] == token && board[1, 1] == token && board[2, 2] == token) { gameOn = false; isWinner = true; }
            if (board[0, 2] == token && board[1, 1] == token && board[2, 0] == token) { gameOn = false; isWinner = true; }

            if (isWinner)
            {
                switch (token)
                {
                    case 'X':
                        {
                            Console.WriteLine("Game over. Player wins");
                            break;
                        }
                    case 'O':
                        {

                            Console.WriteLine("Game over. Computer wins");
                            break;
                        }
                }
            }
        }
    }
}
