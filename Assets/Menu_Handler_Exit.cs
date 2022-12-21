using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu_Handler_Exit : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] UIManager UI;
    [SerializeField] InGame_MenuButton menu;
    bool isEnter;
    
    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isEnter == false)
            {
                if (menu.isEnter) return;
                //UI.showMenu = true;
                UI.OnClickShowMenu();

            }
        }
    }
}
