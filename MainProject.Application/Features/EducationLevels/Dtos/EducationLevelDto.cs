namespace MainProject.Application.Features.EducationLevels.Dtos
{
    public record EducationLevelDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
