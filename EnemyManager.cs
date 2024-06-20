using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyManager : MonoBehaviour
{
    float power = 300;
    int Enemy_HP = 99;
    private int count;

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip damageSound;
    private AudioSource audioSource;

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _agent.destination = collider.transform.position;
            count += 1;
            if (count % 60 == 0)
            {
                Vector3 bulletSpawnPosition = transform.position + new Vector3(0, 5.0f, 0); // 上に1.0fのオフセットを追加
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * power);

                audioSource.PlayOneShot(shootSound);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Enemy_HP -= 33;
            audioSource.PlayOneShot(damageSound);

            if (Enemy_HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
    public void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
}