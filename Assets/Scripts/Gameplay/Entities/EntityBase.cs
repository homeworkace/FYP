using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EntityBase : MonoBehaviour
{
    [Header("Healthbar")]
    public GameObject healthBarPrefab;
    public HealthBar healthBarObject;
    public float healthBarXSize;
    public float healthBarYSize;
    public float healthBarYOffset;

    public bool displayOnlyAfterAttacked = false;
    public bool hideAfterCertainAmountOfTime = false;
    public float hideTime;
    private float timer = 0;
    private float oldHP;

    [Header("STATS")]
    public PhotonView view;
    public Collider collider;
    public int health;
    public int maxhealth;
    public int armor;
    public int damage;
    public float movement;
    public float attackRange;
    public float vision;
    public float rateOfAttack;
    public float spawnTimer;
    public int cost;
    public string bulletType;
    public float bulletSpeed;

    [Header("Variables(Dont Touch Them!)")]
    public FACTION faction;
    public float attackTimer;
    
    public void CreateHealthBar()
    {
        if (healthBarPrefab != null)
        {
            GameObject healthBar = Instantiate(healthBarPrefab);
            healthBar.GetComponent<HealthBar>().entity = GetComponent<EntityBase>();
            healthBar.GetComponent<HealthBar>().xSize = healthBarXSize;
            healthBar.GetComponent<HealthBar>().ySize = healthBarYSize;
            healthBar.GetComponent<HealthBar>().yOffset = healthBarYOffset;

            oldHP = healthBar.GetComponent<HealthBar>().entity.health;
            healthBarObject = healthBar.GetComponent<HealthBar>();
            if (displayOnlyAfterAttacked)
                healthBarObject.DisplayHealthbar(false);
        }
    }

    public void HealthBarUpdate()
    {
        if (healthBarPrefab != null)
        {
            if (displayOnlyAfterAttacked)
            {
                if (oldHP != health)
                {
                    oldHP = health;
                    healthBarObject.DisplayHealthbar(true);
                    timer = 0;
                }
                if (hideAfterCertainAmountOfTime)
                {
                    timer += Time.deltaTime;
                    if (timer >= hideTime)
                    {
                        timer = 0;
                        healthBarObject.DisplayHealthbar(false);
                    }
                }
            }
        }
    }

    public void DamageEntity(EntityBase entity)
    {
        if (PhotonNetwork.OfflineMode == false)
            entity.view.RPC("RPC_GetDamaged", RpcTarget.All, damage);
        else
        {
            if (damage <= entity.armor)
                return;
            int endDamage = damage;
            endDamage -= entity.armor;
            entity.health -= endDamage;
        }
    }

    public void GetDamaged(int damage)
    {
        if (PhotonNetwork.OfflineMode == false)
            view.RPC("RPC_GetDamaged", RpcTarget.All, damage);
        else
        {
            if (damage <= armor)
                return;
            int endDamage = damage;
            endDamage -= armor;
            health -= endDamage;
        }
    }

    [PunRPC]
    public void RPC_GetDamaged(int damageInput)
    {
        if (damageInput <= armor)
            return;

        int endDamage = damageInput;
        endDamage -= armor;

        health -= endDamage;
    }
}
