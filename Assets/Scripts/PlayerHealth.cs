using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            if (health <= 0) gameObject.SetActive(false);
        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
