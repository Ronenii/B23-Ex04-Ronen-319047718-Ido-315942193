using B23_Ex04_Ronen_319047718_Ido_315942193;
using Ex04.Menus.Delegates;
using System;
using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runMainManager();
        }

        private static void runMainManager()
        {
            InitMainMenu().Run();
            Console.Clear();
            Console.WriteLine("Goodbye forever");
            Console.ReadKey();

        }

        public static MainMenu InitInterfaceMainMenu()
        {
            // Init main menu
            MainMenu mainMenu = new MainMenu();

            // Init main menu option 1 (sub menu of show date and show time)
            SubMenuItem subItemShowDateTime = new SubMenuItem("Show Date/Time");
            ActionMenuItem actionItemShowDate = new ActionMenuItem("Show Date", new ShowDate());
            ActionMenuItem actionItemShowTime = new ActionMenuItem("Show Time", new ShowTime());
            subItemShowDateTime.AddMenuItem(actionItemShowDate);
            subItemShowDateTime.AddMenuItem(actionItemShowTime);

            // Init main menu option 2 (sub menu of show version and count spaces)
            SubMenuItem subItemVersionSpaces = new SubMenuItem("Version and Spaces");
            ActionMenuItem actionItemShowVersion = new ActionMenuItem("Show Version", new ShowVersion());
            ActionMenuItem actionItemCountSpaces = new ActionMenuItem("Count Spaces", new CountSpaces());
            subItemVersionSpaces.AddMenuItem(actionItemShowVersion);
            subItemVersionSpaces.AddMenuItem(actionItemCountSpaces);

            // Adding the sub menus to the main menu
            mainMenu.AddMenuItem(subItemShowDateTime);
            mainMenu.AddMenuItem(subItemVersionSpaces);
            return mainMenu;
        }

        public static DelegateMainMenu InitDelegateMainMenu()
        {
            // Init main menu
            DelegateMainMenu mainMenu = new DelegateMainMenu();

            // Init main menu option 1 (sub menu of show date and show time)
            DelegateMenuItem timeDateShow = new DelegateMenuItem("Show Date/Time");
            DelegateMenuItem timeShow = new DelegateMenuItem("Show Time", (path) => DelegateActions.ShowTime(path));
            DelegateMenuItem dateShow = new DelegateMenuItem("Show Date", (path) => DelegateActions.ShowDate(path));
            timeDateShow.AddMenuItem(dateShow);
            timeDateShow.AddMenuItem(timeShow);

            // Init main menu option 2 (sub menu of show version and count spaces)
            DelegateMenuItem spaceAndVersionShow = new DelegateMenuItem("Version and Spaces");
            DelegateMenuItem versionShow = new DelegateMenuItem("Show Version", (path) => DelegateActions.ShowVersion(path));
            DelegateMenuItem spacesShow = new DelegateMenuItem("Count Spaces", (path) => DelegateActions.CountSpaces(path));
            spaceAndVersionShow.AddMenuItem(versionShow);
            spaceAndVersionShow.AddMenuItem(spacesShow);

            // Adding the sub menus to the main menu
            mainMenu.AddMenuItem(timeDateShow);
            mainMenu.AddMenuItem(spaceAndVersionShow);
            return mainMenu;
        }


        public static DelegateMainMenu InitMainMenu()
        {
            // Init main menu
            DelegateMainMenu mainMenu = new DelegateMainMenu();

            // Init main menu option 1 (Delegate implemetation menu)
            DelegateMenuItem delegateMenu = new DelegateMenuItem("Delegate Implematation", (path) => InitDelegateMainMenu().Run());

            // Init main menu option 2 (Interface implemetation)
            DelegateMenuItem interfaceMenu = new DelegateMenuItem("Interface Implematation", (path) => InitInterfaceMainMenu().Run());

            // Adding the sub menus to the main menu
            mainMenu.AddMenuItem(delegateMenu);
            mainMenu.AddMenuItem(interfaceMenu);
            return mainMenu;
        }
    }
}
