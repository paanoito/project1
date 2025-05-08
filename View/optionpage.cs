using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using Final_Project.Views;

namespace Final_Project
{
    public partial class optionpage : Form, IOptionView
    {
        public event EventHandler VolumeChanged;
        public event EventHandler BackClicked;

        public optionpage()
        {
            InitializeComponent();

            trackBarVolume.ValueChanged += (s, e) => VolumeChanged?.Invoke(s, e);
            btnBack.Click += (s, e) => BackClicked?.Invoke(s, e);
        }

        public int GetVolume()
        {
            return trackBarVolume.Value;
        }

        public void CloseView()
        {
            this.Close();

        }
    }
}
