using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script {
    [Serializable]
    public struct FileSave {

        public List<SerializableCube> CubesTransforms ;

        public FileSave(List<GameObject> gameObjects) {
            CubesTransforms = new List<SerializableCube>();
            foreach (GameObject o in gameObjects) {
                SerializableCube serializableCube = new SerializableCube{
                    Position = o.transform.position,
                    Rotation = o.transform.rotation,
                    Scale = o.transform.localScale,
                    Velocity = o.GetComponent<Rigidbody>().velocity,
                    Angular = o.GetComponent<Rigidbody>().angularVelocity,
                    Color = o.GetComponent<MeshRenderer>().material.color
                };
                CubesTransforms.Add(serializableCube);
            }
        }

        public void Save(string cubeData)
        {
            string path = Application.streamingAssetsPath + "/CubesData.json";
            File.WriteAllText(path, cubeData);
        }

        public string Load()
        {
            string path = Application.streamingAssetsPath + "/CubesData.json";
            return File.ReadAllText(path);
        }
    }
}