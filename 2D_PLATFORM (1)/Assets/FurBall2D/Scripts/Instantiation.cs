using UnityEngine;
using System.Collections;

public class Instantiation : MonoBehaviour
{
    public GameObject prefabToSpawn;

    void Start()
    {
        Instantiate(prefabToSpawn);
    }

    void Update()
    {

    }
}
