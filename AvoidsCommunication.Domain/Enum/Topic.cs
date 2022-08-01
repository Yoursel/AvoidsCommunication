using System.ComponentModel.DataAnnotations;


namespace AvoidsCommunication.Domain.Enum
{
    public enum Topic
    {
        [Display(Name = "На улице")]
        Street,
        [Display(Name = "В транспорте")]
        Transport
    }
}
