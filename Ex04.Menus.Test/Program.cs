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
            DelegateMenuManager.Run(InitMainMenu());
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

        public static DelegateMenuItem InitDelegateMainMenu()
        {
            DelegateMenuItem main = new DelegateMenuItem("Delegate Main Menu", null, new List<DelegateMenuItem>());
            DelegateMenuItem timeDateShow = new DelegateMenuItem("Show Date/Time", main, new List<DelegateMenuItem>());
            DelegateMenuItem timeShow = new DelegateMenuItem("Show Time", timeDateShow, (path) => DelegateActions.ShowTime(path));
            DelegateMenuItem dateShow = new DelegateMenuItem("Show Date", timeDateShow, (path) => DelegateActions.ShowDate(path));
            timeDateShow.AddMenuItem(dateShow);
            timeDateShow.AddMenuItem(timeShow);
            DelegateMenuItem spaceAndVersionShow = new DelegateMenuItem("Version and Spaces", main, new List<DelegateMenuItem>());
            DelegateMenuItem versionShow = new DelegateMenuItem("Show Version", spaceAndVersionShow, (path) => DelegateActions.ShowVersion(path));
            DelegateMenuItem spacesShow = new DelegateMenuItem("Count Spaces", spaceAndVersionShow, (path) => DelegateActions.CountSpaces(path));
            spaceAndVersionShow.AddMenuItem(versionShow);
            spaceAndVersionShow.AddMenuItem(spacesShow);
            main.AddMenuItem(timeDateShow);
            main.AddMenuItem(spaceAndVersionShow);
            return main;
        }


        public static DelegateMenuItem InitMainMenu()
        {
            DelegateMenuItem main = new DelegateMenuItem("Main Menu", null, new List<DelegateMenuItem>());
            DelegateMenuItem delegateMenu = new DelegateMenuItem("Delegate Implematation", main, (path) => DelegateMenuManager.Run(InitDelegateMainMenu()));
            DelegateMenuItem interfaceMenu = new DelegateMenuItem("Interface Implematation", main, (path) => InitInterfaceMainMenu().Run());
            main.AddMenuItem(delegateMenu);
            main.AddMenuItem(interfaceMenu);
            return main;
        }
    }
}
