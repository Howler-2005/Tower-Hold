using UnityEngine;
using UnityEngine.Animations;

public class enemyAI : MonoBehaviour
{

    public float speed = 10f;
    public int value;
    private Transform target;
    private int wavepointIndex = 0;

    public int Health;

    public GameObject deathEffect;

    private void Start()
    {
        target = waypoints.points[0];
        transform.LookAt(target);
        Health += PlayerStats.Diff;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);

        PlayerStats.Money += value;
        Destroy(gameObject);
    }


    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        void GetNextWayPoint()
        {
            if (wavepointIndex >= waypoints.points.Length - 1)
            {
                EndPath();
                return;
            }

            wavepointIndex++;
            target = waypoints.points[wavepointIndex];
            transform.LookAt(target);
        }

        void EndPath()
        {
            PlayerStats.Lives--;
            Destroy(gameObject);
        }


    }
}
