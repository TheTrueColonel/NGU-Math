using System;

namespace NGU_Math.Extensions {
    public static class ConsoleExtended {
        /// <summary>
        /// Prevents the console from allowing non-numerical inputs.
        /// </summary>
        /// <returns>Returns integer input.</returns>
        public static int ReadNumericalInput () {
            ConsoleKeyInfo keyInfo;
            var cappedInput = "";

            do {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Backspace) {
                    var validNumber = int.TryParse(keyInfo.KeyChar.ToString(), out _);

                    if (validNumber) {
                        cappedInput += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                } else {
                    if (keyInfo.Key == ConsoleKey.Backspace && cappedInput.Length > 0) {
                        cappedInput = cappedInput.Substring(0, cappedInput.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            if (string.IsNullOrWhiteSpace(cappedInput)) { cappedInput = "0"; }

            return int.Parse(cappedInput);
        }
    }
}