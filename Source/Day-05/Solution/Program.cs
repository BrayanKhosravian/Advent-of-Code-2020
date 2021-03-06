namespace Day5
{
    using Common;
    using Day5;
    using System.IO;

    public static class Program
    {
        public static void Main()
        {
            var data = File.ReadAllLines("Inputs/part1.txt");
            ProgramShell
                .Run(
                    new Part1Solver(data),
                    new Part1ParallelSolver(data),
                    new Part2Solver(data));
        }
    }
}
