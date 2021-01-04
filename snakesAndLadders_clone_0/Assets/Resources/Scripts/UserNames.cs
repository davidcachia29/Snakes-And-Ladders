using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserNames : MonoBehaviour
{
    public Text Username_field;
    public string playername;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameChange()
    {        
        playername = Username_field.text.ToString();
        Debug.Log(playername);
    }
}
