using UnityEngine;

public class ShootState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _bulletTemplate;

    private float _elepsedTime;

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delay)
        {
            Shoot();
            _elepsedTime = 0;
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletTemplate, _shootPoint.position, _shootPoint.rotation);
        bullet.transform.parent = _container;
        bullet.SetDirection(_shootPoint);
    }
}
