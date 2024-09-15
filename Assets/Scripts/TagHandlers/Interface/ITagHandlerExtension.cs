using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TagHandlers
{
    public static class ITagHandlerExtension
    {
        public static bool HasGameObject(this ITagHandler handler, GameObject gameObject, string argName)
        {
            if (gameObject) return true;
            Debug.LogWarning($"{handler.GetTag()} tried to find a game object with the name {argName}," +
                             $"but there was none! Was there a typo?");
            return false;
        }
        public static bool HasImage(this ITagHandler handler, Image image)
        {
            if (image) return true;
            Debug.LogWarning($"{handler.GetTag()} tried to find a Image," +
                             $"but there was none! Was there a typo?");
            return false;
        }

        public static bool HasMinimumArgCount(this ITagHandler handler, List<string> args, int minCount)
        {
            if (args.Count >= minCount) return true;
            Debug.LogWarning($"{handler.GetTag()} expected at least {minCount} arguments, but got {args.Count}!");
            return false;

        }
        
        public static bool HasExactArgCount(this ITagHandler handler,  List<string> args, int argCount)
        {
            if (args.Count == argCount) return true;
            Debug.LogWarning($"{handler.GetTag()} expected exactly {argCount} arguments, but got {args.Count}!");
            return false;

        }
    }
}