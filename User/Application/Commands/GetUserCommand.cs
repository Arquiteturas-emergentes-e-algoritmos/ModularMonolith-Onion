using Common.Application.Command;

namespace User.Application.Commands;

public class GetUserCommand : ICommandRequest
{
    public Guid UserId { get; set; } = Guid.Empty;

    public bool Validate()
    {
        if (UserId == Guid.Empty) return false;
        return true;
    }
}
