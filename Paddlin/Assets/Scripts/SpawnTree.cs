using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    public GameObject[] Trees;
    private int randomTree;
    public int spawnChance;
    public int spawnCeiling;
    public int arraylength;

    void Start ()
    {
        if (gameObject.CompareTag("Obstacle"))
        {
            spawnChance = Random.Range(0, spawnCeiling);
        }
        randomTree = Random.Range(0, arraylength);

        if (spawnChance == 1 || spawnChance == 3)
        {
            Instantiate(Trees[randomTree], transform.position, Quaternion.identity);
        }
	}
}
