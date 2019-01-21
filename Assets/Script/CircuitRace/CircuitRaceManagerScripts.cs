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

    private float rotate = 0;
    private Quaternion RotateNiddle;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            MenuBackGroundMusicScript a = MenuBackGroundMusicScript.instance;
            a.menu = false;
            a.GameBackGroundMusic();
        }
        catch
        {

        }
        var CircuitRaceManager = GameObject.FindWithTag("CircuitRaceManager").GetComponent<CircuitManagerScripts>();
        Instantiate(Map[CircuitRaceManager.MapKind]);
        if (CircuitRaceManager.MapKind == 0)
        {
            rotate = 180.0f;
        }
        if (CircuitRaceManager.MapKind == 1)
        {
            rotate = -90.0f;
        }
        RotateNiddle = Niddle.transform.rotation;

        GameObject[] StartPositionObject = GameObject.FindGameObjectsWithTag("StartPosition");
        Player = Instantiate(Car[CircuitRaceManager.CarKind], StartPositionObject[0].transform.position, Quaternion.Euler(0, rotate, 0));
        
        Player.GetComponentInChildren<CharacterMoveAdvanced>().Is_MyCharacter = true;
        MyCarRigidBody = Player.GetComponentInChildren<Rigidbody>();
        Camera MinimapCamera = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();

        AI = new GameObject[7];
        for(int i = 0; i < 7; i++)
        {
            AI[i] = Instantiate(Car[Random.Range(0, Car.Length)], StartPositionObject[i+1].transform.position, Quaternion.Euler(0, rotate, 0));
            Camera[] Cam = AI[i].GetComponentsInChildren<Camera>();
            foreach(Camera c in Cam)
            {
                c.enabled = false;
            }
            AI[i].GetComponentInChildren<CharacterMoveAdvanced>().Is_MyCharacter = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // 이 부분이 Niddle 을 조종하는 코드입니다. 지금은 단순히 회전만 합니다. 실제 rigid body를 움직이는것처럼 해주세요!
        float velocity = MyCarRigidBody.velocity.sqrMagnitude;
        Niddle.transform.rotation = RotateNiddle;
        Niddle.transform.Rotate(0.0f, 0.0f, -velocity/2 * 0.5f);
    }
}
