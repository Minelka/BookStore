using System.ComponentModel.DataAnnotations;

namespace BookStore.AspNetCoreMvc.Models
{
    public class CityViewModel : BaseViewModel
    {
        [Display(Name="Şehir ADı")]
        [Required(ErrorMessage ="Bu Alan Zorunludur.")]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
