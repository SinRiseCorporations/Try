using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [Header("Трансформ камеры (Указать)")]
    public Transform CameraTransform;
    [HideInInspector] public float vertical;
    [HideInInspector] public float horizontal;
    [HideInInspector]public float moveAmount;

    [Header("Скорость вращения персонажа.")]
    [Space(10)]
    public float smothinkRotation;

    [HideInInspector]public Vector3 rotationDirection;
    [HideInInspector]public Vector3 moveDirection;

    [Header("Звуки ходьбы")]
    private AudioSource walkSource;
    [Space(10)]
    public AudioClip[] walkClips;

    private void Start() 
    {
        walkSource = gameObject.GetComponent<AudioSource>();
    }

    public void MoveUpdate()
    {
        MoveAmount();
        RotationCharacter();
    }

    void MoveAmount()
    {
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));
    }
    
    void RotationCharacter()
    {
        Vector3 moveDir = CameraTransform.forward * vertical;
        moveDir += CameraTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection = CameraTransform.forward;

        rotationDirection = moveDirection;

        Vector3 targetDir = rotationDirection;
        targetDir.y =0;

        if(targetDir == Vector3.zero) targetDir = transform.forward;

        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation,lookDir, Time.deltaTime * smothinkRotation);
        transform.rotation = targetRot;
    }

    public void AudioSourceUpdate()
    {
        if(moveAmount > 0.2f)
        {
        walkSource.volume = PlayerPrefs.GetFloat("EffectSound");
        walkSource.PlayOneShot(walkClips[Random.Range(0,walkClips.Length)]);
        }
    }
}
