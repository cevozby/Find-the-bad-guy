using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] List<BuffSO> buffs;
    [SerializeField] GameObject buffPrefab;
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] float spawnRadius = 5f;

    [SerializeField] Transform parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBuff", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBuff()
    {
        if(lineRenderer.positionCount == 0 || buffPrefab == null)
            return;

        int randomIndex = Random.Range(0, lineRenderer.positionCount);
        Vector3 spawnPosition = lineRenderer.GetPosition(randomIndex) + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0; // Ensure the buff is spawned on the same plane as the line renderer
        GameObject buff = Instantiate(buffPrefab, spawnPosition, Quaternion.identity, parent);

        BuffManager buffManager = buff.GetComponent<BuffManager>();
        if (buffManager != null)
        {
            BuffSO randomBuff = buffs[Random.Range(0, buffs.Count)];
            buffManager.SetBuff(randomBuff);
        }
    }

}
