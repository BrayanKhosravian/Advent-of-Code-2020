namespace Day7
{
    using Common;
    using System.IO;

    public static class Program
    {
        public static void Main()
        {
            var data = File.ReadAllText("Inputs/part1.txt");
            ProgramShell
                .Run(
                    new Day7Solver(data));
        }
    }
}
