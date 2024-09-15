using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public class SetImage : MonoBehaviour, ITagHandler
    {
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
            return "SetImage";
        }

        public void Handle(List<string> arguments)
        {
            if (arguments.Count != 2)
            {
                Debug.LogWarning($"{this.GetTag()} expected 2 arguments, but got {arguments.Count}!");
                switch (arguments.Count)
                {
                    case 4:
                        Debug.LogWarning($"{this.GetTag()} expected 2 arguments, but got 4 {arguments[0]} {arguments[1]} {arguments[2]} {arguments[3]} !");
                        break;
                    case 3:
                        Debug.LogWarning($"{this.GetTag()} expected 2 arguments, but got 3 {arguments[0]} {arguments[1]} {arguments[2]}!");
                        break;
                    case 1:
                        Debug.LogWarning($"{this.GetTag()} expected 2 arguments, but got 1 {arguments[0]}!");
                        break;
                    default:
                        Debug.LogWarning($"{this.GetTag()} expected 2 arguments, but got {arguments.Count}!");
                        break;
                }
                return;
            }
            
            GameObject target = GameObject.Find(arguments[0]);
            // if(ObjectCheck(target))
            // {
            //     
            // }
            
            Image image = target.GetComponent<Image>();
            if (image == null)
            {
                Debug.LogWarning($"{nameof(SetImage)} tried to find an {nameof(Image)} component on the {target.name} " +
                                 $"game object, but there was none! Did you forget to attach an image and set the opacity to 0?");
                return;
            }

            Sprite sprite = Resources.Load<Sprite>(arguments[1]);
            if (sprite == null)
            {
                Debug.LogWarning($"{nameof(SetImage)} tried to find a {nameof(Sprite)} at \"Resources/{arguments[1]}\", " +
                                 $"but there was none! Was there a typo?");
                return;
            }
            
            image.sprite = sprite;
            image.color = Color.white;
        }
    }
}