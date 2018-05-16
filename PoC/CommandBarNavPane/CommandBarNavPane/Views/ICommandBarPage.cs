using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CommandBarNavPane.Views
{
    public interface ICommandBarPage
    {
        IEnumerable<ICommandBarElement> PrimaryCommands { get; }

        IEnumerable<ICommandBarElement> SecondaryCommands { get; }
    }
}
