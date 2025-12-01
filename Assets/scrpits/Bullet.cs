using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public int attack;
    private Transform target;
    public GameObject impactEffect;
    public float explostionRadius;
    public float speed = 70f;
    public float duration;
    public bool AOE;

    public void Seek (Transform _target)
    {
        target = _target;
    }


    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }

   private void HitTarget()
   {
      
        if (AOE)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, duration);
            Aoe();

        }
        else if (explostionRadius > 0f)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, duration);
            Explode();
        }
        else
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, duration);
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explostionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
               
                Damage(collider.transform);
            }


        }
        
        

    }
    
    void Aoe()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, explostionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
        
                Damage(collider.transform);
            }


        }


    }
    void Damage(Transform enemy)
    {
        enemyAI e = enemy.GetComponent<enemyAI>();

        if (e != null)
        {
            e.TakeDamage(attack);
        }

   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explostionRadius);
    }


}
