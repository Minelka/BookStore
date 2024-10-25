namespace BookStore.AspNetCoreMvc.Models
{
    public class AuthourViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateOnly BirthDay { get; set; }

        public string LiveCityName { get; set; }

        public bool Status { get; set; }
    }
}
