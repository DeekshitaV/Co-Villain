using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadInstantiate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject road;
    public Transform road1;
    private Vector3 nextRoadSpawn;
    void Start()
    {
        nextRoadSpawn = road1.localPosition;
        nextRoadSpawn.z = 87.35f;
        StartCoroutine(spawnRoad());
    }

    
    // Update is called once per frame
    IEnumerator spawnRoad()
    {
        yield return new WaitForSeconds(2);
        Instantiate(road, nextRoadSpawn, road1.localRotation);
        nextRoadSpawn.z += 50f;
        StartCoroutine(spawnRoad());
    }
}
