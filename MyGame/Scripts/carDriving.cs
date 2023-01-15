using UnityEngine;

public class carDriving : MonoBehaviour
{
    Rigidbody2D carRb;
    [SerializeField]
    int beschleinigung;
    [SerializeField]
    float lenkungsKraft;
    float lenkungsMenge;
    float speed;
    float richtung;

    private void Start()
    {
        carRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        lenkungsMenge = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * beschleinigung;
        richtung = Mathf.Sign(Vector2.Dot(carRb.velocity, carRb.GetRelativeVector(Vector2.up)));
        carRb.rotation += lenkungsMenge * lenkungsKraft * carRb.velocity.magnitude * richtung;
        carRb.AddRelativeForce(Vector2.up * speed);
        carRb.AddRelativeForce(-Vector2.right * carRb.velocity.magnitude * lenkungsMenge / 2);
    }
}
