using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B23_Ex04_Ronen_319047718_Ido_315942193
{
    public class ActionMenuItem: MenuItem
    {
        public ActionMenuItem(string i_Title, MenuItem i_Parent)
            : base(i_Title, i_Parent)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
