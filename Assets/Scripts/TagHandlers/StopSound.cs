using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public class StopSound : MonoBehaviour, ITagHandler
    {
        public void OnEnable()
        {
            StoryManager storyManager = GetComponent<StoryManager>();
            if (storyManager == null)
            {
                Debug.LogWarning($"{nameof(StopSound)} tried to find a {nameof(StoryManager)} on the \"{gameObject.name}\" " +
                                 $"game object, but there is none! Is {nameof(StopSound)} attached to the wrong game object?");
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
            return "StopSound";
        }

        public void Handle(List<string> arguments)
        {
            if (arguments.Count < 1)
            {
                Debug.LogWarning($"{nameof(StopSound)} expected 2 arguments, but got {arguments.Count}!");
                return;
            }
            
            GameObject target = GameObject.Find(arguments[0]);
            if (target == null)
            {
                Debug.LogWarning($"{nameof(StopSound)} tried to find a game object with the name \"{arguments[0]}\"," +
                                 $"but there was none! Was there a typo?");
                return;
            }

            AudioSource audioSource = target.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogWarning($"{nameof(StopSound)} tried to find an {nameof(AudioSource)} component on the \"{target.name}\" " +
                                 $"game object, but there was none! Did you forget to attach an {nameof(AudioSource)}?");
                return;
            }

            audioSource.Stop();
        }
    }
}