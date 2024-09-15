using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TagHandlers
{
    public interface ITagHandler
    {
        public string GetTag();
        public void Handle(List<string> arguments);
        
        

    }
}