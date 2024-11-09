// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Schuub.HotelTransylvaniaAlarm
{
  public partial class GifAndWavAlarmingForm : Form
  {
    SoundPlayer soundPlayer1;

    public GifAndWavAlarmingForm()
    {
      InitializeComponent();
    }

    private void AlarmingForm_Load(object sender, EventArgs e)
    {
      var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreamingSkull.gif");
      pictureBox1.Image = Image.FromFile(filePath);

      filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreamingSkull.wav");
      soundPlayer1 = new SoundPlayer(filePath);
      soundPlayer1.PlayLooping();
    }
  }
}
