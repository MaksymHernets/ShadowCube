using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.DTO
{
    public class Damage
    {
        public TypeDamage type { get; set; }
        public int value { get; set; }
    }

    public enum TypeDamage
    {
        needles,
        fire,
        venom,
        cool,
        fool
    }
}

