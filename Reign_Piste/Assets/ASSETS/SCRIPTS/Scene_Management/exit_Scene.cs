using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_Scene : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
        Debug.Log("Button was clicked: " + gameObject.name);
    }
}
