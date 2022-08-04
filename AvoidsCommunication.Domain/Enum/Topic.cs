using System.ComponentModel.DataAnnotations;


namespace AvoidsCommunication.Domain.Enum
{
    public enum Topic
    {
        [Display(Name = "На улице")]
        Улица,
        [Display(Name = "В транспорте")]
        Траспорт
    }
}
