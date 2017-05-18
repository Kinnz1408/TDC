using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Slider HealthBar;
   
    Ui MyUi;

    [Header("Status")]
    public int Level;
    public int HP;
    public int Attack;
    public int Defense;
    public bool Enemy; // Só para saber quando Adicionar Gold para o Jogador 




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
        HealthBar.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, 0);

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

