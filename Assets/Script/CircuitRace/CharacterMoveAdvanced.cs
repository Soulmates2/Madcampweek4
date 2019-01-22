using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoveAdvanced : MonoBehaviour
{
    public Vector3 speed;
    float Accel;
    public Rigidbody PlayerRigidBody;
    public bool Is_MyCharacter = false;
    public int Item = 0;
    public GameObject Sphere;
    public GameObject FA;
    public GameObject BA1;
    public GameObject BA2;

    public float Half_Accelerate = 2.0f;
    public float Accelerate = 1.0f;
    public float HighSpeed = 700.0f;
    public float BoostingHighSpeed = 900.0f;

    private Rigidbody MyCarRigidBody;
    public Image ItemBox;
    public Sprite[] ItemImage;
    public Transform LShootPosition;
    public Transform ShootPosition;
    public Transform RShootPosition;
    public Transform LBackPosition;
    public Transform BackPosition;
    public Transform RBackPosition;

    // Start is called before the first frame update
    

    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public AudioClip[] EffectSound;
    public AudioSource audioSource;

    void Start()
    {
        //AudioListener = MenuBackGroundMusicScript.instance;
        ItemBox = GameObject.FindGameObjectWithTag("ItemBox").GetComponent<Image>();
        //Sphere = GameObject.Find("Sphere");
        foreach (AxleInfo axleInfo in axleInfos)
        {

        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Is_MyCharacter)
        {
            UseItem();
            if (Input.GetKey(KeyCode.Space))
            {
                foreach (AxleInfo ax in axleInfos)
                {
                    ax.leftWheel.motorTorque = 0.0f;
                    ax.rightWheel.motorTorque = 0.0f;
                    ax.leftWheel.brakeTorque = 10000.0f;
                    ax.rightWheel.brakeTorque = 10000.0f;
                }
                if (PlayerRigidBody.velocity.sqrMagnitude > 35.0f)
                {
                    PlayerRigidBody.velocity -= PlayerRigidBody.gameObject.transform.forward * 0.5f;
                }
                else
                {
                    PlayerRigidBody.velocity = Vector3.zero;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (AxleInfo ax in axleInfos)
                {
                    ax.leftWheel.motorTorque = 0.0f;
                    ax.rightWheel.motorTorque = 0.0f;
                    ax.leftWheel.brakeTorque = 0.0f;
                    ax.rightWheel.brakeTorque = 0.0f;
                }
            }
        }
    }

    public void FixedUpdate()
    {
        
        if (Is_MyCharacter)
        {
            //Debug.Log(PlayerRigidBody.velocity.sqrMagnitude);

            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            foreach (AxleInfo axleInfo in axleInfos)
            {
                axleInfo.leftWheel.motorTorque = 0.0f;
                axleInfo.rightWheel.motorTorque = 0.0f;
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;

                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //axleInfo.leftWheel.motorTorque = 20 * maxMotorTorque;
                    //axleInfo.rightWheel.motorTorque = 20 * maxMotorTorque;
                    if (PlayerRigidBody.velocity.sqrMagnitude < HighSpeed/2)
                    {
                        PlayerRigidBody.velocity += PlayerRigidBody.gameObject.transform.forward * 0.3f * Half_Accelerate;
                    }else if (PlayerRigidBody.velocity.sqrMagnitude < HighSpeed)
                    {
                        PlayerRigidBody.velocity += PlayerRigidBody.gameObject.transform.forward * 0.3f * Accelerate;
                    }else if(PlayerRigidBody.velocity.sqrMagnitude > HighSpeed + 20.0f)
                    {
                        PlayerRigidBody.velocity -= PlayerRigidBody.gameObject.transform.forward * 0.1f;
                    }
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //axleInfo.leftWheel.motorTorque = 20 * maxMotorTorque;
                    //axleInfo.rightWheel.motorTorque = 20 * maxMotorTorque;
                    PlayerRigidBody.velocity -= PlayerRigidBody.gameObject.transform.forward * 0.15f;
                }
            }

            if(PlayerRigidBody.velocity.sqrMagnitude > 5.0f)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource = GetComponent<AudioSource>();
                    audioSource.clip = EffectSound[0];
                    audioSource.mute = false;
                    audioSource.volume = 0.5f * PlayerPrefs.GetFloat("BGMVolume", 0.1f);
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; // is this wheel attached to motor?
        public bool steering; // does this wheel apply steer angle?
    }

    private void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Item == ItemKindDefinition.NO_ITEM)
            {
                
            }
            // BLUE: BARRIER
            if (Item == ItemKindDefinition.BLUE_FIRST)
            {
                PlayerRigidBody.mass *= 10;
                Invoke("Shield", 5);
                Item = ItemKindDefinition.NO_ITEM;
            }
            if (Item == ItemKindDefinition.BLUE_SECOND)
            {
                PlayerRigidBody.mass *= 10;
                Accelerate = 20;
                Half_Accelerate = 40;
                Invoke("Boost", 5);
                Invoke("Shield", 5);
                Debug.Log("Boostset");
                Item = ItemKindDefinition.NO_ITEM;
            }

            // RED: FORWARD ATTACK
            if (Item == ItemKindDefinition.RED_FIRST)
            {
                FA = Instantiate(Sphere);
                FA.transform.position = ShootPosition.position;
                Rigidbody RGBD = FA.GetComponent<Rigidbody>();
                RGBD.AddRelativeForce(transform.forward * 200000000 + transform.up * 100000000 + PlayerRigidBody.velocity);
                RGBD.AddExplosionForce(100, FA.transform.position, 10);

                Item = ItemKindDefinition.NO_ITEM;
            }

            if (Item == ItemKindDefinition.RED_SECOND)
            {
                BA1 = Instantiate(Sphere);
                BA1.transform.position = LShootPosition.position;
                FA = Instantiate(Sphere);
                FA.transform.position = ShootPosition.position;
                BA2 = Instantiate(Sphere);
                BA2.transform.position = RShootPosition.position;
                Rigidbody RGBD1 = BA1.GetComponent<Rigidbody>();
                Rigidbody RGBD2 = FA.GetComponent<Rigidbody>();
                Rigidbody RGBD3 = BA2.GetComponent<Rigidbody>();
                RGBD1.AddRelativeForce(transform.forward * 200000000 + transform.up * 100000000);
                RGBD1.AddExplosionForce(100, FA.transform.position, 10);
                RGBD2.AddRelativeForce(transform.forward * 200000000 + transform.up * 100000000);
                RGBD2.AddExplosionForce(100, FA.transform.position, 10);
                RGBD3.AddRelativeForce(transform.forward * 200000000 + transform.up * 100000000);
                RGBD3.AddExplosionForce(100, FA.transform.position, 10);
                Item = ItemKindDefinition.NO_ITEM;
            }

            // GREEN: BOOST
            if (Item == ItemKindDefinition.GREEN_FIRST)
            {
                Accelerate = 10;
                Half_Accelerate = 20;
                Invoke("Boost", 5);
                Item = ItemKindDefinition.NO_ITEM;
            }
            if (Item == ItemKindDefinition.GREEN_SECOND)
            {
                Accelerate = 25;
                Half_Accelerate = 50;
                Invoke("Boost", 5);
                Item = ItemKindDefinition.NO_ITEM;
            }
            // YELLOW: BACKWARD ATTACK
            if (Item == ItemKindDefinition.YELLOW_FIRST)
            {
                FA = Instantiate(Sphere);
                FA.transform.position = BackPosition.position;
                Rigidbody RGBD = FA.GetComponent<Rigidbody>();
                RGBD.AddRelativeForce(-transform.forward * 200000000 + transform.up * 10000);
                RGBD.AddExplosionForce(100, FA.transform.position, 10);
                Item = ItemKindDefinition.NO_ITEM;
            }
            if (Item == ItemKindDefinition.YELLOW_SECOND)
            {
                BA1 = Instantiate(Sphere);
                BA1.transform.position = LBackPosition.position;
                FA = Instantiate(Sphere);
                FA.transform.position = BackPosition.position;
                BA2 = Instantiate(Sphere);
                BA2.transform.position = RBackPosition.position;
                Rigidbody RGBD1 = BA1.GetComponent<Rigidbody>();
                Rigidbody RGBD2 = FA.GetComponent<Rigidbody>();
                Rigidbody RGBD3 = BA2.GetComponent<Rigidbody>();
                RGBD1.AddRelativeForce(-transform.forward * 200000000 + transform.up * 10000);
                RGBD1.AddExplosionForce(100, FA.transform.position, 10);
                RGBD2.AddRelativeForce(-transform.forward * 200000000 + transform.up * 10000);
                RGBD2.AddExplosionForce(100, FA.transform.position, 10);
                RGBD3.AddRelativeForce(-transform.forward * 200000000 + transform.up * 10000);
                RGBD3.AddExplosionForce(100, FA.transform.position, 10);
                Item = ItemKindDefinition.NO_ITEM;
            }

            ItemBox.sprite = null;

        }

    }
    private void Boost()
    {
        Accelerate = 1;
        Half_Accelerate = 2;
    }
    private void Shield()
    {
        PlayerRigidBody.mass /= 10;
    }


    // GET & UPGRADE ITEM 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TypeScript>() != null)
        {
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Blue Item"))
            {
                Destroy(collision.gameObject);
                if (Item == ItemKindDefinition.BLUE_FIRST)
                {
                    Item = ItemKindDefinition.BLUE_SECOND;
                    ItemBox.sprite = ItemImage[5];
                }
                else if (Item == ItemKindDefinition.BLUE_SECOND)
                {
                    Item = ItemKindDefinition.BLUE_SECOND;
                    ItemBox.sprite = ItemImage[5];
                }
                else
                {
                    Item = ItemKindDefinition.BLUE_FIRST;
                    ItemBox.sprite = ItemImage[4];
                }
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Red Item"))
            {
                Destroy(collision.gameObject);
                if (Item == ItemKindDefinition.RED_FIRST)
                {
                    Item = ItemKindDefinition.RED_SECOND;
                    ItemBox.sprite = ItemImage[1];

                }
                else if (Item == ItemKindDefinition.RED_SECOND)
                {
                    Item = ItemKindDefinition.RED_SECOND;
                    ItemBox.sprite = ItemImage[1];
                }
                else
                {
                    Item = ItemKindDefinition.RED_FIRST;
                    ItemBox.sprite = ItemImage[0];
                }
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Yellow Item"))
            {
                Destroy(collision.gameObject);
                if (Item == ItemKindDefinition.YELLOW_FIRST)
                {
                    Item = ItemKindDefinition.YELLOW_SECOND;
                    ItemBox.sprite = ItemImage[7];
                }
                else if (Item == ItemKindDefinition.YELLOW_SECOND)
                {
                    Item = ItemKindDefinition.YELLOW_SECOND;
                    ItemBox.sprite = ItemImage[7];
                }
                else
                {
                    Item = ItemKindDefinition.YELLOW_FIRST;
                    ItemBox.sprite = ItemImage[6];
                }
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Green Item"))
            {
                Destroy(collision.gameObject);
                if (Item == ItemKindDefinition.GREEN_FIRST)
                {
                    Item = ItemKindDefinition.GREEN_SECOND;
                    ItemBox.sprite = ItemImage[3];
                }
                else if (Item == ItemKindDefinition.GREEN_SECOND)
                {
                    Item = ItemKindDefinition.GREEN_SECOND;
                    ItemBox.sprite = ItemImage[3];
                }
                else
                {
                    Item = ItemKindDefinition.GREEN_FIRST;
                    ItemBox.sprite = ItemImage[2];
                }
            }

            
        }

        // 아이템을 할당하는 코드
        // 위에 보면 ItemBox 라고 하는 Image 변수가 있습니다. 이 이미지 변수에 들어간 아이템에 맞는 이미지를 넣어주시면 됩니다 :)

    }
}
