using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public int speed = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.position = new Vector3(-2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime); 

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),
                                        Input.GetAxis("Vertical"),
                                        0)
                                         * Time.deltaTime * speed);

    }
}
