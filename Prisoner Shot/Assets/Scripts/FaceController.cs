using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FaceController : MonoBehaviour
{
    [SerializeField] private FaceDatabaseSO faceDatabaseSO;
    [SerializeField] private float maxMoveTimer = 2f;

    [SerializeField] private SpriteRenderer face;
    [SerializeField] private SpriteRenderer hat;
    [SerializeField] private SpriteRenderer eyes;
    [SerializeField] private SpriteRenderer ears;
    [SerializeField] private SpriteRenderer nose;
    [SerializeField] private SpriteRenderer mouth;

    private float moveSpeed;
    private Dictionary<string, Sprite> faceDict = new();
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isSelected;
    private float currentTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // InitializeRandomFace();
        // SetNewDestination();
    }

    public void InitializeRandomFace()
    {
        int randomNumber = Random.Range(0, faceDatabaseSO.faces.Length);
        face.sprite = faceDatabaseSO.faces[randomNumber];
        faceDict["Face"] = face.sprite;

        randomNumber = Random.Range(0, faceDatabaseSO.hats.Length);
        hat.sprite = faceDatabaseSO.hats[randomNumber];
        faceDict["Hat"] = hat.sprite;

        randomNumber = Random.Range(0, faceDatabaseSO.eyes.Length);
        eyes.sprite = faceDatabaseSO.eyes[randomNumber];
        faceDict["Eyes"] = eyes.sprite;

        randomNumber = Random.Range(0, faceDatabaseSO.ears.Length);
        ears.sprite = faceDatabaseSO.ears[randomNumber];
        faceDict["Ears"] = ears.sprite;

        randomNumber = Random.Range(0, faceDatabaseSO.noses.Length);
        nose.sprite = faceDatabaseSO.noses[randomNumber];
        faceDict["Nose"] = nose.sprite;

        randomNumber = Random.Range(0, faceDatabaseSO.mouths.Length);
        mouth.sprite = faceDatabaseSO.mouths[randomNumber];
        faceDict["Mouth"] = mouth.sprite;
    }

    private void OnMouseDown()
    {
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        if (isOverUI) return;

        if (isSelected)
        {
            GameManager.Instance.SetCorrectChoice();
        }
        else
        {
            GameManager.Instance.SetWrongChoice();
        }
    }

    public void SetNewDestination()
    {
        currentTimer = maxMoveTimer;
        moveSpeed = GameManager.Instance.GetFaceMoveSpeed();

        float randomXNumber = Random.Range(-1, 1);
        float randomYNumber = Random.Range(-1, 1);
        moveDirection = new Vector2(randomXNumber, randomYNumber);
        rb.velocity = moveDirection * moveSpeed;
    }

    public Dictionary<string, Sprite> GetFaceDict() => faceDict;
    public void Select()
    {
        isSelected = true;
    }
}
