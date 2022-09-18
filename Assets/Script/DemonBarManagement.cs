using UnityEngine;
using UnityEngine.UI;

public class DemonBarManagement : MonoBehaviour
{
    [SerializeField] Slider demonBar;

    // Start is called before the first frame update
    void Start()
    {
        demonBar.minValue = 0;
        demonBar.maxValue = GameManager.maxEscapeValue;
        demonBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        demonBar.value = Points.escapeSouls;
    }
}
