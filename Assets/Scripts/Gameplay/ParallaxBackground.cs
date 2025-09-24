using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float parallaxEffect;
    private float length, startPos;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float temp =(cam.transform.position.x * (1 - parallaxEffect));
        float dist  =(cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y,transform.position.z);


        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
