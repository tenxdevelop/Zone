/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Infrastructure.Command;
using UnityEngine;

namespace Zone
{
    public class CmdMovePlayer : ICommand
    {
        public Vector3 Direction { get; private set; }

        public CmdMovePlayer(Vector3 direction, float speed)
        {
            Direction = direction * speed;
        }
    }
}
