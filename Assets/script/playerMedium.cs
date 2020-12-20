using System.Collections;
using UnityEngine;
using TMPro;

public class playerMedium : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    private float minX, maxX, minY, maxY;
    public GameObject tb1;
    public GameObject tb2;

    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;
    public GameObject f5;
    public GameObject f6;
    public GameObject f7;
    public GameObject f8;
    public GameObject f9;
    public GameObject f10;
    public GameObject f11;
    public GameObject f12;
    public GameObject f13;
    public GameObject f14;
    public GameObject f15;
    public GameObject f16;
    public Canvas cw;
    public GameObject[] foods = new GameObject[15];
    public Canvas cgo;




    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    float rot;
    int score;
    int a = 0;
    public GameObject winText;
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public TrailRenderer tr;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip clip1;
    public AudioClip clip2;

    // audioSource.PlayOneShot(eatO);





    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        tr = GetComponent<TrailRenderer>();

        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        foods[0] = f1;
        foods[1] = f2;
        foods[2] = f3;
        foods[3] = f4;
        foods[4] = f5;
        foods[5] = f6;
        foods[6] = f7;
        foods[7] = f8;
        foods[8] = f9;
        foods[9] = f11;
        foods[10] = f12;
        foods[11] = f13;
        foods[12] = f14;
        foods[13] = f15;
        foods[14] = f16;

        

    }

    // Start is called before the first frame update
    void Start()
    {
        tb1.SetActive(false);
        tb2.SetActive(false);
        cw.enabled = false;
        cgo.enabled = false;
        f10.transform.position = new Vector3(Random.Range(-2.6f, 2.6f), Random.Range(-4.8f, 4.3f), 0);
        //        b5.transform.position = new Vector3(Random.Range(-2.6f, 2.6f),Random.Range(-4.8f, 4.3f), 0);
        //        b6.transform.position = new Vector3(Random.Range(-2.6f, 2.6f), Random.Range(-4.8f, 4.3f), 0);


        for (int i = 0; i <= 14; i++)
        {
            foods[i].SetActive(false);
        }
        

        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < 0)
            {
                rot = rotateAmount;
                tb1.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
                //StartCoroutine(stop1());
                tb1.SetActive(true);
            }
            else
            {
                rot = -rotateAmount;
                tb1.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
                //StartCoroutine(stop2());
                tb1.SetActive(true);
            }

            transform.Rotate(0, 0, rot);
        }
        else
        {
            tb1.SetActive(false);
            tb2.SetActive(false);
        }
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX)
        {
            tr.time = 0; pos.x = -minX;
            transform.position = pos;
            StartCoroutine(stop());
        }
        if (pos.x > maxX)
        {
            tr.time = 0; pos.x = -maxX;
            transform.position = pos;
            StartCoroutine(stop());
        }

        // vertical contraint
        if (pos.y < minY)
        {
            tr.time = 0; pos.y = -(minY + 1);
            transform.position = pos;
            StartCoroutine(stop());
        }
        if (pos.y > maxY - 1)
        {
            tr.time = 0; pos.y = -maxY;
            transform.position = pos;
            StartCoroutine(stop());
        }

        // Update position
        //        transform.position =pos;
        //        StartCoroutine(stop());
    }

    IEnumerator stop()
    {

        yield return new WaitForSeconds(0.1f);
        tr.time = 0.6f;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "danger")
        {
            moveSpeed = 0;

            StartCoroutine(Break());


        }
        else if (collision.gameObject.tag == "food")
        {
            audioSource2.PlayOneShot(clip2);
            foods[a].transform.position = new Vector3(Random.Range(-2.4f, 2.4f), Random.Range(-4.5f, 4.0f), 0);
            foods[a].SetActive(true);

            Destroy(collision.gameObject);



            score++;
            text.text = score.ToString() + "/15";

            

            a++;
            print(score);
            if (score == 15)
            {
                print("Level Complete");
                winText.SetActive(true);
                Time.timeScale = 0;
                cw.enabled = true;
            }


        }


    }
    private IEnumerator Break()
    {
        particle.Play();

        audioSource1.PlayOneShot(clip1);

        //audioSource.PlayOneShot(audioSource.eatO);
        sr.enabled = false;
        bc.enabled = false;
        tr.enabled = false;


        //yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        cgo.enabled = true;
    }

}






