namespace NandithaPieShop.Models
{

    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
        IEnumerable<Pie> SeasonalPies();
        IEnumerable<Pie> CheesePies();
        IEnumerable<Pie> FruitPies();

    }

}
