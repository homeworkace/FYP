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
    public GameObject child;
    private Vector3 originalScale;

    // Start is called before the first frame update
    private void Awake()
    {
        transform.parent = GameObject.Find("Environment").transform.Find("HealthBars");
        Vector3 currScale = transform.localScale;
        originalScale = transform.localScale;
        currScale.x *= xSize;
        currScale.y *= ySize;
        transform.localScale = currScale;
    }

    void Start()
    {
        if (entity == null)
        {
            Destroy(gameObject);
        }
        else
        {
            child = GameObject.Find("HealthBG");
        }
    }

    private void LateUpdate()
    {
        if (entity != null)
        {
            yOffset = entity.GetComponent<EntityBase>().healthBarYOffset;
            Vector3 newPos = entity.transform.position;
            newPos.y += yOffset;
            transform.position = newPos;

            xSize = entity.GetComponent<EntityBase>().healthBarXSize;
            ySize = entity.GetComponent<EntityBase>().healthBarYSize;
            Vector3 currScale = originalScale;
            currScale.x *= xSize;
            currScale.y *= ySize;
            transform.localScale = currScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (entity == null)
        {
            Destroy(gameObject);
            return;
        }
        healthBar.fillAmount = (float)((float)entity.health / (float)entity.maxhealth);

        transform.LookAt(Camera.main.transform.position);
        Vector3 newEuler = transform.eulerAngles;
        //newEuler.x += 90;
        transform.eulerAngles = newEuler;
    }

    public void DisplayHealthbar(bool display)
    {
        if (display)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
