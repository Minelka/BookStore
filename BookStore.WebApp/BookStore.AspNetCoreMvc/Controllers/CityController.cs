using Microsoft.AspNetCore.Mvc;
using BookStore.AspNetCoreMvc.Context;
using BookStore.AspNetCoreMvc.Models;
using BookStore.AspNetCoreMvc.Context.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;

namespace BookStore.AspNetCoreMvc.Controllers
{
    public class CityController : Controller
    {
        //private readonly IConfiguration _configuration;
        //public CityController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        private readonly BaseStoreDbContext _dbContext;
        private MapperConfiguration _mapConfig;
        private IMapper _mapper;

        public CityController(BaseStoreDbContext dbContext)
        {
            _dbContext = dbContext;

            _mapConfig = new MapperConfiguration(
                cfg => cfg.CreateMap<CityViewModel, City>()
                          .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Status))
                          .ReverseMap()
               );
            _mapper = new Mapper(_mapConfig);
        }

        public IActionResult Index(string orderType, string orderColumn, string status = "")
        {
            IQueryable<City> citiesQuery = _dbContext.Cities.AsQueryable().Where(c => c.IsDeleted == false);

            #region Order kodu kontrol edilecek
            //if (string.IsNullOrEmpty(orderType) && string.IsNullOrEmpty(orderColumn))
            //{
            //    if(orderType == "Asc")
            //    {
            //        switch (orderColumn)
            //        {
            //            case "Id":
            //                citiesQuery = citiesQuery.OrderBy(m => m.Id);
            //                break;
            //            case "Name":
            //                citiesQuery = citiesQuery.OrderBy(m => m.Name);
            //                break;
            //            case "Status":
            //                citiesQuery = citiesQuery.OrderBy(m => m.IsActive);
            //                break;
            //            default:
            //                citiesQuery = citiesQuery.OrderBy(m => m.Name);
            //                break;

            //        }
            //    }
            //    else if(orderType == "Desc")
            //    {
            //        switch (orderColumn)
            //        {
            //            case "Id":
            //                citiesQuery = citiesQuery.OrderByDescending(m => m.Id);
            //                break;
            //            case "Name":
            //                citiesQuery = citiesQuery.OrderByDescending(m => m.Name);
            //                break;
            //            case "Status":
            //                citiesQuery = citiesQuery.OrderByDescending(m => m.IsActive);
            //                break;
            //            default:
            //                citiesQuery = citiesQuery.OrderByDescending(m => m.Name);
            //                break;

            //        }
            //    }
            //    else
            //    {
            //        switch (orderColumn)
            //        {
            //            case "Id":
            //                citiesQuery = citiesQuery.OrderBy(m => m.Id);
            //                break;
            //            case "Name":
            //                citiesQuery = citiesQuery.OrderBy(m => m.Name);
            //                break;
            //            case "Status":
            //                citiesQuery = citiesQuery.OrderBy(m => m.IsActive);
            //                break;
            //            default:
            //                citiesQuery = citiesQuery.OrderBy(m => m.Name);
            //                break;

            //        }
            //    }    
            //} 
            #endregion

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "aktif")
                {
                    citiesQuery = citiesQuery.Where(c => c.IsActive == true);
                }
                else if (status == "pasif")
                {
                    citiesQuery = citiesQuery.Where(c => c.IsActive == false);
                }
            }

            List<CityViewModel> model = _mapper.Map<List<CityViewModel>>(citiesQuery.ToList());

            return View(model);
        }

        public IActionResult Add()
        {
            CityViewModel model = new CityViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CityViewModel model)
        {
            if (!ModelState.IsValid) 
                return View( model);
            //DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
            //dbContextOptionsBuilder.UseSqlServer("Server=ANK2-YZLMORT-00\\MSSQLSERVERKGK; Database=BookStoreDb; Trusted_Connection=true; Encrypt=no");

            //DbContextOptions dbContextOptions = dbContextOptionsBuilder.Options;

            //BookStoreDbContext bookStoreDbContext = new BookStoreDbContext(dbContextOptions);

            //bookStoreDbContext.Cities.Add(new Context.Entities.Concrete.City() { Name = "Ankara" });
            //bookStoreDbContext.SaveChanges();

            City city = _mapper.Map<City>(model);

            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            City city = _dbContext.Cities.Where(c => c.Id == id).FirstOrDefault();

            CityViewModel model = _mapper.Map<CityViewModel>(city);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CityViewModel model)
        {
            City city = _mapper.Map<City>(model);

            _dbContext.Cities.Update(city);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Remove(int id)
        {
            City city = _dbContext.Cities.Where(c => c.Id == id && c.IsDeleted == false).FirstOrDefault();

            if (city != null)
            {
                city.IsDeleted = true;
                city.Deleted = DateTime.Now;

                _dbContext.Cities.Update(city);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
