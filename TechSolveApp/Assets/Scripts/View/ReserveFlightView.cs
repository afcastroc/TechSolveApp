using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReserveFlightView : MonoBehaviour {

    public Transform reservePanel;
    public InputField name;
    public InputField id;
    public InputField age;
    public Text charge;
    public InputField creditCard;
    public Transform popupMakeReserve;
    public float timeToShow = 0f;

    public void BackToTable()
    {
        reservePanel.gameObject.SetActive(false);
    }

    public void ShowReservePanel()
    {
        reservePanel.gameObject.SetActive(true);
    }

    public void ShowReservingPopup()
    {
        popupMakeReserve.gameObject.SetActive(true);
        StartCoroutine(HideReservingPopup());
    }

    IEnumerator HideReservingPopup()
    {
        yield return new WaitForSeconds(timeToShow);
        popupMakeReserve.gameObject.SetActive(false);
        Popups.popupManager.ShowPopup(true, Errors.RESERVE_SUCCESS);
        BackToTable();
    }
}
