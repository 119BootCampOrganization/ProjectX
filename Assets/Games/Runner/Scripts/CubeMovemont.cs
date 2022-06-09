using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMovemont : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float sideSpeed = 10f;
    [SerializeField] private float limit = 2.5f;

    public GameObject canvasGameOver;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        float side = Input.GetAxis("Horizontal") * sideSpeed * Time.deltaTime;

        transform.Translate(side, 0f, forwardSpeed * Time.deltaTime);

        if (transform.position.x <= -limit)
        {
            Vector3 _position = new Vector3(-limit, transform.position.y, transform.position.z);
            transform.position = _position;
        }
        else if (transform.position.x >= limit)
        {
            Vector3 _position = new Vector3(limit, transform.position.y, transform.position.z);
            transform.position = _position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GWall")
        {
            canvasGameOver.SetActive(true);
            animator.enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<CubeMovemont>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        //Application.Quit();
    }

}
