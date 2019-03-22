using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : ProjectileBase
{
    private Vector3 targetDir;

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine)
            return;

        if (targetGO == null)
        {
            timer += Time.deltaTime;
            if (timer >= lifeTime)
                PhotonNetwork.Destroy(gameObject);
        }
        else
        {
            Collider targetCollider = targetGO.GetComponent<Collider>();
            targetDir = (targetCollider.bounds.center - transform.position).normalized;
        }
        transform.Translate(targetDir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!view.IsMine)
            return;
        if (targetGO == other.gameObject)
        {
            targetGO.GetComponent<EntityBase>().GetDamaged(damage);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
