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

    private Rigidbody MyCarRigidBody;
    public Image ItemBox;
    // Start is called before the first frame update

    void Start()
    {
        ItemBox = GameObject.FindGameObjectWithTag("Item").GetComponent<Image>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Is_MyCharacter)
        {
            CharacterMove();
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


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
           // 아이템을 사용하는 코드. 굉장히 길어지겠군요 이부분도 떼서 함수로 작업합시다.
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TypeScript>() != null)
        {
            //지금 여기 아이템 업그레이드가 되지 않습니다. 아이템이 실제로 업그레이드 되는 코드를 작성해주세요
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Blue Item"))
            {
                Item = ItemKindDefinition.BLUE_FIRST;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Red Item"))
            {
                Item = ItemKindDefinition.RED_FIRST;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Yellow Item"))
            {
                Item = ItemKindDefinition.YELLOW_FIRST;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.GetComponent<TypeScript>().GetTypeScript().Equals("Green Item"))
            {
                Item = ItemKindDefinition.GREEN_FIRST;
                Destroy(collision.gameObject);
            }
        }

        // 아이템을 할당하는 코드
        // 위에 보면 ItemBox 라고 하는 Image 변수가 있습니다. 이 이미지 변수에 들어간 아이템에 맞는 이미지를 넣어주시면 됩니다 :)

    }
}

