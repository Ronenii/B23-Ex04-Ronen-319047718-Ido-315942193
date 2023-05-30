using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public class SubMenuItem : MenuItem
    {
        private List<IMenuItem> m_SubMenuItems;

        private readonly bool m_isMainMenu;

        public SubMenuItem(string i_Title, MenuItem i_Parent, bool i_IsMainMenu)
            : base(i_Title, i_Parent)
        {
            m_isMainMenu = i_IsMainMenu;
        }

        public override void Execute()
        {
            Console.Clear();
            PrintSubMenu();
            int userChoice = getUserInput();

            if(isGoBack(userChoice))
            {
                goBack();
            }
            else
            {
                m_SubMenuItems[userChoice - 1].Execute();
            }
        }

        private static bool isGoBack(int i_Choice)
        {
            return i_Choice == 0;
        }

        private void goBack()
        {
            if (m_isMainMenu)
            {
                Console.WriteLine("Bye");
                Console.ReadKey();
            }
            else
            {
                Parent.Execute();
            }
        }

        private int getUserInput()
        {
            Console.Write("Enter your request: ");

            if(int.TryParse(Console.ReadLine(), out int input))
            {
                if(!isInputInRange(input))
                {
                    throw new ArgumentException("Input not listed on menu.");
                }
            }
            else
            {
                throw new FormatException("Invalid input, must be a number.");
            }

            return input;
        }

        private bool isInputInRange(int i_Input)
        {
            return i_Input >= 0 && i_Input <= m_SubMenuItems.Count;
        }

        public void PrintSubMenu()
        {
            int numOfSubMenuItems = m_SubMenuItems.Count;
            PrintPath();
            Console.WriteLine();
            PrintTitle();
            for (int i = 1; i < numOfSubMenuItems; i++)
            {
                Console.WriteLine("{0}. {1}", i, m_SubMenuItems[i - 1].Title);
            }
        }

        private void printLastOption()
        {
            if (m_isMainMenu)
            {
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back");
            }
        }
    }
}
