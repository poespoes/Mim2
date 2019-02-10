using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VineSine : MonoBehaviour
{
//PUBLIC
    [Range(-1,1)] public float offsetIndividual;
    [Range(0,1)] public float offsetGeneral;
    [FormerlySerializedAs("velocidad")] public float speed;
    [FormerlySerializedAs("amplitud")] public float amplitude;


    //PRIVATE
    Chain[] chains;
    Transform parentTransform;
    Transform[] tempTransform;
    List<Transform> listRoots = new List<Transform> ();


    public struct Chain
    {
        public Transform rootJoint;
        public Transform[] joints;
        public Vector3[] jointsOriginalRot;

        public void AlimentarJoints()
        {
            joints = rootJoint.gameObject.GetComponentsInChildren<Transform> ();
            jointsOriginalRot = new Vector3[joints.Length];
            for (int i = 0; i < joints.Length; i++)
            {
                jointsOriginalRot [i] = joints [i].localEulerAngles;
            }
        }

    }



    void Awake()
    {
        parentTransform = transform;
        tempTransform = GetComponentsInChildren<Transform> ();
        chains = new Chain[parentTransform.childCount];

        for (int x = 1; x < tempTransform.Length; x++)
        {
            if (tempTransform [x].parent == parentTransform)
                listRoots.Add (tempTransform [x]);
        }

        for (int i = 0; i < chains.Length; i++)
        {
            chains [i].rootJoint = listRoots [i];
            chains [i].AlimentarJoints ();
        }

    }



    void FixedUpdate()
    {
        for (int i = 0; i < chains.Length; i++)
        {
            RotarJoint(chains[i], Time.time - (i*offsetGeneral));
        }

    }



    // SINEWAVE TENTACLE
    void RotarJoint (Chain chain, float tiempo)
    {
        for (int i = 0; i < chain.joints.Length; i++)
        {
            float angulo = Mathf.Sin ((tiempo * speed) - i * offsetIndividual) * amplitude ;
            float rotOriginal = chain.jointsOriginalRot [i].z;
            chain.joints [i].localEulerAngles = new Vector3 (0, 0, rotOriginal + angulo);
        }
    }

}
