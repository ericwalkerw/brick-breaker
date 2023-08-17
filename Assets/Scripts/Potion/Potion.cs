using UnityEngine;

public class Potion : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IReceiveBuff xPotion = collision.GetComponent<IReceiveBuff>();
            OnActive(xPotion);
        }
    }

    public virtual void OnActive(IReceiveBuff xPotion)
    {
        Destroy(gameObject);
    }
}
