using UnityEngine;

public class BuffManager : MonoBehaviour
{
    private BuffSO buffSO;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float destroyTime = 5f;

    public void SetBuff(BuffSO buff)
    {
        buffSO = buff;
        spriteRenderer.sprite = buffSO.buffIcon;
        Invoke("SelfDestroy", destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                ApplyBuff(playerManager);
            }
        }
    }

    public void ApplyBuff(PlayerManager playerManager)
    {
        if (buffSO == null)
            return;
        switch (buffSO.buffType)
        {
            case BuffType.Speed:
                playerManager.SetSpeed(buffSO.buffValue, buffSO.buffDuration);
                break;
            case BuffType.Damage:
                playerManager.SetExtraDamage(buffSO.buffValue, buffSO.buffDuration);
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
