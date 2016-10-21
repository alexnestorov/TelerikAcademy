// <copyright file="ConsoleWriterProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;

namespace SimpleQuery
{
/// <summary>
/// Defines implementation of IWriter interface.
/// </summary>
    public class ConsoleWriterProvider : IWriter
    {
        /// <summary>
        /// Returns different of writer providers.
        /// </summary>
        /// <param name="result">Must be with type string</param>
        public void Provider(string result)
        {
            Console.WriteLine(result);
        }
    }
}
