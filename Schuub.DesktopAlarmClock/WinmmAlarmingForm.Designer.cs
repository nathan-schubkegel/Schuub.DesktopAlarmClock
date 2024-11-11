// This is free and unencumbered software released into the public domain under The Unlicense.
// You have complete freedom to do anything you want with the software, for any purpose.
// Please refer to <http://unlicense.org/>

namespace Schuub.DesktopAlarmClock
{
  partial class WinmmAlarmingForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      buttonPlay = new System.Windows.Forms.Button();
      txtFileName = new System.Windows.Forms.TextBox();
      picPlayer = new System.Windows.Forms.PictureBox();
      buttonStop = new System.Windows.Forms.Button();
      buttonPause = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)picPlayer).BeginInit();
      SuspendLayout();
      // 
      // buttonPlay
      // 
      buttonPlay.Location = new System.Drawing.Point(246, 315);
      buttonPlay.Name = "buttonPlay";
      buttonPlay.Size = new System.Drawing.Size(75, 23);
      buttonPlay.TabIndex = 0;
      buttonPlay.Text = "Play";
      buttonPlay.UseVisualStyleBackColor = true;
      buttonPlay.Click += btnPlay_Click;
      // 
      // txtFileName
      // 
      txtFileName.Location = new System.Drawing.Point(107, 366);
      txtFileName.Name = "txtFileName";
      txtFileName.Size = new System.Drawing.Size(596, 23);
      txtFileName.TabIndex = 1;
      txtFileName.Text = "C:\\Users\\Bratface\\Downloads\\Hotel Transylvania alarm clock.mp4";
      // 
      // picPlayer
      // 
      picPlayer.Location = new System.Drawing.Point(12, 12);
      picPlayer.Name = "picPlayer";
      picPlayer.Size = new System.Drawing.Size(776, 297);
      picPlayer.TabIndex = 2;
      picPlayer.TabStop = false;
      // 
      // buttonStop
      // 
      buttonStop.Location = new System.Drawing.Point(457, 315);
      buttonStop.Name = "buttonStop";
      buttonStop.Size = new System.Drawing.Size(75, 23);
      buttonStop.TabIndex = 3;
      buttonStop.Text = "Stop";
      buttonStop.UseVisualStyleBackColor = true;
      buttonStop.Click += btnStop_Click;
      // 
      // buttonPause
      // 
      buttonPause.Location = new System.Drawing.Point(347, 315);
      buttonPause.Name = "buttonPause";
      buttonPause.Size = new System.Drawing.Size(75, 23);
      buttonPause.TabIndex = 4;
      buttonPause.Text = "Pause";
      buttonPause.UseVisualStyleBackColor = true;
      buttonPause.Click += btnPause_Click;
      // 
      // AlarmForm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(800, 450);
      Controls.Add(buttonPause);
      Controls.Add(buttonStop);
      Controls.Add(picPlayer);
      Controls.Add(txtFileName);
      Controls.Add(buttonPlay);
      Name = "AlarmForm";
      Text = "AlarmForm";
      ((System.ComponentModel.ISupportInitialize)picPlayer).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button buttonPlay;
    private System.Windows.Forms.TextBox txtFileName;
    private System.Windows.Forms.PictureBox picPlayer;
    private System.Windows.Forms.Button buttonStop;
    private System.Windows.Forms.Button buttonPause;
  }
}