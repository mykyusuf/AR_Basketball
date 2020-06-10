using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class top : MonoBehaviour {

    Vector3 temp;
    public float thrust;
    public Rigidbody rb;
    private GameObject videoplayer;
    private GameObject sayi;
    private VideoPlayer videofile;
    public float t;
    public float t2;
    // Use this for initialization
    void Start () {


        rb = GetComponent<Rigidbody>();
        temp = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseDown()
    {
        t = Time.time;

        // this object was clicked - do something
        Debug.Log("dokunduu");
        
    }


    void OnBecameInvisible()
    {
        Debug.Log(transform.position);
		if (transform.position.y < temp.y)
		{
			transform.position = temp;
			rb.isKinematic = true;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = new Vector3(0f, 0f, 0f);
			rb.useGravity = false;
		}

    }

    void OnMouseUp()
    {
        t2 = Time.time;
        
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * 30f);
        rb.AddForce(Vector3.forward * 40f * (t2-t));
    }

    void OnCollisionEnter(Collision collision)
    {
        //Ouput the Collision to the console
        if (collision.gameObject.tag == "goal")
        {

            Debug.Log("goool");
            transform.position = temp;
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            sayi = GameObject.FindGameObjectWithTag("sayi");
            var s =  int.Parse( sayi.GetComponent<TextMesh>().text );
            if (s + 10 >= 50)
            {
                SceneManager.LoadScene("menuScene");
            }
            else
            {
                sayi.GetComponent<TextMesh>().text = (s + 10).ToString();
                videoplayer = GameObject.FindGameObjectWithTag("skor");
                videofile = videoplayer.GetComponent<UnityEngine.Video.VideoPlayer>();
                videofile.Play();
            }

        }

    }
}
