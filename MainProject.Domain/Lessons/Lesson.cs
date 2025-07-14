using MainProject.Domain.Common;
using System.Collections.Generic;

namespace MainProject.Domain.Lessons;

public class Lesson : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Foreign key for the Branch
    public Guid BranchId { get; set; }
    public Branch Branch { get; set; }

    // Collection of education levels for this lesson
    public ICollection<LessonEducationLevel> LessonEducationLevels { get; set; } = new List<LessonEducationLevel>();
}
