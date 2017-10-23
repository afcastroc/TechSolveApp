using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadData {

    public static SaveLoadData instance;

    public SaveLoadData()
    {
        if (instance == null)
        {
            instance = this;
        }        
    }

    //*********************************************************************************** Make Reservations Methods ***************************************************//

    public bool BuildAndSaveReserve(ReserveFlightModel.ReserveData info)
    {
        string urlFile = Application.persistentDataPath + "/" + info.id + ".txt";        
        if (!File.Exists(urlFile))
        {            
            var newFile = File.CreateText(urlFile);
            WriteFile(newFile, info);            
            return true;
        }
        else
        {            
            if (CheckFlightDate(info.id, info.dateToFlight))
            {
                var newFile = File.AppendText(urlFile);
                WriteFile(newFile, info);
                return true;
            }
            else
            {
                return false;
            }
        }        
    }

    public bool CheckFlightDate(string id, string date)
    {
        string urlFile = Application.persistentDataPath + "/" + id + ".txt";        
        string[] fileSaved = File.ReadAllLines(urlFile);
        for (int i = 0; i < fileSaved.Length; i++)
        {
            if (fileSaved[i].Contains("date"))
            {
                string dateInfo = GetDataSinceCharacter("*", fileSaved[i]);
                System.DateTime dateTime;
                System.DateTime dateCurrentFlight;
                System.DateTime.TryParse(dateInfo, out dateTime);
                System.DateTime.TryParse(date, out dateCurrentFlight);                
                if (dateTime == dateCurrentFlight)
                {                    
                    return false;
                }
            }
        }
        return true;
    }

    public void WriteFile(StreamWriter fileOpen, ReserveFlightModel.ReserveData info)
    {
        fileOpen.WriteLine("Reserve Flight Info Start");

        fileOpen.WriteLine("name = *" + info.name);
        fileOpen.WriteLine("id = *" + info.id);
        fileOpen.WriteLine("age = *" + info.age);
        fileOpen.WriteLine("date = *" + info.dateToFlight);
        fileOpen.WriteLine("from = *" + info.cityFrom);
        fileOpen.WriteLine("to = *" + info.cityTo);
        fileOpen.WriteLine("airportFrom = *" + info.airportFrom);
        fileOpen.WriteLine("airportTo = *" + info.airportTo);
        fileOpen.WriteLine("depart = *" + info.departHour);
        fileOpen.WriteLine("arrive = *" + info.arriveHour);
        fileOpen.WriteLine("passengers = *" + info.passengers);
        fileOpen.WriteLine("charge = *" + info.charge);

        fileOpen.WriteLine("Reserve Flight Info End");
        fileOpen.Close();
    }

    //*********************************************************************************** Search Reservations Methods ***************************************************//

    public ReserveFlightModel.ReserveData[] SearchUserReservations(string id)
    {
        string path = Application.persistentDataPath + "/" + id + ".txt";        
        if (File.Exists(path))
        {            
            List<ReserveFlightModel.ReserveData> userData = new List<ReserveFlightModel.ReserveData>();
            ReserveFlightModel.ReserveData singleData = new ReserveFlightModel.ReserveData();
            string[] dataText = File.ReadAllLines(path);
            for (int i = 0; i < dataText.Length; i++)
            {
                if (dataText[i].Contains("Reserve Flight Info Start"))
                {
                    singleData = new ReserveFlightModel.ReserveData();                   
                }
                else if (dataText[i].Contains("id"))
                {
                    singleData.id = GetDataSinceCharacter("*", dataText[i]);                                        
                }
                else if (dataText[i].Contains("name"))
                {
                    singleData.name = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("age"))
                {
                    singleData.age = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("date"))
                {
                    singleData.dateToFlight = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("from"))
                {
                    singleData.cityFrom = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("to"))
                {
                    singleData.cityTo = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("airportFrom"))
                {
                    singleData.airportFrom = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("airportTo"))
                {
                    singleData.airportTo = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("depart"))
                {
                    singleData.departHour = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("arrive"))
                {
                    singleData.arriveHour = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("passengers"))
                {
                    singleData.passengers = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("charge"))
                {
                    singleData.charge = GetDataSinceCharacter("*", dataText[i]);                    
                }
                else if (dataText[i].Contains("Reserve Flight Info End"))
                {
                    userData.Add(singleData);
                }
            }
            return userData.ToArray();
        }        
        return null;
    }

    //************************************************************************ tools ******************************************************//

    public string GetDataSinceCharacter(string character, string line)
    {
        int index = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i].ToString() == character)
            {
                index = i;
                break;
            }
        }
        string result = line.Substring(index+1);        
        return result;
    }
}
