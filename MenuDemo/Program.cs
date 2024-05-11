﻿using System;
using System.ComponentModel;

namespace MenuDemo
{
    /// <summary>
    /// Defines the behavior of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <remarks>
        /// This method serves as the starting point of the console application.
        /// <para />
        /// It continuously displays a menu of choices to the user and executes the
        /// corresponding actions based on their selection.
        /// <para />
        /// The menu is displayed until the user decides to exit the application.
        /// </remarks>
        public static void Main()
        {
            while (true)
            {
                DisplayMenu();
                var choice = GetUserChoice();

                // Convert 1-based menu choice to 0-based index
                var choiceIndex = (int)choice - 1;

                // Check if choice is within the valid range
                if (choiceIndex >= 0 && choiceIndex < Enum
                        .GetValues(typeof(MenuChoices))
                        .Length) // Check against all menu items
                    // Perform action based on user choice index
                    switch (choiceIndex)
                    {
                        case (int)MenuChoices.EatCandy:
                            Console.WriteLine("You chose to Eat Candy.");

                            // Add your Eat Candy logic here
                            break;

                        case (int)MenuChoices.GoFishing:
                            Console.WriteLine("You chose to Go Fishing.");

                            // Add your Go Fishing logic here
                            break;

                        case (int)MenuChoices.PlayBasketball:
                            Console.WriteLine("You chose to Play Basketball.");

                            // Add your Play Basketball logic here
                            break;

                        case (int)MenuChoices.Exit:
                            Console.Write(
                                "Are you sure you want to exit the application? (Y/N): "
                            );
                            var confirmation = Console.ReadLine()
                                .ToUpper()[0];
                            Console.WriteLine();
                            if (confirmation == 'Y')
                            {
                                Console.WriteLine("Exiting the application...");
                                return; // Exit the Main method
                            }

                            Console.Clear();
                            continue;

                        default:
                            Console.WriteLine(
                                "Invalid choice. Please try again."
                            );
                            break;
                    }
                else
                    Console.WriteLine("Invalid choice. Please try again.");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear(); // Clear the console for the next iteration
            }
        }

        /// <summary>
        /// Displays the menu of choices on the console.
        /// </summary>
        /// <remarks>
        /// This method iterates through all the available menu choices and displays them
        /// along with their corresponding numbers.
        /// <para />
        /// The numbering of the choices starts from <c>1</c>.
        /// </remarks>
        private static void DisplayMenu()
        {
            Console.WriteLine("Please choose an action:\n");
            var menuItemNumber = 1;
            foreach (MenuChoices choice in Enum.GetValues(typeof(MenuChoices)))
                if (choice != MenuChoices.Unknown)
                {
                    var description = GetEnumDescription(choice);
                    Console.WriteLine($"[{menuItemNumber}]:    {description}");
                    menuItemNumber++;
                }

            Console.Write("\nEnter your selection: ");
        }

        /// <summary>
        /// Retrieves the description attribute value associated with the specified enum
        /// value.
        /// </summary>
        /// <param name="value">
        /// The <see langword="enum" /> value for which to retrieve the
        /// description.
        /// </param>
        /// <returns>
        /// The description associated with the <see langword="enum" /> value, if
        /// available; otherwise, the
        /// string representation of the <see langword="enum" /> value.
        /// </returns>
        /// <remarks>
        /// This method retrieves the description attribute value, if present, associated
        /// with the specified <see langword="enum" /> value.
        /// <para />
        /// If no description attribute is found, it returns the string representation of
        /// the <see langword="enum" /> value.
        /// </remarks>
        private static string GetEnumDescription(Enum value)
        {
            var field = value.GetType()
                             .GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(
                field, typeof(DescriptionAttribute)
            );
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Reads user input from the console and parses it into a
        /// <see cref="T:MenuDemo.MenuChoices" /> enumeration value.
        /// </summary>
        /// <returns>
        /// The <see cref="T:MenuDemo.MenuChoices" /> enumeration value corresponding to
        /// the user input.
        /// If the input cannot be parsed into a valid enumeration value, returns
        /// <see cref="F:MenuDemo.MenuChoices.Unknown" />.
        /// </returns>
        /// <remarks>
        /// This method reads a line of text from the console input and attempts to parse
        /// it into a <see cref="T:MenuDemo.MenuChoices" /> enumeration value.
        /// <para />
        /// If the input matches any of the enumeration values, the corresponding
        /// enumeration value is returned.
        /// <para />
        /// If the input cannot be parsed into a valid enumeration value, the method
        /// returns <see cref="F:MenuDemo.MenuChoices.Unknown" />.
        /// </remarks>
        private static MenuChoices GetUserChoice()
        {
            var input = Console.ReadLine();
            return Enum.TryParse(input, out MenuChoices choice)
                ? choice
                : MenuChoices.Unknown;
        }
    }
}