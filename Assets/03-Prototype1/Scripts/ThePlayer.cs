using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class ThePlayer : MonoBehaviour
{
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    public float speed = 0;
    private float movementX;
    private float movementY;
    private int count;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Capsules: " + count.ToString();
        if (count >= 22)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Capsule"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
