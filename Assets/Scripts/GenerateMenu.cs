using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMenu : MonoBehaviour
{

    public MenuList AllMenus;

    public GameObject MenuButton;

    public Gameplay controller;

    // Start is called before the first frame update
    void Start()
    {
        var jsonString = File.ReadAllText("Assets/Raw/menus.json");
        AllMenus = JsonUtility.FromJson<MenuList>(jsonString);
        controller.FullMenuList = AllMenus;

        //CreateButtons(0, 40, true);
        gameObject.SetActive(false);
    }

    private void CreateButtons(int xOffset, int yOffset, bool vertical)
    {

        int i = 0;

        var menu = Array.Find<Menu>(AllMenus.Menus, n => n.Name == gameObject.name);

        foreach (MButton item in menu.MButtons)
        {
            
            var btn = Instantiate(MenuButton, new Vector3(i*xOffset, -i*yOffset, 0), Quaternion.identity);
            i++;
            btn.transform.SetParent(gameObject.transform, false);
            
            TMP_Text btnText = btn.GetComponentInChildren(typeof(TMP_Text), true) as TMP_Text;
            btnText.SetText(item.Label);

            Button btnObj = btn.GetComponent(typeof(Button)) as Button;
            if (i == 0) {
                btnObj.Select();
            }
            btnObj.onClick.AddListener(delegate { CallGameFunction(item.Function); });

            //Debug.Log("Menu Item #" + i + ": "+ item.ID );
        }
    }

    void CallGameFunction(string func)
    {
        var omc = "OpenMenu";
        var ri = func.IndexOf(omc,0);
        if (ri > -1) {
            var newMenu = func.Remove(ri, omc.Length);
            controller.CloseActiveMenu();
            controller.OpenMenu(newMenu);
        } else {
            controller.SendMessage(func); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class MenuList
{
    public Menu[] Menus;
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

