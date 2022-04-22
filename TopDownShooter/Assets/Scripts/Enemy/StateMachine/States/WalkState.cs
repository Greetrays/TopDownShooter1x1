using UnityEngine;

public class WalkState : State
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        Walk();
        Rotate();
    }

    private void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 difference = Target.transform.position - transform.position;
        difference.Normalize();
        float zRotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}
