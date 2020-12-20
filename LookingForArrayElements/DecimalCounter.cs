﻿using System;

#pragma warning disable S2368

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int a = 0; a < ranges.GetLength(0); a++)
            {
                if (ranges[a] is null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
            }

            for (int a = 0; a < ranges.GetLength(0); a++)
            {
                if (ranges[a].Length != 2 && ranges[a].Length != 0)
                {
                    throw new ArgumentException("length of one of the ranges is less or greater than 2.");
                }
            }

            if (ranges.Length == 0 || arrayToSearch.Length == 0)
            {
                return 0;
            }

            int result = 0;
            int i = 0;
            do
            {
                int j = 0;
                do
                {
                    if (ranges[j].Length != 0 && arrayToSearch[i] >= ranges[j][0] && arrayToSearch[i] <= ranges[j][1])
                    {
                        result++;
                        break;
                    }
                }
                while (++j < ranges.GetLength(0));
            }
            while (++i < arrayToSearch.Length);

            return result;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            for (int a = 0; a < ranges.GetLength(0); a++)
            {
                if (ranges[a] is null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }
            }

            for (int a = 0; a < ranges.GetLength(0); a++)
            {
                if (ranges[a].Length != 2 && ranges[a].Length != 0)
                {
                    throw new ArgumentException("length of one of the ranges is less or greater than 2.");
                }
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startIndex)} start index is negative.");
            }

            if (arrayToSearch.Length == 0)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            int result = 0;
            for (int i = startIndex; i < startIndex + count; i++)
            {
                for (int j = 0; j < ranges.GetLength(0); j++)
                {
                    if (ranges[j].Length != 0 && arrayToSearch[i] >= ranges[j][0] && arrayToSearch[i] <= ranges[j][1])
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
