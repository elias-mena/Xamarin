using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.Reflection;
using System.IO;

namespace AudioPlayer
{
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer player;
        public MainPage()
        {
            InitializeComponent();
            var stream = GetStreamFromFile("music1.mp3");
            player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

            player.Load(stream);
            InitControl();
        }
        private void InitControl()
        {
            btnPlay.Clicked += BtnPlay_Clicked;
            btnStop.Clicked += BtnStop_Clicked;
            btnPause.Clicked += BtnPause_Clicked;
        }

        private void BtnPause_Clicked(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void BtnStop_Clicked(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            player.Play();
        }
        Stream GetStreamFromFile(string Filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("AudioPlayer." + Filename);
            return stream;
        }
    }
}
