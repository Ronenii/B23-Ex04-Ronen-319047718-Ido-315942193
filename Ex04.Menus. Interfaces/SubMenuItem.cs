using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{

    public class SubMenuItem : MenuItem
    {
        private const int k_GoBack = 0;
        private readonly bool r_isMainMenu;

        private List<IMenuItem> m_SubMenuItems = new List<IMenuItem>();

        public SubMenuItem(string i_Title, MenuItem i_Parent, bool i_IsMainMenu)
            : base(i_Title, i_Parent)
        {
            r_isMainMenu = i_IsMainMenu;
        }

        // A sub menu item can only display itself and ask user for input. This is it's Execute
        public override void Execute()
        {
            Console.Clear();
            PrintSubMenu();
            int userChoice = getUserInput();

            if (userChoice == k_GoBack)
            {
                goBack();
            }
            else
            {
                m_SubMenuItems[userChoice - 1].Execute();
            }
        }

        // If this is the main menu then display goodbye message and exit, else go back to parent menu
        private void goBack()
        {
            if (!r_isMainMenu)
            {
                Parent.Execute();
            }
        }

        // Prompts the user to enter a request and validates it, returns said request if valid
        private int getUserInput()
        {
            Console.Write("Enter your request: ");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (!isInputInRange(input))
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

        private void printLastOption()
        {
            if (r_isMainMenu)
            {
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back");
            }
        }

        public void AddMenuItem(IMenuItem i_MenuItem)
        {
            m_SubMenuItems.Add(i_MenuItem);
        }
    }
}
