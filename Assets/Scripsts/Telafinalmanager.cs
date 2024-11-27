using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Telafinalmanager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private string nomeDomenu;

    public void Restart()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }
    public void IrMenu()
    {
        SceneManager.LoadScene(nomeDomenu);
    }
   
}
