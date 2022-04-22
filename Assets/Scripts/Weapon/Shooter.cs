using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _bulletTemplate;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletTemplate, _shootPoint.position, _shootPoint.rotation);
        bullet.transform.parent = _container;
        bullet.SetDirection(_shootPoint);
    }
}
