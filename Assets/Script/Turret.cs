using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private EnemyMove targetEnemy;
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int dameOverTime = 30;
    public float slowPct = .5f;

    
    public AudioClip bulletSound;
    public AudioSource playAudio;

    private Transform target;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public float shortesDistance;
    public GameObject bulletprefabs;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        playAudio = GetComponent<AudioSource>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        shortesDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // Tinh khoang cach tu tru den muc tieu
            if(distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearesEnemy = enemy;
            }
        }

        if(nearesEnemy != null && shortesDistance <= range)
        {
            target = nearesEnemy.transform;
            targetEnemy = nearesEnemy.GetComponent<EnemyMove>();
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if (useLaser) // Chi su dung cho sung laser
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            return;
        }

        LockOnTarget(); // Khoa muc tieu
        if (useLaser)
        {
            laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void laser()
    {
        targetEnemy.TakeDamage(dameOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletprefabs, firePoint.position, firePoint.rotation);
        playAudio.PlayOneShot(bulletSound, 1.0f);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
