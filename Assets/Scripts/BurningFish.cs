using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BurningFish : AnimatedFish
{
    public float BurningSeconds = 5f; 
    private float burnTimer;

    Animator anim;

    // Reference to a burning effect prefab. Set this in the Inspector.
    public GameObject burningEffectPrefab;
    private GameObject currentBurningEffect;

    void Start()
    {
        // Initialize the burnTimer to the specified burning duration
        burnTimer = BurningSeconds;

        // Instantiate the burning effect and parent it to the fish GameObject
        if (burningEffectPrefab != null)
        {
            currentBurningEffect = Instantiate(burningEffectPrefab, transform.position, Quaternion.identity, transform);
        }
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void Update()
    {
        // If the fish is still in the burning state, decrement the timer
        if (burnTimer > 0)
        {
            burnTimer -= Time.deltaTime;
        }
        else
        {
            // Once the burnTimer reaches 0, destroy the fish
            //DestroyFish();
        }
    }

    // Override the DestroyFish method to include burning behavior
    public override void DestroyFish()
    {
        // Destroy the burning effect when the fish is destroyed
        if (currentBurningEffect != null)
        {
            Destroy(currentBurningEffect);
        }

        Debug.Log($"Burning fish destroyed! Points earned: {pointValue}");

        anim.enabled = true;
        // Destroy the fish GameObject itself
        Destroy(gameObject, 2f);
    }

}
