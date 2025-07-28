namespace MainProject.Application.Features.Roles.Dtos
{
    public record RoleDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
