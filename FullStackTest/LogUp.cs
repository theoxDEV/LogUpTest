using Microsoft.AspNetCore.Http.HttpResults;

namespace FullStackTest
{
    public class LogUp
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Comments { get; set; }
    }
}
