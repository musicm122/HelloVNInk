using System;
using System.Collections.Generic;
using System.Linq;
using Ink;
using Ink.Runtime;
using TagHandlers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

// public class DisplayLookup
// {
//     public string GetDisplay(string name, FaceExpressions expression = FaceExpressions.Neutral)
//     {
//         
//     }
// }

[DefaultExecutionOrder(1)]
public class StoryManager : MonoBehaviour
{

    public CanvasRenderer SpeakerPanel;  
    [FormerlySerializedAs("storyAsset")] public TextAsset StoryAsset;
    [FormerlySerializedAs("dialogueText")] public TMP_Text DialogueText;
    
    [FormerlySerializedAs("LeftSpeakerName")] public TMP_Text LeftSpeakerName;
    [FormerlySerializedAs("RightSpeakerName")] public TMP_Text RightSpeakerName;
    [FormerlySerializedAs("speakerDisplay")] public TMP_Text SpeakerDisplay;


    [FormerlySerializedAs("choiceButton")] public Button ChoiceButton;
    [FormerlySerializedAs("textSpeed")] public float TextSpeed = 40f;

    [NonSerialized] public readonly List<ITagHandler> TagHandlers = new(); // This will not be visible in the inspector, but other scripts will be able to add themselves to this list
    
    private Story _story;
    private List<Button> _choiceButtons;
    
    // Variables for animating dialogue
    private String _targetText;
    private float _numDisplayedCharacters;
    
    // Start is called before the first frame update
    void Start()
    {
        _story = new Story(StoryAsset.text);
        _story.onError+=StoryOnonError;
        ChoiceButton.onClick.AddListener(SelectChoice);
        ChoiceButton.gameObject.SetActive(false);
        _choiceButtons = new List<Button>();
        _choiceButtons.Add(ChoiceButton);
        HideButtons();
        
        Continue();
    }

    private void StoryOnonError(string message, ErrorType type)
    {
        Debug.LogError($"Story Manager threw an error : {message} of error type {type.ToString()}");
    }

    private void SelectChoice()
    {
        ChooseChoice();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            if (IsTextAnimating())
            {
                FinishAnimatingAndShowChoices();
            }
            else if (!AreChoicesVisible())
            {
                Continue();
            }
        }
        
