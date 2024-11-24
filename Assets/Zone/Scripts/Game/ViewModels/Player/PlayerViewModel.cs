/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using UnityEngine;
using Zone.Gameplay;

namespace Zone
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public ReactiveProperty<Vector3> Position { get; private set; }

        private readonly IPlayerService m_playerService;
        private readonly PlayerSettings m_playerSettings;

        public PlayerViewModel(PlayerSettings playerSettings, IPlayerStateProxy playerState, IPlayerService playerService)
        {
            Position = playerState.Position;
            m_playerSettings = playerSettings;
            m_playerService = playerService;
        }


        public void Dispose()
        {
            
        }

        public void Move(Vector3 direction)
        {
            m_playerService.MovePlayer(direction, m_playerSettings.Speed);
        }
    }
}
