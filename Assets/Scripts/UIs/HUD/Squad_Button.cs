using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squad_Button : MonoBehaviour
{
    public int squad_id = -1;
    Button clicker;
    public bool detail_view = false;
    public List<RectTransform> children;
    public bool toDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        clicker = GetComponent<Button>();
        clicker.onClick.AddListener(delegate { GoToSquad(squad_id); });
        foreach (RectTransform child in GetComponentsInChildren<RectTransform>())
        {
            if (child.name != name)
            {
                children.Add(child);
            }

            if (child.name == "DetailText")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToSquad(int index)
    {
        Squads_Manager.instance.GotoSquad(index);
    }

    public void DetailSwitcher()
    {
        detail_view = !detail_view;
        foreach (RectTransform child in children)
        {
            if (child.name.Contains("Button"))
            {
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
            else if (child.name == "DetailText")
            {
                string text;
                text = "";

                int solno, tankno, scoutno, artino, sniperno;
                solno = tankno = scoutno = artino = sniperno = 0;

                child.gameObject.SetActive(!child.gameObject.activeSelf);

                foreach (EnemyBase unit in Squads_Manager.instance.SquadFinder(squad_id))
                {
                    if (!unit)
                        continue;

                    switch (unit.type)
                    {
                        case ENEMYTYPE.FOOTSOLDIER:
                            solno++;
                            break;
                        case ENEMYTYPE.TANK:
                            tankno++;
                            break;
                        case ENEMYTYPE.SCOUT:
                            scoutno++;
                            break;
                        case ENEMYTYPE.ARTILLERY:
                            artino++;
                            break;
                        case ENEMYTYPE.SNIPER:
                            sniperno++;
                            break;
                    }
       
                }

                if (solno > 0)
                {
                    text += "Soldiers: " + solno + " \n";
                }
                if (tankno > 0)
                {
                    text += "Tanks: " + tankno + " \n";
                }
                if (scoutno > 0)
                {
                    text += "Scouts: " + scoutno + " \n";
                }
                if (artino > 0)
                {
                    text += "Artillery: " + artino + " \n";
                }
                if (sniperno > 0)
                {
                    text += "Snipers: " + sniperno + " \n";
                }

                child.GetComponentInChildren<Text>().text = text;
            }
        }

    }

    public void Disbander()
    {
        toDestroy = true;
        Squads_Manager.instance.MoveButtonPos();
        Destroy(gameObject);
    }
    
}
