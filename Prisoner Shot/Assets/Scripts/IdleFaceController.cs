using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IdleFaceController : MonoBehaviour
{
    [SerializeField] private FaceDatabaseSO faceDatabaseSO;
    [SerializeField] private float minTimerToChange = 1f;
    [SerializeField] private float maxTimerToChange = 2f;

    [SerializeField] private Image face;
    [SerializeField] private Image hat;
    [SerializeField] private Image eyes;
    [SerializeField] private Image ears;
    [SerializeField] private Image nose;
    [SerializeField] private Image mouth;

    private float timeRemaining;

    void Start()
    {
        InitializeRandomFace();
        timeRemaining = Random.Range(minTimerToChange, maxTimerToChange);
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            InitializeRandomFace();
            timeRemaining = Random.Range(minTimerToChange, maxTimerToChange);
        }
    }

    public void InitializeRandomFace()
    {
        int randomNumber = Random.Range(0, faceDatabaseSO.faces.Length);
        face.sprite = faceDatabaseSO.faces[randomNumber];

        randomNumber = Random.Range(0, faceDatabaseSO.hats.Length);
        hat.sprite = faceDatabaseSO.hats[randomNumber];

        randomNumber = Random.Range(0, faceDatabaseSO.eyes.Length);
        eyes.sprite = faceDatabaseSO.eyes[randomNumber];

        randomNumber = Random.Range(0, faceDatabaseSO.ears.Length);
        ears.sprite = faceDatabaseSO.ears[randomNumber];

        randomNumber = Random.Range(0, faceDatabaseSO.noses.Length);
        nose.sprite = faceDatabaseSO.noses[randomNumber];

        randomNumber = Random.Range(0, faceDatabaseSO.mouths.Length);
        mouth.sprite = faceDatabaseSO.mouths[randomNumber];
    }
}
