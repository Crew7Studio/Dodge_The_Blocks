using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xClamp;
    [SerializeField] private float _slowTime = 2f;

    private Rigidbody2D _rbd;
    

    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xMov =  Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
        Vector2 newPos = _rbd.position + Vector2.right * xMov;

        newPos.x = Mathf.Clamp(newPos.x, -_xClamp, _xClamp);        // Clamping the player so it won't go out of play area

        _rbd.MovePosition(newPos);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.GameOver();
    }
}
