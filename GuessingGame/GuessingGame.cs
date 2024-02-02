namespace Assignment1
{
    internal class GuessingGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Maximum number");
            int num = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int Answer = rand.Next(1, num + 1);

            bool runtime = true;
            while (runtime)
            {
                Console.WriteLine($"Guess a number between 1 and {num}");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess == Answer)
                {
                    Console.WriteLine("Correct guess!");
                    runtime = false;
                }

                else if (guess > Answer)
                {
                    Console.WriteLine("Guess too high, try again");
                }

                else if (guess < Answer)
                {
                    Console.WriteLine("Guess too low, try again");
                }

            }

        }
    }
}