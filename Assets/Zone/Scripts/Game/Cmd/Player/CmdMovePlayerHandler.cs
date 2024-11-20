/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Command;
using SkyForge.Infrastructure.Reactive;
using UnityEngine;

namespace Zone
{
    public class CmdMovePlayerHandler : ICommandHandler<CmdMovePlayer>
    {
        private IGameStateProxy m_gameState;

        public CmdMovePlayerHandler(IGameStateProxy gameState) 
        {
            m_gameState = gameState;
        }

        public bool Handle(CmdMovePlayer command)
        {
            m_gameState.PlayerState.Value.Position.UpdateValue(command.Direction * Time.deltaTime);
            return true;
        }
    }
}
