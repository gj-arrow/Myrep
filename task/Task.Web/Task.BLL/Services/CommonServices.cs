using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Interfaces;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;


namespace Task.BLL.Services
{
    public class CommonServices : ICommon
    {
        IUnitOfWork Database { get; set; }

        public CommonServices(IUnitOfWork uow)
        {
            Database = uow;
        }

        public bool ParsingData()
        {
            HtmlDocument HD = new HtmlDocument();
            string url_songs, url_one_song, urlName, urlNameVideo = "";
            string url, count_views, count_songs, name_of_group;
            int count_for_cicle = 0;
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8,
            };
            for (int i = 0; i < 3; i++)
            {
                url = "https://amdm.ru/chords/page" + (i + 1) + "/";
                HD = web.Load(url);
                HtmlNodeCollection NoAltElements = HD.DocumentNode.SelectNodes("//td[@class='artist_name']/a");
                if (NoAltElements != null)
                {
                    foreach (HtmlNode hn in NoAltElements)
                    {
                        if (hn.OuterHtml.Contains("//amdm.ru/akkordi"))
                        {
                            url_songs = "https:" + hn.GetAttributeValue("href", "href");
                            HtmlNode node_count_song = hn.ParentNode.NextSibling;
                            count_songs = node_count_song.InnerText.Trim();

                            HtmlNode node_count_views = node_count_song.NextSibling;
                            count_views = node_count_views.InnerText.Trim();

                            var a = url_songs.Split('/');
                            urlName = a[a.Length - 2];
                            name_of_group = hn.InnerText.Trim();

                            Performer performer = new Performer();
                            count_for_cicle = 0;
                            HD = web.Load(url_songs + "wiki/");
                            HtmlNode html_node = HD.DocumentNode.SelectSingleNode("//div[@class='artist-profile__bio']");
                            if (html_node.FirstChild != null)
                            {
                                html_node.RemoveChild(html_node.FirstChild);
                            }
                            performer.Biography = html_node.InnerHtml;
                            Thread.Sleep(15000);

                            HD = web.Load(url_songs);
                            HtmlNode ShortBio = HD.DocumentNode.SelectSingleNode("//div[@class='artist-profile__bio']");
                            if (ShortBio.FirstChild != null)
                            {
                                ShortBio.RemoveChild(ShortBio.FirstChild);
                                ShortBio.RemoveChild(ShortBio.LastChild);
                            }
                            HtmlNode UrlImage = HD.DocumentNode.SelectSingleNode("//div[@class='artist-profile__photo debug1']");
                            performer.CountOfSongs = count_songs;
                            performer.Name = name_of_group;
                            performer.Views = count_views;
                            performer.ShortBiography = ShortBio.InnerHtml;
                            performer.UrlImage = UrlImage.FirstChild.GetAttributeValue("src", "");
                            performer.UrlName = urlName;

                            Database.Performers.Create(performer);
                            Database.Save();
                            //выбирае деревья из класса написанного в textBox и элемента написанного
                            HtmlNodeCollection Elements = HD.DocumentNode.SelectNodes("//td/a");
                            if (Elements != null)
                            {
                                foreach (HtmlNode hn3 in Elements)
                                {
                                    if (count_for_cicle == 5) break;
                                    if (hn3.OuterHtml.Contains("//amdm.ru/akkordi"))
                                    {
                                        url_one_song = "https:" + hn3.GetAttributeValue("href", "href");
                                        node_count_views = hn3.ParentNode.NextSibling.NextSibling;
                                        count_views = node_count_views.InnerText.Trim();
                                        string name = hn3.InnerText.Trim();
                                        count_for_cicle++;

                                        HD = web.Load(url_one_song);
                                        HtmlNode html_node_text = HD.DocumentNode.SelectSingleNode("//div[@class='b-podbor__text']/pre");
                                        HtmlNode html_node_video = HD.DocumentNode.SelectSingleNode("//div[@class='b-video']");
                                        if (html_node_video != null)
                                            urlNameVideo = html_node_video.FirstChild.NextSibling.FirstChild.GetAttributeValue("src", "");
                                        else urlNameVideo = "";

                                        Song song = new Song();
                                        song.Name = name;
                                        song.Views = count_views;
                                        song.Text = html_node_text.InnerHtml;
                                        song.Performer = performer;
                                        song.UrlVideo = urlNameVideo;

                                        Database.Songs.Create(song);
                                        Database.Save();

                                        //выбирае деревья из класса написанного в textBox и элемента написанного
                                        HtmlNodeCollection Elements2 = HD.DocumentNode.SelectNodes("//div[@id='song_chords']/img");
                                        if (Elements2 != null)
                                        {
                                            foreach (HtmlNode hn4 in Elements2)
                                            {
                                                Accord accord = new Accord();
                                                accord.Name = (hn4.GetAttributeValue("alt", "")).TrimStart();
                                                accord.UrlImage = hn4.GetAttributeValue("src", "");
                                                accord.Song = song;

                                                Database.Accords.Create(accord);
                                                Database.Save();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
                Thread.Sleep(60000);
            }
            return true;
        }
    }
}