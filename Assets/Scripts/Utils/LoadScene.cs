using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(int i)
    {
        SceneManager.LoadScene(1);
    }
    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }
}
