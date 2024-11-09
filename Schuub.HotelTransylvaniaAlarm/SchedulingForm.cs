// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

using System;
using System.Windows.Forms;

namespace Schuub.HotelTransylvaniaAlarm
{
  public partial class SchedulingForm : Form
  {
    public SchedulingForm()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using var form = new GifAndWavAlarmingForm();
      form.ShowDialog(this);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      using var form = new WinmmAlarmingForm();
      form.ShowDialog(this);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      using var form = new MediaPlayerAlarmingForm();
      form.ShowDialog(this);
    }
  }
}
