using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public class SetTint : MonoBehaviour, ITagHandler // Note that I added the TagHandler interface!
    {
        public float DefaultTransparency = 0.5f;
        public void OnEnable()
        {
            StoryManager storyManager = GetComponent<StoryManager>();
            if (storyManager == null)
            {
                Debug.LogWarning($"{this.GetTag()} tried to find a {nameof(StoryManager)} on the \"{gameObject.name}\" " +
                                 $"game object, but there is none! Is {this.GetTag()} attached to the wrong game object?");
                return;
            }
            
            storyManager.TagHandlers.Add(this);
        }
        
        public void OnDisable()
        {
            StoryManager storyManager = GetComponent<StoryManager>();
            if (storyManager != null) storyManager.TagHandlers.Remove(this);
        }
        
        public string GetTag()
        {
            return "SetTint";
        }

        public void Handle(List<string> arguments)
        {
            if (!this.HasMinimumArgCount(arguments, 2)) return;
            
            var target = GameObject.Find(arguments[0]);
            if (!this.HasGameObject(target, arguments[0])) return;
            
            var image = target.GetComponent<Image>();
            if (!this.HasGameObject(target, arguments[1])) return;

            string colorTextInput = arguments[1];
            
            var isValidColor = ColorUtility.TryParseHtmlString(colorTextInput, out var colorResult);
            if (!isValidColor)
            {
                Debug.LogWarning($"{GetTag()} was not provided a valid color :{colorTextInput} ");
            }
            
            switch (arguments.Count)
            {
                case 3: 
                    var isValidPercentage = float.TryParse(arguments[2], out var percentageResult);
                    if (!isValidPercentage)
                    {
                        Debug.LogWarning($"{GetTag()} was not provided a valid percentage color :{colorTextInput} ");
                    }
                    colorResult.a = percentageResult;
                    break;
                default:
                    colorResult.a = this.DefaultTransparency;
                    break;
            }

            image.color = colorResult;
        }
    }
}