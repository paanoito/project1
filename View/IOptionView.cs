using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Final_Project.Views
{
    public interface IOptionView
    {
        event EventHandler VolumeChanged;
        event EventHandler BackClicked;

        int GetVolume();
        void CloseView();
    }
}

