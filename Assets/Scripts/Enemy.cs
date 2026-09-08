using Unity.VectorGraphics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;

    public float enemyHealth;
    public int points;

    public GameObject ui;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ui = GameObject.FindGameObjectWithTag("UI");
    }

    public void FixedUpdate()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            
            enemyHealth--;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                ui.GetComponent<ScoreSystem>().AddScore(points);
            }
        }
    }
}
