using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signature
{
    public class FindControl
    {
        FormCollection fc = Application.OpenForms;

        Control c = null;
        Control f = null;

        public Control TheForm(string name)
        {
            for (int i = 0; i < fc.Count; i++)
            {
                c = null;
                if (fc[i].Name == name)
                {
                    f = fc[i];
                    break;
                }
            }
            return ((Control)f);
        }
        public Control Ctrl(Control f, string name)
        {
            for (int i = 0; i < f.Controls.Count; i++)
            {
                //look for the control by name
                if (f.Controls[i].Name == name)
                {
                    c = f.Controls[i];
                    break;
                }
                //control may be on a container control on the form, look for it there.
                if (c == null)
                {
                    if (f.Controls[i].Controls.Count > 0)
                        Ctrl(f.Controls[i], name);
                }
                //found the control, get out of here
                if (c != null)
                    break;
            }
            return (c);
        }
    }
}