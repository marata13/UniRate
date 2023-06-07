namespace UniRate.Models
{
    public class UniResultsModel
    {
        public University University { get; set; }

        public IEnumerable<IGrouping<string, Department>> DepartmentsBySchool { get; set; }

        public UniReviewsAggregate? ReviewsAggregate { get; set; }

        public UniResultsModel(University _university, IEnumerable<IGrouping<string, Department>> _DepartmentsBySchool,
                               UniReviewsAggregate _ReviewsAggregate)
        {
            University = _university;
            DepartmentsBySchool = _DepartmentsBySchool;
            ReviewsAggregate = _ReviewsAggregate;
        }
    }
}
