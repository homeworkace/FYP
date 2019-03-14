using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squads_Manager : MonoBehaviour
{
    public static Squads_Manager instance = new Squads_Manager();
    public HUD_Manager hud_manager;
    public List<GameObject> squad_buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        hud_manager = GameObject.Find("Game Management").GetComponent<HUD_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hud_manager)
        {

        }
    }

    public void AddSquad()
    {

    }

    public void RemoveSquad()
    {

    }
}
