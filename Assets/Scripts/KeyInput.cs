using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Language;

public class KeyInput : MonoBehaviour {

    public Text text_field;
    public UnicodeAnsiHandler unicode_ansi_handler = new UnicodeAnsiHandler();
    public string unicode;
    public TextManager textManager = new TextManager();

    // Use this for initialization
    void Start()
    {
    }

	// Update is called once per frame
	void Update () {
		
	}
}   