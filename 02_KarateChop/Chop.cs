using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kata02_KarateChop
{
    public class Chop
    {
        public int Chopper(int target, int[] theArray)
        {
            if (theArray.Length == 0)
                throw new EmptyArrayException("The array is empty");
            int first = 0, last = theArray.Length - 1, middle = 0, position = -1;
            bool found = false;
            int iterations = 0;
            if(first == last)
            {
                if (theArray[middle] == target)
                    position = middle;
                found = true;
            }

            while (!found && first <= theArray.Length && last >= 0)
            {
                middle = (first + last) / 2;
                if (theArray[middle] == target)
                {
                    found = true;
                    position = middle;
                }
                else
                {
                    if (theArray[middle] < target)
                        first = middle + 1;
                    else
                        last = middle - 1;
                }

                iterations++;
                if (iterations > 1000)
                    throw new CycleThresholdException(
                        CurrentStateInString(target, theArray, first, last, middle, iterations));
            }

            if (position >= 0)
                return position;
            else
                throw new TargetNumberNotFoundException(
                    CurrentStateInString(target, theArray, first, last, middle, iterations));
        }

        private static string CurrentStateInString(int target, int[] theArray, int first, int last, int middle, int iterations)
        {
            return $"First: {first}, Last: {last}, Middle: {middle}, " +
                                    $"Iterations: {iterations}, Target: {target}, " +
                                    $"ArrayCount: {theArray.Length.ToString()}.";
        }
    }

    [Serializable]
    public class CycleThresholdException : Exception
    {


        public CycleThresholdException()
        {
        }

        public CycleThresholdException(string message) : base(message)
        {
        }

        public CycleThresholdException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CycleThresholdException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class TargetNumberNotFoundException : Exception
    {


        public TargetNumberNotFoundException()
        {
        }

        public TargetNumberNotFoundException(string message) : base(message)
        {
        }

        public TargetNumberNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TargetNumberNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class EmptyArrayException : Exception
    {
        public EmptyArrayException()
        {
        }

        public EmptyArrayException(string message) : base(message)
        {
        }

        public EmptyArrayException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EmptyArrayException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
