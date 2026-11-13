using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    private Transform currentTarget;

    void Start()
    {
        currentTarget = pointB != null ? pointB : pointA;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (currentTarget == null || pointA == null || pointB == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = (currentTarget == pointA) ? pointB : pointA;

            // Flip sprite
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
