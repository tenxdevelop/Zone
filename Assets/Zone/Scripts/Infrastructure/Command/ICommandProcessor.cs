/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForge.Infrastructure.Command
{
    public interface ICommandProcessor
    {
        void RegisterCommandHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;

        bool Process<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
