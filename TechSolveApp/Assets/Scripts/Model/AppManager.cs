using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {

    public Transform mainFrame;
    public Transform ConsultingForm;
    public Transform consultingTable;
    public Transform searchForm;

    public void ChangeMainToConsulting()
    {        
        mainFrame.GetComponentInChildren<Animator>().Play("FrameMainHide");
        ConsultingForm.GetComponentInChildren<Animator>().Play("FrameMainShow");
    }

    public void ChangeConsultingToMain()
    {
        mainFrame.GetComponentInChildren<Animator>().Play("FrameMainShow");
        ConsultingForm.GetComponentInChildren<Animator>().Play("FrameMainHide");
    }

    public void ChangeConsultingToTable()
    {
        consultingTable.GetComponentInChildren<Animator>().Play("FrameMainShow");
        ConsultingForm.GetComponentInChildren<Animator>().Play("FrameMainHide");
        FlightCell[] cells = GameObject.FindObjectsOfType<FlightCell>();
        foreach (FlightCell fc in cells)
        {
            fc.Start();
        }
    }

    public void ChangeTableToConsulting()
    {
        consultingTable.GetComponentInChildren<Animator>().Play("FrameMainHide");
        ConsultingForm.GetComponentInChildren<Animator>().Play("FrameMainShow");        
    }

    public void ChangeMainToSearch()
    {
        SearchReservationsView.instance.CleanResults();
        mainFrame.GetComponentInChildren<Animator>().Play("FrameMainHide");
        searchForm.GetComponentInChildren<Animator>().Play("FrameMainShow");
    }

    public void ChangeSearchToMain()
    {
        mainFrame.GetComponentInChildren<Animator>().Play("FrameMainShow");
        searchForm.GetComponentInChildren<Animator>().Play("FrameMainHide");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
