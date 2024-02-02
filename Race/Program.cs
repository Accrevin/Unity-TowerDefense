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

            for (int j = 0; j < course.Length; j++)
            {
                bool APrint = false;
                bool BPrint = false;
                Console.Clear();
                for (int i = 0; i < course.Length; i++)
                {
                    if (PlayerAPos == i && APrint == false)
                    {
                        Console.Write('A');
                        PlayerAPos++;
                        APrint = true;
                    }

                    else if (PlayerBPos == i && BPrint == false)
                    {
                        Console.Write('B');
                        PlayerBPos++;
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
