using CardCollection.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CardCollection.Repos
{
    public class TCGCardRepo : ITCGCardRepo
    {
        
        string _connectionString = "Server=localhost;Database=TradingCardManager;Trusted_Connection=true;";

        string _cardConnection = "https://api.pokemontcg.io/v2/cards";

        string _setsConnection = "https://api.pokemontcg.io/v2/sets";

        private DataSet ExecuteQuery(string query)
        {
            DataSet set = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(set);
            }
            return set;
        }

        public string AddAll()
        {
            ExecuteQuery("DELETE FROM Cards");
            using (WebClient wc = new WebClient())
            {
                for (int i = 1; i < 56; i++)
                {
                    string json = "";
                    if (i == 1)
                    {
                        json = wc.DownloadString(_cardConnection);
                    }
                    else
                    {
                        if (i % 20 == 0)
                        {
                            Thread.Sleep(60000);
                        }

                        json = wc.DownloadString(_cardConnection + "?page=" + i);
                    }

                    JObject data = JObject.Parse(json);


                    foreach (var x in data.First)
                    {
                        foreach (var card in x)
                        {
                            Card toAdd = new Card();
                            toAdd.Name = card["name"].ToString();
                            toAdd.Id = card["id"].ToString();
                            toAdd.NumberInSet = card["number"].ToString();
                            toAdd.Rarity = (card["rarity"] != null) ? card["rarity"].ToString() : null;
                            toAdd.ReleaseYear = ((DateTime)card["set"]["releaseDate"]).Year;
                            toAdd.SetId = card["set"]["id"].ToString();
                            toAdd.Illustrator = (card["artist"] != null) ? card["artist"].ToString() : null;

                            //TODO: GET ALL TYPES
                            toAdd.Type = (card["types"] != null) ? card["types"][0].ToString() : null;

                            toAdd.Image = card["images"]["small"].ToString();
                            toAdd.supertype = card["supertype"].ToString();
                            
                            toAdd.price = decimal.Parse("0.38");
                            //toAdd.price = decimal.Parse(card["tcgplayer"]["prices"]["common"]["market"].ToString());
                            //toAdd.price = decimal.Parse(string.Format("{0:0.##}", new Random().NextDouble() * 10));


                            if (card["hp"] == null)
                            {
                                toAdd.hp = 0;
                            }
                            else
                            {
                                toAdd.hp = int.Parse(card["hp"].ToString());
                            }
                            
                           

                            if (toAdd.Name.Contains("'"))
                            {
                                toAdd.Name = toAdd.Name.Insert(toAdd.Name.IndexOf("'"), "'");
                            }

                            DataSet set = ExecuteQuery("INSERT INTO Cards " +
                                "(Id, Name, Type, SetId, Rarity, NumberInSet, Illustrator, Image, ReleaseYear, hp, supertype, price) " +
                                $"VALUES('{toAdd.Id}', '{toAdd.Name}', '{toAdd.Type}', " +
                                $"'{toAdd.SetId}', '{toAdd.Rarity}', '{toAdd.NumberInSet}', '{toAdd.Illustrator}', " +
                                $"'{toAdd.Image}', {toAdd.ReleaseYear}, {toAdd.hp}, '{toAdd.supertype}', {toAdd.price} )");
                        }
                    }

                }

            }

            return "Cards added successfully.";
        }

        public void AddAllSets()
        {
            ExecuteQuery("DELETE FROM Sets");
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(_setsConnection);
                JObject data = JObject.Parse(json);

                foreach (var x in data.First)
                {
                    foreach (var set in x)
                    {
                        Sets toAdd = new Sets();
                        toAdd.Id = set["id"].ToString();
                        toAdd.Series = set["series"].ToString();
                        toAdd.Name = set["name"].ToString();
                        toAdd.Image = set["images"]["logo"].ToString();

                        if (toAdd.Name.Contains("'"))
                        {
                            toAdd.Name = toAdd.Name.Insert(toAdd.Name.IndexOf("'"), "'");
                        }

                        DataSet ds = ExecuteQuery("INSERT INTO Sets" +
                            "(Id, Series, Name, Image) " +
                            $"VALUES ('{toAdd.Id}','{toAdd.Series}','{toAdd.Name}','{toAdd.Image}')");
                    }
                        
                }
            }
                

        }
    }
}