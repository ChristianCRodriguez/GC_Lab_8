using System;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput, firstName;
            int infoIndex = 0, userIndex = 0;
            bool continueApp = true, repeatApp = false;

            string[] students = { "Christian Rodriguez", "Guadalupe Rodriguez", "Andrea Maldonado" };
            string[] food = { "Broccoli Cheddar Soup", "Apple Pie", "Mexican Food" };
            string[] hometown = { "Long Beach", "Long Beach", "Grand Blanc" };

            do
            {
                if(repeatApp == true)
                {
                    Console.Clear();
                }
                Console.WriteLine("Welcome to our C# class.\n");
                Console.Write("Which student would you like to learn about? (enter a number 1- 3): ");

                do
                {
                    if (continueApp != true)
                    {
                        Console.Write("\nThat student does not exist. (enter a number 1- 3): ");
                    }

                    userInput = GetUserInput();

                    infoIndex = GetIndex(userInput);
                    userIndex = infoIndex + 1;
                    continueApp = DoesStudentExist(students, infoIndex);
                } while (continueApp != true);

                firstName = GetFirstName(students, infoIndex);

                Console.Write($"\nStudent {userIndex} is {students[infoIndex]}. What would you like to know about {firstName}?\n(Enter \"hometown\" or \"favorite food\"): ");
                userInput = Console.ReadLine();

                while (userInput.ToLower() != "hometown" && userInput.ToLower() != "favorite food")
                {
                    Console.Write("\nThat data does not exist. Please try again.\n(Enter \"hometown\" or \"favorite food\"): ");
                    userInput = Console.ReadLine();
                }

                if (userInput.ToLower() == "hometown")
                {
                    Console.Write($"\n{firstName} is from {hometown[infoIndex]}. Would you like to know another fact about {firstName}?\n(Enter \"yes\" or \"no\"): ");
                    userInput = Console.ReadLine();

                    while (userInput.ToLower() != "yes" && userInput.ToLower() != "no")
                    {
                        Console.Write("\nThat input is not valid. Please try again.\n(Enter \"yes\" or \"no\"): ");
                        userInput = Console.ReadLine();
                    }
                    if (userInput.ToLower() == "yes")
                    {
                        Console.WriteLine($"\n{firstName}'s favorite food is {food[infoIndex]}.");
                    }
                    Console.Write("\nWould you like to learn about another student? (Enter \"yes\" or \"no\"): ");
                    userInput = Console.ReadLine();

                    while (userInput.ToLower() != "yes" && userInput.ToLower() != "no")
                    {
                        Console.Write("\nThat input is not valid. Please try again.\n(Enter \"yes\" or \"no\"): ");
                        userInput = Console.ReadLine();
                    }
                    repeatApp = userInput.ToLower() == "yes" ? true : false;
                }
                else
                {
                    Console.Write($"\n{firstName}'s favorite food is {food[infoIndex]}. Would you like to know more?\n(Enter \"yes\" or \"no\"): ");
                    userInput = Console.ReadLine();

                    while (userInput.ToLower() != "yes" && userInput.ToLower() != "no")
                    {
                        Console.Write("\nThat input is not valid. Please try again.\n(Enter \"yes\" or \"no\"): ");
                        userInput = Console.ReadLine();
                    }

                    if (userInput.ToLower() == "yes")
                    {
                        Console.WriteLine($"\n{firstName} is from {hometown[infoIndex]}.");
                    }

                    Console.Write("\nWould you like to learn about another student? (Enter \"yes\" or \"no\"): ");
                    userInput = Console.ReadLine();

                    while (userInput.ToLower() != "yes" && userInput.ToLower() != "no")
                    {
                        Console.Write("\nThat input is not valid. Please try again.\n(Enter \"yes\" or \"no\"): ");
                        userInput = Console.ReadLine();
                    }

                    repeatApp = userInput.ToLower() == "yes" ? true : false;
                }
            } while (repeatApp == true);
            Console.WriteLine("\nGoodbye!");
        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        public static int GetIndex(string input)
        {
            int index = 0;
            bool repeat = true;

            do
            {
                try
                {
                    index = int.Parse(input);
                    repeat = false;
                }
                catch (FormatException)
                {
                    Console.Write("\nInput is not valid, please try again: ");
                    input = GetUserInput();
                }
                catch (OverflowException)
                {
                    Console.Write("\nThat number is too large, please try again: ");
                    input = GetUserInput();
                }
            } while (repeat);
            return --index;
        }

        public static string GetFirstName(string[] array, int index)
        {
            string[] studentName = array[index].Split(' ');
            return studentName[0];
        }

        public static bool DoesStudentExist(string[] array, int index)
        {
            try
            {
                string student = array[index];
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
