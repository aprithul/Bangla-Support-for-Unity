using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Language;

public class KeyInput : MonoBehaviour {

    public Text text_field;
    public UnicodeAnsiHandler unicode_ansi_handler = new UnicodeAnsiHandler();
    public string unicode;


    // Use this for initialization
    void Start()
    {
        var t = " ";
        //print(unicode);
        //t = unicode_ansi_handler.get_ascii_word(bangla);
        text_field.text = t;
    }

	// Update is called once per frame
	void Update () {
		
	}
}   