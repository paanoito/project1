using System;
using Final_Project.Views;

namespace Final_Project.Presenters
{
    public class MenuPresenter
    {
        private readonly IForm2View _view;

        public MenuPresenter(IForm2View view)
        {
            _view = view;

            // Event wiring
            _view.StartClicked += OnStartClicked;
            _view.OptionClicked += OnOptionClicked;
            _view.ExitClicked += OnExitClicked;

            _view.StartHover += (s, e) => _view.SetStartImage(Properties.Resources.start_hover);
            _view.StartLeave += (s, e) => _view.SetStartImage(Properties.Resources.start_normal);

            _view.OptionHover += (s, e) =>
            {
                _view.SetOptionImage(Properties.Resources.option_hover);
                _view.PlayHoverSound(@"D:\BRICK BREAKER\BRICK BREAKER\Resources\background sound.wav");
            };
            _view.OptionLeave += (s, e) => _view.SetOptionImage(Properties.Resources.option_normal);

            _view.ExitHover += (s, e) =>
            {
                _view.SetExitImage(Properties.Resources.exit_hover);
                _view.PlayHoverSound(@"D:\BRICK BREAKER\BRICK BREAKER\Resources\background sound.wav");
            };
            _view.ExitLeave += (s, e) => _view.SetExitImage(Properties.Resources.exit_normal);
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            _view.ShowForm(new Form1());
        }

        private void OnOptionClicked(object sender, EventArgs e)
        {
            _view.ShowDialog(new optionpage());
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            _view.CloseApp();
        }
    }
}
