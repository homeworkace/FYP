using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FOWRevealer : MonoBehaviour
{

    public int sight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EntityBase>())
        {
            if (sight != (int)GetComponent<EntityBase>().vision)
            {
                sight = (int)GetComponent<EntityBase>().vision;
            }

        }
    }
}
