using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPley = false;

    void Start()
    {
        isPley = true;
    }

    public void OnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
