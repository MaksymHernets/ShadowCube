using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube
{
    public class StageMachine
    {
        public BaseStage CurrentStage;

        public StageMachine(BaseStage baseStage)
        {
            SetStage(baseStage);
        }

        public void SetStage(BaseStage baseStage)
        {
            //baseStage.EventFinished += Handler_EventFinished
            CurrentStage = baseStage;
        }

        public void Handler_EventFinished()
        {
            //
        }
    }
}
