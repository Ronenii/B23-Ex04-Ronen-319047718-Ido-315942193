using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateMainMenu
    {

        private string m_title;
        private List<DelegateMenuItem> m_sumMenu;

        public DelegateMainMenu(string i_Title, List<DelegateMenuItem> i_SubMenu)
        {
            m_title = i_Title;
            m_sumMenu = i_SubMenu;
        }

        public List<DelegateMenuItem> SubItems { get => m_sumMenu; set => m_sumMenu = value; }
        public string Title { get => m_title; set => m_title = value; }

        public void Show()
        {
            Console.WriteLine($"---- {Title} ----");
            for (int i = 1; i <= m_sumMenu.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i, m_sumMenu[i - 1].Title);
            }
        }
    }

}
