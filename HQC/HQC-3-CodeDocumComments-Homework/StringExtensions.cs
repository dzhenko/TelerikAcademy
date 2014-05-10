//  <copyright file="StringExtensions.cs" company="probably telerik">
//     Telerik. All rights certainly reserved.
//  </copyright>
//  <author>I wish I was</author>

// stylecop variant of header is UP / C# variant of header is DOWN

/// <copyright file="StringExtensions.cs" company="probably telerik">
///     Telerik. All rights certainly reserved.
/// </copyright>
/// <author>I wish I was</author>
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contains all the available extensions for string operations
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the input string to a byte array and compute the hash
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>A hexadecimal string representing each byte of the hashed data</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts the input string to a equivalent boolean value
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>Boolean value</returns>
        public static bool ToBoolean(this string input)
        {
            // all the possible values that mean true
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };

            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Attempts to convert the input string to a short value
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>Equivalent short value or 0</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Attempts to convert the input string to a integer value
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>Equivalent integer value or 0</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Attempts to convert the input string to a long value
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>Equivalent long value or 0</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Attempts to convert the input string to a DateTime value
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>Equivalent DateTime value or default</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts the first letter of the input into capital one
        /// </summary>
        /// <param name="input">Input string to convert</param>
        /// <returns>The original string with capital first letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // concatinating the capitalized first letter with the rest of the string
            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Extracts the string between given two strings
        /// </summary>
        /// <param name="input">The string to extract from</param>
        /// <param name="startString">The string to start from</param>
        /// <param name="endString">The string to extract to</param>
        /// <param name="startFrom">The position to start searching from</param>
        /// <returns>The substring between the given two strings</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            // we only need the part of the string where we have to search in
            input = input.Substring(startFrom);

            // start position is already used and must be nulled
            startFrom = 0;

            // the start or end pieces of string are not present in the input string
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // we remove the start string from the result - by adding its length to the start position index
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            // the search starts from the previously found start position index
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts a all cyrillic letters to their equivalent latin letters (phonetic rules)
        /// </summary>
        /// <param name="input">The string to convert</param>
        /// <returns>The original string with replaced cyrillic letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            // all the letters in the bulgarian alphabet
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };

            // coresponding latin letters by index to the bulgarian letters
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            // checking seperatly for capital and small letters in the input
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts a all latin letters to their equivalent cyrillic letters (phonetic rules)
        /// </summary>
        /// <param name="input">The string to convert</param>
        /// <returns>The original string with replaced latin letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            // all the letters in the latin alphabet
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            // coresponding bulgarian letters by index to the latin letters
            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            // checking seperatly for capital and small letters in the input
            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Removes all forbidden signs for an email from a string and converts it to latin
        /// </summary>
        /// <param name="input">The string to convert</param>
        /// <returns>Valid string for an email</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Removes all forbidden signs for an file name from a string and converts it to latin and replaces spaces with dashes
        /// </summary>
        /// <param name="input">The string to convert</param>
        /// <returns>Valid string for a file name</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the first several characters from a string or the whole strings if it doesn't have enough characters
        /// </summary>
        /// <param name="input">The string to convert</param>
        /// <param name="charsCount">The number of characters to return</param>
        /// <returns>The first characters or the original input</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extension from a given fileName as string
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The file extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);

            // checks if the input is only the file name or its extension is empty or null
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts a file extension to its equivalent content type
        /// </summary>
        /// <param name="fileExtension">The file extension to convert</param>
        /// <returns>Content type or "application/octet-stream"</returns>
        public static string ToContentType(this string fileExtension)
        {
            // all usable content types in this version (see top of file)
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            // the default content type
            return "application/octet-stream";
        }

        /// <summary>
        /// Converts an input string to a byte array
        /// </summary>
        /// <param name="input">The input string to convert</param>
        /// <returns>The original string as byte array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)

// default documentation settings