using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bomb : ProjectileBase
{
    public float airResistance;
    public float gravity;
    public float explosionRadius;

    private float startingHorizontalVelocity;
    private float startingVerticalVelocity;

    private Vector3 targetPos;
    private Vector3 velocity;
    private Vector3 horizontalDirection;
    private float timeWhenHorizontalFinish;
    private float timeWhenYVelZero;
    private float endVel;
    public GameObject explosionPrefab;

    public override void AdditionalAwake()
    {
        if (targetGO != null)
        {
            targetPos = targetGO.GetComponent<Collider>().bounds.center;
            horizontalDirection = (targetPos - transform.position).normalized;
            horizontalDirection.y = 0;
            startingHorizontalVelocity = Mathf.Sqrt(2 * (airResistance) * GetHorizontalDistance(transform.position, targetPos));
            timeWhenHorizontalFinish = (0 - startingHorizontalVelocity) / (-airResistance);
            startingVerticalVelocity = (GetVerticalDistance(targetPos, transform.position) - (0.5f * (-gravity) * (timeWhenHorizontalFinish * timeWhenHorizontalFinish))) / timeWhenHorizontalFinish;

            velocity = horizontalDirection * startingHorizontalVelocity;
            velocity += Vector3.up * startingVerticalVelocity;
        }
        else
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine)
            return;
        transform.position += velocity * Time.deltaTime;

        //Air Resistance
        Vector3 velocityHorizonal = velocity;
        velocityHorizonal.y = 0;
        velocity -= (velocityHorizonal.normalized) * airResistance * Time.deltaTime;
        //Gravity
        velocity += Vector3.down * gravity * Time.deltaTime;
    }
    private float GetHorizontalDistance(Vector3 pos1,Vector3 pos2)
    {
        pos1.y = 0;
        pos2.y = 0;
        return Vector3.Distance(pos1, pos2);
    }

    private Vector3 GetHorizontalDirection(Vector3 target,Vector3 curr)
    {
        target.y = 0;
        curr.y = 0;
        Vector3 newDir = Vector3.zero;
        newDir = (target - curr).normalized;
        return newDir;
    }

    private float GetVerticalDistance(Vector3 pos1, Vector3 pos2)
    {
        pos1.x = 0;
        pos2.x = 0;
        pos1.z = 0;
        pos2.z = 0;
        return (pos1.y - pos2.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!view.IsMine)
            return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Terrain") || other.gameObject.layer == LayerMask.NameToLayer("Structure") || other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (other.gameObject.GetComponent<EntityBase>() && other.gameObject.GetComponent<EntityBase>().faction == faction)
                return;
            //EXPLODE
            var all = FindObjectsOfType<EntityBase>();
            foreach(EntityBase entity in all)
            {
                if (entity.faction == faction)
                    continue;
                float distanceFrom = Vector3.Distance(entity.transform.position, transform.position);
                if (distanceFrom <= explosionRadius)
                {
                    float multiplier = (explosionRadius-distanceFrom) / explosionRadius;
                    int actualDamage = (int)((float)damage * multiplier);
                    entity.GetDamaged(actualDamage);
                }
            }

            CreateExplosionParticles();
            PhotonNetwork.Destroy(gameObject);
        }
    }

    void CreateExplosionParticles()
    {
        if (PhotonNetwork.OfflineMode)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity, GameObject.Find("Environment").transform);
        }
        else
        {
            view.RPC("RPCCreateExplosionParticles", RpcTarget.All);
        }
    }

    [PunRPC]
    void RPCCreateExplosionParticles()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity, GameObject.Find("Environment").transform);
    }
}
