using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    interface ISubMenu
    {
        void ListSubMenu();
    }

    interface IAction
    {
        void MenuAction();
    }

    public class MenuItem
    {
        private List<MenuItem> m_MenuItems;
        private readonly List<string> m_Path;
        private string m_Propmt;
        private int m_ItemNum;

        public MenuItem(string i_Prompt, int i_ItemNum)
        {
            m_Propmt = i_Prompt;
            m_ItemNum = i_ItemNum;
        }

        public void ListSubMenu()
        {
            foreach(string subPath in m_Path)
            {
                Console.Write(subPath + "/");
            }
            foreach(MenuItem item in m_MenuItems)
            {
                item.PrintItem();
            }
        }

        public void PrintItem()
        {
            string prompt = string.Format("{0}. {1}", m_ItemNum, m_Propmt);
            Console.WriteLine(prompt);
        }

        public void AddItem(MenuItem i_Item)
        {
            m_MenuItems.Add(i_Item);
        }
    }
}
