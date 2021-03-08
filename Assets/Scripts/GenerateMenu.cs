using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMenu : MonoBehaviour
{

    public Menu menu;

    public GameObject MenuButton;

    public Gameplay controller;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My parent is: "+ gameObject.name);

        var jsonString = File.ReadAllText("Assets/Raw/menus.json");
        menu = JsonUtility.FromJson<Menu>(jsonString);
        
        CreateButtons(0, 40, true);
    }

    private void CreateButtons(int xOffset, int yOffset, bool vertical)
    {
        Debug.Log("Menu Name: "+ menu.Name);

        int i = 0;
        foreach (MButton item in menu.MButtons)
        {
            
            var btn = Instantiate(MenuButton, new Vector3(i*xOffset, -i*yOffset, 0), Quaternion.identity);
            btn.transform.SetParent(gameObject.transform, false);
            
            TMP_Text btnText = btn.GetComponentInChildren(typeof(TMP_Text), true) as TMP_Text;
            btnText.SetText(item.Label);

            Button btnObj = btn.GetComponent(typeof(Button)) as Button;
            if (i == 0) {
                btnObj.Select();
            }
            btnObj.onClick.AddListener(delegate { CallGameFunction(item.Function); });

            Debug.Log("Menu Item #" + (i++) + ": "+ item.ID );
        }
    }

    void CallGameFunction(string func)
    {
        controller.SendMessage(func);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class Menu
{
    public string Name;
    public MButton[] MButtons;
}

[Serializable]
public class MButton {
    public string ID;
    public string Label;
    public string Function;
}

