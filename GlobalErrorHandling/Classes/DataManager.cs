using System.Collections.Generic;
using GlobalErrorHandling.Models;

namespace GlobalErrorHandling.Classes
{
    public class DataManager
    {
        public static List<Person> GetAllStudents() =>
            new()
            {
                new() { Name="Joe", LastName="Doe", Age=35, Gender="Male"},
                new() { Name="Jane", LastName="Doe", Age=25, Gender="Female"},
                new() { Name="Mick", LastName="Simon", Age=32, Gender="Male"},
                new() { Name="Sandra", LastName="Summer", Age=30, Gender="Female"},
            };
    }
}
