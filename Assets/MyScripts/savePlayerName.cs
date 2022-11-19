using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class savePlayerName : MonoBehaviour
{
    //public TextMeshProUGUI nameField;
    // Start is called before the first frame update
    //public GameObject textDisplay;

    public void savePlayerNameMethod(){
        string name = GetComponent<TMP_InputField>().text;
        Debug.Log("Name: "+ name);

        Usuario.setPlayerName(name);
    }
}
