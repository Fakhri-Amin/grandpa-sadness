using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject facePrefab;
    [SerializeField] private int faceSpawnNumber = 1;
    [SerializeField] private float faceMoveSpeed = 0;
    [SerializeField] private Vector2 spawnXPoint;
    [SerializeField] private Vector2 spawnYPoint;
    [SerializeField] private TMP_Text ageText;
    [SerializeField] private GameObject correctChoiceUI;
    [SerializeField] private GameObject wrongChoiceUI;
    [SerializeField] private FaceSelectionManager faceSelectionManager;

    [Header("Timer Bar")]
    [SerializeField] private Image barFill;
    [SerializeField] private float maxTimer;
    private float timeRemaining;

    [Header("MMFeedbacks")]
    [SerializeField] private MMFeedbacks wrongFeedbacks;

    private int ageNumber = 50;
    private List<GameObject> faceControllerList = new();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        timeRemaining = maxTimer;
        SpawnFace();
        UpdateUI();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        barFill.fillAmount = timeRemaining / maxTimer;

        if (timeRemaining <= 0)
        {
            SetWrongChoice();
        }
    }

    private void SpawnFace()
    {
        for (int i = 0; i < faceSpawnNumber; i++)
        {
            Vector2 spawnPoint = new Vector2(Random.Range(spawnXPoint.x, spawnXPoint.y), Random.Range(spawnYPoint.x, spawnYPoint.y));
            GameObject face = Instantiate(facePrefab, spawnPoint, Quaternion.identity);
            faceControllerList.Add(face);
            face.GetComponent<FaceController>().InitializeRandomFace();
            face.GetComponent<FaceController>().SetNewDestination();
        }
    }

    public float GetFaceMoveSpeed() => faceMoveSpeed;
    public List<GameObject> GetFaceControllers() => faceControllerList;

    public void SetCorrectChoice()
    {
        correctChoiceUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetWrongChoice()
    {
        wrongFeedbacks.PlayFeedbacks();
        // wrongChoiceUI.SetActive(true);
        // Time.timeScale = 0;
    }

    public void GetToNextLevel()
    {
        Time.timeScale = 1;
        correctChoiceUI.SetActive(false);
        faceSelectionManager.ClearFaceComponentUI();
        ClearFaceInstances();
        maxTimer++;
        timeRemaining = maxTimer;
        ageNumber++;
        if (ageNumber % 2 == 0) faceSpawnNumber++;
        if (ageNumber % 3 == 0) faceMoveSpeed += 0.2f;
        SpawnFace();
        UpdateUI();
        faceSelectionManager.SetChosenFace();
    }

    private void UpdateUI()
    {
        ageText.text = ageNumber + " Years Old";
    }

    public void ClearFaceInstances()
    {
        foreach (var item in faceControllerList)
        {
            Destroy(item);
        }
        faceControllerList.Clear();
    }
}
