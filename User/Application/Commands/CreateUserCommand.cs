using Common.Application.Command;

namespace User.Application.Commands;

public class CreateUserCommand : ICommandRequest
{
    public bool Validate()
    {
        return true;
    }
}
