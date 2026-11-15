using UnityEngine;

public class Bouncer : MonoBehaviour
{

    public float bounceHorizontal = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
      Debug.Log("Bounce collision");
      if (collision.collider.name == "Player") {
          collision.rigidbody.linearVelocity = new Vector2(bounceHorizontal, 5.0f);
      }
    }
}
