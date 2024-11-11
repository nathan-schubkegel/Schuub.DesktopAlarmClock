// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schuub.DesktopAlarmClock
{
  public partial class MediaPlayerAlarmingForm : Form
  {
    public MediaPlayerAlarmingForm()
    {
      InitializeComponent();
    }

    private void MediaPlayerAlarmingForm_Load(object sender, EventArgs e)
    {
      axWindowsMediaPlayer1.URL = @"C:\Users\Bratface\Downloads\Hotel Transylvania alarm clock.mp4";
      axWindowsMediaPlayer1.uiMode = "none";
    }
  }
}
