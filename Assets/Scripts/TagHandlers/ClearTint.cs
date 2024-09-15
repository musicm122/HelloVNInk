using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public class ClearTint : MonoBehaviour, ITagHandler // Note that I added the TagHandler interface!
    {
        public string GetTag()
        {
            return "ClearTint";
        }
        

        public void Handle(List<string> arguments)
        {
            if (!this.HasExactArgCount(arguments, 1)) return;
            var target = GameObject.Find(arguments[0]);
            if (!this.HasGameObject(target, arguments[0])) return;
            
            var image = target.GetComponent<Image>();
            if (!this.HasImage(image)) return;

            image.color = Color.clear;
        }


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
    }
}