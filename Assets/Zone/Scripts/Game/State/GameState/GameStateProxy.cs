/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;

namespace Zone
{
    public class GameStateProxy : IGameStateProxy
    {
        public ReactiveProperty<PlayerStateProxy> PlayerState { get; private set; }

        public GameState OriginState { get; private set; }

        public GameStateProxy(GameState gameState)
        {
            OriginState = gameState;
            
            PlayerState = new ReactiveProperty<PlayerStateProxy>(new PlayerStateProxy(gameState.PlayerState));

            PlayerState.Subscribe(newPlayerState => gameState.PlayerState = newPlayerState.OriginState);
        }
    }
}
