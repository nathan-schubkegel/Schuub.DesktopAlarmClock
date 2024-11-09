// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Schuub.HotelTransylvaniaAlarm
{
  public partial class WinmmAlarmingForm : Form
  {
    public WinmmAlarmingForm()
    {
      InitializeComponent();
    }


    [DllImport("winmm.dll", CharSet = CharSet.Auto)]
    private static extern Int32 mciSendString(
      String command,
      StringBuilder buffer,
      Int32 bufferSize,
      IntPtr hwndCallback);

    [DllImport("winmm.dll", CharSet = CharSet.Auto)]
    private static extern Int32 mciGetErrorString(Int32 errorCode,
      StringBuilder errorText, Int32 errorTextSize);

    private const string VideoAlias = "myVideo";

    private void btnPlay_Click(object sender, EventArgs e)
    {
      // open the device
      var cmd = string.Format("open \"{0}\" alias {1} wait", txtFileName.Text.Trim(), VideoAlias);
      SendMCIString(cmd, IntPtr.Zero);

      // set the picture box as player window
      cmd = string.Format("window {0} handle {1} wait", VideoAlias, picPlayer.Handle);
      SendMCIString(cmd, IntPtr.Zero);

      // set the destination rect
      cmd = string.Format("put {0} destination at {1} {2} {3} {4} wait",
      new object[] { VideoAlias, 0, 0, picPlayer.Width, picPlayer.Height});
      SendMCIString(cmd, IntPtr.Zero);

      // start playing
      cmd = string.Format("play {0}", VideoAlias);
      SendMCIString(cmd, IntPtr.Zero);
    }

    private void btnPause_Click(object sender, EventArgs e)
    {
      string cmd = string.Format("status {0} mode", VideoAlias);
      // first check the playing status
      if (SendMCIString(cmd, IntPtr.Zero).ToLowerInvariant() == "paused")
      {
        // if already paused, then play
        cmd = string.Format("play {0}", VideoAlias);
      }
      else
      {
        // if already playing, then pause
        cmd = string.Format("pause {0}", VideoAlias);
      }
      SendMCIString(cmd, IntPtr.Zero);
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      // close the device
      string cmd = string.Format("close {0}", VideoAlias);
      SendMCIString(cmd, IntPtr.Zero);
    }

    private string SendMCIString(string mciString, IntPtr hWndCallback)
    {
      StringBuilder buffer = new StringBuilder(512);
      int errCode;

      errCode = mciSendString(mciString, buffer, buffer.Capacity, hWndCallback);

      // If error occurred, get the error text and throw exception
      if (errCode != 0)
      {
        buffer = new StringBuilder(256);
        mciGetErrorString(errCode, buffer, buffer.Capacity);
        throw new ApplicationException(buffer.ToString());
      }

      return buffer.ToString();
    }
  }
}