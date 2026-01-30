
using UnityEngine;
using InteractionSystem.Runtime.Core; // IInteractable arayüzünü kullanmak için

namespace InteractionSystem.Runtime.Interactions
{
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Door Settings")]
        [SerializeField] private bool m_IsOpen = false; // Kapý açýk mý kapalý mý?
        [SerializeField] private float m_OpenAngle = 90f; // Açýlýnca kaç derece dönsün?

        // Oyuncu 'E'ye bastýðýnda burasý çalýþýr
        public void OnInteract()
        {
            m_IsOpen = !m_IsOpen; // Açýksa kapat, kapalýysa aç
            // Kapýyý Y ekseninde (kendi etrafýnda) döndür
            float targetAngle = m_IsOpen ? m_OpenAngle : 90f;
            transform.localEulerAngles = new Vector3(0, targetAngle, 0);

            Debug.Log(m_IsOpen ? "Kapý açýldý!" : "Kapý kapandý!");
        }
        
        // Arayüzün (Interface) istediði diðer zorunlu kýsýmlar
        public bool CanInteract() => true;
        public string GetInteractionPrompt() => m_IsOpen ? "Kapat (E)" : "Aç (E)";
        public void OnInteractionStart() { }
        public void OnInteractionEnd() { }

    }
}