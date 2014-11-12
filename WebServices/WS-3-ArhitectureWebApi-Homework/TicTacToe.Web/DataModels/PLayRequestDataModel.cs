using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicTacToe.Web.DataModels
{
    public class PlayRequestDataModel
    {
        [Required]
        public string GameId { get; set; }

        [Range(1, 3)]
        public int Row { get; set; }

        [Range(1, 3)]
        public int Col { get; set; }
    }
}