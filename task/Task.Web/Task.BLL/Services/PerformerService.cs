using Task.BLL.DTO;
using Task.DAL.Entities;
using Task.DAL.Interfaces;
using Task.BLL.Infrastructure;
using Task.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;



using System;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;



namespace Task.BLL.Services
{
    public class PerformerService : IPerformerService
    {
        IUnitOfWork Database { get; set; }

        public PerformerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<PerformerDTO> GetPerformers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.Initialize(cfg => cfg.CreateMap<Performer, PerformerDTO>());
            return Mapper.Map<IEnumerable<Performer>, List<PerformerDTO>>(Database.Performers.GetAll());
        }

        public PerformerDTO GetPerformer(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id исполнителя", "");
            var performer = Database.Performers.Get(id.Value);
            if (performer == null)
                throw new ValidationException("Исполнитель не найден", "");
            // применяем автомаппер для проекции Performer на PerformerDTO
            Mapper.Initialize(cfg => cfg.CreateMap<Performer, PerformerDTO>());
            return Mapper.Map<Performer, PerformerDTO>(performer);
        }



        public bool getData()
        {
            HtmlDocument HD = new HtmlDocument();
            HtmlDocument HDBiography = new HtmlDocument();
            string url_songs, url_one_song;
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
                //выбирае деревья из класса написанного в textBox и элемента написанного
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

                            name_of_group = hn.InnerText.Trim();

                            Performer performer = new Performer();
                            performer.CountOfSongs = count_songs;
                            performer.Name = name_of_group;
                            performer.Views = count_views;

                            count_for_cicle = 0;
                            HDBiography = web.Load(url_songs + "wiki/");
                            HtmlNode html_node = HDBiography.DocumentNode.SelectSingleNode("//div[@class='artist-profile__bio']");
                            performer.Biography = html_node.InnerHtml;

                            Database.Performers.Create(performer);
                            Database.Save();


                            Thread.Sleep(15000);

                            HD = web.Load(url_songs);
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

                                        Song song = new Song();
                                        song.Name = name;
                                        song.Views = count_views;
                                        song.Text = html_node_text.InnerHtml;
                                        song.Performer = performer;

                                        Database.Songs.Create(song);
                                        Database.Save();

                                        //выбирае деревья из класса написанного в textBox и элемента написанного
                                        HtmlNodeCollection Elements2 = HD.DocumentNode.SelectNodes("//div[@id='song_chords']/img");

                                        if (Elements2 != null)
                                        {
                                            foreach (HtmlNode hn4 in Elements2)
                                            {
                                                Accord accord = new Accord();
                                                accord.Name = (hn4.GetAttributeValue("alt", ""));
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





        public void Dispose()
        {
            Database.Dispose();
        }
    }
}