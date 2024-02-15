using System.Net.Quic;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string course = "----..-.-----...--..----|";
            int PlayerAPos = 0;
            int PlayerBPos = 0;
            bool RunGame = true;

            while (RunGame)
            {
                //Checks if program has already printed A or B in this loop yet
                bool APrint = false;
                bool BPrint = false;
                Console.Clear();
                for (int i = 0; i < course.Length; i++)
                {

                    //Check to see if any of the players have reached the end of the course yet

                    if (PlayerAPos >= course.Length - 1 || PlayerBPos >= course.Length - 1)
                    {
                        if (PlayerAPos >= course.Length - 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player A wins!");
                            RunGame = false;
                            break;
                        }

                        else if (PlayerBPos >= course.Length - 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player B wins!");
                            RunGame = false;
                            break;
                        }

                    }


                    //PlayerA Logic.
                    if (PlayerAPos == i && APrint == false)
                    {
                        Console.Write('A');

                        //Regular Terrain Logic
                        if (course[PlayerAPos] == '-')
                        {
                            Random rand = new Random();
                            int PlayerMove = rand.Next(1, 5);
                            if (PlayerMove == 4)
                            {
                                PlayerAPos++;
                            }
                        }

                        //Muddy Terrain Logic
                        else if (course[PlayerAPos] == '.')
                        {
                            Random rand = new Random();
                            int PlayerMove = rand.Next(1, 9);
                            if (PlayerMove == 8)
                            {
                                PlayerAPos++;
                            }
                        }

                        APrint = true;
                    }


                    //PlayerB Logic.
                    else if (PlayerBPos == i && BPrint == false)
                    {
                        Console.Write('B');
                        //Regular Terrain Logic
                        if (course[PlayerBPos] == '-')
                        {
                            Random rand = new Random();
                            int PlayerMove = rand.Next(1, 5);
                            if (PlayerMove == 4)
                            {
                                PlayerBPos++;
                            }
                        }

                        //Muddy Terrain Logic
                        else if (course[PlayerBPos] == '.')
                        {
                            Random rand = new Random();
                            int PlayerMove = rand.Next(1, 9);
                            if (PlayerMove == 8)
                            {
                                PlayerBPos++;
                            }
                        }

                        BPrint = true;
                    }

                    else
                    {
                        Console.Write(course[i]);
                    }

                }


                //zzz
                Thread.Sleep(200);
            }


        }
    }
}