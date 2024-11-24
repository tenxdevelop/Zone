/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Infrastructure.Command
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        bool Handle(TCommand command);
    }
}
