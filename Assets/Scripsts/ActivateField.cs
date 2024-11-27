using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateField : MonoBehaviour
{
    [SerializeField] private GameObject[] fields; // Array com os campos (GameObjects)

    private void Start()
    {
        Debug.Log("Start called in ActivateField");

        // Verifica se o SkinManager está configurado
        if (SkinManager.Instance != null)
        {
            // Obter o índice da skin selecionada
            int selectedSkinIndex = SkinManager.Instance.selectedSkinIndex;
            Debug.Log("Selected skin index in Start: " + selectedSkinIndex);

            // Ativar o campo correspondente e desativar os demais
            ActivateSelectedField(selectedSkinIndex);
        }
    }

    private void ActivateSelectedField(int index)
    {
        Debug.Log("ActivateSelectedField called with index: " + index);

        // Iterar por todos os campos e ativar apenas o escolhido
        for (int i = 0; i < fields.Length; i++)
        {
            fields[i].SetActive(i == index);
            Debug.Log("Field " + i + " set to " + (i == index));
        }
    }
    private void OnDestroy()
    { // Desinscrever do evento quando o objeto for destruído
      if (SkinManager.Instance != null) 
        {
         SkinManager.Instance.OnSkinChanged -= ActivateSelectedField; 
        } 
    }
}
