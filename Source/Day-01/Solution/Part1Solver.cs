﻿namespace Day1
{
    using Common;
    using Serilog;

    public class Part1Solver : ISolver
    {
        private readonly int target;
        private readonly int[] inputs;

        public Part1Solver(int target, params int[] inputs)
        {
            this.target = target;
            this.inputs = inputs;
        }

        public string Name => "Day1 Part1";

        public void Solve()
        {
            var length = this.inputs.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (this.inputs[i] + this.inputs[j] == this.target)
                    {
                        Log.Information("Match: {D} * {E} = {F}", this.inputs[i], this.inputs[j], this.inputs[i] * this.inputs[j]);
                        return;
                    }
                }
            }
        }
    }
}
