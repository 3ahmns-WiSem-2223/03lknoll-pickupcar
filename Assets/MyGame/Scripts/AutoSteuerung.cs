using UnityEngine;

public class AutoSteuerung : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private float carYMove;
    [SerializeField] private float carXMove;
    

    void Update()
    {
        if (Input.GetKey("w"))
        {
            carYMove = carYMove + 0.05f;
        }
        if (Input.GetKey("d"))
        {
            carXMove = carXMove + 0.05f;
        }
        if (Input.GetKey("s"))
        {
            carYMove = carYMove - 0.05f;
        }
        if (Input.GetKey("a"))
        {
            carXMove = carXMove - 0.025f;
        }
        car.transform.position = new Vector3(carXMove, carYMove, 0);
    }
}
