using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateMenuItem
    {
        private readonly string r_Title;

        private DelegateMenuItem m_Parent;

        private List<DelegateMenuItem> m_SubMenuItems;

        private event Action<string> m_Action;
        public string Title { get => r_Title; }
        public List<DelegateMenuItem> SubMenuItems { get => m_SubMenuItems; }
        public Action<string> Action { get => m_Action; }
        public DelegateMenuItem Parent { get => m_Parent; set => m_Parent = value; }

        public DelegateMenuItem(string i_Title, Action<string> i_Action)
        {
            r_Title = i_Title;
            m_Action += i_Action;
            m_SubMenuItems = new List<DelegateMenuItem>();
        }

        public DelegateMenuItem(string i_Title)
        {
            r_Title = i_Title;
            m_Action = null;
            m_SubMenuItems = new List<DelegateMenuItem>();
        }

        private string createCurrentPath()
        {
            string menuPath = "";
            if (!isMainMenu())
            {
                menuPath += $"{m_Parent.createCurrentPath()} -> ";
            }

            menuPath += r_Title;
            return menuPath;
        }

        public void AddMenuItem(DelegateMenuItem i_SubMenuItems)
        {
            i_SubMenuItems.Parent = this;
            m_SubMenuItems.Add(i_SubMenuItems);
        }

        public void Show()
        {
            Console.Clear();
            string path = createCurrentPath();
            Console.WriteLine(path);
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
            return m_Parent == null;
        }

        public void Execute()
        {
            Console.Clear();
            m_Action?.Invoke(createCurrentPath());
        }
    }
}
