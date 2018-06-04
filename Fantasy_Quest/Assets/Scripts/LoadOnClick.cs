using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene1()
    {
        Application.LoadLevel(1);
    }
    public void LoadScene2()
    {
        Application.LoadLevel(2);
    }
    public void LoadScene3()
    {
        Application.LoadLevel(3);
    }
    public void LoadHelp()
    {
        Application.LoadLevel(6);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
