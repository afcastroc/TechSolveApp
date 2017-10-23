package com.techsolve.afcastroc.techsolvetools;

import android.app.DatePickerDialog;
import android.app.DialogFragment;
import android.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

/**
 * Created by Andres on 21/10/2017.
 */

public class MainClass
{
    public static void StartCalendar()
    {
        Log.e("MainClass", "Before create Calendar");
        MainClass main = new MainClass();
        main.ShowCalendar();
    }

    public void ShowCalendar()
    {
        Picker picker = new Picker();
        picker.show(UnityPlayer.currentActivity.getFragmentManager(), "UNIQUE_KEY");
    }
}
