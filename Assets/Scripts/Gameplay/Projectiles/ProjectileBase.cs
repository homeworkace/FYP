using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ProjectileBase : MonoBehaviour
{
    public int damage;
    public float speed;
    public PhotonView view;
    public float lifeTime;
    public float timer = 0;
    public GameObject targetGO;
    public FACTION faction;
    
    public void Awake()
    {
        view = GetComponent<PhotonView>();
        object[] data = view.InstantiationData;
        damage = (int)data[0];
        speed = (float)data[1];
        if (PhotonView.Find((int)data[2]) != null)
            targetGO = PhotonView.Find((int)data[2]).gameObject;
        else
            targetGO = null;
        faction = (FACTION)data[3];
        AdditionalAwake();
    }

    public virtual void AdditionalAwake()
    {

    }
}
