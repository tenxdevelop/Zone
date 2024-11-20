/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Command;
using SkyForge;

namespace Zone
{
    public static class GameplayServiceRegistration
    {
        public static void RegisterService(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameState = container.Resolve<IGameStateProvider>().ProxyState;
            var commandProcessor = new CommandProcessor();

            commandProcessor.RegisterCommandHandler(new CmdMovePlayerHandler(gameState));

            container.RegisterInstance<ICommandProcessor>(commandProcessor);

            container.RegisterSingleton<IPlayerService>(factory => new PlayerService(gameState.PlayerState.Value, commandProcessor));
        }
    }
}
