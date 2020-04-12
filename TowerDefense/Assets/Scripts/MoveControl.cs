using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveControl : MonoBehaviour
{
    public void moveToMain() {
        SceneManager.LoadScene(1);
    }

    public void moveToRestart()
    {
        SceneManager.LoadScene(2);
    }
}
