using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private new GameObject gameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Player1Controller player1Controller;

    private void Update()
    {

        if (playerInteract.GetInteractableObject() != null && player1Controller.player1State == Player1State.Idle)
        {

            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }
    private void Show(IInteractable interactable)
    {
        gameObject.SetActive(true);
        textMeshProUGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        textMeshProUGUI.text = "";
    }

   
}
