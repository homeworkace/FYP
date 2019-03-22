using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squads_Manager : MonoBehaviour
{
    public static Squads_Manager instance = new Squads_Manager();
    public HUD_Manager hud_manager;
    public List<Button> squad_buttons = new List<Button>();
    public Vector3 beginpos = new Vector3(461, 168, 0);
    float yincrement = 95.0f;
    public int squad_count = 1;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        hud_manager = GameObject.Find("Game Management").GetComponent<HUD_Manager>();

        foreach (Button button in GetComponentsInChildren<Button>())
        {
            if (!button.name.Contains("Detail") && !button.name.Contains("Disband"))
            {
                squad_buttons.Add(button);
            }
        }

        beginpos = squad_buttons[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddSquad()
    {
        if (hud_manager)
        {
            if (hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits.Count <= 0)
            {
                // Prevent nothing from getting added
            }
            else
            {
                // Assign units their squad number for future recalling
                if (hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits.Equals(SquadFinder(squad_count)))
                    return;

                foreach (EnemyBase unit in hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits)
                {
                    if (!unit)
                        continue;


                    // Check if unit already has current squad assigned to it
                    if (!unit.squadIDs.Contains(squad_count))
                    unit.squadIDs.Add(squad_count);

                    // Check for final item in list's list of units
                    if (unit == hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits[hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits.Count - 1])
                    {
                        // Button Adder
                        GameObject go = Instantiate(Resources.Load<GameObject>("HUD/SquadSet"), transform);
                        go.transform.SetParent(GameObject.Find("SquadContent").transform);
                        go.GetComponent<Squad_Button>().squad_id = squad_count;

                        UpdateButtons();

                        go.GetComponentInChildren<Text>().text = "Squad " + (go.GetComponent<Squad_Button>().squad_id);

                        UpdateButtonPos();

                        squad_count++;

                        break;
                    }
                }

            }


        }
    }

    public void RemoveSquad(int index)
    {
        foreach (EnemyBase unit in SquadFinder(index))
        {
            if (unit.squadIDs.Contains(index))
            {
                unit.squadIDs.Remove(index);
            }
        }

    }

    public void GotoSquad(int index)
    {
        hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits.Clear();

        hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits = SquadFinder(index);
        Debug.Log(hud_manager.player_instance.GetComponent<PlayerDetails>().selectedUnits);
    }

    public List<EnemyBase> SquadFinder(int index)
    {
        List<EnemyBase> returner = new List<EnemyBase>();
        foreach (EnemyBase unit in GameObject.Find("Enemies").GetComponentsInChildren<EnemyBase>())
        {
            if (unit.squadIDs.Contains(index))
            {
                returner.Add(unit);
            }
        }

        return returner;
    }

    public void UpdateButtonPos()
    {
        for (int i = 1; i < squad_buttons.Count; ++i)
        {
            squad_buttons[i].transform.position = new Vector3(transform.position.x, beginpos.y + (-yincrement * (i - 1)), 0);
        }

        squad_buttons[0].transform.position = new Vector3(squad_buttons[0].transform.position.x, squad_buttons[squad_buttons.Count - 1].transform.position.y - (yincrement * 1.2f), 0);
    }

    public void MoveButtonPos()
    {
        UpdateButtons();
        for (int i = 1; i < squad_buttons.Count; ++i)
        {
            if (squad_buttons[i])
            squad_buttons[i].transform.position = new Vector3(transform.position.x, beginpos.y + (-yincrement * (i - 1)), 0);
        }

        if (squad_buttons.Count > 1)
        squad_buttons[0].transform.position = new Vector3(squad_buttons[0].transform.position.x, squad_buttons[squad_buttons.Count - 1].transform.position.y - (yincrement * 1.2f), 0);
        else
            squad_buttons[0].transform.position = new Vector3(squad_buttons[0].transform.position.x, beginpos.y, 0);

    }

    public void UpdateButtons()
    {
        squad_buttons.Clear();
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            if (!button.name.Contains("Detail") && !button.name.Contains("Disband"))
            {
                if (button.GetComponent<Squad_Button>())
                {
                    if (button.GetComponent<Squad_Button>().toDestroy)
                    {

                    }
                    else
                    {
                        squad_buttons.Add(button);
                    }
                }
                else
                    squad_buttons.Add(button);
            }
        }
    }
}
