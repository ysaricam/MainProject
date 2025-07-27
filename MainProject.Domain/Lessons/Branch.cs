using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class Branch : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
