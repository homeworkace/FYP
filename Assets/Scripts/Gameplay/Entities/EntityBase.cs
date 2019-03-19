using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EntityBase : MonoBehaviour
{
    [Header("Healthbar")]
    public GameObject healthBarPrefab;
    public float healthBarXSize;
    public float healthBarYSize;
    public float healthBarYOffset;

    [Header("STATS")]
    public int health;
    public int maxhealth;
    public int damage;
    public float movement;
    public float attackRange;
    public float vision;
    public float rateOfAttack;

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
            healthBar.GetComponent<HealthBar>().yOffset = healthBarYOffset * healthBar.transform.localScale.y;
        }
    }
}
