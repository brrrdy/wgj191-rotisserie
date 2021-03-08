using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject selector;

    // Start is called before the first frame update
    void OnEnable() 
    { 
    }

    void OnDisable() {
        doDeselectButton();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData) 
    {
        doSelectButton();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        doDeselectButton();
    }

    public void doSelectButton()
    {
        // activate selector sprite
        selector.SetActive(true);
    }

    public void doDeselectButton()
    {
        selector.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selector.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selector.SetActive(true);
    }
}
