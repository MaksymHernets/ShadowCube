using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameDamage : MonoBehaviour
{
    public Image imageBlood;
    public Image imageIce;
    public Image imageBlitness;

    public void Show(float xp)
	{
        imageBlood.color = new Color(imageBlood.color.r, imageBlood.color.g, imageBlood.color.b, 1 - xp * 0.01f);
    }
    
}
