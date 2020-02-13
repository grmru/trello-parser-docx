using System;
using System.Collections.Generic;

namespace TIAS.Tools.Trello
{
    public class TrelloData
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string desc { get; set; } = string.Empty;

        public List<TrelloCard> cards { get; set; } = new List<TrelloCard>();
        public List<TrelloList> lists { get; set; } = new List<TrelloList>();
    }

    public class TrelloCard
    {
        public string id { get; set; } = string.Empty;
        public string idList { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string desc { get; set; } = string.Empty;
    }

        public class TrelloList
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string desc { get; set; } = string.Empty;
    }
}