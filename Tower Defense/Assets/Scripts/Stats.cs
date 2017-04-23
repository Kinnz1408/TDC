using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float HP;
    public int Attack;
    public int Defense;
    public bool Enemy;
    Ui MyUi;

    [Header("Health Bar")]
    public Slider HealthBar;



    // Range Implementar depois 
    //Attack Size implentar depois
    //public float CooldownAttack;

    // Use this for initialization
    void Start()
    {
        HealthBar.maxValue = HP;
        GameObject UiManager = GameObject.Find("Ui");
        MyUi = UiManager.GetComponent<Ui>();
        
      //  DamageToDeal = Attack / 2 + Defense / 100;
        //   Debug.Log(DamageToDeal);

    }

    // Update is called once per frame
    void Update()
    {
        
        HealthBar.value = HP;



        if (HP <= 0)
        {
            if (Enemy)
            {
                MyUi.Gold += 2;
            }
            Destroy(gameObject);
        }

    }
   


}

