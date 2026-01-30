using UnityEngine;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Camera m_PlayerCamera;
        [SerializeField] private float m_InteractionRange = 3f;
        [SerializeField] private LayerMask m_InteractableLayer;

        void Update()
        {
            // E tuþuna basýldýðýnda etkileþimi baþlat
            if (Input.GetKeyDown(KeyCode.E))
            {
                PerformInteraction();
            }
        }

        private void PerformInteraction()
        {
            // Kamera yoksa iþlemi durdur
            if (m_PlayerCamera == null) return;

            Ray ray = new Ray(m_PlayerCamera.transform.position, m_PlayerCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableLayer))
            {
                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
                if (interactable != null)
                {
                    interactable.OnInteract();
                }
            }
        }

        // Scene ekranýnda ýþýný kýrmýzý çizgi olarak görmek için:
        private void OnDrawGizmos()
        {
            if (m_PlayerCamera == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawRay(m_PlayerCamera.transform.position, m_PlayerCamera.transform.forward * m_InteractionRange);
        }
    }
}