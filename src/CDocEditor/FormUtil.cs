using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CDocEditor
{
    public static class FormUtil
    {
        public static void ShowException(Form owner, Exception ex)
        {
            MessageBox.Show(owner, ex.GetType().Name, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AutoTabIndex(Form form)
        {
            List<Control> controls = new List<Control>();
            foreach (Control i in form.Controls)
            {
                controls.Add(i);
            }
            AutoTabIndex(controls);
        }

        public static void AutoTabIndex(Control control)
        {
            List<Control> controls = new List<Control>();
            foreach (Control i in control.Controls)
            {
                controls.Add(i);
            }
            AutoTabIndex(controls);
        }

        public static void AutoTabIndex(List<Control> controls)
        {
            controls.Sort(delegate (Control a, Control b) {
                if (a.Location.Y != b.Location.Y)
                {
                    return a.Location.Y.CompareTo(b.Location.Y);
                }
                if (a.Location.X != b.Location.X)
                {
                    return a.Location.X.CompareTo(b.Location.X);
                }
                return 0;
            });

            for (int i = 0; i < controls.Count; i++)
            {
                controls[i].TabIndex = i + 1;
            }

            for (int i = 0; i < controls.Count; i++)
            {
                AutoTabIndex(controls[i]);
            }
        }
    }
}
