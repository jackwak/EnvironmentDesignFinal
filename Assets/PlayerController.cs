using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    public Animator _animator;

    [SerializeField] private float hor;

    Rigidbody2D rb;

    bool isOpen = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hor * _moveSpeed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Fire Base")
        {
            textMeshProUGUI.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isOpen)
                {
                    collision.transform.GetChild(0).gameObject.SetActive(!isOpen);
                }
                else
                {
                    collision.transform.GetChild(0).gameObject.SetActive(isOpen);
                }
            }
        }
        else
        {
            textMeshProUGUI.enabled = false;
        }
    }
}
