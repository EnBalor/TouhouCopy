using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamIn_controller : MonoBehaviour
{
    [SerializeField]
    GameObject _redHexaGram = null;

    [SerializeField]
    GameObject _blueHexaGram = null;

    void Start()
    {
        GameObject redHexagram = Instantiate(_redHexaGram);

        redHexagram.transform.position = this.transform.position;
        redHexagram.transform.rotation = Quaternion.Euler(0, 0, 90);
        redHexagram.transform.SetParent(this.transform);

        GameObject blueHexagram = Instantiate(_blueHexaGram);
        blueHexagram.transform.position = this.transform.position;
        blueHexagram.transform.rotation = Quaternion.Euler(0, 0, 180);
        blueHexagram.transform.SetParent(this.transform);
    }
}
