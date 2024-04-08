using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplodingFish : AnimatedFish
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    public override void DestroyFish()
    {
        Debug.Log($"Exploding fish destroyed! Points earned: {pointValue}");

        anim.enabled = true;
        Destroy(gameObject, 2f);
    }

}
