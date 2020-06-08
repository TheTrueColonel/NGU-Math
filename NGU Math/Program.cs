using System;
using NGU_Math.Extensions;

namespace NGU_Math {
    public static class Program {
        private static int _cappedLimit;
        
        private static void Main () {
            RunIntro();
            
            Console.WriteLine("Please enter the starting capped energy limit:");

            _cappedLimit = ConsoleExtended.ReadNumericalInput();
            
            Console.WriteLine();

            var totalIterations = CalculateIterations(_cappedLimit);
            var nextIteration = CalculateNextIteration(_cappedLimit);
            
            Console.WriteLine($"Iterations (until 10 or less): {totalIterations}\n" +
                              $"Next Iteration: {nextIteration}\n" +
                              "Press Enter to exit...");
            Console.Read();
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
                remainingLimit = (int) Math.Floor(remainingLimit * 0.9f);
                iterations++;
            }
            
            return iterations;
        }

        /// <summary>
        /// Calculates the next skill cap.
        /// </summary>
        /// <param name="cappedLimit"></param>
        private static int CalculateNextIteration (int cappedLimit) => 
            (int) Math.Floor(cappedLimit * 0.9f);
    }
}