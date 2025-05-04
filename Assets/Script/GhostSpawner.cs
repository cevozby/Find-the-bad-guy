using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] Transform[] odalar;
    [SerializeField] GameObject prefab;
    [SerializeField] List<GhostType> ghosts;

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
        GameObject ghost = Instantiate(prefab, CalculateSpawnPos(), Quaternion.identity);
        GhostType ghostType = GetGhost();
        ghost.GetComponent<GhostTiming>().SetGhost(ghostType);
        Points.souls += ghostType.scrorePoint;
    }
    Vector2 CalculateSpawnPos()
    {
        int a = Random.Range(0, odalar.Length);
        Vector2 v = Random.insideUnitCircle * .8f;
        return (Vector2)odalar[a].position + v;
    }

    private GhostType GetGhost()
    {
        GameLevel gameLevel = FindAnyObjectByType<GameManager>().GameLevel;
        GhostType ghost = ghosts[0];
        float randomValue = Random.value;
        Debug.Log(randomValue);
        switch (gameLevel)
        {
            case GameLevel.Easy:
                
                if (randomValue < 0.6f)
                    ghost = ghosts[0];
                else if (randomValue < 0.8f)
                {
                    ghost = ghosts[1];
                }
                else
                    ghost = ghosts[2];
                break;
            case GameLevel.Medium:
                if (randomValue < 0.5f)
                    ghost = ghosts[0];
                else if (randomValue < 0.75f)
                {
                    ghost = ghosts[1];
                }
                else
                    ghost = ghosts[2];
                break;
            case GameLevel.Hard:
                if (randomValue < 0.4f)
                    ghost = ghosts[0];
                else if (randomValue < 0.6f)
                {
                    ghost = ghosts[1];
                }
                else
                    ghost = ghosts[2];
                break;
        }
        Debug.Log(ghost.ghostName);
        return ghost;
    }
}
