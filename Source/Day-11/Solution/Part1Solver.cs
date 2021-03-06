﻿namespace Day11
{
    using Common;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Part1Solver : ISolver
    {
        private readonly string text;

        public Part1Solver(string text)
        {
            this.text = text;
        }

        public string Name => "Day11 Part1";

        public void Solve()
        {
            Log.Information("Differences: {Value}", Solve(this.text));
        }

        public static int Solve(string text)
        {
            char[] a = new char[text.Length];
            char[] b = new char[text.Length];

            text.CopyTo(0, a, 0, text.Length);

            var readTable = a;
            var writeTable = b;

            var rowLength = text.IndexOf('\n');
            var rowFullLength = rowLength;
            if (text[rowLength - 1] == '\r')
            {
                rowFullLength++;
                rowLength--;
            }

            bool changeOccured;
            do
            {
                changeOccured = false;

                readTable.CopyTo(writeTable, 0);

                var row = 0;
                var adjacency = new List<char>(8);
                while (row * rowFullLength < a.Length)
                {
                    for(var cell = 0; cell < rowLength; cell++)
                    {
                        var thisCell = row * rowFullLength + cell;
                        if (readTable[thisCell] == '.')
                        {
                            continue;
                        }

                        adjacency.Clear();
                        for(var adjRow = -1; adjRow <= 1; ++adjRow)
                        {
                            for (var adjCell = -1; adjCell <= 1; ++adjCell)
                            {
                                if (adjRow == 0 && adjCell == 0)
                                {
                                    continue;
                                }

                                var adjacencyCell = ((row + adjRow) * rowFullLength) + cell + adjCell;
                                if (adjacencyCell >= 0 && adjacencyCell < readTable.Length)
                                {
                                    adjacency.Add(readTable[adjacencyCell]);
                                }
                            }
                        }

                        if (readTable[thisCell] == 'L')
                        {
                            if (!adjacency.Any(a => a == '#'))
                            {
                                changeOccured = true;
                                writeTable[thisCell] = '#';
                            }
                        }
                        else if (readTable[thisCell] == '#')
                        {
                            if (adjacency.Count(a => a == '#') >= 4)
                            {
                                changeOccured = true;
                                writeTable[thisCell] = 'L';
                            }
                        }
                    }

                    row++;
                }

                readTable = readTable == a ? b : a;
                writeTable = writeTable == a ? b : a;
            } while (changeOccured);

            return writeTable.Count(c => c == '#');
        }
    }
}
