using System;
using UnityEngine;

namespace Script {
    [Serializable]
    public struct SerializableCube {

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        public Vector3 Velocity;
        public Vector3 Angular;
        public Color Color;

    }
}