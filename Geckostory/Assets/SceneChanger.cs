using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public void Trigger()
    {
        SceneManager.LoadScene("my_vr_scene_3");
    }
}
