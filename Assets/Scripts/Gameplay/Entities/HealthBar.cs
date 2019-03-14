using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public EntityBase entity;
    public Image healthBar;
    public float xSize;
    public float ySize;
    public float yOffset;
    // Start is called before the first frame update
    private void Awake()
    {
        Vector3 currScale = transform.localScale;
        currScale.x *= xSize;
        currScale.y *= ySize;
    }

    void Start()
    {
        if (entity == null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (entity == null)
            Destroy(gameObject);
        healthBar.fillAmount = (float)((float)entity.health/(float)entity.maxhealth);

        transform.LookAt(Camera.main.transform.position);
        Vector3 newEuler = transform.eulerAngles;
        //newEuler.x += 90;
        transform.eulerAngles = newEuler;

        if (entity != null)
        {
            Vector3 newPos = entity.transform.position;
            newPos.y += yOffset;
            transform.position = newPos;
        }
    }
}
