using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using com.omicronlab.avro;

[CustomEditor(typeof(KeyInput))]
public class KeyInputEditor : Editor
{
    PhoneticParser avro = PhoneticParser.getInstance();
    static string[] hotKeys = new string[] {
												 "a", "b", "c", "d", "e","f",
												 "g", "h", "i", "j","k",
												 "l", "m", "n", "o","p",
												 "q", "r", "s", "t","u",
												 "v", "w", "x", "y", "z",
												 "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                                                 "Backspace"
	};

    private void OnEnable()
    {
        avro.setLoader(new PhoneticXmlLoader());
        TextManager.current_text = "";
    }

    private void OnDisable()
    {
        
    }


    void OnSceneGUI()
	{

        var _target = (KeyInput)target;
		int controlID = GUIUtility.GetControlID(FocusType.Passive);
		Event e = Event.current;

		PreventHotKeys(hotKeys);


        if (Event.current.type == EventType.keyUp && Event.current.keyCode == KeyCode.Backspace)
        {
            TextManager.remove_from_end();
        }
        else if (Event.current.type == EventType.keyUp && Event.current.keyCode == KeyCode.Space)
        {
            TextManager.append(" ");
        }
        else if (Event.current.control && Event.current.alt)
        {
            if (Event.current.GetTypeForControl(controlID) == EventType.keyDown)
            {
                if (Event.current.keyCode == KeyCode.F7)
                {
                    TextManager.append("Ǝ");
                }
            }
        }
        else if (Event.current.GetTypeForControl(controlID) == EventType.keyDown)
        {
            if (Event.current.keyCode == KeyCode.None)
            {
                TextManager.append(Event.current.character.ToString());
            }
        }

        string[] input_text_splitted = TextManager.current_text.Split('Ǝ');
        string unicode_text = "";
        bool odd = true;
        foreach (string s in input_text_splitted)
        {
            if (odd)
            {
                unicode_text += avro.parse(s);
                odd = false;
            }
            else
            {
                unicode_text += s;
                odd = true;
            }

        }
        string ascii = _target.unicode_ansi_handler.get_ascii_word(unicode_text);
        _target.text_field.text = ascii;
        EditorUtility.SetDirty(_target.text_field);

    }

    public static void PreventHotKeys(string[] keys)
	{
		foreach (string s in keys)
		{
			PreventUserHotkey(s);
		}
	}


	public static bool PreventUserHotkey(string hotkey)
	{
		Event e = Event.current; // Grab the current event
		if (e.type == EventType.keyDown && e.isKey && e.Equals(Event.KeyboardEvent(hotkey)))
		{
			e.Use(); // We don't want to propagate the event            
			return true;
		}
		return false;
	}

}
