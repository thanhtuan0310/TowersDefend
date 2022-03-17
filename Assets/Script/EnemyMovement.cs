using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMove))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndext = 0;

    private EnemyMove enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyMove>();

        target = WayPoint.point[0];
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        if (wavepointIndext >= WayPoint.point.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndext++;
        target = WayPoint.point[wavepointIndext];
    }

    void EndPath()
    {
        PlayerStarts.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
