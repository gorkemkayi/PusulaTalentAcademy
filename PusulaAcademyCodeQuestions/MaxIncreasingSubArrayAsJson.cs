using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PusulaAcademyCodeQuestions
{
    public class MaxIncreasingSubArrayAsJson
    {
        public static string MaxIncreasingSubarrayAsJson(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return JsonSerializer.Serialize(new List<int>());
            }

            List<int> bestSubArray = new List<int>();
            int bestSum = int.MinValue;

            List<int> CurrentSubArray = new List<int>();
            int currentSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == 0 || numbers[i] > numbers[i - 1])
                {
                    CurrentSubArray.Add(numbers[i]);
                    currentSum = currentSum + numbers[i];
                }
                else
                {
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestSubArray = new List<int>(CurrentSubArray);
                    }

                    CurrentSubArray.Clear();
                    CurrentSubArray.Add(numbers[i]);
                    currentSum = numbers[i];
                }
            }

            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestSubArray = new List<int>(CurrentSubArray);
            }

            return JsonSerializer.Serialize(bestSubArray);
        }
    }
}
