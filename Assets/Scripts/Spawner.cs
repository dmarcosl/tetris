using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    // Groups
    public GameObject[] groups;

    public void spawnNext() {
        // Random Index
        var i = Random.Range(0, groups.Length);

        // Spawn Group at current Position
        Instantiate(groups[i],
            transform.position, // transform.position is the Spanner's position
            Quaternion.identity); // Quaternion.identity is the default rotation
    }

    // Start is called before the first frame update
    void Start() {
        spawnNext();
    }

    // Update is called once per frame
    void Update() {
    }
}