using MainProject.Domain.Common;
using MainProject.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MainProject.Domain.Lessons;

public class Lesson : BaseEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign key for the Branch
    public Guid BranchId { get; set; }
    public Branch Branch { get; set; } = null!;

    // Collection of education levels for this lesson
    private readonly List<LessonEducationLevel> _lessonEducationLevels = new();
    public IReadOnlyCollection<LessonEducationLevel> LessonEducationLevels => _lessonEducationLevels.AsReadOnly();

    public void AddEducationLevel(EducationLevel educationLevel)
    {
        if (educationLevel is null)
        {
            throw new ArgumentNullException(nameof(educationLevel));
        }

        if (_lessonEducationLevels.Any(lel => lel.EducationLevelId == educationLevel.Id))
        {
            // Already added, do nothing.
            return;
        }

        _lessonEducationLevels.Add(new LessonEducationLevel { LessonId = this.Id, EducationLevelId = educationLevel.Id });
    }

    public void RemoveEducationLevel(Guid educationLevelId)
    {
        var levelToRemove = _lessonEducationLevels.FirstOrDefault(lel => lel.EducationLevelId == educationLevelId);
        if (levelToRemove != null)
        {
            _lessonEducationLevels.Remove(levelToRemove);
        }
    }
}
