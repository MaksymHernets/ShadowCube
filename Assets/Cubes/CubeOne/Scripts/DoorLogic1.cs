﻿using ShadowCube.Cubes;
using UnityEngine;

namespace ShadowCubeCubes.CubeOne
{
    public class DoorLogic1 : DoorLogic
    {
        [SerializeField] private Animator animator;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
                _doorStage = DoorStage.open;

            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open)
            {
                _doorStage = DoorStage.closing;
                animator.SetBool("Open", false);
                animator.SetBool("Close", true);
                _doorStage = DoorStage.closed;
            }
        }
    }
}
