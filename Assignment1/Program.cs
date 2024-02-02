namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            string text = "The quick brown fox jumps over the lazy dog";
            bool run = true;
            int loop = 0;
            while (run)
            {
                if (loop == 0)
                {
                    Console.Clear();
                    for (int i = 0; i < text.Length; i++)
                    {
                        Console.Write(text[i]);
                        Thread.Sleep(100);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Enter a letter");
                    loop++;
                }

                else
                {
                    string letterString = Console.ReadLine();
                    char LetterChar = Convert.ToChar(letterString);
                    Console.Clear();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == LetterChar)
                        {
                            Console.Write(char.ToUpper(text[i]));
                            Thread.Sleep(100);
                        }

                        else
                        {
                            Console.Write(text[i]);
                            Thread.Sleep(100);
                        }
                    }
                    Console.WriteLine();

                    Console.WriteLine("Enter a letter");
                }
            }

               
            }
        }
    }
