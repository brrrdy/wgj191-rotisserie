using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectFirstButton : MonoBehaviour
{

    public Button DefaultButton;

    private void Start() {
        
    }

    void OnEnable() 
    {
        DefaultButton = gameObject.GetComponentInChildren(typeof(Button), true) as Button;
        DefaultButton.Select();
        DefaultButton.transform.Find("selector").gameObject.SetActive(true);
    }
}
