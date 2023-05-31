using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateMenuItem
    {
        private readonly string r_Title;

        private readonly DelegateMenuItem r_Parent;

        private readonly string r_Path;

        private List<DelegateMenuItem> m_SubMenuItems;

        private event Action<string> m_Action;

        public string Title { get => r_Title; }
        public DelegateMenuItem Parent { get => r_Parent; }
        public List<DelegateMenuItem> SubMenuItems { get => m_SubMenuItems; }
        public Action<string> Action { get => m_Action; }
        public string Path { get => r_Path; }

        public DelegateMenuItem(string i_Title, DelegateMenuItem i_Parent, Action<string> i_Action)
        {
            r_Title = i_Title;
            r_Parent = i_Parent;
            m_Action += i_Action;
            m_SubMenuItems = new List<DelegateMenuItem>();
            r_Path = createCurrentPath();
        }

        public DelegateMenuItem(string i_Title, DelegateMenuItem i_Parent, List<DelegateMenuItem> i_SubMenuItems)
        {
            r_Title = i_Title;
            m_Action = null;
            r_Parent = i_Parent;
            m_SubMenuItems = i_SubMenuItems;
            r_Path = createCurrentPath();
        }

        private string createCurrentPath()
        {
            string menuPath = "";
            if (!isMainMenu())
            {
                menuPath += $"{r_Parent.Path} -> ";
            }
            menuPath += r_Title;
            return menuPath;
        }

        public void AddMenuItem(DelegateMenuItem i_SubMenuItems)
        {
            m_SubMenuItems.Add(i_SubMenuItems);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(r_Path);
            Console.WriteLine();
            Console.WriteLine($"---- {Title} ----");
            for (int i = 1; i <= m_SubMenuItems.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, m_SubMenuItems[i - 1].Title);
            }
            printLastOption();
            Console.WriteLine();
        }

        private void printLastOption()
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
            return r_Parent == null;
        }

        public void Execute()
        {
            Console.Clear();
            m_Action?.Invoke(r_Path);
        }
    }
}
