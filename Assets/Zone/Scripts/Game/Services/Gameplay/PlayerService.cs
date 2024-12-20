/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using SkyForge.Infrastructure.Command;
using UnityEngine;
using Zone.Gameplay;

namespace Zone
{
    public class PlayerService : Service, IPlayerService
    {
        public IReactiveProperty<IPlayerViewModel> PlayerViewModel => m_plyaer;

        private ReactiveProperty<IPlayerViewModel> m_plyaer;

        public PlayerService(PlayerSettings playerSettings, IPlayerStateProxy playerState, ICommandProcessor commandProcessor) : base(commandProcessor)
        {
            m_plyaer = new ReactiveProperty<IPlayerViewModel>(new PlayerViewModel(playerSettings, playerState, this));
        }

        public bool MovePlayer(Vector3 direction, float speed)
        {
            var moveCommand = new CmdMovePlayer(direction, speed);
            var result = m_commandProcessor.Process(moveCommand);
            return result;
        }

        public void Dispose()
        {
            
        }
    }
}
