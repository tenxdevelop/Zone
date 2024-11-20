/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Reactive;
using UnityEngine;

namespace Zone
{
    public class PlayerViewModel : IPlayerViewModel
    {
        public ReactiveProperty<Vector3> Position { get; private set; }

        private readonly IPlayerService m_playerService;
        public PlayerViewModel(IPlayerStateProxy playerState, IPlayerService playerService)
        {
            Position = playerState.Position;
            m_playerService = playerService;
        }


        public void Dispose()
        {
            
        }

        public void Move(Vector3 direction)
        {
            m_playerService.MovePlayer(direction, 30f);
        }
    }
}
