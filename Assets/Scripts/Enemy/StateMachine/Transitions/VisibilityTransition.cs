using UnityEngine;

public class VisibilityTransition : Transition
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private bool _isVisibility;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, _shootPoint.up * 10);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out PlayerMover player) == _isVisibility)
            {
                NeedTransit = true;
            }
        }

    }
}
