using Ex04.Menus.Delegates;
using System;

namespace Ex04.Menus.Test
{
    public class DelegateMenuManager
    {
        private static DelegateMenuItem m_ActiveDelegateMenuItem = null;

        public static void Run(DelegateMenuItem i_DelegateMenu)
        {
            m_ActiveDelegateMenuItem = i_DelegateMenu;
            while (m_ActiveDelegateMenuItem != null)
            {
                m_ActiveDelegateMenuItem.Show();
                updateMenuItemFromUser();
                if (m_ActiveDelegateMenuItem != null)
                {
                    m_ActiveDelegateMenuItem.Execute();
                }
            }
        }

        private static void updateMenuItemFromUser()
        {
            Console.Write("Enter your request: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {

                if (!isInputInRange(userInput))
                {
                    throw new ArgumentException("Input not listed on menu.");
                }
                if (userInput == 0)
                {
                    goBack();
                }
                else
                {
                    DelegateMenuItem nextMenuItem = m_ActiveDelegateMenuItem.SubMenuItems[userInput - 1];
                    if (nextMenuItem.Action == null)
                    {
                        m_ActiveDelegateMenuItem = nextMenuItem;
                    }
                    nextMenuItem.Execute();
                }
            }

            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }


        private static bool isInputInRange(int i_Input)
        {

            return (i_Input >= 0 && i_Input <= m_ActiveDelegateMenuItem.SubMenuItems.Count);
        }

        private static void goBack()
        {
            m_ActiveDelegateMenuItem = m_ActiveDelegateMenuItem.Parent;
        }
    }
}