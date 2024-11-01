namespace uts_frontend_72220561.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category(); // Initialize the Category property
    }

    public class CourseUpdateDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }

}
