using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionText; // Inspector'dan yazýyý buraya sürükleyeceðiz

    private void Start()
    {
        HideMessage(); // Oyun baþlarken yazý gizli olsun
    }

    public void ShowMessage(string message)
    {
        interactionText.text = message;
        interactionText.gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        interactionText.gameObject.SetActive(false);
    }
}