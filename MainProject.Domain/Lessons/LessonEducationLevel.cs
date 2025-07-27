using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class LessonEducationLevel
{
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;

    public Guid EducationLevelId { get; set; }
    public EducationLevel EducationLevel { get; set; } = null!;
}
