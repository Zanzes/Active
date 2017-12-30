using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LZSoft.TestConsumer.View
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();

            var dp = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));

            dp.AddValueChanged(tb, (object a, EventArgs b) =>
            {
                if (a is TextBlock textBlock)
                {
                    textBlock.
                }
            });
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
        }
    }
}
