using System.Collections.Generic;
using Script;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public GameObject CubePrefab;

    private List<GameObject> _cubeList = new List<GameObject>();
    private string _savedData;
    
    private void Update() {
        if (Input.GetButton("Jump")) {
            GameObject instantiate = Instantiate(CubePrefab, transform.position, Quaternion.identity);
            instantiate.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            _cubeList.Add(instantiate);
        }
        if (Input.GetButtonDown("Fire1")) {
            // Serialization process
            FileSave fileSave = new FileSave(_cubeList);
            _savedData = JsonUtility.ToJson(fileSave);
            fileSave.Save(_savedData);
        }
        if (Input.GetButtonDown("Fire2")) {
            // Clear state
            foreach (GameObject o in _cubeList) {
                Destroy(o);
            }
            _cubeList.Clear();
            // Deserialization process
            FileSave fileSave = JsonUtility.FromJson<FileSave>(new FileSave().Load());
            foreach (SerializableCube serializableCube in fileSave.CubesTransforms) {
                GameObject instantiate = Instantiate(CubePrefab, transform.position, Quaternion.identity);
                instantiate.transform.position = serializableCube.Position;
                instantiate.transform.rotation = serializableCube.Rotation;
                instantiate.transform.localScale = serializableCube.Scale;
                instantiate.GetComponent<Rigidbody>().velocity = serializableCube.Velocity;
                instantiate.GetComponent<Rigidbody>().angularVelocity = serializableCube.Angular;
                instantiate.GetComponent<MeshRenderer>().material.color = serializableCube.Color;
                _cubeList.Add(instantiate);
            }
        }
    }

}