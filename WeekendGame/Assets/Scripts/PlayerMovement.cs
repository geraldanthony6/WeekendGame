using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        float Horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movementVector = new Vector3(Horizontal, Vertical, 0);
        transform.Translate(movementVector * _playerSpeed * Time.deltaTime);
    }
}
