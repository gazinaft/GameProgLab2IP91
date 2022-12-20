using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public PlayerStateful ps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ps.controller.Move(ps.move * 4);
            // rb.AddForce(ps.move * 2, ForceMode.Impulse);
        }
    }
}
