
using UnityEngine;
using InteractionSystem.Runtime.Core; // IInteractable arayüzünü kullanmak için

namespace InteractionSystem.Runtime.Interactions
{
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Door Settings")]
        [SerializeField] private bool m_IsOpen = false;         // Kapý açýk mý kapalý mý?
        [SerializeField] private float m_OpenAngle = 90f;       // Açýlýnca kaç derece dönsün?


        // Oyuncu 'E'ye bastýðýnda burasý çalýþýr
        public void OnInteract()
        {
            m_IsOpen = !m_IsOpen;          // Kapý açýksa kapat, kapalýysa aç


            float targetAngle = m_IsOpen ? m_OpenAngle : 0f;                 // Kapýyý kendi ekseninde (Y ekseninde) döndür

            transform.localRotation = Quaternion.Euler(0, targetAngle, 0);   //Kapýyý döndür (Quaternion kullanmak açý karýþýklýklarýný önler)

            // Console'a durumu yazdýr (Hata takibi için çok önemli)
            Debug.Log("Sistem: Kapý durumu deðiþti. Yeni durum Açýk mý?: " + m_IsOpen);
        }

        // Arayüzün (Interface) istediði diðer zorunlu kýsýmlar
        public bool CanInteract() => true;
        public string GetInteractionPrompt() => m_IsOpen ? "Kapat (E)" : "Aç (E)";
        public void OnInteractionStart() { }
        public void OnInteractionEnd() { }

    }
}