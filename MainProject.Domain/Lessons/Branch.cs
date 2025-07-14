using MainProject.Domain.Common;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class Branch : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
