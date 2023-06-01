using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{

    public class SubMenuItem : MenuItem
    {
        private int m_NumOfSubItems;
        public int NumOfSubItems
        {
            get
            {
                return m_NumOfSubItems;
            }
        }
        private List<MenuItem> m_SubMenuItems = new List<MenuItem>();

        public SubMenuItem(string i_Title)
            : base(i_Title)
        {
            m_NumOfSubItems = 0;
        }

        // A sub menu item can only display itself and ask user for input. This is it's Execute
        public override void Execute()
        {
            Console.Clear();
            PrintSubMenu();
        }

        // Checks if input is withing the acceptable range of options in the menu
        private bool isInputInRange(int i_Input)
        {
            return i_Input >= 0 && i_Input <= m_SubMenuItems.Count;
        }

        public void PrintSubMenu()
        {
            int numOfSubMenuItems = m_SubMenuItems.Count;

            //Prints the path of the menu only if we are not in the main menu

            PrintPath();
            PrintTitle();
            for (int i = 1; i <= numOfSubMenuItems; i++)
            {
                Console.WriteLine("{0}. {1}", i, m_SubMenuItems[i - 1].Title);
            }
            printLastOption();
            Console.WriteLine();
        }

        public MenuItem getMenuItemByIndex(int index)
        {
            return m_SubMenuItems[index - 1];
        }

        // Prints out the last available option (op 0) based on if its a main menu or not
        private void printLastOption()
        {
            if (IsMainMenu())
            {
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back");
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {

            i_MenuItem.Parent = this;
            m_SubMenuItems.Add(i_MenuItem);
            m_NumOfSubItems++;
        }
    }
}
