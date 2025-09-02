using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PusulaAcademyCodeQuestions
{
    public class FilterPeopleFromXml
    {
        public static string FilterpeopleFromXml(string xmlData)
        {
            var doc = XDocument.Parse(xmlData);

            var people = doc.Descendants("Person")
                .Select(p => new
                {
                    Name = (string)p.Element("Name"),
                    Age = (int)p.Element("Age"),
                    Department = (string)p.Element("Department"),
                    Salary = (int)p.Element("Salary"),
                    HireDate = DateTime.Parse((string)p.Element("HireDate"))
                })
                .Where(p => p.Age > 30 &&
                            p.Department == "IT" &&
                            p.Salary > 5000 &&
                            p.HireDate < new DateTime(2019, 1, 1))
                .ToList();

            var names = people.Select(p => p.Name).OrderBy(n => n).ToList();

            int count = people.Count;
            int totalSalary = count > 0 ? people.Sum(p => p.Salary) : 0;
            int maxSalary = count > 0 ? people.Max(p => p.Salary) : 0;
            int averageSalary = count > 0 ? (int)people.Average(p => p.Salary) : 0;

            var result = new
            {
                Names = names,
                TotalSalary = totalSalary,
                AverageSalary = averageSalary,
                MaxSalary = maxSalary,
                Count = count
            };
            return JsonSerializer.Serialize(result);
        }

    }
}
