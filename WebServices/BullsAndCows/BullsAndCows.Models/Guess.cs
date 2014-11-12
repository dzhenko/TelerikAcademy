namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Guess
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}
