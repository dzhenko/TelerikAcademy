namespace BullsAndCows.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class JoinGameRequestDataModel
    {
        [Required]
        public string Number { get; set; }
    }
}