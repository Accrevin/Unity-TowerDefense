using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Checkers
{
    class Piece
    {
        public Vector2 Pos;
        public char Team;

        public Piece(char team)
        {
            Team = team;
        }
    }

    class program
    {
        static void Main()
        {

            //Dictionary to turn the coordinate letters into numbers
            Dictionary<char, int> BoardPlaces = new Dictionary<char, int>();

            BoardPlaces.Add('a', 0);
            BoardPlaces.Add('b', 1);
            BoardPlaces.Add('c', 2);
            BoardPlaces.Add('d', 3);
            BoardPlaces.Add('e', 4);
            BoardPlaces.Add('f', 5);
            BoardPlaces.Add('g', 6);
            BoardPlaces.Add('h', 7);


            //keep track of who's turn it is (0 = X, 1 = O)
            int turn = 0;
            //8x8 board
            int boardSize = 8;

            List<Piece> Xpieces = new List<Piece>();
            List<Piece> Opieces = new List<Piece>();


            //Set the starting positions of the 'O' Pieces
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Piece Player = new Piece('O');


                    int xPosition = (j * 2 + i % 2 + 1);
                    if (xPosition >= 8)
                    {
                        xPosition = 0;
                    }
                    int yPosition = i;

                    Player.Pos = new Vector2(xPosition, yPosition);
                    Player.Team = 'O';
                    Opieces.Add(Player);

                }
            }


            //Set the starting positions of the 'X' Pieces
            for (int i = 7; i >= 5; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    Piece Player = new Piece('X');


                    int xPosition = (j * 2 + i % 2 + 1);
                    if (xPosition >= 8)
                    {
                        xPosition = 0;
                    }
                    int yPosition = i;

                    Player.Pos = new Vector2(xPosition, yPosition);
                    Player.Team = 'X';
                    Xpieces.Add(Player);
                }
            }

            //initial board display
            PrintBoard(Xpieces, Opieces, boardSize);

            while (true)
            {
      
                Console.Clear();
                PrintBoard(Xpieces, Opieces, boardSize);
                Console.WriteLine();


                //'X' Turn
                if (turn == 0)
                {
                    Console.WriteLine("Player X turn");
                    string moveinput = Console.ReadLine();

                    //split input into selected piece and direction to move in
                    string[] move = moveinput.Split(' ');



                    int TargetIndex = -1;

                    //order of input should be letter then number
                    string movePiece = move[0];
                    if (movePiece.Length < 2)
                    {
                        Console.WriteLine("Invalid move format. Please enter a valid move.");
                        continue;
                    }

                    //look up the letter in the dictionary
                    int Xtarget = BoardPlaces[movePiece[0]];

                    //Take the number from the coordinates
                    int YTargetSubtract = Convert.ToInt32(movePiece.Substring(1));
                    //math
                    int Ytarget = boardSize - YTargetSubtract;

                    //turn the numbers from input into a Vector 2 to compare to the positions of pieces
                    Vector2 TargetPiecePos = new Vector2(Xtarget, Ytarget);

                    // Find the index of the piece to move
                    for (int i = 0; i < Xpieces.Count; i++)
                    {
                        if (Xpieces[i].Pos == new Vector2(Xtarget, Ytarget))
                        {
                            TargetIndex = i;
                            break;
                        }
                    }

                    // Check if the piece was found
                    if (TargetIndex <= -1)
                    {
                        Console.WriteLine("Invalid move. Please enter a valid move.");
                        continue;
                    }

                    //select the piece
                    Piece TargetMovePiece = Xpieces[TargetIndex];

                    //set the movement
                    string directionMove = move[1];

                    Vector2 direction = Vector2.Zero;

                    Vector2 targetPos = TargetMovePiece.Pos;

                    if (directionMove == "left")
                    {
                        direction = new Vector2(-1, -1);
                        Console.WriteLine(targetPos);
                    }

                    else if (directionMove == "right")
                    {
                        direction = new Vector2(1, -1);
                        Console.WriteLine(targetPos);
                    }


                   
                    //if the player has moved check to see if the movement will make the piece go out of bounds
                    if (direction != Vector2.Zero)
                    {
                        Vector2 targetPosition = TargetMovePiece.Pos + direction;

                        //the player has now moved a piece. Change to player O's turn
                        turn = 1;

                        //if the player has moved check to see if the movement will make the piece go out of bounds
                        if (targetPos.X >= 0 || targetPos.X < boardSize && targetPos.Y >= 0 || targetPos.Y < boardSize)
                        {
                            TargetMovePiece.Pos = targetPos;

                            if (targetPosition.X >= 0 && targetPosition.X < boardSize
                            && targetPosition.Y >= 0 && targetPosition.Y < boardSize)
                            {
                                Piece occupyingPiece = null;

                                foreach (Piece piece in Opieces)
                                {
                                    if (piece.Pos == targetPosition)
                                    {
                                        occupyingPiece = piece;

                                        break;
                                    }
                                }

                                if (occupyingPiece == null)
                                {
                                    TargetMovePiece.Pos += direction;
                                }

                                else
                                {
                                    //if the spot is occupied by an O piece; calculate the movement to make to check to see if it will result in a piece moving off the board
                                    Vector2 CaptureTarget = TargetMovePiece.Pos + (direction + direction);

                                    //if it does only make it take up the spot the captured piece was on
                                    if (CaptureTarget.X <= 0 || CaptureTarget.X >= boardSize && CaptureTarget.Y <= 0 || CaptureTarget.Y >= boardSize)
                                    {
                                        TargetMovePiece.Pos += direction;
                                    }

                                    //if not then jump
                                    else
                                    {
                                        TargetMovePiece.Pos = CaptureTarget;
                                    }

                                    //remove captured piece
                                    Opieces.Remove(occupyingPiece);
                                }
                            }
                        }
                        continue;
                    }
                }


                //this is basically the exact same thing as X but swapped to O
                if (turn == 1)
                {
                    Console.WriteLine("Player O turn");
                    string moveinput = Console.ReadLine();
                    string[] move = moveinput.Split(' ');



                    int TargetIndex = -1;

                    string movePiece = move[0];
                    if (movePiece.Length < 2)
                    {
                        Console.WriteLine("Invalid move format. Please enter a valid move.");
                        continue;
                    }

                    int Xtarget = BoardPlaces[movePiece[0]];
                    int YTargetSubtract = Convert.ToInt32(movePiece.Substring(1));
                    int Ytarget = boardSize - YTargetSubtract;

                    Console.WriteLine($"Move Piece: {movePiece}, Xtarget: {Xtarget}, Ytarget: {Ytarget}");

                    Vector2 TargetPiecePos = new Vector2(Xtarget, Ytarget);

                    for (int i = 0; i < Opieces.Count; i++)
                    {
                        if (Opieces[i].Pos == new Vector2(Xtarget, Ytarget))
                        {
                            TargetIndex = i;
                            break;
                        }
                    }

                    if (TargetIndex == -1)
                    {
                        Console.WriteLine("Invalid move. Please enter a valid move.");
                        continue;
                    }

                    Piece TargetMovePiece = Opieces[TargetIndex];

                    string directionMove = move[1];

                    Vector2 direction = Vector2.Zero;

                    Vector2 targetPos = TargetMovePiece.Pos;

                    //go down rather than up
                    if (directionMove == "left")
                    {
                        direction = new Vector2(-1, 1);
                        Console.WriteLine(targetPos);
                    }

                    else if (directionMove == "right")
                    {
                        direction = new Vector2(1, 1);
                        Console.WriteLine(targetPos);
                    }





                    if (direction != Vector2.Zero)
                    {
                        Vector2 targetPosition = TargetMovePiece.Pos + direction;

                        turn = 0;

                        if (targetPos.X >= 0 || targetPos.X < boardSize && targetPos.Y >= 0 || targetPos.Y < boardSize)
                        {
                            TargetMovePiece.Pos = targetPos;

                            if (targetPosition.X >= 0 && targetPosition.X < boardSize
                            && targetPosition.Y >= 0 && targetPosition.Y < boardSize)
                            {
                                Piece occupyingPiece = null;

                                foreach (Piece piece in Xpieces)
                                {
                                    if (piece.Pos == targetPosition)
                                    {
                                        occupyingPiece = piece;

                                        break;
                                    }
                                }

                                if (occupyingPiece == null)
                                {
                                    TargetMovePiece.Pos += direction;
                                }

                                else
                                {
                                    Vector2 CaptureTarget = TargetMovePiece.Pos + (direction + direction);
                                    if (CaptureTarget.X <= 0 || CaptureTarget.X >= boardSize && CaptureTarget.Y <= 0 || CaptureTarget.Y >= boardSize)
                                    {
                                        TargetMovePiece.Pos += direction;
                                    }

                                    else
                                    {
                                        TargetMovePiece.Pos = CaptureTarget;
                                    }

                                    Xpieces.Remove(occupyingPiece);
                                }
                            }
                        }
                        continue;
                    }
                }



                //win conditions
                if (Opieces.Count == 0)
                {
                    Console.Clear();
                    PrintBoard(Xpieces, Opieces, boardSize);
                    Console.WriteLine("Game over! X wins!");
                    break;
                } 

                else if (Xpieces.Count == 0)
                {
                    Console.Clear();
                    PrintBoard(Xpieces, Opieces, boardSize);
                    Console.WriteLine("Game over! O wins!");
                    break;
                }

                //continue with the game if no one wins
                else
                {
                    continue;
                }
            }

        }


            static void PrintBoard(List<Piece> Xpieces, List<Piece> Opieces, int boardSize)
            {

            //Print out the corrdinate system
            char[] header = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];
            Console.Write("  ");
            for (int i = 0; i < header.Length; i++)
            {
                Console.Write($" {header[i]} ");
            }

            Console.WriteLine();
                
                for (int y = 0; y < boardSize; y++)
                {
                //Print the number for the row (its in reverse so math time)
                Console.Write($"{boardSize - y} ");

                    for (int x = 0; x < boardSize; x++)
                    {
                        bool isOccupied = false;

                        Console.Write("[");

                        //if a piece is at the location of the tile, print the piece's team
                        foreach (Piece piece in Xpieces)
                        {
                            if (piece.Pos == new Vector2(x, y))
                            {
                                Console.Write(piece.Team);

                                isOccupied = true;
                                break;
                            }
                        }

                        //if a piece is at the location of the tile, print the piece's team
                        foreach (Piece piece in Opieces)
                        {
                            if (piece.Pos == new Vector2(x, y))
                            {
                                Console.Write(piece.Team);

                                isOccupied = true;
                                break;
                            }
                        }

                        if (isOccupied == false)
                        {
                            Console.Write(" ");
                        }

                        Console.Write("]");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
