using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter_Scene : MonoBehaviour
{
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
