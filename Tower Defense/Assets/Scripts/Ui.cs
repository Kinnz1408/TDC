using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour {
    public Text GoldText;
    public int Gold;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GoldText.text = "" + Gold;
    }
    public void AddGold() {

        Gold++;
    }
}
