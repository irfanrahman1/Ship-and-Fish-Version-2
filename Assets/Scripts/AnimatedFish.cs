using UnityEngine;

public abstract class AnimatedFish : Fish
{
    // Reference to the animated fish prefab
    public GameObject PrefabAnimation;


    public override void DestroyFish()
    {

        Debug.Log($"Animated fish destroyed! Points earned: {pointValue}");


        Destroy(gameObject);
    }
}
