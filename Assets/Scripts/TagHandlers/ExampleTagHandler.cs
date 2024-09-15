using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public class ExampleTagHandler : MonoBehaviour, ITagHandler // Note that I added the TagHandler interface!
    {
        public void OnEnable()
        {
            GetComponent<StoryManager>().TagHandlers.Add(this);
        }
        
        public void OnDisable()
        {
            GetComponent<StoryManager>().TagHandlers.Remove(this);
        }
        
        public string GetTag()
        {
            return "Example";
        }

        public void Handle(List<string> arguments)
        {
            print("Hello, world! These are my arguments:");
            foreach (string argument in arguments)
            {
                print("- " + argument);
            }
        }
    }
}