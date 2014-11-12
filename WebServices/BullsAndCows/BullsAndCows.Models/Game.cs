namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        private ICollection<Guess> guesses;
        private ICollection<Notification> notifications;

        public Game()
        {
            this.guesses = new HashSet<Guess>();
            this.notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public DateTime DateCreated { get; set; }

        // Red Player
        [Required]
        public string FirstPlayerId { get; set; }

        public virtual User FirstPlayer { get; set; }


        // Blue Player
        public string SecondPlayerId { get; set; }

        public virtual User SecondPlayer { get; set; }

        [Required]
        public string FirstPlayerNumber { get; set; }

        public string SecondPlayerNumber { get; set; }

        public GameState GameState { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
    }
}
