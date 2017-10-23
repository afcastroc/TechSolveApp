using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsultingFlightsModel : MonoBehaviour {

    public Dictionary<string, string> airports = new Dictionary<string, string>()
    {
        { "Bogota", "El Dorado"},
        { "Medellin", "Jose Maria Cordoba"},
        { "Santa Marta", "Simon Bolivar"},
        { "Cali", "Alfonso Bonilla Aragon" }
    };

    private int tiketValue = 0;
    public int TiketValue { get { return tiketValue; } set { tiketValue = value; } }
}
