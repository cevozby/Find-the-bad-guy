using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BakeMesh2D();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BakeMesh()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        int pointCount = lr.positionCount;
        for (int i = 0; i < pointCount - 1; i++)
        {
            Vector3 start = lr.GetPosition(i);
            Vector3 end = lr.GetPosition(i + 1);
            Vector3 midPoint = (start + end) / 2;
            Vector3 direction = end - start;
            float length = direction.magnitude;

            GameObject obs = Instantiate(obstaclePrefab, midPoint, Quaternion.LookRotation(direction), transform);
            obs.transform.localScale = new Vector3(0.2f, 1f, length); // X: geniþlik, Z: uzunluk
        }
    }

    public void BakeMesh2D()
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        int pointCount = lr.positionCount;

        for (int i = 0; i < pointCount - 1; i++)
        {
            Vector3 start = lr.GetPosition(i);
            Vector3 end = lr.GetPosition(i + 1);

            Vector3 midPoint = (start + end) / 2f;
            Vector3 direction = end - start;
            float length = direction.magnitude;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject obs = Instantiate(obstaclePrefab, midPoint, Quaternion.Euler(0f, 0f, angle), transform);
            obs.transform.localScale = new Vector3(length, 0.2f, 1f); // X: uzunluk, Y: kalýnlýk (yükseklik)
        }
    }
}
