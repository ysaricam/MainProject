using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class EducationLevel : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<LessonEducationLevel> LessonEducationLevels { get; set; } = new List<LessonEducationLevel>();
}
