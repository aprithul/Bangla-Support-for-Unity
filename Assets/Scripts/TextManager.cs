using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextManager {
    
    public string current_text="";
    public string last_word ="";

    public void append(string character)
    {
        current_text += character;
    }

    public void remove_from_end()
    {
        if(current_text.Length>0)
            current_text = current_text.Remove(current_text.Length - 1);
    }

    public static string substitue(string input)
    {
        switch(input)
        {
            case "k":
                return "K";
        }

        return "";
    }
}
