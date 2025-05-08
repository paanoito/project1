using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Views;

namespace Final_Project.Presenters
{
    public class OptionPresenter
    {
        private readonly IOptionView _view;

        public OptionPresenter(IOptionView view)
        {
            _view = view;

            _view.VolumeChanged += OnVolumeChanged;
            _view.BackClicked += OnBackClicked;
        }

        private void OnVolumeChanged(object sender, EventArgs e)
        {
            int newVolume = _view.GetVolume();
            Console.WriteLine($"Volume changed to {newVolume}");
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            _view.CloseView();
        }
    }
}

