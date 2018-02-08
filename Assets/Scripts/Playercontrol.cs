using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontrol : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text WinText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }
    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Счет: " + count.ToString ();
        if (count >=20)
        {
            WinText.text = "Ты победил(а)!";
        }
    }
}
