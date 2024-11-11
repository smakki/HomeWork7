namespace HomeWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var running = true;
            Console.WriteLine("Program 1 - anonymous objects");
            Console.WriteLine("Program 2 - tuples");
            Console.WriteLine("Program 3 - lambdas");
            Console.WriteLine("Please type 1, 2, 3 or exit to exit");
            while (running)
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Program1.Run();
                        break;
                    case "2":
                        Program2.Run();
                        break;
                    case "3":
                        Program3.Run();
                        break;
                    case "exit":
                        running = false;
                        break;
                }
            }
        }
    }
}
