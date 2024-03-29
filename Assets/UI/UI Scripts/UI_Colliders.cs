using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Colliders : MonoBehaviour
{
    public Button[] buttons;
    public RectTransform panel;

    public void EnableUIcolliders()
    {
        foreach(Button btn in buttons)
        {
            Collider2D btnCollider = btn.GetComponent<Collider2D>();
            if (btnCollider != null)
                btnCollider.enabled = btnCollider.enabled ? false : true;
        }

        Collider2D panelCollider = panel.GetComponent<Collider2D>();
        if (panelCollider != null)
            panelCollider.enabled = panelCollider.enabled ? false : true;

        EventSystem.current.SetSelectedGameObject(null);
    }
}
