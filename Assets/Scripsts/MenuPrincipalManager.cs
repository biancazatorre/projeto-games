using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeSingle;
    [SerializeField] private string nomeDoLevelDeMulti;
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject MenusSkins;

    public void JogarSingle()
    {
        SceneManager.LoadScene(nomeDoLevelDeSingle);
    }
    public void JogarMulti()
    {
        SceneManager.LoadScene(nomeDoLevelDeMulti);
    }
    public void Sair()
    {
        Debug.Log("saindo do jogo");
        Application.Quit();
    }
    public void AbrirSkins()
    {
        MenuPrincipal.SetActive(false);
        MenusSkins.SetActive(true);
    }
    public void AbrirMenuPrincipal() 
    {   
        MenusSkins.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
}
