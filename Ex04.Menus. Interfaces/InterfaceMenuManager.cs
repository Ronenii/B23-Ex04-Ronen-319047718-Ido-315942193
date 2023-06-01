using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public static class InterfaceMenuManager
    {
        private const int k_GoBack = 0;
        private static MenuItem m_ActiveMenuItem = null;

        // Runs the given interface Menu
        public static void Run(MenuItem i_Menu)
        {
            m_ActiveMenuItem = i_Menu;
            while (m_ActiveMenuItem != null)
            {
                m_ActiveMenuItem.Execute();
                try
                {
                    updateMenuItemFromUser();
                }
                catch (Exception e)
                {
                    printErrorMessage(e);
                }
                if (m_ActiveMenuItem != null)
                {
                    m_ActiveMenuItem.Execute();
                }
            }
        }

        // Updates the current active menu item based on valid user input. Otherwise throws exception 
        private static void updateMenuItemFromUser()
        {
            Console.Write("Enter your request: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {

                if (!isInputInRange(userInput))
                {
                    throw new ArgumentException("Input not listed on menu.");
                }
                else if (userInput == k_GoBack)
                {
                    goBack();
                }
                else
                {
                    MenuItem nextMenuItem = (m_ActiveMenuItem as SubMenuItem).MenuItems[userInput - 1];
                    if (nextMenuItem is SubMenuItem)
                    {
                        m_ActiveMenuItem = nextMenuItem;
                    }

                    nextMenuItem.Execute();
                }
            }
            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }

        // Checks if the user input is in the range of the sub menu items
        private static bool isInputInRange(int i_Input)
        {

            return (i_Input >= 0 && i_Input <= (m_ActiveMenuItem as SubMenuItem).MenuItems.Count);
        }

        private static void goBack()
        {
            m_ActiveMenuItem = m_ActiveMenuItem.Parent;
        }

        private static void printErrorMessage(Exception i_Exception)
        {
            Console.WriteLine("Error: {0}", i_Exception.Message);      
            holdForUserAction();
        }

        private static void holdForUserAction()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
