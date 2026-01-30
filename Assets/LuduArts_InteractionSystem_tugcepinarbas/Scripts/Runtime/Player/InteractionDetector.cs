using UnityEngine;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private InteractionUI m_UIHandler;      //UI kontrolü
        [SerializeField] private Camera m_PlayerCamera;
        [SerializeField] private float m_InteractionRange = 3f;
        [SerializeField] private LayerMask m_InteractableLayer;


        private void Update()
        {
            // Ray oluþtur
            Ray ray = new Ray(m_PlayerCamera.transform.position, m_PlayerCamera.transform.forward);
            RaycastHit hit;

            //Bir þeye bakýyor muyuz?
            if (Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableLayer))
            {
                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

                if (interactable != null)
                {
                    // Yazýyý göster
                    if (m_UIHandler != null) m_UIHandler.ShowMessage("Press [E] to Open");

                    // E tuþuna basýlýrsa etkileþime gir
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.OnInteract();
                    }
                }
                else
                {
                    // Interactable olmayan bir objeye bakýyorsak yazýyý gizle
                    if (m_UIHandler != null) m_UIHandler.HideMessage();
                }
            }
            else
            {
                // Hiçbir þeye bakmýyorsak yazýyý gizle
                if (m_UIHandler != null) m_UIHandler.HideMessage();
            }
        }
    }
}
        
    