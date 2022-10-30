using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour
{
    int ammoCounter;
    int chargesCounter; 

    public int unitsOfAmmo;
    public int unitsOfCharges;

    public Text AmmoTag;
    public Text ChargesTag;
    void Start()
    {
        ammoCounter = unitsOfAmmo;
        chargesCounter = unitsOfCharges; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void minusAmmo(){
        if(ammoCounter > 0){
            ammoCounter -= 1;
            AmmoTag.text = ""+ammoCounter;
        }
        
    }

    public void rechargeAmmo(){
        //if(Input.GetKeyDown(KeyCode.R)){
            //Si aún tengo cartuchos
            if(chargesCounter > 0){
                //Si recargo aún teniendo munición
                ammoCounter += 10;
                chargesCounter -= 10; 
                AmmoTag.text = ""+(ammoCounter);
                ChargesTag.text = ""+(chargesCounter);
            }
        //}
    }

    public int getAmmoCounter(){
        return ammoCounter;
    }

    public void plusAmmo(){
        chargesCounter +=10;
        ChargesTag.text = ""+(chargesCounter);
    }
}
