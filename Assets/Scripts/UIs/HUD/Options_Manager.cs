using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_Manager : MonoBehaviour
{
    public GameObject hud_manager;
    public List<GameObject> children = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        hud_manager = GameObject.Find("Game Management");
        foreach (Text child in GetComponentsInChildren<Text>())
        {
            if (!child)
                continue;

            if (child.name.Contains("Part"))
            {
                children.Add(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
