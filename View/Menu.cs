using Final_Project.View;
using Final_Project.Views;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WMPLib;


namespace Final_Project
{
    public partial class Form2 : Form, IForm2View
    {
        public static WindowsMediaPlayer wplayer = new WindowsMediaPlayer();

        public event EventHandler StartClicked;
        public event EventHandler OptionClicked;
        public event EventHandler ExitClicked;

        public event EventHandler StartHover;
        public event EventHandler StartLeave;

        public event EventHandler OptionHover;
        public event EventHandler OptionLeave;

        public event EventHandler ExitHover;
        public event EventHandler ExitLeave;

        public Form2()
        {
            InitializeComponent();

            PlayBackgroundMusic(@"D:\BRICK BREAKER\BRICK BREAKER\Resources\hhhhhhhhhhhhhhhh.wav");
            HideMediaPlayer();

            btn_start.Click += (s, e) => StartClicked?.Invoke(s, e);
            btn_option.Click += (s, e) => OptionClicked?.Invoke(s, e);
            btn_exit.Click += (s, e) => ExitClicked?.Invoke(s, e);

            btn_start.MouseHover += (s, e) => StartHover?.Invoke(s, e);
            btn_start.MouseLeave += (s, e) => StartLeave?.Invoke(s, e);

            btn_option.MouseHover += (s, e) => OptionHover?.Invoke(s, e);
            btn_option.MouseLeave += (s, e) => OptionLeave?.Invoke(s, e);

            btn_exit.MouseHover += (s, e) => ExitHover?.Invoke(s, e);
            btn_exit.MouseLeave += (s, e) => ExitLeave?.Invoke(s, e);
        }

        public void SetStartImage(Image image)
        {
            btn_start.Image = image;
        }

        public void SetOptionImage(Image image)
        {
            btn_option.Image = image;
        }

        public void SetExitImage(Image image)
        {
            btn_exit.Image = image;
        }

        public void PlayHoverSound(string path)
        {
            SoundPlayer sound = new SoundPlayer(path);
            sound.Play();
        }

        public void PlayBackgroundMusic(string path)
        {
            wplayer.URL = path;
            wplayer.controls.play();
        }

        public void HideMediaPlayer()
        {
            axWindowsMediaPlayer1.Hide();
        }

        public void ShowForm(Form form)
        {
            form.Show();
        }

        public void ShowDialog(Form form)
        {
            form.ShowDialog();
        }

        public void CloseApp()
        {
            Application.Exit();
        }
    }
}
