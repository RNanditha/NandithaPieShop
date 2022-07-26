
using Microsoft.EntityFrameworkCore;


namespace NandithaPieShop.Models
{


    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        private readonly ICategoryRepository _categoryRepository;

        public IEnumerable<Pie> AllPies// => appDbContext.Pies;
        { get { return appDbContext.Pies.Include(c => c.Category); } }



        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek);


        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(pie => pie.PieId == pieId); ;
        }



        public IEnumerable<Pie> SeasonalPies()
        {
            return AllPies.Where(pie => pie.CategoryId == 1);

        }

        public IEnumerable<Pie> CheesePies()
        {
            return AllPies.Where(pie => pie.CategoryId == 2);

        }

        public IEnumerable<Pie> FruitPies()
        {
            return AllPies.Where(pie => pie.CategoryId == 3);

        }
    }
}

