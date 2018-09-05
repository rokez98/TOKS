using System;
using System.Windows.Forms;

namespace TOKS.UI.Extensions
{
    public static class ComboBoxExtensions
    {
        public static void InitializeWithEnum(this ComboBox comboBox, Type enumType, Func<object, object> transformFunction, int selectedIndex = 0)
        {
            foreach (var name in Enum.GetValues(enumType))
                comboBox.Items.Add(transformFunction(name));

            comboBox.SelectedIndex = selectedIndex;
        }
    }
}
