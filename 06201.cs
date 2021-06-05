using System;

namespace ConsoleApp22
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }

        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }

        static void Main(string[] args)
        {
            double score = 0;
            Difficulty level = 0;
            mainmenupage(score, level);
        }

        static void mainmenupage(double page1, Difficulty page2 )
        {
            int page;
            Console.WriteLine("Score: {0}, Difficulty: {1}", page1, page2);
            test(out page);

            if(page == 0)
            {
                gameplaypage(page1, page2);
            }
            else if(page == 1)
            {
                Settingspage(page1, page2);
            }
            else if(page == 2)
            {

            }
        }

        static void test(out int Page)
        {
            do
            {
                Page = int.Parse(Console.ReadLine());

                if (Page != 0 && Page != 1 && Page != 2)
                {
                    Console.WriteLine("Please input 0 - 2.");
                }
            } while (Page != 0 && Page != 1 && Page != 2);
        }

        static void gameplaypage(double score, Difficulty level)
        {
            int X = (int)level;
            double answer, Qa, Qc = 0;
            Problem[] randomquestions = GenerateRandomProblems(X * 2 + 3);
            long start = DateTimeOffset.Now.ToUnixTimeSeconds();

            for(int j = 0; j < randomquestions.Length; j++)
            {
                Console.WriteLine(randomquestions[j].Message);
                Console.WriteLine("");
                answer = int.Parse(Console.ReadLine());

                if(answer == randomquestions[j].Answer)
                {
                    Qc = Qc + 1;
                }
            }
            long stop = DateTimeOffset.Now.ToUnixTimeSeconds();
            long duration = stop - start;
            Qa = X * 2 + 3;
            score = score + ((Qc / Qa) * ((25 - Math.Pow(X, 2)) / Math.Max(duration, 25 - (double)Math.Pow(X, 2))) * (Math.Pow(2 * X + 1, 2)));
            mainmenupage(score, level);
        }

        static void Settingspage(double score, Difficulty level)
        {
            int testlevel;
            Console.WriteLine("Score: {0}, Difficulty: {1}", score, (Difficulty)level);

            do
            {
                testlevel = int.Parse(Console.ReadLine());

                if (testlevel != 0 && testlevel != 1 && testlevel != 2)
                {
                    Console.WriteLine("Please input 0 - 2.");
                }
            } while (testlevel != 0 && testlevel != 1 && testlevel != 2);
            level = (Difficulty)testlevel;
            mainmenupage(score, level);
        }


        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }
            return randomProblems;
        }
    }
}
