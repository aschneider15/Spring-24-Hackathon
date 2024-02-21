using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyParent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {

            Instantiate(enemyPrefab, this.gameObject.transform.position, Quaternion.identity, enemyParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
