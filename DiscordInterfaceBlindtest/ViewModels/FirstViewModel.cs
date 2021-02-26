using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using static Google.Apis.YouTube.v3.ChannelSectionsResource;

namespace DiscordInterfaceBlindtest.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public YouTubeService YouTubeService { get; set; }
        public DelegateCommand<string> SearchVideosCommand { get; set; }
        public ObservableCollection<string> ListVideo { get; set; }
        public Visibility VisibilityAddButton { get; set; } = Visibility.Hidden;
        public string TextAddButton { get; set; }
        public FirstViewModel()
        {
            dynamic data = JsonConvert.DeserializeObject(File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Config.json"), typeof(object));
            YouTubeService = new YouTubeService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                ApplicationName = data.APPName,
                ApiKey = data.APIKey
            });
            SearchVideosCommand = new DelegateCommand<string>(SearchVideos);
            ListVideo = new ObservableCollection<string>();
        }
        public void SearchVideos(string urlVideo)
        {
            //https://www.youtube.com/playlist?list=PLXZpZdvKAqine94N7vrQN7EkvDolfhHBC
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(urlVideo);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (!response.ResponseUri.ToString().Contains("youtube.com"))
                    {
                        MessageBox.Show("This url is not a youtube url");
                        return;
                    }
                }
            }
            catch (UriFormatException)
            {
                MessageBox.Show("This is not an URL");
                return;
            }
            PlaylistItemListResponse Response = null;
            if (Regex.IsMatch(urlVideo, @"^.*(youtu\.be\/|v\/|u\/\w\/|embed\/|watch\?v=|\&v=)([^#\&\?]*).*"))
            {
                var Request = YouTubeService.Videos.List("snippet");
            }
            else if (Regex.IsMatch(urlVideo, @"^.*(youtu\.be\/|v\/|u\/\w\/|embed\/|playlist\?list=|\&v=)([^#\&\?]*).*"))
            {
                var Request = YouTubeService.PlaylistItems.List("snippet");
                var test = Regex.Match(urlVideo, @"^.*(youtu\.be\/|v\/|u\/\w\/|embed\/|playlist\?list=|\&v=)([^#\&\?]*).*").Groups.Cast<Group>().Select(x => x.Value);
                Request.PlaylistId = test.ElementAt(2);
                Request.MaxResults = 50;
                Response = Request.Execute();
            }

            foreach (var item in Response.Items)
            {
                ListVideo.Add("https://www.youtube.com/watch?v=" + item.Snippet.ResourceId.VideoId);
            }
            VisibilityAddButton = Visibility.Visible;
            
            if (ListVideo.Count > 1)
                TextAddButton = "Add these Videos to your Blindtest";
        }
    }
}
