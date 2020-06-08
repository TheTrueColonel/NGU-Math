using System;
using NGU_Math.Extensions;

namespace NGU_Math {
    public static class Program {
        private static int _cappedLimit;
        private static int _totalIterations;
        private static int _nextIteration;
        
        private static void Main () {
            RunIntro();

            CalculationInstance();
        }

        private static void CalculationInstance () {
            while (true) {
                Console.WriteLine("Please enter the starting capped energy limit:");

                _cappedLimit = ConsoleExtended.ReadNumericalInput();

                Console.WriteLine();

                _totalIterations = CalculateIterations(_cappedLimit);
                _nextIteration = CalculateNextIteration(_cappedLimit);

                Console.WriteLine($"Iterations (until 10 or less): {_totalIterations}\n" + $"Next Iteration: {_nextIteration}");

                Console.WriteLine("Would you like to calculate another skill cap? Y/N");

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Y) {
                    Console.Clear();
                    continue;
                }

                break;
            }
        }

        private static void RunIntro () {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("This is a fun little bit of software to help gauge how many more rebirths you need to get to a skills capped limit to or less than " +
                              "ten. This software will also let you know (roughly) what the next cap will be.\n" +
                              "PLEASE NOTE: Because of how NGU Idle keeps hold of capped skill limit values internally, the outputs may be off by a small amount. " +
                              "There is no easy way to mitigate this issue, so please keep in mind that the values returned may be slightly off.");
            Console.WriteLine("------------------------------------------------------------------------");
        }

        /// <summary>
        /// Calculates amount of rebirths needed to get the skill cap at or below 10.
        /// </summary>
        /// <param name="cappedLimit"></param>
        private static int CalculateIterations (int cappedLimit) {
            var remainingLimit = cappedLimit;
            var iterations = 0;

            while (remainingLimit > 10) {
                remainingLimit = (int) Math.Round(remainingLimit * 0.9f) - 1;
                Console.WriteLine(remainingLimit);
                iterations++;
            }
            
            return iterations;
        }

        /// <summary>
        /// Calculates the next skill cap.
        /// </summary>
        /// <param name="cappedLimit"></param>
        private static int CalculateNextIteration (int cappedLimit) => 
            (int) Math.Round(cappedLimit * 0.9f) - 1;
    }
}