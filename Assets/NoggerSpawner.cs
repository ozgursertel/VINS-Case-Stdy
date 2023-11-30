using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoggerSpawner : MonoBehaviour
{
    float timer;
    public float spawnTime;
    public float min_x;
    public float max_x;
    public float spawn_y;
    public float min_z;
    public float max_z;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameFinished)
        {
            return;
        }
        if(timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Debug.Log("Nogger Spawn");
            NoggerSpawn();
        }

    }

    private void NoggerSpawn()
    {
        float x = UnityEngine.Random.Range(min_x,max_x);
        float z = UnityEngine.Random.Range(min_z, max_z);

        GameObject obj=ObjectPooler.Instance.SpawnFromPool("Nogger", new Vector3(x, spawn_y, z), Quaternion.identity);
        obj.SetActive(true);
        StartCoroutine(obj.GetComponent<NoggerScript>().doNoggerYMove());
    }
}
