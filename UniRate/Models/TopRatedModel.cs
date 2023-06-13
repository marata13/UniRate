namespace UniRate.Models
{
    public class TopRatedModel
    {
        public IEnumerable<TopRatedUni> Universities { get; set; }

        public IEnumerable<TopRatedDep> Departments { get; set; }
    }
}
