using UnityEngine;
using InteractionSystem.Runtime.Core;

namespace InteractionSystem.Runtime.Player
{
    public class InteractionDetector : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float m_InteractionRange = 3.0f;
        [SerializeField] private LayerMask m_InteractableLayer;

        [Header("References")]
        [SerializeField] private Camera m_PlayerCamera;

        private IInteractable m_CurrentInteractable;

        private void Update()
        {
            DetectInteractable();
            HandleInput();
        }

        private void DetectInteractable()
        {
            if (m_PlayerCamera == null) return;

            Ray ray = m_PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableLayer))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    m_CurrentInteractable = interactable;
                    return;
                }
            }
            m_CurrentInteractable = null;
        }

        private void HandleInput()
        {
            if (m_CurrentInteractable == null) return;

            if (Input.GetKeyDown(KeyCode.E))
            {
                m_CurrentInteractable.OnInteract();
            }
        }
    }
}