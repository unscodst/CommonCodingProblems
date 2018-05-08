using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace UndoAction
{
    class UndoButton
    {
        public UndoButton(Button button)
        {
            // Store button changed
            _button = button;

            // Store buttons current brush for the background
            _brush = button.Background.CloneCurrentValue();
        }

        public void Execute()
        {
            // Sets the background color of the button to the brush value
            _button.Background = _brush;
        }

        public override string ToString()
        {
            // Display button number and button color as hex string
            return string.Format("{0}: {1}", _button.Content, _brush.ToString());
        }
        Button _button;
        Brush _brush;
    }
}
