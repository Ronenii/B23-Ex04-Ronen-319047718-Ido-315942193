using Ex04.Menus.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class DelegateActionHandler
    {
        private DelegateMainMenu m_DelegateMainMenu;
        private DelegateMenuItem m_ActiveDelegateMenuItem;
        private void initMenu()
        {
            DelegateMenuItem timeDateShow = new DelegateMenuItem("Time/Date Show", new List<DelegateMenuItem>());
            DelegateMenuItem timeShow = new DelegateMenuItem("Time Show", timeDateShow, () => DelegateActions.ShowTime());
            DelegateMenuItem dateShow = new DelegateMenuItem("Date Show", timeDateShow, () => DelegateActions.ShowDate());
            timeDateShow.addMenuItem(timeShow);
            timeDateShow.addMenuItem(dateShow);
            DelegateMenuItem spaceAndVersionShow = new DelegateMenuItem("Spaces and Version", new List<DelegateMenuItem>());
            DelegateMenuItem versionShow = new DelegateMenuItem("Show Version", spaceAndVersionShow, () => DelegateActions.ShowVersion());
            DelegateMenuItem spacesShow = new DelegateMenuItem("Count Spaces", spaceAndVersionShow, () => DelegateActions.CountSpaces());
            spaceAndVersionShow.addMenuItem(versionShow);
            spaceAndVersionShow.addMenuItem(spacesShow);
            m_DelegateMainMenu = new DelegateMainMenu("Main", new List<DelegateMenuItem>() { timeDateShow, spaceAndVersionShow });
        }

        private void showMenu()
        {
            m_DelegateMainMenu.Show();
        }

        public void Run()
        {
            initMenu();
            showMenu();
            while (true)
            {
                m_ActiveDelegateMenuItem = getMenuItemFromUser();
                if (m_ActiveDelegateMenuItem.Action != null)
                {
                    m_ActiveDelegateMenuItem.Execute();
                }
                else
                {
                    Console.WriteLine(m_ActiveDelegateMenuItem.Title);
                }
            }
        }

        private DelegateMenuItem getMenuItemFromUser()
        {
            int numberOfSubItems = m_DelegateMainMenu.SubItems.Count;
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                if (!isInputInRange(userInput))
                {
                    throw new ArgumentException("Input not listed on menu.");
                }
                return m_DelegateMainMenu.SubItems[userInput - 1];

            }
            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }
        }

        private bool isInputInRange(int i_Input)
        {
            return i_Input >= 0 && i_Input <= m_DelegateMainMenu.SubItems.Count;
        }

        private void goBack()
        {
            throw new NotImplementedException();
        }
    }
}