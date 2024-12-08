using System;

namespace CodeSnippets{
    
    public class CodeSnippets{
        
        /// <summary>
        /// This function checks if the given string is a palindrome (reads the same backward and forward).
        /// Input: A string pattern.
        /// Output: A boolean indicating if the string is a palindrome.
        /// Usage: Can be used to validate text symmetry or detect palindromic strings.
        /// </summary>
        static bool function1(string pattern) {
            var parts = pattern.ToCharArray();
            Array.Reverse(parts);
            var starp = (new string(parts)).ToLower();
            
            var b = pattern.ToLower().Equals(starp);
            return b;
        }
        
        
        /// <summary>
        /// This function performs a Shell Sort on an array of integers.
        /// Input: An integer array.
        /// Output: Returns 0 (placeholder) after sorting the input array in-place.
        /// Usage: Efficient for medium-sized datasets when performance is crucial.
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