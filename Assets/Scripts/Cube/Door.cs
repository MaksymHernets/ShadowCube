using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes
{
    public class Door
    {

    }

    public interface IDoor
    {
        void Open();
        void Close();
    }

    public enum DoorStage
    {
        closed = 0,
        opening = 1,
        open = 2,
        closing = 3,
    }
}
