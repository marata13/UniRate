namespace UniRate.Models
{
    public class DepResultsModel
    {
        public Department Department { get; set; }

        public IEnumerable<IGrouping<string, Subject>> SubjectsBySemester { get; set; }

        public DepReviewsAggregate? ReviewsAggregate { get; set; }

        public DepResultsModel(Department _department, DepReviewsAggregate _ReviewsAggregate, IEnumerable<IGrouping<string, Subject>> subjectsBySemester)
        {
            Department = _department;
            ReviewsAggregate = _ReviewsAggregate;
            SubjectsBySemester = subjectsBySemester;
        }
    }
}
