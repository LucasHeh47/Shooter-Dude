using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    
    public void LoadScene(string scene)
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Waves"))
        {
            ExpManager.Instance.SaveExp();
        }
        GlobalManager.Instance.LoadScene(scene);
    }

    public void DisableObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void EnableObject(GameObject obj)
    {
        obj.SetActive(true);
    }

}
