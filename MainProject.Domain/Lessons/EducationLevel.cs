using MainProject.Domain.Common;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class EducationLevel : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<LessonEducationLevel> LessonEducationLevels { get; set; } = new List<LessonEducationLevel>();
}
