namespace Assignment1
{
    abstract class Piece
    {
        public Vector2 Pos;
        public char Team;

        public Piece (char team)
        {
            Team = team;
        }

        public abstract List<Vector2> CalculateMovements();
    }

    class Knight : Piece
    {
        public Knight(char team) : base (team) 
        {
        }

        public override List<Vector2> CalculateMovements()
        {
            List<Vector2> movements =
            [
                Pos + new Vector2(1, -2),
                Pos - new Vector2(2, -1),
                Pos + new Vector2(2, -1),
                Pos - new Vector2(1, -2),
                Pos + new Vector2(1, 2),
                Pos - new Vector2(2, 1),
                Pos + new Vector2(2, 1),
                Pos - new Vector2(1, 2),
            ];

            return movements;
        }
    }

    struct Vector2
    {
        public int X, Y;

        public static readonly Vector2 Zero = new Vector2(0,0);

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }


        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
    class program
    {
        static void Main()
        {
            int boardSize = 8;
            List<Piece> = new List<Piece>();
            piece player = new Knight('X');
            List<Vector2> movements = new List<Vector2>();

            PrintBoard(Piece, boardSize);

            while (true)
            {
                Console.Clear();
                
                List<Vector2> movements = player.CalculateMovements();
                

                PrintBoard(Piece, boardSize);
                while (!Console.KeyAvailable) { }
                ConsoleKey key = Console.ReadKey(true).Key;
                Vector2 targetPos = Piece.Pos;

                if (key == ConsoleKey.Q)
                {
                    targetPos.Y -= 1;
                    targetPos.X -= 1;
                    Console.WriteLine(targetPos);
                }

                else if (key == ConsoleKey.E)
                {
                    targetPos.Y -= 1;
                    targetPos.X += 1;
                    Console.WriteLine(targetPos);
                }

                else if (key == ConsoleKey.A)
                {
                    targetPos.Y += 1;
                    targetPos.X -= 1;
                    Console.WriteLine(targetPos);
                }

                else if (key == ConsoleKey.D)
                {
                    targetPos.Y += 1;
                    targetPos.X += 1;
                    Console.WriteLine(targetPos);
                }
                if (targetPos.X >=0 && targetPos.X < boardSize && targetPos.Y >= 0 && targetPos.Y < boardSize)
                {
                    Piece.Pos = targetPos;
                }
            }

        }
        static void PrintBoard(Piece piece, int N)
        {
            string TilePiece = "[X]";
            string tile = "[ ]";
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (piece.Pos.Y == i && piece.Pos.X == j)
                    {
                        Console.Write(TilePiece);
                    }
                    else
                    {
                        Console.Write(tile);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(piece.Pos);

        }
    }

   
    //internal class GuessingGame
    //{
    //    static void Main(string[] args)
    //    {
    //        Vector2 location = new Vector2(0.0f, 0.0f);

    //        Character character = new Character(location, "cube");
    //        character.translateDistance = new Vector2(1.5f, 2.5f);
    //        character.position = character.Translate(character.translateDistance, character.position);
    //        Console.WriteLine(character.position);
            
           


            //        Console.WriteLine("Enter the Maximum number");
            //        int num = Convert.ToInt32(Console.ReadLine());
            //        Random rand = new Random();
            //        int Answer = rand.Next(1, num + 1);

            //        bool runtime = true;
            //        while (runtime)
            //        {
            //            Console.WriteLine($"Guess a number between 1 and {num}");
            //            int guess = Convert.ToInt32(Console.ReadLine());

            //            if (guess == Answer)
            //            {
            //                Console.WriteLine("Correct guess!");
            //                runtime = false;
            //            }

            //            else if (guess > Answer)
            //            {
            //                Console.WriteLine("Guess too high, try again");
            //            }

            //            else if (guess < Answer)
            //            {
            //                Console.WriteLine("Guess too low, try again");
            //            }

            //        }

            //    }
            //}

            //string text = "The quick brown fox jumps over the lazy dog";
            //bool run = true;
            //int loop = 0;
            //while (run)
            //{
            //    if (loop == 0)
            //    {
            //        Console.Clear();
            //        for (int i = 0; i < text.Length; i++)
            //        {
            //            Console.Write(text[i]);
            //            Thread.Sleep(100);
            //        }
            //        Console.WriteLine();

            //        Console.WriteLine("Enter a letter");
            //        loop++;
            //    }

            //    else
            //    {
            //        string letterString = Console.ReadLine();
            //        char LetterChar = Convert.ToChar(letterString);
            //        Console.Clear();
            //        for (int i = 0; i < text.Length; i++)
            //        {
            //            if (text[i] == LetterChar)
            //            {
            //                Console.Write(char.ToUpper(text[i]));
            //                Thread.Sleep(100);
            //            }

            //            else
            //            {
            //                Console.Write(text[i]);
            //                Thread.Sleep(100);
            //            }
            //        }
            //        Console.WriteLine();

            //        Console.WriteLine("Enter a letter");
            //    }
            //}



               
        //    }
        //}
    }
