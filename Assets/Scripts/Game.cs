using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Player _enemy;
    [SerializeField] private Transform _bulletContainer;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        _player.Restart();
        _enemy.Restart();

        for (int i = 0; i < _bulletContainer.childCount; i++)
        {
            Destroy(_bulletContainer.GetChild(i).gameObject);
        }
    }
}
