using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchReservationsView : MonoBehaviour {

    public static SearchReservationsView instance;
    public InputField id;
    public GameObject cell;
    public ScrollRect scrollTitle;
    public ScrollRect scrollContent;
    public Transform scrollCellsParent;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CleanResults()
    {
        for (int i = 0; i < scrollCellsParent.childCount; i++)
        {
            Destroy(scrollCellsParent.GetChild(i).gameObject);
        }
    }

    public void UpdateScrolls(ScrollRect model)
    {
        scrollTitle.horizontalNormalizedPosition = model.horizontalNormalizedPosition;
        scrollContent.horizontalNormalizedPosition = model.horizontalNormalizedPosition;
    }

    public void UpdateCells(ReserveFlightModel.ReserveData[] userDate)
    {
        for (int i = 0; i < userDate.Length; i++)
        {
            GameObject currentCell = (GameObject)Instantiate(cell, scrollCellsParent.position, Quaternion.identity);
            currentCell.transform.SetParent(scrollCellsParent);
            currentCell.transform.localPosition = Vector3.zero;
            currentCell.transform.localScale = Vector3.one;
            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollCellsParent.gameObject.GetComponent<RectTransform>());
            ReserveInfoCell infoCell = currentCell.GetComponent<ReserveInfoCell>();
            infoCell.UpdateInfo(userDate[i]);
        }
    }    
}
