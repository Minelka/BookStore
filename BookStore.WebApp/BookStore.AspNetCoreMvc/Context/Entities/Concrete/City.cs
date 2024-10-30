using BookStore.AspNetCoreMvc.Context.Entities.Abstract;

namespace BookStore.AspNetCoreMvc.Context.Entities.Concrete
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
    }
}
