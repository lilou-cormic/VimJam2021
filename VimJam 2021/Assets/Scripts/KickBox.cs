using UnityEngine;

public class KickBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>()?.Die();
    }
}