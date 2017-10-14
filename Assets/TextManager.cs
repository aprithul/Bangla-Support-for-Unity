using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextManager {

    public static string current_text;
    public static string last_word ="";
    private static string current_word ="";

    public static void append(string character)
    {
        current_text += character;
        if (character == " ")
        {
            last_word = current_word;
            current_word = "";
        }
        else
            current_word += character;
    }

    public static void remove_from_end()
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
