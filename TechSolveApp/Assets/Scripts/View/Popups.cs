using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popups : MonoBehaviour {

    public Transform popupPanel;
    public Text errorMessage;
    public Sprite warningIcon;
    public Sprite successIcon;
    public Image icon;
    public float timeToShow = 0f;
    public static Popups popupManager;

    public void Start()
    {
        if (popupManager == null)
        {
            popupManager = this;
        }
    }

    public void ShowPopup(bool success,string message)
    {
        popupPanel.gameObject.SetActive(true);
        if (success)
        {
            icon.sprite = successIcon;
        }
        else
        {
            icon.sprite = warningIcon;
        }
        errorMessage.text = message;
        StartCoroutine(TimeToShow());
    }

    IEnumerator TimeToShow()
    {
        yield return new WaitForSeconds(timeToShow);
        popupPanel.gameObject.SetActive(false);
    }
}
