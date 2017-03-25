using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    public int HP;
    public int Attack;
    public int Defense;
    public int Level;
    // Range Implementar depois 
    //Attack Size implentar depois
    public float CooldownAttack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0) {
            Destroy(gameObject);

        }
	}
}
