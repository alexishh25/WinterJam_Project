using System.ComponentModel;
using UnityEngine;

public class Prueba : MonoBehaviour 
{

    private Rigidbody2D rb2d;
    private Sprite miSprite;
    private SpriteRenderer sr;
    private float thrust = 1f;

    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
        rb2d = gameObject.AddComponent<Rigidbody2D>();
    }

    void Start()
    {
        sr.color = new Color(0.9f, 0.9f, 0.5f, 1.0f);
        sr.sprite = miSprite;
        transform.position = new Vector3(0.0f, -2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        rb2d.AddForce(transform.up * thrust);
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        rb2d.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }
}
