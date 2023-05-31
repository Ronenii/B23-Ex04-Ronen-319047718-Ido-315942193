using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public static class DelegateActions
    {
        public static void ShowTime(string i_Path)
        {
            Console.WriteLine(i_Path);
            Console.WriteLine();
            DateTime date = DateTime.Now;
            Console.WriteLine("Current Time: " + date.ToString("HH:mm:ss"));
            holdForUserKeyPress();
        }

        public static void ShowDate(string i_Path)
        {
            Console.WriteLine(i_Path);
            Console.WriteLine();
            Console.WriteLine($"Current Date: {DateTime.Now.ToLongDateString()}");
            holdForUserKeyPress();
        }

        public static void ShowVersion(string i_Path)
        {
            Console.WriteLine(i_Path);
            Console.WriteLine();
            Console.WriteLine("Version: 23.2.4.9805");
            holdForUserKeyPress();
        }

        public static void CountSpaces(string i_Path)
        {
            Console.WriteLine(i_Path);
            Console.WriteLine();
            Console.Write("Please write a sentence: ");
            string sentence = Console.ReadLine();
            int spacesCounter = sentence.Split(' ').Length - 1;
            Console.WriteLine("Sentence contains {0} spaces", spacesCounter);
            holdForUserKeyPress();
        }

        private static void holdForUserKeyPress()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}

