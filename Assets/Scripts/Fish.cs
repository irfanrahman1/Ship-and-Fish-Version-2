using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    // Public field for point value
    public int pointValue;

    // Abstract method to destroy the fish
    public abstract void DestroyFish();
}
