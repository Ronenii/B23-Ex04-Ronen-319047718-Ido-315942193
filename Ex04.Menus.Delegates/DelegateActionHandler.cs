using Ex04.Menus.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class DelegateActionHandler
    {
        private DelegateMenuItem m_ActiveDelegateMenuItem = null;
        private void initMenu()
        {
            DelegateMenuItem main = new DelegateMenuItem("Main", null, new List<DelegateMenuItem>());
            DelegateMenuItem timeDateShow = new DelegateMenuItem("Time/Date Show", main, new List<DelegateMenuItem>());
            DelegateMenuItem timeShow = new DelegateMenuItem("Time Show", timeDateShow, (path) => DelegateActions.ShowTime(path));
            DelegateMenuItem dateShow = new DelegateMenuItem("Date Show", timeDateShow, (path) => DelegateActions.ShowDate(path));
            timeDateShow.addMenuItem(timeShow);
            timeDateShow.addMenuItem(dateShow);
            DelegateMenuItem spaceAndVersionShow = new DelegateMenuItem("Spaces and Version", main, new List<DelegateMenuItem>());
            DelegateMenuItem versionShow = new DelegateMenuItem("Show Version", spaceAndVersionShow, (path) => DelegateActions.ShowVersion(path));
            DelegateMenuItem spacesShow = new DelegateMenuItem("Count Spaces", spaceAndVersionShow, (path) => DelegateActions.CountSpaces(path));
            spaceAndVersionShow.addMenuItem(versionShow);
            spaceAndVersionShow.addMenuItem(spacesShow);
            main.addMenuItem(timeDateShow);
            main.addMenuItem(spaceAndVersionShow);
            m_ActiveDelegateMenuItem = main;
        }


        public void Run()
        {
            initMenu();
            while (m_ActiveDelegateMenuItem != null)
            {
                m_ActiveDelegateMenuItem.Show();
                updateMenuItemFromUser();
                if (m_ActiveDelegateMenuItem != null)
                {
                    m_ActiveDelegateMenuItem.Execute();
                }
            }
            exitHandler();
        }

        private static void exitHandler()
        {
            Console.WriteLine("Thank you and goodbye!");
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


        private bool isInputInRange(int i_Input)
        {

            return (i_Input >= 0 && i_Input <= m_ActiveDelegateMenuItem.SubMenuItems.Count);
        }

        private void goBack()
        {
            m_ActiveDelegateMenuItem = m_ActiveDelegateMenuItem.Parent;
        }
    }
}