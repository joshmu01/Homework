using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            Console.WriteLine("Beginning users:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name.ToString());
            }
            Console.WriteLine();

            var usersWithPasswordHello = users.Where(x => x.Password == "hello");

            Console.WriteLine("Users with the password 'hello':");
            foreach (var user in usersWithPasswordHello)
            {
                Console.WriteLine(user.Name.ToString());
            }
            Console.WriteLine();

            users.RemoveAll(PasswordEqualsLowercaseName);
            users.Remove(users.First(x => x.Password == "hello"));

            Console.WriteLine("Removed users with passwords that are the lower-cased version of their name.");
            Console.WriteLine();
            Console.WriteLine("Removed the first user with the password 'hello'.");
            Console.WriteLine();
            Console.WriteLine("Remaining Users:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name.ToString());
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        private static bool PasswordEqualsLowercaseName(Models.User user)
        {
            return user.Password == user.Name.ToLower();
        }
    }
}
