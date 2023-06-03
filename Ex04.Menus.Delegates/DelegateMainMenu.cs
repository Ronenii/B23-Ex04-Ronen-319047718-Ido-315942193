using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateMainMenu
    {
        private DelegateMenuItem m_MainMenuItem;

        public DelegateMainMenu()
        {
            m_MainMenuItem = new DelegateMenuItem("Main Menu");
        }

        public void AddMenuItem(DelegateMenuItem i_SubMenuItems)
        {
            m_MainMenuItem.AddMenuItem(i_SubMenuItems);
        }

        public void Run()
        {
            while (m_MainMenuItem != null)
            {
                m_MainMenuItem.Show();
                try
                {
                    updateMenuItemFromUser();
                }
                catch (Exception e)
                {
                    printErrorMessage(e);
                }
                if (m_MainMenuItem != null)
                {
                    m_MainMenuItem.Execute();
                }
            }
        }

        private void updateMenuItemFromUser()
        {
            Console.Write("Enter your request: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {

                if (!isInputInRange(userInput))
                {
                    throw new ArgumentException("Input not listed on menu.");
                }
                if (isBackExitChoice(userInput))
                {
                    goBack();
                }
                else
                {
                    DelegateMenuItem nextMenuItem = m_MainMenuItem.SubMenuItems[userInput - 1];
                    if (isSubMenu(nextMenuItem))
                    {
                        m_MainMenuItem = nextMenuItem;
                    }
                    nextMenuItem.Execute();
                }
            }

            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }


        private bool isSubMenu(DelegateMenuItem nextMenuItem)
        {
            return nextMenuItem.Action == null;
        }

        private bool isBackExitChoice(int userInput)
        {
            return userInput == 0;
        }

        private bool isInputInRange(int i_Input)
        {

            return (i_Input >= 0 && i_Input <= m_MainMenuItem.SubMenuItems.Count);
        }

        private void goBack()
        {
            m_MainMenuItem = m_MainMenuItem.Parent;
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
