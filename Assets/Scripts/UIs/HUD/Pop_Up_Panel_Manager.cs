using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class BoolwithName{
    public bool value = false;
    public string name = "";

    public BoolwithName(bool val, string nam)
    {
        value = val;
        name = nam;
    }
}

public class Pop_Up_Panel_Manager : MonoBehaviour
{
    public Canvas mainScreen;
    public bool isactive = false;
    List<BoolwithName> buttonchecks;
    public Button[] buttons;
    string lastButtonPressed;
    public List<GameObject> panelChildren = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        mainScreen = GameObject.Find("Canvas").GetComponent<Canvas>();
        buttons = new Button[GameObject.Find("Game Management").GetComponentsInChildren<Button>().Length];
        buttons = GameObject.Find("Game Management").GetComponentsInChildren<Button>();
        buttonchecks = new List<BoolwithName>();
        buttonchecks.Add(new BoolwithName(false, "Production"));
        buttonchecks.Add(new BoolwithName(false, "Squads"));
        buttonchecks.Add(new BoolwithName(false, "Options"));
        buttonchecks.Add(new BoolwithName(false, "Concede"));
        foreach (RectTransform go in GetComponentsInChildren<RectTransform>())
        {
            if (go.name == name)
                continue;

            if (go.name.Contains("Panel"))
            {
                go.gameObject.SetActive(false);
                panelChildren.Add(go.gameObject);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PanelMovement()
    {
        if (!isactive)
        {
            //   Debug.Log(transform.localScale);
            //   transform.position.Set(transform.position.x + transform.localScale.x * 2, transform.position.y, transform.position.z);
            transform.position -= new Vector3((mainScreen.pixelRect.max.x * 0.15f), 0, 0);
       //     Debug.Log(transform.position);

            foreach (Button button in buttons)
            {
                if (!button)
                    continue;

                if (!isactive && button.GetComponentInParent<Pop_Up_Panel_Manager>() == null)
                    button.transform.position -= new Vector3((mainScreen.pixelRect.max.x * 0.15f), 0, 0);
            }
            isactive = true;
        }
        else
        {
            int activebuttons = 0;
            foreach (BoolwithName button in buttonchecks)
            {
                if (button.value == true)
                {              
                    activebuttons++;
                }
            }

            if (activebuttons == 1)
            {
                // Switch panels
                foreach (Button button in buttons)
                {
                   
                    if (!button)
                        continue;

     
                }
            }
            else
            {
                transform.position += new Vector3((mainScreen.pixelRect.max.x * 0.15f), 0, 0);
                // Move back
                foreach (Button button in buttons)
                {
                    if (!button)
                        continue;

                    if (button.name.Contains("Button"))
                    {
                        button.transform.position += new Vector3((mainScreen.pixelRect.max.x * 0.15f), 0, 0);
                    }
                }

                foreach (BoolwithName button in buttonchecks)
                {
                    button.value = false;
                }

                foreach (GameObject go in panelChildren)
                {
                    go.SetActive(false);
                }

                
                isactive = false;
            }


        }

    }

    public void MainSwitch(string name)
    {
        foreach (BoolwithName button in buttonchecks)
        {
            if (button.name == name)
            {
                button.value = !button.value;
                lastButtonPressed = button.name;
                continue;
            }

            button.value = false;
        }

        foreach (GameObject go in panelChildren)
        {
            if (go.name.Contains(name))
            {
                go.SetActive(true);
                continue;
            }
            go.SetActive(false);
        }

        
    }
}
