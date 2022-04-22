using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Transform _shootPoint;
    private Vector3 _direction;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        TryDestroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }

        Vector2 wallNormal = collision.contacts[0].normal;
        _direction = Vector2.Reflect(_rigidbody2D.velocity, wallNormal).normalized;
        _rigidbody2D.velocity = _direction * _speed;
    }

    public void SetDirection(Transform shootPoint)
    {
        _direction = shootPoint.up;
        _rigidbody2D.velocity = _direction * _speed;
    }

    private void TryDestroy()
    {
        Vector3 minDisablePosition = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f));
        Vector3 maxDisablePosition = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f));

        if (transform.position.x < minDisablePosition.x ||
            transform.position.x > maxDisablePosition.x ||
            transform.position.y < minDisablePosition.y ||
            transform.position.y > maxDisablePosition.y)
        {
            Destroy(gameObject);
        }
    }
}
