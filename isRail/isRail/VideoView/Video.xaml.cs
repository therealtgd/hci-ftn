﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace isRail.VideoView
{
	/// <summary>
	/// Interaction logic for Video.xaml
	/// </summary>
	public partial class Video : Window
	{
		public Video(string videoName)
		{
			InitializeComponent();

			videoPlayer.Source = new Uri(videoName, UriKind.Relative);
			videoPlayer.Play();

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			if (videoPlayer.Source != null)
			{
				if (videoPlayer.NaturalDuration.HasTimeSpan)
					Status.Content = String.Format("{0} / {1}", videoPlayer.Position.ToString(@"mm\:ss"), videoPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
			}
			else
				Status.Content = "No file selected...";
		}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			videoPlayer.Play();
		}

		private void btnPause_Click(object sender, RoutedEventArgs e)
		{
			videoPlayer.Pause();
		}

		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			videoPlayer.Stop();
		}
	}
}

