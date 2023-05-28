using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public interface ISubMenuItem
    {
        void ListSubMenu();
        void AddSubMenuItemToSubMenu(string i_Prompt);
        void AddFinalItemToSubMenu(string i_Prompt);
    }

    public interface IFinalMenuItem
    {
        void MenuAction();
    }

    public class MenuItem
    {
        private readonly string m_Path;

        public string Path
        {
            get;
        }
        private readonly string m_Propmt;

        public string Prompt
        {
            get;
        }

        private readonly int m_ItemNum;

        public int ItemNum
        {
            get;
        }

        public MenuItem(string i_Prompt, int i_ItemNum, string i_ParentMenuItem)
        {
            m_Propmt = i_Prompt;
            m_ItemNum = i_ItemNum;
            m_Path += string.Format("/{0}", i_ParentMenuItem);
        }

        public void PrintPath()
        {
            Console.WriteLine(m_Path);
        }

        public void PrintItem()
        {
            string prompt = string.Format("{0}. {1}", m_ItemNum, m_Propmt);
            Console.WriteLine(prompt);
        }
    }
}
