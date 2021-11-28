using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 20f;

    private void Update()
    {
        Vector3 target = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}