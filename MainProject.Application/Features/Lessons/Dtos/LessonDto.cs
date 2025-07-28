namespace MainProject.Application.Features.Lessons.Dtos
{
    public record LessonDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Guid BranchId { get; init; }
    }
}
