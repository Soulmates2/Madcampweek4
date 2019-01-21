using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircuitRaceManagerScripts : MonoBehaviour
{

    public GameObject[] Map;
    public GameObject[] Car;

    private GameObject Player;
    private GameObject[] AI;
    public GameObject[] Items;

    public RawImage MinimapArea;
    public Image Niddle;

    public Rigidbody MyCarRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        var CircuitRaceManager = GameObject.FindWithTag("CircuitRaceManager").GetComponent<CircuitManagerScripts>();
        Instantiate(Map[CircuitRaceManager.MapKind]);

        GameObject[] StartPositionObject = GameObject.FindGameObjectsWithTag("StartPosition");
        Player = Instantiate(Car[CircuitRaceManager.CarKind], StartPositionObject[0].transform.position, Quaternion.Euler(0, 0, 0));
        
        Player.GetComponentInChildren<ItemUse>().Is_MyCharacter = true;
        MyCarRigidBody = Player.GetComponentInChildren<Rigidbody>();
        Instantiate(Items[Random.Range(0, Items.Length)], StartPositionObject[0].transform.position + Vector3.forward * 5, Quaternion.Euler(0, 0, 0));

        //Camera MinimapCamera = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();

        AI = new GameObject[7];
        for(int i = 0; i < 7; i++)
        {
            AI[i] = Instantiate(Car[Random.Range(0, Car.Length)], StartPositionObject[i+1].transform.position, Quaternion.Euler(0, 0, 0));
            Camera[] Cam = AI[i].GetComponentsInChildren<Camera>();
            foreach(Camera c in Cam)
            {
                c.enabled = false;
            }
            AI[i].GetComponentInChildren<ItemUse>().Is_MyCharacter = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // 이 부분이 Niddle 을 조종하는 코드입니다. 지금은 단순히 회전만 합니다. 실제 rigid body를 움직이는것처럼 해주세요!
        float velocity = MyCarRigidBody.velocity.sqrMagnitude;
        Niddle.transform.Rotate(0.0f, 0.0f, -velocity * 0.5f);
    }
}
