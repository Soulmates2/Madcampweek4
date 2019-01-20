using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoveScripts : MonoBehaviour
{
    public Vector3 speed;
    float Accel;
    public Rigidbody PlayerRigidBody;
    public bool Is_MyCharacter = false;
    public int Item = 0;
    public GameObject Sphere;

    private Rigidbody MyCarRigidBody;
    public Image ItemBox;
    // Start is called before the first frame update

    void Start()
    {
        //ItemBox = GameObject.FindGameObjectWithTag("Item").GetComponent<Image>();
        Sphere = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Is_MyCharacter)
        {
            CharacterMove();
            UseItem();
        }
    }

    void CharacterMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Accel < 0.1f && Accel > -0.1f)
            {
                transform.Rotate(new Vector3(0, -Time.deltaTime * 320.0f, 0) * Accel);
            }
            else
                transform.Rotate(new Vector3(0, -Time.deltaTime * 160.0f, 0) * Accel);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Accel < 0.1f && Accel > -0.1f)
            {
                transform.Rotate(new Vector3(0, Time.deltaTime * 320.0f, 0) * Accel);
            }
            else
                transform.Rotate(new Vector3(0, Time.deltaTime * 160.0f, 0) * Accel);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Accel <= 0.5f)
            {
                Accel += 0.003f;
                transform.position += (transform.forward) * Accel;
                //speed += new Vector3(0, 0, 0.1f);
                //PlayerRigidBody.velocity = speed;
                //PlayerRigidBody.AddForce(0, 0, 80f * Time.deltaTime);
                //transform.GetComponent<Rigidbody>().AddForce(0,0, 80f * Time.deltaTime);
            }
            else
            {
                transform.position += (transform.forward) * Accel;
            }
        }
        else
        {
            if (Accel > 0)
            {
                Accel -= 0.003f;
                transform.position += (transform.forward) * Accel;
            }
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Accel >= 0f)
            {
                Accel -= 0.001f;

            }
            else if (Accel < 0f && Accel >= -0.3f)
            {
                Accel -= 0.001f;
                transform.position += (transform.forward) * Accel;
            }
            else
            {
                transform.position += (transform.forward) * Accel;
            }
        }
        else
        {
            if (Accel < 0)
            {
                Accel += 0.001f;
                transform.position += (transform.forward) * Accel;
            }
        }
    }
    private void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Item == ItemKindDefinition.NO_ITEM)
            {
                Debug.Log("Sphere");
                GameObject FA = Instantiate(Sphere);
                Debug.Log("Sphere init");
                Rigidbody RGBD = FA.GetComponent<Rigidbody>();
                FA.transform.position = transform.position;
                FA.transform.position += (transform.forward) * 1.0f;
                Debug.Log("Sphere pos");
                RGBD.AddRelativeForce(0, 300, 300);
                Debug.Log("FA pos");
            }
            // BLUE: BARRIER
            if (Item == ItemKindDefinition.BLUE_FIRST)
            {

            }
            if (Item == ItemKindDefinition.BLUE_SECOND)
            {

            }
            // RED: FORWARD ATTACK
            if (Item == ItemKindDefinition.RED_FIRST)
            {
                GameObject FA = Instantiate(Sphere);
                FA.transform.position = transform.position;
                FA.transform.position += (transform.forward) * 1.0f;
            }
            if (Item == ItemKindDefinition.RED_SECOND)
            {

            }
            // GREEN: BOOST
            if (Item == ItemKindDefinition.GREEN_FIRST)
            {

            }
            if (Item == ItemKindDefinition.GREEN_SECOND)
            {

            }
            // YELLOW: BACKWARD ATTACK
            if (Item == ItemKindDefinition.YELLOW_FIRST)
            {

            }
            if (Item == ItemKindDefinition.YELLOW_SECOND)
            {

            }            
        }

    }
    private void FowardAttack(GameObject FA)
    {
        
    }


    // GET & UPGRADE ITEM 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TypeScript>() != null)
        {
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Blue Item"))
            {
                if (Item == ItemKindDefinition.BLUE_FIRST)
                {
                    Item = ItemKindDefinition.BLUE_SECOND;
                    Destroy(collision.gameObject);
                }
                else
                {
                    Item = ItemKindDefinition.BLUE_FIRST;
                    Destroy(collision.gameObject);
                }
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Red Item"))
            {
                if (Item == ItemKindDefinition.RED_FIRST)
                {
                    Item = ItemKindDefinition.RED_SECOND;
                    Destroy(collision.gameObject);
                }
                else
                {
                    Item = ItemKindDefinition.RED_FIRST;
                    Destroy(collision.gameObject);
                }
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Yellow Item"))
            {
                if (Item == ItemKindDefinition.YELLOW_FIRST)
                {
                    Item = ItemKindDefinition.YELLOW_SECOND;
                    Destroy(collision.gameObject);
                }
                else
                {
                    Item = ItemKindDefinition.YELLOW_FIRST;
                    Destroy(collision.gameObject);
                }
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Green Item"))
            {
                if (Item == ItemKindDefinition.GREEN_FIRST)
                {
                    Item = ItemKindDefinition.GREEN_SECOND;
                    Destroy(collision.gameObject);
                }
                else
                {
                    Item = ItemKindDefinition.GREEN_FIRST;
                    Destroy(collision.gameObject);
                }
            }
        }

        // 아이템을 할당하는 코드
        // 위에 보면 ItemBox 라고 하는 Image 변수가 있습니다. 이 이미지 변수에 들어간 아이템에 맞는 이미지를 넣어주시면 됩니다 :)

    }
}

