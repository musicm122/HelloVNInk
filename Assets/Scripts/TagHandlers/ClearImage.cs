using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public class ClearImage : MonoBehaviour, ITagHandler
    {
        public void OnEnable()
        {
            StoryManager storyManager = GetComponent<StoryManager>();
            if (storyManager == null)
            {
                Debug.LogWarning($"{nameof(ClearImage)} tried to find a {nameof(StoryManager)} on the \"{gameObject.name}\" " +
                                 $"game object, but there is none! Is {nameof(ClearImage)} attached to the wrong game object?");
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
            return "ClearImage";
        }

        public void Handle(List<string> arguments)
        {
            if (arguments.Count != 1)
            {
                Debug.LogWarning($"{nameof(ClearImage)} expected 1 argument, but got {arguments.Count}!");
                return;
            }
            
            GameObject target = GameObject.Find(arguments[0]);
            if (target == null)
            {
                Debug.LogWarning($"{nameof(ClearImage)} tried to find a game object with the name \"{arguments[0]}\"," +
                                 $"but there was none! Was there a typo?");
                return;
            }

            Image image = target.GetComponent<Image>();
            if (image == null)
            {
                Debug.LogWarning($"{nameof(ClearImage)} tried to find an {nameof(Image)} component on the \"{target.name}\" " +
                                 $"game object, but there was none! Did you forget to attach an {nameof(Image)} and set the opacity to 0?");
                return;
            }

            image.color = Color.clear;
        }
    }
}