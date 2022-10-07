using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace ManagerProjectDotNet.base_app.linear
{

    public abstract class LinearLayout : Panel
    {
        public static string MATCH_PARENT = "match_parent";
        public static string WRAP_CONTENT = "wrap_parent";
        public static Orientation HORIZONTAL = Orientation.Horizontal;
        public static Orientation VERTICAL = Orientation.Vertical;    
        public string width = WRAP_CONTENT;
        public string height = WRAP_CONTENT;
        private int widthLayout = 0;
        private int heightLayout = 0;
        public int x = 0;
        public int y = 0;
        public Control parent;
        public Orientation orientation = VERTICAL;
        public DockStyle dockStyle = DockStyle.Fill;
        public List<Control> list = new List<Control>();

        protected LinearLayout(String width, String height, Control parent)
        {
            this.width = width;
            this.height = height;
            this.parent = parent;
            this.Dock = dockStyle;
            this.SetBounds(x, y, widthLayout, heightLayout);
            
            
        }


        private void setSize()
        {
            int w = 0, h = 0;
            int MAX_WIDTH = Screen.PrimaryScreen.Bounds.Width;
            int MAX_HEIGHT = Screen.PrimaryScreen.Bounds.Height;
            if (this.width == MATCH_PARENT)
            {
                if (this.parent == null)
                {
                    w = MAX_WIDTH;
                }
                else
                {
                    w = this.parent.Width;
                }
            }
            if (this.height == MATCH_PARENT)
            {
                if (this.parent == null)
                {
                    h = MAX_HEIGHT;
                }
                else
                    h = this.parent.Height;
            }

            if (orientation == VERTICAL)
            {
                
                if (this.width == WRAP_CONTENT)
                {
                    foreach (Control control in list)
                    {
                        w += control.Width;
                    }
                    if (w >= this.parent.Width)
                    {
                        w = this.parent.Width;
                    }
                }
                if (this.height == WRAP_CONTENT)
                {
                    int maxH = list[0].Height;
                    list.ForEach(control =>
                    {
                        if (control.Height > maxH)
                        {
                            maxH = control.Height;
                        }
                    });
                    h = maxH;
                    if (h >= this.parent.Height)
                    {
                        h = this.parent.Height;
                    }
                }
            }
            if (orientation == HORIZONTAL)
            {
                if (this.width == WRAP_CONTENT)
                {
                    int maxW = list[0].Width;
                    list.ForEach(control =>
                    {
                        if (control.Width > maxW)
                        {
                            maxW = control.Width;
                        }
                    });
                    w = maxW;
                    if (w >= this.parent.Width)
                    {
                        w = this.parent.Width;
                    }
                }
                if (this.height == WRAP_CONTENT)
                {
                    foreach (Control control in list)
                    {
                        h += control.Height;
                    }
                    if (h >= this.parent.Height)
                    {
                        h = this.parent.Height;
                    }
                }

            }
            this.widthLayout = w;
            this.heightLayout = h;
            this.Width = (int)widthLayout;
            this.Height = (int)heightLayout;
        }
        private void setView()
        {
            if (this.orientation == VERTICAL)
            {
                int currentY = 0;
                foreach (Control item in list)
                {
                    item.SetBounds(this.Location.X, currentY, item.Width, item.Height);
                    currentY += item.Height;
                }
            }
            if (this.orientation == HORIZONTAL)
            {
                int currentX = 0;
                foreach (Control item in list)
                {
                    item.SetBounds(currentX, this.Location.Y, item.Width, item.Height);
                    currentX += item.Width;
                }
            }
        }
        public void addView(Control obj)
        {
            list.Add(obj);
        }

        public void notifiDataChanged()
        {
            this.Controls.Clear();
            foreach (Control item in list)
            {
                this.Controls.Add(item);
            }
            setSize();
            setView();
        }

        public void addView(int index, Control obj)
        {
            while (true)
            {
                if (index > list.Count)
                {
                    for (int i = 0; i < index - 1 - list.Count; i++)
                    {
                        Control control = new Control();
                        list.Add(control);
                    }
                    list.Add((Control)obj);
                    break;
                }
                else if (index == list.Count)
                {
                    list.Add((Control)obj);
                    break;
                }
                else
                {
                    list.Add(new Control());
                    for (int i = index; i < list.Count - 1; i++)
                    {
                        list[i + 1] = list[i];
                    }
                    list[index] = obj;
                    break;
                }
            }
        }
        public bool removeView(Control obj)
        {
            return list.Remove(obj);
        }
        public bool removeView(int index)
        {
            return list.Remove(list[index]);
        }
        public Control updateView(int index, Control obj)
        {
            if (obj == null)
                return null;
            list[index] = obj;

            return list[index];
        }
        public Control updateView(Control currentObj, Control newObj)
        {
            int obj = list.IndexOf(currentObj);
            if (!(obj < list.Count && obj > -1))
            {
                return updateView(list.IndexOf(currentObj), newObj);
            }
            return currentObj;

        }
        public void setViewSize(String w, String h)
        {
            this.width = w;
            this.height = h;
        }
    }
}
