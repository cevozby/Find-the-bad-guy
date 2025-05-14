using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CharacterAttackControl characterAttackControl;

    public void SetSpeed(float speed, float duration)
    {
        playerMovement.ChangeSpeedMultiplier(speed, duration);
    }

    public void SetExtraDamage(float extraDamage, float time)
    {
        characterAttackControl.SetExtraDamage(extraDamage, time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
