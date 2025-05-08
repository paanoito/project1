using System;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project.Views
{
    public interface IForm2View
    {
        event EventHandler StartClicked;
        event EventHandler OptionClicked;
        event EventHandler ExitClicked;

        event EventHandler StartHover;
        event EventHandler StartLeave;

        event EventHandler OptionHover;
        event EventHandler OptionLeave;

        event EventHandler ExitHover;
        event EventHandler ExitLeave;

        void SetStartImage(Image image);
        void SetOptionImage(Image image);
        void SetExitImage(Image image);

        void PlayHoverSound(string path);
        void PlayBackgroundMusic(string path);
        void HideMediaPlayer();
        void ShowForm(Form form);
        void ShowDialog(Form form);
        void CloseApp();
    }
}
