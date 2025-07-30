using MainProject.Domain.Postings;
using MainProject.Domain.Users;
using MainProject.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace MainProject.Application.Features.Postings.Commands.EnrollStudent;

public class EnrollStudentToPostingCommandHandler : IRequestHandler<EnrollStudentToPostingCommand, bool>
{
    private readonly IRepository<Posting> _postingRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EnrollStudentToPostingCommandHandler(IRepository<Posting> postingRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
    {
        _postingRepository = postingRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(EnrollStudentToPostingCommand request, CancellationToken cancellationToken)
    {
        var posting = await _postingRepository.GetByIdAsync(request.PostingId);
        if (posting == null)
        {
            return false; // Posting not found
        }

        var student = await _userRepository.GetByIdAsync(request.StudentId);
        if (student == null)
        {
            return false; // Student not found
        }

        try
        {
            posting.EnrollStudent(student);
        }
        catch (InvalidOperationException)
        {
            return false; // Business rule violation (e.g., posting is full)
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
