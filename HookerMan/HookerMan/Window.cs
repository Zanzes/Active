using System;
using System.Windows.Forms;

namespace HookerMan
{
    public partial class Window : Form
    {
        Hooker h = new Hooker();

        public Window()
        {
            InitializeComponent();
            h.Ds(x => {WriteLine(x.scanCode.ToString());});
        }

        void WriteLine(string text)
        {
            textBox1.AppendText(text+Environment.NewLine);
        }
    }
}
