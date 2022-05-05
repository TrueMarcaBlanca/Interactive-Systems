using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuitButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick( PointerEventData eventData )
    {
        Application.Quit();
    }
    
}
