namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string course = "----..-.-----...--..----|";
            char PlayerA = 'A';
            char PlayerB = 'B';
            char[] TerrainCode = { '-', '.' };
            string[] Terrain = { "default", "muddy" };
            int PlayerAPos = 0;
            int PlayerBPos = 1;
            bool RunGame = true;

           while (RunGame)
            {
                bool APrint = false;
                bool BPrint = false;
                Console.Clear();
                for (int i = 0; i < course.Length; i++)
                {


                    //PlayerA Logic.
                    if (PlayerAPos == i && APrint == false)
                    {
                        Console.Write('A');

                        //Regular Terrain Logic
                        if (course[PlayerAPos] == '-')
                        {
                            Random rand = new Random();
                            int PlayerMove = rand.Next(1, 5);
                            if(PlayerMove == 4) 
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

                        //
                        BPrint = true;
                    }

                    else
                    {
                        Console.Write(course[i]);
                    }
                }
                Thread.Sleep(200);
            }


        }
    }
}
