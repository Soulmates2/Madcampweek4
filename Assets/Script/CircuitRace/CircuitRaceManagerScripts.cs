using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitRaceManagerScripts : MonoBehaviour
{

    public GameObject[] Map;
    public GameObject[] Car;

    private GameObject Player;
    private GameObject[] AI;
    public GameObject[] Items;

    // Start is called before the first frame update
    void Start()
    {
        var CircuitRaceManager = GameObject.FindWithTag("CircuitRaceManager").GetComponent<CircuitManagerScripts>();
        Instantiate(Map[CircuitRaceManager.MapKind]);

        GameObject[] StartPositionObject = GameObject.FindGameObjectsWithTag("StartPosition");
        Player = Instantiate(Car[CircuitRaceManager.CarKind], StartPositionObject[0].transform.position, Quaternion.Euler(0, 0, 0));
        
        Player.GetComponentInChildren<CharacterMoveScripts>().Is_MyCharacter = true;
        Instantiate(Items[Random.Range(0, Items.Length)], StartPositionObject[0].transform.position + Vector3.forward * 5, Quaternion.Euler(0, 0, 0));

        AI = new GameObject[7];
        for(int i = 0; i < 7; i++)
        {
            AI[i] = Instantiate(Car[Random.Range(0, Car.Length)], StartPositionObject[i].transform.position, Quaternion.Euler(0, 0, 0));
            AI[i].GetComponentInChildren<Camera>().enabled = false;
            AI[i].GetComponentInChildren<CharacterMoveScripts>().Is_MyCharacter = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
