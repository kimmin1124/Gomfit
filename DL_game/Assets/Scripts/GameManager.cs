using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int curPosition = 0;
    [SerializeField] private GameObject[] position;
    [SerializeField] private GameObject player;
    private bool isMoving = false;
    private const int maxHealth = 3;
    private int curHealth = 1;
    private float myTime = 0;

    [SerializeField] private Text timeText;
    [SerializeField] private Image[] healthImages = new Image[3];
    [SerializeField] private Sprite[] healthOrigins = new Sprite[2];

    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject[] obsGenPositions = new GameObject[3];
    [SerializeField] private Transform obsContainer;

    private bool gameIsRunning = false;

    private void Start()
    {
        curHealth = maxHealth;
        isMoving = false;
        curPosition = 0;
        gameIsRunning = true;
        UpdateHealthUI();
        StartCoroutine(ObstacleGenerator());
    }
    private void Update()
    {
        myTime += Time.deltaTime;
        UpdateTime();
        
        bool inputRight = Input.GetKeyDown(KeyCode.RightArrow);
        bool inputLeft = Input.GetKeyDown(KeyCode.LeftArrow);

        if (curPosition != -1 && inputLeft && !isMoving)
        {
            print("Left Shift");
            Shift(curPosition - 1);
        }
        else if (curPosition != 1 && inputRight && !isMoving)
        {
            print("Right Shift");
            Shift(curPosition + 1);
        }
    }

    private void Shift(int pointIndex)
    {
        curPosition = pointIndex;
        StartCoroutine(MoveCor(position[pointIndex + 1].transform.position));
    }

    private IEnumerator MoveCor(Vector3 targetPosition)
    {
        print("Shift Start");
        isMoving = true;
        const int wholeFrame = 4;
        const float moveTime = 0.5f;
        var initialPosition = player.transform.position;
        var normalizedDirection = (targetPosition - initialPosition) / wholeFrame;
        for(var i = 0; i < wholeFrame; i++)
        {
            player.transform.Translate(normalizedDirection);
            yield return new WaitForSeconds(moveTime / wholeFrame);
        }
        player.transform.position = targetPosition;
        isMoving = false;
        print("Shift Comped");
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        UpdateHealthUI();
        if (curHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void UpdateTime()
    {
        timeText.text = myTime.ToString("F2");
    }

    private void UpdateHealthUI()
    {
        for (var i = 0; i < 3; i++)
        {
            healthImages[i].sprite = (curHealth > i) ? healthOrigins[0] : healthOrigins[1];
        }
    }

    private IEnumerator ObstacleGenerator()
    {
        var genTerm = 3f;
        while (true)
        {
            while (gameIsRunning)
            {
                yield return new WaitForSeconds(genTerm);
                var pos = Random.Range(0, obsGenPositions.Length);
                var spr = Random.Range(0, obstacles.Length);
                // 장애물 생성
                GameObject tmp = Instantiate(obstacles[spr], obsContainer);
                tmp.transform.position = obsGenPositions[pos].transform.position;
                tmp.GetComponent<Obstacle>().Init();
            }

            yield return null;
        }
    }
}
