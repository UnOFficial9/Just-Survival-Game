using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Transform camera;
    public float speedRotation;
    public float speed;
    private float boost;
    private Rigidbody rb;
    public float jumpForce;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public int Money;
    private Vector3 lastPos;
    private Quaternion lastRot;
    public Transform info;
    private bool showInfo;
    public FixedJoystick joy;
    private bool jump;
    
    void Awake()
    {
        Load();   
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        Rotate();
        Boost();
        Sounds();
        Save();
        ShowInfo();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 
        transform.Translate(new Vector3(h, 0 ,v) * speed * Time.deltaTime * boost);
        transform.Translate(new Vector3(joy.Horizontal, 0, joy.Vertical)* speed * Time.deltaTime * boost);
    }
    private void Rotate()
    {
        /*
        transform.localEulerAngles += new Vector3(0, speedRotation * Input.GetAxis("Mouse X"), 0);
        float angleX = camera.localEulerAngles.x;
        angleX -= speedRotation * Input.GetAxis("Mouse Y");
        if (angleX < 300 && angleX > 180) angleX = 300;
        else if (angleX > 60 && angleX < 180) angleX = 60;
        camera.localEulerAngles = new Vector3(angleX, 0, 0);
        */
        
    }
    private void Boost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = 2;
        }
        else
        {
            boost = 1;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        jump = true;
    }
    public void Jump() 
    {
        if(jump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }   
    }
    private void OnCollisionExit(Collision collision)
    {
        jump = false;
    }
    public void PickUpSound()
    {
        audioSource1.Play();
    }
    void Sounds()
    {
        if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Vertical") == 1)
        {
            Debug.Log("Walking");
            if(!audioSource2.isPlaying)
            {
                audioSource2.Play();
            }

        }
        
        else 
        {
            audioSource2.Stop();
        }

    }
    public void AddCoins(int coins)
    {
        Money = Money + coins;
    }
    void Save()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
        PlayerPrefs.SetInt("money", Money);
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
            
        }
    }
    void Load()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        audioSource1.volume = PlayerPrefs.GetFloat("volume");
        audioSource2.volume = PlayerPrefs.GetFloat("volume");
        if (PlayerPrefs.GetFloat("x") != 0f && PlayerPrefs.GetFloat("z") != 0f)
            lastPos = new Vector3(PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
        else
            lastPos = new Vector3(1231, 40, 1196);
        Money = PlayerPrefs.GetInt("money");
        lastRot = new Quaternion(PlayerPrefs.GetFloat("xRot"), PlayerPrefs.GetFloat("yRot"), PlayerPrefs.GetFloat("zRot"), 0);
        transform.rotation = lastRot;
        transform.position = lastPos;
        Money = PlayerPrefs.GetInt("money");
    }
    void ShowInfo()
    {
        if(Input.GetKey(KeyCode.U))
        {
            showInfo = !showInfo;
        }
        if (showInfo)
        {
            Ray ray = new Ray(transform.position, camera.transform.forward);
            RaycastHit hit;
            Debug.DrawRay(camera.transform.position, camera.transform.forward);
            Physics.Raycast(ray, out hit);
            Transform obj = hit.transform;
            if(obj != null) 
            {
                info.gameObject.SetActive(true);
            }
            else
            {
                info.gameObject.SetActive(false);
            }
            if (obj.gameObject.GetComponent<DestroyableThings>() != null)
            {
                info.Find("Name").GetComponent<Text>().text = obj.gameObject.name;
                info.Find("Hp").GetComponent<Slider>().maxValue = obj.gameObject.GetComponent<DestroyableThings>().health;
                info.Find("Hp").GetComponent<Slider>().value = obj.gameObject.GetComponent<DestroyableThings>().health;
                info.Find("Hp").GetChild(0).GetChild(0).GetComponent<Text>().text = obj.gameObject.GetComponent<DestroyableThings>().health.ToString() + "/"
                + obj.gameObject.GetComponent<DestroyableThings>().maxHealth.ToString();
            }
        }
        else
        {
            info.gameObject.SetActive(false);
        }

        
    }
}
