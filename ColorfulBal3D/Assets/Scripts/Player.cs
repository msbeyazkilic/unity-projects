using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Rigidbody rb;
    private Touch touch;
    [Range(20,40)]
    public int speedModifier;
    public int forwardSpeed;
    public GameObject cam;
    public GameObject vectorForward;
    public GameObject vectorBack;
    public CameraShake CameraShake;
    public UIManager uiManager;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Variables.firstTouch == 1)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Variables.firstTouch = 1;
                    break;
                case TouchPhase.Moved:
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                                      transform.position.y,
                                                      touch.deltaPosition.y * speedModifier * Time.deltaTime);
                    break;
                case TouchPhase.Ended:
                    rb.velocity = Vector3.zero;
                    break;
            }
        }
    }

    public GameObject[] fractureItems;

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles")) {
            CameraShake.ShakeCamera();
            uiManager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in fractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            
        }
    }
}
