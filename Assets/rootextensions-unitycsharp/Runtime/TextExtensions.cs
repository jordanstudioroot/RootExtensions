using UnityEngine;
using UnityEngine.UI;

namespace RootExtensions {
    public static class TextExtensions {
        public static void AsText(
            this Text textBehaviour,
            string textContent
        ) {
            textBehaviour.color = Color.black;

            textBehaviour.font = Resources.GetBuiltinResource(
                typeof(Font),
                "Arial.ttf"
            ) as Font;
            
            textBehaviour.text = textContent;
        }
    }
}
