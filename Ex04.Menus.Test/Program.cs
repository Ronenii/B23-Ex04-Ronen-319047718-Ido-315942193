using Ex04.Menus.Delegates;
using System;
using B23_Ex04_Ronen_319047718_Ido_315942193;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            bool isExist = false;
            DelegateActionHandler delegateActionHandler = new DelegateActionHandler();

            while (!isExist)
            {
                Console.Clear();
                Console.WriteLine("Please choose the implementation: ");
                Console.WriteLine("1. Delegate implementation");
                Console.WriteLine("2. Interface implementation");
                Console.WriteLine("0. Exit");
                if (int.TryParse(Console.ReadLine(), out int userImplemetationSelection))
                {
                    if (userImplemetationSelection == 0)
                    {
                        isExist = true;
                        Console.WriteLine("Goodbye for forever");
                        Console.ReadKey();
                    }
                    else if (userImplemetationSelection == 1)
                    {
                        delegateActionHandler.Run();
                    }
                    else if (userImplemetationSelection == 2)
                    {
                        initInterfaceMainMenu(); // TODO export to handler class
                    }
                    else
                    {
                        Console.WriteLine("Input not listed on menu");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, must be a number");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            }


        }

        private static void initInterfaceMainMenu()
        {
            const bool v_IsMainMenu = true;

            // Init main menu
            SubMenuItem mainMenu = new SubMenuItem("Main Menu", null, v_IsMainMenu);

            // Init main menu option 1 (sub menu of show date and show time)
            SubMenuItem subItemShowDateTime = new SubMenuItem("Show Date/Time", mainMenu, !v_IsMainMenu);
            ActionMenuItem actionItemShowDate = new ActionMenuItem("Show Date", subItemShowDateTime, new ShowDate());
            ActionMenuItem actionItemShowTime = new ActionMenuItem("Show Time", subItemShowDateTime, new ShowTime());
            subItemShowDateTime.AddMenuItem(actionItemShowDate);
            subItemShowDateTime.AddMenuItem(actionItemShowTime);

            // Init main menu option 2 (sub menu of show version and count spaces)
            SubMenuItem subItemVersionSpaces = new SubMenuItem("Version and Spaces", mainMenu, !v_IsMainMenu);
            ActionMenuItem actionItemShowVersion = new ActionMenuItem("Show Version", subItemVersionSpaces, new ShowVersion());
            ActionMenuItem actionItemCountSpaces = new ActionMenuItem("Count Spaces", subItemVersionSpaces, new CountSpaces());
            subItemVersionSpaces.AddMenuItem(actionItemShowVersion);
            subItemVersionSpaces.AddMenuItem(actionItemCountSpaces);

            // Adding the sub menus to the main menu
            mainMenu.AddMenuItem(subItemShowDateTime);
            mainMenu.AddMenuItem(subItemVersionSpaces);

            // Running the menu
            mainMenu.Execute();
        }
    }
}
