//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Just Shoot Me">
//     Copyright Just Shoot Me LTD.
// </copyright>
//-----------------------------------------------------------------------
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
    /// Adds extension methods to the string <see cref="System.String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Execute all routines in the class.
        /// </summary>
        public static void Main()
        {

        }

        /// <summary>
        /// Convert string <see cref="System.String"/> to MD5Hash string
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns <see cref="System.String"/> to MD5Hash string</returns>
        public static string ToMd5HashCode(this string input)
        {
            var md5HashCode = MD5.Create();

            var data = md5HashCode.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Returns true or false depending on the input string.
        /// <para>If the string is one of the values in the collection ["true", "ok", "yes", "1", "да"] it returns true, else it returns false.</para>
        /// <para>Case Insensitive.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns true if the input string is in the collection ["true", "ok", "yes", "1", "да"].
        /// <para>Case Insensitive.</para>
        /// </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string <see cref="System.String"/> to short <see cref="System.Int16"/> if the string can be parsed to this short <see cref="System.Int16"/>.
        /// <para>Otherwise it returns 0.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns the source string converted to short <see cref="System.Int16"/> or 0 if the operation failed.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);

            return shortValue;
        }

        /// <summary>
        /// Converts the string <see cref="System.String"/> to int <see cref="System.Int32"/> if the string can be parsed to int <see cref="System.Int32"/>.
        /// <para>Otherwise it returns 0.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>returns the source string to int <see cref="System.Int32"/> or 0 if the operation failed.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);

            return integerValue;
        }

        /// <summary>
        /// Converts the string <see cref="System.String"/> to long <see cref="System.Int64"/> if the string can be parsed to long <see cref="System.Int64"/>.
        /// <para>Otherwise it returns 0.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>returns the source string to long <see cref="System.Int64"/> or 0 if the operation failed.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);

            return longValue;
        }

        /// <summary>
        /// Converts the string <see cref="System.DateTime"/> to <see cref="System.DateTime"/> if the string can be parsed to this type <see cref="System.DateTime"/>.
        /// <para>Otherwise it returns 1.1.0001 г. 00:00:00 ч. in format according to the Culture used.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the parameter is the source string.</param>
        /// <returns>Returns the string converted to <see cref="System.DateTime"/>. Returns 1.1.0001 г. 00:00:00 ч. in format according to the Culture used if it fails.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);

            return dateTimeValue;
        }

        /// <summary>
        /// Capitalize the first letter of the string <see cref="System.String"/>.
        /// <para>Returns empty string or null if the string is null or empty.</para>
        /// <seealso cref="System.String.IsNullOrEmpty"/>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns the string <see cref="System.String"/> with capitalized first letter. Returns empty or the string is null or empty</returns>
        public static string MakeUpperCaseFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Gets the substring from string <see cref="System.String"/> between two given substrings or returns empty string if not present.
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <param name="startString">The start substring.</param>
        /// <param name="endString">The end substring.</param>
        /// <param name="startFrom">The start position to search from.</param>
        /// <returns>Returns the substring between two substrings in given string <see cref="System.String"/>. Returns empty string if not found.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert string <see cref="System.String"/> from Cyrillic to Latin representation.
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns the Latin representation of the string <see cref="System.String"/>.</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianAlphabet = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianAlphabet.Length; i++)
            {
                input = input.Replace(bulgarianAlphabet[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianAlphabet[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].MakeUpperCaseFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert string <see cref="System.String"/> from Latin to Cyrillic representation.
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns the Cyrillic representation of the string <see cref="System.String"/>.</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Convert any cyrillic letter in the string <see cref="System.String"/> to Latin representation.
        /// <para>Replace all the symbols that are not letters, digits, lower dash or dot with empty string <see cref="System.String.Empty"/></para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns valid username as string <see cref="System.String"/>. Contains only latin letters, digits, lower dash or dot.</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Convert any cyrillic letter in the string <see cref="System.String"/> to Latin representation.
        /// <para>Replace all the symbols that are not letters, digits, lower dash, dash or dot with empty string <see cref="System.String.Empty"/></para>
        /// <para>Replace all the spaces with dash.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns valid username as string <see cref="System.String"/>. Contains only latin letters, digits, lower dash, dash or dot.</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets given number of characters from the first character of the string <seealso cref="System.String"/>
        /// <para>Returns all the characters if the string length is smaller than charsCount parameter.</para>
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <param name="charsCount">Characters to return.</param>
        /// <returns>Returns substring of characters as string <see cref="System.String"/> from string.</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Return the file extension from the string if present.
        /// <para>Returns empty string <see cref="System.String.Empty"/> if no file type exist.</para>
        /// </summary>
        /// <param name="fileName">This is an extension method for <see cref="System.String"/> and the fileName parameter is the source string.</param>
        /// <returns>Returns extension of the as string <see cref="System.String"/> file if such exist or empty string if there is no extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            // Splits the file by "." if present. And checks if there is file extension.
            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type according to the file extension if such present.
        /// <para>Returns default content type "application/octet-stream" if there is no extension or extension is not known.</para>
        /// </summary>
        /// <param name="fileExtension">This is an extension method for <see cref="System.String"/> and the fileExtension parameter is the source string.</param>
        /// <returns>Returns the content type as string <see cref="System.String"/> according to the file extension if such present or default content type if not.</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static string ToContentType(this string fileExtension)
        {
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

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts string to byte array of ASCII code of each character.
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Byte array with ASCII code of each character</returns>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        public static byte[] ToByteArray(this string input)
        {
            // Creates new array with length input.length * 2. sizeof(char) = 2 in bytes.
            var bytesArray = new byte[input.Length * sizeof(char)];

            // Copies the chars from the array to new array as bytes.
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}