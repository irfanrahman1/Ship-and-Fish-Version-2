using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollector : MonoBehaviour
{

    [SerializeReference] GameObject fishPrefab;
    public List<GameObject> fishList = new List<GameObject>();

    [SerializeReference] GameObject explodingFishPrefab;
    [SerializeReference] GameObject burningFishPrefab;
    [SerializeReference] GameObject regularFishPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Check for any mouse button click (left, right, or middle)
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            // Call the modified SpawnFish method that randomly selects a fish type
            SpawnRandomFish();
        }
    }

    void SpawnRandomFish()
    {
        // Create an array of fish prefabs to choose from
        GameObject[] fishPrefabs = { regularFishPrefab, explodingFishPrefab, burningFishPrefab };

        // Randomly select an index for the fishPrefabs array
        int randomIndex = Random.Range(0, fishPrefabs.Length);

        // Use the randomly selected prefab to spawn a fish
        SpawnFish(fishPrefabs[randomIndex]);
    }

    // Existing method to spawn a fish of the specified prefab at the mouse click location
    void SpawnFish(GameObject fishPrefab)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        GameObject fish = Instantiate(fishPrefab, worldPosition, Quaternion.identity);
        fishList.Add(fish);
    }


    public void RemoveFishFromList(GameObject fish)
    {
        if (fishList.Contains(fish))
        {
            fishList.Remove(fish);
        }
    }

}