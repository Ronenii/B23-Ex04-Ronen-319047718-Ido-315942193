using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public static class DelegateActions
    {
        public static void ShowTime()
        {
            Console.WriteLine($"Current time: {DateTime.Now.ToLongTimeString()}");
            Console.ReadLine();
        }

        public static void ShowDate()
        {
            Console.WriteLine($"Today's date: {DateTime.Now.ToLongDateString()}");
            Console.ReadLine();
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805");
            Console.ReadLine();
        }

        public static void CountSpaces()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            int spacesCount = sentence.Split(' ').Length - 1;
            Console.WriteLine($"Number of spaces: {spacesCount}");
        }
    }
}