        AnimateText();
    }

    private void AnimateText()
    {
        if (!IsTextAnimating()) return; // If we are not animating, then we don't need to do anything else. This is called a "guard clause."

        _numDisplayedCharacters = Math.Clamp(_numDisplayedCharacters + Time.deltaTime * TextSpeed, 0, _targetText.Length);
        DialogueText.text = _targetText.Substring(0, (int)_numDisplayedCharacters);

        if (!IsTextAnimating()) FinishAnimatingAndShowChoices();
    }

    private void FinishAnimatingAndShowChoices()
    {
        _numDisplayedCharacters = _targetText.Length;
        DialogueText.text = _targetText;
        ShowChoices();
    }

    private void ShowChoices()
    {
        if (AreChoicesVisible()) return; // If choices are already visible, then we don't need to do anything else. This is called a "guard clause."

        // First, hide all buttons.
        HideButtons();

        // Second, create more buttons if we don't have enough.
        for (int i = _choiceButtons.Count; i < _story.currentChoices.Count; i++)
        {
            GameObject buttonInstance = Instantiate(ChoiceButton.gameObject, ChoiceButton.transform.parent);
            Button button = buttonInstance.GetComponent<Button>();
            _choiceButtons.Add(button);
            button.onClick.RemoveAllListeners(); // I'm actually not sure if this is necessary. I'm not sure if instantiating a button would keep the existing onClick references.
            int choiceIndex = i;
            button.onClick.AddListener(() => ChooseChoice(choiceIndex));
        }
        
        // Third, enable the buttons that we need.
        for (int i = 0; i < _story.currentChoices.Count; i++)
        {
            Button button = _choiceButtons[i];
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<TMP_Text>().text = _story.currentChoices[i].text;
        }
    }

    private void HideButtons()
    {
        foreach (Button button in _choiceButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    private (string, string) GetSpeakerLine(string line, string splitCharacter)
    {
        var speaker = "";
        var lineOfDialog = line.Trim();
        var textSplit = line.Split(splitCharacter, 2);

        if (textSplit.Length <= 1 || !line.Contains(splitCharacter)) return (speaker, lineOfDialog);
        // If we have a colon,
        // the left side of the text becomes the speaker and the right side becomes the dialogue.
        speaker = textSplit[0].Trim(); 
        lineOfDialog = textSplit[1].Trim();
        return (speaker, lineOfDialog);
    }
    
    private bool IsTagElement(string line) => line.StartsWith("#");

    private void Continue()
    {
        LeftSpeakerName.text = "";
        RightSpeakerName.text = "";

        LeftSpeakerName.fontWeight = FontWeight.Light; 
        RightSpeakerName.fontWeight = FontWeight.Light; 

        var leftSpeakerSplit = ":<:";
        var rightSpeakerSplit = ":>:";

        if (!_story.canContinue) return;

        string newStoryText = _story.Continue();
        if (IsTagElement(newStoryText))
        {
            _story.currentTags.Add(newStoryText);
            return;
        }

        if (newStoryText.Contains(leftSpeakerSplit))
        {
            var leftDialog = this.GetSpeakerLine(newStoryText, leftSpeakerSplit);
            LeftSpeakerName.text = leftDialog.Item1.Trim();
            LeftSpeakerName.fontWeight = FontWeight.Bold; 
            RightSpeakerName.fontWeight = FontWeight.Light; 
            _targetText = leftDialog.Item2.Trim();
            SpeakerPanel.SetAlpha(1);

        }
        else if(newStoryText.Contains(rightSpeakerSplit))
        {
            var rightDialog = this.GetSpeakerLine(newStoryText, rightSpeakerSplit);
            RightSpeakerName.text = rightDialog.Item1.Trim();
            RightSpeakerName.fontWeight = FontWeight.Bold; 
            LeftSpeakerName.fontWeight = FontWeight.Light; 
            _targetText = rightDialog.Item2.Trim();
            SpeakerPanel.SetAlpha(1);
        }
        else
        {
            // If we do not have a colon, leave the speaker is blank.
            LeftSpeakerName.text = "";
            RightSpeakerName.text = "";
            _targetText = newStoryText;
        }

        SpeakerPanel.SetAlpha(LeftSpeakerName.text == "" ? 0:1);
        //SpeakerPanel.gameObject.SetActive(LeftSpeakerName.text != "");

        _numDisplayedCharacters = 0;
        
        HandleTags();
    }

    private void HandleTags()
    {
        foreach (string tag in _story.currentTags)
        {
            List<string> arguments = new List<string>(tag.Split(' '));
            string tagIdentifier = arguments[0];
            arguments.RemoveAt(0);
            foreach (ITagHandler tagHandler in TagHandlers)
            {
                if (tagHandler.GetTag().ToLower() == tagIdentifier.ToLower())
                {
                    tagHandler.Handle(arguments);
                }
            }
        }
        //_story.currentTags.Clear();
    }

    private void ChooseChoice(int choiceIndex =0)
    {
        if (!AreChoicesVisible()) return; // If the buttons aren't visible, we shouldn't be making a choice. This is called a "guard clause."
        
        _story.ChooseChoiceIndex(choiceIndex);
        HideButtons();
        Continue();
    }

    private bool IsTextAnimating()
    {
        // If we are displaying fewer characters than the target text's number of characters, then we are still animating the text.
        return _numDisplayedCharacters < _targetText.Length;
    }

    private bool AreChoicesVisible()
    {
        // This is a relatively fancy LINQ expression. If any of the buttons are active, this function returns true.
        return _choiceButtons.Any(button => button.gameObject.activeInHierarchy);
    }

}