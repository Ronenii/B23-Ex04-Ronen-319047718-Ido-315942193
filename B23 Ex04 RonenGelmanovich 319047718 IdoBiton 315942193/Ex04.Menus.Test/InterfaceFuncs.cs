﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B23_Ex04_Ronen_319047718_Ido_315942193;

namespace Ex04.Menus.Test
{
    public class ShowDate : IMenuObserver
    {
        public void Execute()
        {
            Console.WriteLine("Current Date: " + DateTime.Now.ToLongDateString());
            Utils.HoldForUserKeyPress();
        }
    }

    public class ShowTime : IMenuObserver
    {
        public void Execute()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine("Current Time: " + date.ToString("HH:mm:ss"));
            Utils.HoldForUserKeyPress();
        }
    }

    public class ShowVersion : IMenuObserver
    {
        public void Execute()
        {
            Console.WriteLine("Version: 23.2.4.9805");
            Utils.HoldForUserKeyPress();
        }
    }

    public class CountSpaces : IMenuObserver
    {
        public void Execute()
        {
            Console.Write("Please write a sentence: ");
            string sentence = Console.ReadLine();
            int spacesCounter = sentence.Split(' ').Length - 1;

            Console.WriteLine("Sentence contains {0} spaces", spacesCounter);
            Utils.HoldForUserKeyPress();
        }
    }

    public static class Utils
    {
        public static void HoldForUserKeyPress()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }

}
