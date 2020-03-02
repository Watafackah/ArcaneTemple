using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Dash : ability
{
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;

    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Debug.Log("Using Dash!");
            StartCoroutine(Cast());
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.isKinematic = true;
        }
    }

    public override IEnumerator Cast()
    {
        // GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * dashForce, ForceMode.Impulse);
        //rb.AddForce(Camera.main.transform.forward * dashForce, ForceMode.VelocityChange);
        rb.velocity = (Camera.main.transform.forward * dashForce);
        rb.isKinematic = false;

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
