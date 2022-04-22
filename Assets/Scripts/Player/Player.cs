using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _enemy;

    private Rigidbody2D _rigidbody2D;
    private int _scoreCount;

    public event UnityAction Died;
    public event UnityAction<int> ScoreChanged;

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Restart();
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void Update()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            Died?.Invoke();
        }
    }

    public void Restart()
    {
        transform.position = _spawnPoint.position;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void OnDied()
    {
        _scoreCount++;
        ScoreChanged?.Invoke(_scoreCount);
    }
}
