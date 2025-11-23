using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace card_game.Domain.Entities
{
    public class Card 
    { 

        public int CardId { get; set; }
        public int UserId { get; set; }
        public bool Public { get; set; }
        public Image BaseImage { get; set; }
        public Image CardImage { get; set; }
        public string CardName { get; set; }
        public int Life { get; set; }
        public int Damage { get; set; }
        public int Shield { get; set; }
        public string Type { get; set; }

        public int Move { get; set; }

        public Card() { }

        public Card(int userIdn, string name, Image img, int life, int damage, int shield)
        {
            CardName = name;
            BaseImage = img;
            Life = life;
            Damage = damage;
            Shield = shield;

            Public = true;
            Type = "character";
            UserId = userIdn;
            CardId = 404;
        }

        public Card(int id, string Name, Image img, int life, int damage, int shield, string type)
        {
            CardId = id;
            CardName = Name;
            CardImage = img;
            Life = life;
            Damage = damage;
            Shield = shield;
            Type = type;
        }

        public Card(int id, Image cardImage)
        {
            CardId = id;
            CardImage = cardImage;
        }

        public Card(int life, int damage, int shield)
        {
            Life = life;
            Damage = damage;
            Shield = shield;
            Move = 1;
        }

        public static List<Card> DeckFromJson(string json)
        {
            var doc = JsonDocument.Parse(json);
            var deck = new List<Card>();

            foreach(var cardEl in doc.RootElement.GetProperty("deck").EnumerateArray())
            {
                var card = new Card
                {
                    CardName = cardEl.TryGetProperty("name", out var nameEl) ? nameEl.GetString() : null,
                    UserId = cardEl.TryGetProperty("userId", out var userEl) ? userEl.GetInt32() : 0,
                    Public = cardEl.TryGetProperty("public", out var pubEl) ? pubEl.GetBoolean() : false,
                    Life = cardEl.TryGetProperty("life", out var lifeEl) ? lifeEl.GetInt32() : 0,
                    Damage = cardEl.TryGetProperty("damage", out var dmgEl) ? dmgEl.GetInt32() : 0,
                    Shield = cardEl.TryGetProperty("shield", out var shEl) ? shEl.GetInt32() : 0,
                    Type = cardEl.TryGetProperty("type", out var typeEl) ? typeEl.GetString() : null,
                    CardImage = DecodeImage(cardEl.TryGetProperty("card", out var cardImgEl) ? cardImgEl.GetString() : null),
                    BaseImage = DecodeImage(cardEl.TryGetProperty("image", out var baseImgEl) ? baseImgEl.GetString() : null)
                };
                deck.Add(card);
            }
            return deck;
        }

        private static Image DecodeImage(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return null;
            byte[] bytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

    }
}
