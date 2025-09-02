using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace PusulaAcademyCodeQuestions
{
    public class FilterEmployees
    {
        public static string Filteremployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
        {
            var filtered = employees
                .Where(e => e.Age >= 25 && e.Age <= 40)
                .Where(e => e.Department == "IT" || e.Department == "Finance")
                .Where(e => e.Salary >= 5000m && e.Salary <= 9000m)
                .Where(e => e.HireDate > new DateTime(2017, 12, 31))
                .ToList();

            int count = filtered.Count;

            decimal totalSalary = count > 0 ? filtered.Sum(e => e.Salary) : 0;
            decimal averageSalary = count > 0 ? Math.Round(filtered.Average(e => e.Salary), 2) : 0;
            decimal minSalary = count > 0 ? filtered.Min(e => e.Salary) : 0;
            decimal maxSalary = count > 0 ? filtered.Max(e => e.Salary) : 0;

            var names = filtered
                .Select(e => e.Name)
                .OrderByDescending(n => n.Length) 
                .ThenBy(n => n)                 
                .ToList();

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = averageSalary,
                MinSalary = minSalary,
                MaxSalary = maxSalary,
                Count = count
            };
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = false
            };
            return JsonSerializer.Serialize(result,options);
        }
    }
}
