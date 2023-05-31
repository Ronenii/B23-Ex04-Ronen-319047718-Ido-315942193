using System;
using B23_Ex04_Ronen_319047718_Ido_315942193;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            const bool v_IsMainMenu = true;
            const bool v_IsNotMainMenu = false;

            // Init main menu
            SubMenuItem mainMenu = new SubMenuItem("Main Menu", null, v_IsMainMenu);

            // Init main menu option 1 (sub menu of show date and show time)
            SubMenuItem subItemShowDateTime = new SubMenuItem("Show Date/Time", mainMenu, v_IsNotMainMenu);
            ActionMenuItem actionItemShowDate = new ActionMenuItem("Show Date", subItemShowDateTime, new ShowDate());
            ActionMenuItem actionItemShowTime = new ActionMenuItem("Show Time", subItemShowDateTime, new ShowTime());
            subItemShowDateTime.AddMenuItem(actionItemShowDate);
            subItemShowDateTime.AddMenuItem(actionItemShowTime);

            // Init main menu option 2 (sub menu of show version and count spaces)
            SubMenuItem subItemVersionSpaces = new SubMenuItem("Version and Spaces", mainMenu, v_IsNotMainMenu);
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
