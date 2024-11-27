using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance; // Singleton para acessar de outras cenas.
    public int selectedSkinIndex = 0;   // Índice da skin selecionada.
    public delegate void SkinChanged(int newSkinIndex); 
    public event SkinChanged OnSkinChanged;

    private static bool instanceExists = false;
    private void Awake()
    {
        Debug.Log("Awake called in SkinManager");

        if (!instanceExists)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistir entre cenas.
            instanceExists = true;
            Debug.Log("SkinManager Instance created");
        }
        else
        {
            Debug.Log("Duplicate SkinManager instance detected. Destroying this instance.");
            Destroy(gameObject);
        }
    }

    public void SelectSkin(int index)
    {
        selectedSkinIndex = index;
        Debug.Log("Skin selecionada: " + selectedSkinIndex);

        OnSkinChanged?.Invoke(selectedSkinIndex);
        Debug.Log("OnSkinChanged event invoked");
    }
}

