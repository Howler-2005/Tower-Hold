using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;
    public float explostionRadius;
    public float speed = 70f;
    

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
      
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (explostionRadius > 0f)
        {
            Explode();
        }
        else
        {
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
    
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explostionRadius);
    }


}
