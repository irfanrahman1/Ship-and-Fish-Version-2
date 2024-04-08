using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Take a reference of component
    private FishCollector fishInScene;
    // Current fish being targeted;
    private GameObject target;
    // Current direction being impulsed towards to
    private Vector2 direction;
    // Get the component of the RigidBody for impulse
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        fishInScene = Camera.main.GetComponent<FishCollector>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnMouseDown is called when the user has pressed the mouse button while over the Collider.
    void OnMouseDown()
    {
        //while (fishInScene.fishList.Count != 0)
        //{
            findNearestFish();
            //yield return new WaitUntil(() => rb.velocity.magnitude < 0.1f);
        //}
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Fish fish = other.gameObject.GetComponent<Fish>();
        //BurningFish bFish = other.gameObject.GetComponent<BurningFish>();
        //ExplodingFish eFish = other.gameObject.GetComponent<ExplodingFish>();
        if (fish != null)
        {
            fish.DestroyFish();
            fishInScene.RemoveFishFromList(fish.gameObject); // Suggested method in FishCollector to encapsulate list removal logic
            Debug.Log("Fish Collected" + fish.gameObject.transform.position);
        }
        
        OnMouseDown();

    }


    void findNearestFish()
    {

        //target = fishInScene.fishList.First();


        //float nearestDistance = Vector3.Distance(transform.position, target.transform.position);
        float nearestDistance = 9999999999;
        rb.velocity = Vector2.zero;

        foreach (GameObject fish in fishInScene.fishList)
        {

            float comparingDistance = Vector3.Distance(transform.position, fish.transform.position);

            if (comparingDistance < nearestDistance)
            {

                nearestDistance = comparingDistance;

                target = fish;
            }
        }

        if(target != null)
        {
            direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);

            //rb.AddForce(direction, ForceMode2D.Impulse);
            rb.AddForce(direction, ForceMode2D.Impulse);
            Debug.Log("Target" + target.transform.position);
            Debug.DrawLine(target.transform.position, transform.position, Color.green, 100f);
        }

    }
}

