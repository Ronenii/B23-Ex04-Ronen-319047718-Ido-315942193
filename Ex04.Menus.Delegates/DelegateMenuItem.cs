using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class DelegateMenuItem
    {
        private string m_Path;

        private string m_Title;

        private DelegateMenuItem m_Parent;

        private Action m_action;

        private List<DelegateMenuItem> m_SubMenuItems;

        public string Title { get => m_Title; set => m_Title = value; }
        public string Path { get => m_Path; set => m_Path = value; }
        public DelegateMenuItem Parent { get => m_Parent; set => m_Parent = value; }
        public List<DelegateMenuItem> SubMenuItems { get => m_SubMenuItems; set => m_SubMenuItems = value; }
        public Action Action { get => m_action; set => m_action = value; }

        public DelegateMenuItem(string i_Title, DelegateMenuItem i_Parent, Action i_Action)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            m_action = i_Action;
            m_SubMenuItems = new List<DelegateMenuItem>();
            m_Path += string.Format("{0}->{1}", i_Parent.Path, i_Parent.Title);
        }

        public DelegateMenuItem(string i_Title, List<DelegateMenuItem> i_SubMenuItems)
        {
            m_Title = i_Title;
            m_action = null;
            m_SubMenuItems = i_SubMenuItems;
        }

        public void addMenuItem(DelegateMenuItem i_SubMenuItems)
        {
            m_SubMenuItems.Add(i_SubMenuItems);
        }

        public void Execute()
        {
            m_action?.Invoke();
        }
    }
}
