using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coin = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coin++;
            Destroy(other.gameObject);
        }
    }
}
