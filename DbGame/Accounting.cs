﻿

namespace DbGame
{
    public class Accounting
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
