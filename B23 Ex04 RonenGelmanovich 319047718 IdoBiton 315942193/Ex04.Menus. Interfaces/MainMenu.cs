using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public class MainMenu
    {
        private const int k_GoBack = 0;
        private SubMenuItem m_MainMenuItem;

        public MainMenu()
        {
            m_MainMenuItem = new SubMenuItem("Main Menu");
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            i_MenuItem.Parent = m_MainMenuItem;
            m_MainMenuItem.AddMenuItem(i_MenuItem);
        }

        // Main menu loop
        public void Run()
        {
            MenuItem currentMenuItem = m_MainMenuItem;
            while (currentMenuItem != null)
            {
                currentMenuItem.Execute();
                goBackIfAction(ref currentMenuItem); 

                try
                {
                    updateMenuItemFromUser(ref currentMenuItem);
                }
                catch (Exception e)
                {
                    printErrorMessage(e);
                }
            }
        }

        // Updates the current active menu item based on valid user input. Otherwise throws exception 
        private void updateMenuItemFromUser(ref MenuItem i_CurrentMenuItem)
        {
            Console.Write("Enter your request: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (!isInputInRange(userInput, i_CurrentMenuItem))
                {
                    throw new ArgumentException("Input not listed on menu.");
                }

                if (userInput == k_GoBack)
                {
                    goBack(ref i_CurrentMenuItem);
                }
                else
                {
                    goToUserChoice(ref i_CurrentMenuItem, userInput);
                }
            }
            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }

        // Checks if the user input is in the range of the sub menu items
        private bool isInputInRange(int i_Input, MenuItem i_MenuItem)
        {
            return (i_Input >= 0 && i_Input <= (i_MenuItem as SubMenuItem).NumOfSubItems);
        }

        // Advances the current menu item to the user choice
        private void goToUserChoice(ref MenuItem i_CurrentMenuItem, int i_UserInput)
        {
            if(i_CurrentMenuItem is SubMenuItem)
            {
                i_CurrentMenuItem = (i_CurrentMenuItem as SubMenuItem).getMenuItemByIndex(i_UserInput);
            }
        }

        // If given menuItem is action then go back to the previous submenu
        private void goBackIfAction(ref MenuItem i_CurrentMenuItem)
        {
            if (i_CurrentMenuItem is ActionMenuItem)
            {
                goBack(ref i_CurrentMenuItem);
                i_CurrentMenuItem.Execute();
            }
        }

        // Goes back to the previous subMenu
        private void goBack(ref MenuItem i_CurrentMenuItem)
        {
            i_CurrentMenuItem = i_CurrentMenuItem.Parent;
        }

        private void printErrorMessage(Exception i_Exception)
        {
            Console.WriteLine("Error: {0}", i_Exception.Message);
            holdForUserAction();
        }

        private void holdForUserAction()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
