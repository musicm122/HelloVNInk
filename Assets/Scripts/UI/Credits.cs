using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private ScenePicker _picker;

    public KeyCode[] ExitKeys { get; set; } =
    {
        KeyCode.Escape
    };

    public KeyCode[] SpeedUpKeys { get; set; } =
    {
        KeyCode.LeftShift
    };

    public KeyCode[] PauseKeys { get; set; } =
    {
        KeyCode.Space
    };
    
    private TMP_Text TextBox;
    public float TextCrawlSpeed = 1;
    public float TextCrawlSpeedMultiplier = 1;

    
    public float RateOfTime= 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Input.GetKeyDown(KeyCode.Space);
        _picker = GetComponent<ScenePicker>();
        TextBox = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TextMoveCoroutine());
    }

    public bool AnyKeyPressed(KeyCode[] keys)=>
        keys.Any(Input.GetKeyDown);

    IEnumerator TextMoveCoroutine()
    {
        if (AnyKeyPressed(ExitKeys))
        {
            SceneManager.LoadScene(_picker.scenePath);
        }
        MoveText();
        
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(RateOfTime);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    void MoveText()
    {
        var deltaPosition = TextBox.transform.position;
        deltaPosition.y += TextCrawlSpeed * TextCrawlSpeedMultiplier;
        TextBox.transform.position = TextBox.transform.position = deltaPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MoveText();
        
        while (AnyKeyPressed(SpeedUpKeys))
        {
            TextCrawlSpeedMultiplier = 1.5f;
        }
        
        while (AnyKeyPressed(PauseKeys))
        {
            TextCrawlSpeedMultiplier = 0f;
        }
    }
}
