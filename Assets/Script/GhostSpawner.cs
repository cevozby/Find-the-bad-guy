using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] Transform[] odalar;
    [SerializeField] GameObject prefab;

    private void Start()
    {
        StartCoroutine(Routine());
    }
    IEnumerator Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Spawn();
        }
    }
    void Spawn()
    {
        Instantiate(prefab,CalculateSpawnPos(),Quaternion.identity);
    }
    Vector2 CalculateSpawnPos()
    {
        int a = Random.Range(0, odalar.Length);
        Vector2 v = Random.insideUnitCircle;
        return (Vector2)odalar[a].position + v;
    }
}
