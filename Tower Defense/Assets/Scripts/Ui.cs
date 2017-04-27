using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour {
    [HideInInspector] public Text GoldText;
    public int Gold;
    [HideInInspector] public Transform towerCanvas;
    [HideInInspector] public Transform towerCanvas1;
    SpawnPlayer Sp;


    // Use this for initialization
    void Start () {
        Sp = GameObject.Find("Ui").GetComponent<SpawnPlayer>();
		
	}
	
	// Update is called once per frame
	void Update () {
        GoldText.text = "" + Gold;
    }
    public void AddGold() {

        Gold++;
    }
    public void TowerCanvas()
    {

        if (towerCanvas1.gameObject.activeInHierarchy == true) {

            towerCanvas1.gameObject.SetActive(false);
        }

        if (towerCanvas.gameObject.activeInHierarchy == false)
        {

            towerCanvas.gameObject.SetActive(true);


        }
        else
        {
            towerCanvas.gameObject.SetActive(false);


        }

    }
    public void TowerCanvas01()
    {

        if (towerCanvas.gameObject.activeInHierarchy == true)
        {

            towerCanvas.gameObject.SetActive(false);
        }

        if (towerCanvas1.gameObject.activeInHierarchy == false)
        {

            towerCanvas1.gameObject.SetActive(true);


        }
        else
        {
            towerCanvas1.gameObject.SetActive(false);


        }

    }
    public void SetCanvasOff() { 
        if (towerCanvas.gameObject.activeInHierarchy == true&&Sp.shutOffCanvas)
        {

            towerCanvas.gameObject.SetActive(false);
        } else if (towerCanvas1.gameObject.activeInHierarchy == true && Sp.shutOffCanvas)
        {

            towerCanvas1.gameObject.SetActive(false);
        }













    }
}
