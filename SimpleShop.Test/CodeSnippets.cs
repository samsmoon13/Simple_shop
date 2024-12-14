using System;

namespace CodeSnippets{
    
    public class CodeSnippets{
        
        /// <summary>
        /// The function checks if the input pattern is a paliandrome (if it reads the same forward and backward), while ignoring the letter case.
        /// First, the function converts the input sting into array.
        /// Then, reverses the array and creates a new string from it.
        /// Both strings are then converted into lowercase and compared.
        /// Finally, function returns a boolean indicating if two strings are the same or not. 
        /// </summary>
        static bool function1(string pattern) {
            var parts = pattern.ToCharArray();
            Array.Reverse(parts);
            var starp = (new string(parts)).ToLower();
            
            var b = pattern.ToLower().Equals(starp);
            return b;
        }
        
        
        /// <summary>
        /// The function sorts the input array in ascending order using Shell Sort.
        /// It takes integer array as an input and otputs 0 indicatng success after performing sorting.
        /// Usage: Is useful for sorting small to medium size datasets.
        /// </summary>
        public static int function2(int[] numbers){
            for (var h = numbers.Length / 2; h > 0; h /= 2){
                for (var i = h; i < numbers.Length; i += 1){
                    var temp = numbers[i];
                    int t;
                    for (t = i; t >= h && numbers[t - h] > temp; t -= h){
                        numbers[t] = numbers[t - h];
                    }
                    numbers[t] = temp;
                }
            }
            return 0;
        }
    }
}