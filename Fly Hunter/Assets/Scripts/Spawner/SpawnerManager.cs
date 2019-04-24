using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    private Transform positionsParent;

    //wave1
    public GameObject[] ennemysToSpawnWave1;
    public float[] timeBeforeSpawnWave1;
    public float[] standardIntervallSpawnWave1;
    public float[] difficultyIndicatorWave1;
    public float minRangeWave1;
    public float maxRangeWave1;
    public float wavedurationWave1;

    private float timeActualInWave1;

    // Use this for initialization
    void Start() {
        positionsParent = transform;
    }

    // Update is called once per frame
    void Update() {
        //Wave1();
    }

    /*private void Wave1(Transform ParentSpawner, GameObject[] ennemys, float[] timeBeforeSpawn, float[] standardIntervallSpawn, float[] difficultyIndicator, float minRange, float maxRange, float realTimer, float duration)
    {
        float Timer = Time.time - realTimer;
        var i = 0;

        float ennemysSizeList = ennemys.ToList();

        for (i = 0, i < ennemys)
        {
            var TimeBeforeSpawning = standardIntervallSpawn[i];
        Instantiate(ennemys[i], positionsParent.GetChild(Random.Range(0, positionsParent.childCount)).position, Quaternion.identity);
        }
    }*/

}
