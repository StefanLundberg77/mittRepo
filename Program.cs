﻿﻿namespace DebugExample
{
    public class Program
    {
        
        public static void Main()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("[B]inary search");
                Console.WriteLine("[W]eekdays");
                Console.WriteLine("[S]tack overflow");
                Console.WriteLine("[D]ivision calculator");
                Console.WriteLine("[Q]uit");
                Console.Write("Val: ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "b":
                        BinarySearch.TestBS();
                        break;
                    case "w":
                        Weekdays.TodayAndTomorrow();
                        break;
                    case "s":
                        Console.Write("Enter a value: ");
                        if(!int.TryParse(Console.ReadLine(), out int x))
                        {
                            Console.WriteLine("only integers please, setting x to 0");
                            x = 0;
                        }
                        StackOverFlow.X(x);
                        break;
                    case "d":
                        Division.Calculator();
                        break;
                    case "q":
                        Console.WriteLine("Thank you, good bye...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("I don't understand...");
                        break;
                }
            }
        }
    }
}
﻿namespace DebugExample
{
    public class Person
    {
        public string name;
        public int personalNr;

        public Person(string name, int personalNr)
        {
            this.name = name;
            this.personalNr = personalNr;
        }
    }
    // There is something wrong with this code.
    // 1) Just run this code and see what happens. Do NOT google or chatgpt how binary search
    //      is supposed to work. That will spoil this exercise.
    // 2) Try to search with different personal numbers - do some seem to work?
    // 3) Try different numbers while using the debugger, and step trough the search algorithm step
    //      --> what happens?
    // 4) What conclutions can you draw from this?
    // 5) Ok. Now that you've found the error. Can you find a way to solve it? Now you can use google...

    public class BinarySearch
    {
        public static void TestBS()
        {
            List<Person> people = new List<Person>
            {
                new Person("Anna Andersson", 50125),
                new Person("Bertil Bengtsson", 50232),
                new Person("Carl Carlsson", 50315),
                new Person("David Davidsson", 50375)
            };

            // Sort the list before searchning. Necessary for binary search.
            people.Sort((a, b) => a.personalNr.CompareTo(b.personalNr));

            
            int personalNrToFind = 50232;
            int index = DoBinarySearch(people, personalNrToFind);

            if(index != -1)
            {
                Console.WriteLine($"Personen {people[index].name} med personnummer {personalNrToFind} hittades på index {index}.");
            }
            else
            {
                Console.WriteLine($"Personen med personnummer {personalNrToFind} hittades inte.");
            }
        }


        private static int DoBinarySearch(List<Person> persons, int personalNr)
        {
            // bra ställe att sätta break point?
            int left = 0;
            int right = persons.Count;

            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (persons[middle].personalNr == personalNr)
                {
                    return middle;
                }
                else if (persons[middle].personalNr < personalNr)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }
            return -1; // Inte funnet

        }
    }
}
namespace DebugExample
{
    class Division
    {   // This is a classic one. Most integers will work in this example, but one will fail in one case...
        // No need to debug here really, but how would you solve it?
        public static void Calculator()
        {
            Console.WriteLine("Welcome to the Division Program!");
            while(true) // loop to restart if the user enters things that are not numbers...
            {
                Console.Write("Enter the numerator: ");
                if(!int.TryParse(Console.ReadLine(), out int numerator))
                {
                    Console.WriteLine("numbers only!");
                    continue;
                }
                Console.Write("Enter the denominator: ");


                
                if(!int.TryParse(Console.ReadLine(), out int denominator))
                {
                    {    
                        Console.WriteLine("numbers only!");
                        continue;
                    }
                }
                if (denominator == 0)
                {
                    Console.WriteLine("Cannot divide by zero!");
                    continue;
                }
                int quotient = numerator / denominator;

                Console.WriteLine($"The quotient of {numerator} and {denominator} is: {quotient}");
                break; // if we reach this code, the user has not entered anything wrong and we can end this method.
            }
        }
    }
}
namespace DebugExample
{
    // Stack overflow is not just one of the best websites there is for a coder, it is also a concept in programming
    // 1) Read about the concept, then try this code out.
    // 2) Test to run this code with a debugger. What do you see?
    // 3) Try to understand what recursion does and why this gives an error.
    // 4) Check the call stack in the debugger
    // 5) Somewhere else (in another file) in this code, there is another recursion hidden.
    //      This is wrong and gives an ugly call stack, even tough it does work. Find it. Fix it.
    public class StackOverFlow
    {
        public static int X(int value)
        {
            if (value <= 1)
            {
                return value;
            }
            int y = Y(value*value);
            return y;
        }
        private static int Y(int value)
        {
                if (value <= 1)
            {
                return value;
            }
            int x = X(value*value);
            return x;
        }
    }
}
namespace DebugExample
{
    public class Weekdays
    {
        // During a certain day this code will crasch.
        // 1) How are you to find out what day?
        // 2) On what line does the problem occur?
        // 3) What is the problem? Read the error message and check with the debugger.
        // 4) How will you fix it? Note: leave the line with the crash as it is and do the fix above it
        public static void TodayAndTomorrow()
        {
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // We use DateTime to get the day of the week index (0 basead).
            int todayIndex = 6; //(int)DateTime.Now.DayOfWeek-1; KOMMER BLI FEL NÄR de är 0????
            System.Console.WriteLine("Today index: " + (int)todayIndex);

            // Try to calculate tomorrow's index.
            
            int tomorrowIndex = (todayIndex + 1);
            if (tomorrowIndex > 6)
            {
                tomorrowIndex = 0;
            }

            Console.WriteLine("Today is: " + weekdays[todayIndex]);
            Console.WriteLine("Tomorrow will be: " + weekdays[tomorrowIndex]);
            Program.Main();
        }
    }
}