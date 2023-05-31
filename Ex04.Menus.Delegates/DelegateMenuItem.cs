using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateMenuItem
    {
        private string m_Title;

        private DelegateMenuItem m_Parent;

        private Action<string> m_Action;

        private List<DelegateMenuItem> m_SubMenuItems;

        private string m_Path;

        public string Title { get => m_Title; set => m_Title = value; }
        public DelegateMenuItem Parent { get => m_Parent; set => m_Parent = value; }
        public List<DelegateMenuItem> SubMenuItems { get => m_SubMenuItems; set => m_SubMenuItems = value; }
        public Action<string> Action { get => m_Action; set => m_Action = value; }
        public string Path { get => m_Path; set => m_Path = value; }

        public DelegateMenuItem(string i_Title, DelegateMenuItem i_Parent, Action<string> i_Action)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            m_Action = i_Action;
            m_SubMenuItems = new List<DelegateMenuItem>();
            m_Path = getPath();
        }

        public DelegateMenuItem(string i_Title, DelegateMenuItem i_Parent, List<DelegateMenuItem> i_SubMenuItems)
        {
            m_Title = i_Title;
            m_Action = null;
            m_Parent = i_Parent;
            m_SubMenuItems = i_SubMenuItems;
            m_Path = getPath();
        }

        private string getPath()
        {
            string menuPath = "";
            if (!isMainMenu())
            {
                menuPath += $"{m_Parent.getPath()} -> ";
            }
            menuPath += m_Title;
            return menuPath;
        }

        public void AddMenuItem(DelegateMenuItem i_SubMenuItems)
        {
            m_SubMenuItems.Add(i_SubMenuItems);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(m_Path);
            Console.WriteLine();
            Console.WriteLine($"---- {Title} ----");
            for (int i = 1; i <= m_SubMenuItems.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, m_SubMenuItems[i - 1].Title);
            }
            printRelevantBackMessage();
            Console.WriteLine();
        }

        private void printRelevantBackMessage()
        {
            if (isMainMenu())
            {
                Console.WriteLine("0. Exit");
            }
            else
            {
                Console.WriteLine("0. Back");
            }
        }

        private bool isMainMenu()
        {
            return m_Parent == null;
        }

        public void Execute()
        {
            Console.Clear();
            m_Action?.Invoke(m_Path);
        }
    }
}
