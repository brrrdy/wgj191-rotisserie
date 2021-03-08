using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMenu : MonoBehaviour
{

    public MenuItem menu;

    public GameObject MenuButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("My parent is: "+ gameObject.name);

        var jsonString = File.ReadAllText("Assets/Raw/menus.json");
        menu = JsonUtility.FromJson<MenuItem>(jsonString);
        
        CreateButtons(0, 40, true);
    }

    private void CreateButtons(int xOffset, int yOffset, bool vertical)
    {
        Debug.Log("Menu Name: "+ menu.Name);

        int i = 0;
        foreach (var item in menu.Items)
        {
            
            var btn = Instantiate(MenuButton, new Vector3(i*xOffset, -i*yOffset, 0), Quaternion.identity);
            btn.transform.SetParent(gameObject.transform, false);
            
            TMP_Text btnText = btn.GetComponentInChildren(typeof(TMP_Text), true) as TMP_Text;
            btnText.SetText(item);

            Button btnObj = btn.GetComponent(typeof(Button)) as Button;
            if (i == 0) {
                btnObj.Select();
            }
            btnObj.onClick.AddListener(delegate { TestFunc(item); });

            Debug.Log("Item #" + (i++) + ": "+ item );
        }
    }

    void TestFunc(string message)
    {
        Debug.Log("Button click: " + message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class MenuItem
{
    public string Name;
    public string[] Items;
}

