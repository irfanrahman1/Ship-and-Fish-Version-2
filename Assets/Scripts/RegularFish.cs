using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularFish : Fish
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public override void DestroyFish()
    {

        Debug.Log($"Regular fish destroyed! Points earned: {pointValue}");

        Destroy(gameObject);
    }
}
