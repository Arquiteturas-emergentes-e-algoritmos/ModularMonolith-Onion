using Common.Application.Command;

namespace Common.Application.Service;
public interface IService<in T> where T : ICommandRequest
{
    ICommandResponse Handle(T command);
}

public interface IServiceAsync<T>
{
    Task<ICommandResponse> Handle(T command);
}