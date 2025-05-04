using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CharacterAttackControl characterAttackControl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Buff"))
        {
            //Buff buff = collision.GetComponent<Buff>();
            //if (buff != null)
            //{
            //    switch (buff.BuffType)
            //    {
            //        case BuffType.Speed:
            //            playerMovement.SetSpeed(buff.BuffValue);
            //            break;
            //        case BuffType.Attack:
            //            characterAttackControl.SetExtraDamage(buff.BuffValue, buff.BuffDuration);
            //            break;
            //        default:
            //            break;
            //    }
            //    Destroy(collision.gameObject);
            //}
        }
    }
}
