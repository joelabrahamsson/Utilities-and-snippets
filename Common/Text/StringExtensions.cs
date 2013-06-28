using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Text
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        private static readonly HashSet<char> DefaultNonWordCharacters = new HashSet<char> { ',', '.', ':', ';' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <param name="nonWordCharacters"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Thrown when <paramref name="length"/> is negative</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="value"/> is null</exception>
        public static string CropWholeWords(this string value, int length, HashSet<char> nonWordCharacters = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (length < 0)
            {
                throw new ArgumentException("Negative values not allowed.", "length");
            }

            if (nonWordCharacters == null)
            {
                nonWordCharacters = DefaultNonWordCharacters;
            }

            //ALT3
            if (length > value.Length)
            {
                length = value.Length;
            }
            int end = length;

            bool multipleWords = false;
            for (int i = end; i > 0; i--)
            {
                if (value.Length > i && value[i] == ' ')
                {
                    multipleWords = true;
                }

                if (value.Length == length)
                {
                    break;
                }

                if (value.Length > i && (value[i] == ' ' || (nonWordCharacters.Contains(value[i]) && (value.Length == i + 1 || value[i + 1] == ' '))))
                {
                    break;
                }
                end--;
            }

            if (end == 0 && !multipleWords)
            {
                end = length;
            }

            return value.Substring(0, end);

            //ALT2
            //int end = 0;
            //if (length > value.Length)
            //{
            //    length = value.Length;
            //}
            //bool multipleWords = false;
            //int lastWordEnd = 0;
            //for (int i = 0; i < length; i++)
            //{
            //    end++;
            //    if (value.Length > length && value[i + 1] == ' ')
            //    {
            //        lastWordEnd = end;
            //        multipleWords = true;
            //    }
            //    if (i + 1 == length && value.Length > length && !nonWordCharacters.Contains(value[i + 1]) && multipleWords)
            //    {
            //        end = lastWordEnd;
            //    }
            //}

            //return value.Substring(0, end);

            //ALT1
            //if (length > value.Length)
            //{
            //    return value;
            //}

            //if (nonWordCharacters == null)
            //{
            //    nonWordCharacters = defaultNonWordCharacters;
            //}

            //var words = value.Split(new[] {' '});
            //var buffer = new StringBuilder();
            //foreach (var word in words)
            //{
            //    if (buffer.Length == 0 && word.Length >= length)
            //    {
            //        buffer.Append(word.Substring(0, length));
            //    }

            //    var wordToInsert = word;
            //    if (buffer.Length + word.Length + 1 > length)
            //    {
            //        if (nonWordCharacters.Contains(wordToInsert[wordToInsert.Length-1]) && buffer.Length + wordToInsert.Length <= length)
            //        {
            //            wordToInsert = wordToInsert.Substring(0, wordToInsert.Length - 1);
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

            //    if (buffer.Length > 0)
            //    {
            //        buffer.Append(" ");
            //    }

            //    buffer.Append(wordToInsert);
            //}
            //return buffer.ToString();
        }

        public static bool EndsWith(this string fullString, HashSet<char> characters)
        {
            foreach (var character in characters)
            {
                if (fullString[fullString.Length - 1].Equals(character))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
