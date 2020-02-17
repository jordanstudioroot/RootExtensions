using UnityEngine;
using UnityEngine.EventSystems;

namespace RootExtensions {
    public static class PointerEventDataExtensions {
        public static Vector2 DeltaPosition(
            this PointerEventData pData,
            Vector2 position
        ) {
            return new Vector2(
                Mathf.Abs(pData.position.x - position.x),
                Mathf.Abs(pData.position.y - position.y)
            );
        }

        public static bool IsNorthOf(
            this PointerEventData pData,
            Vector2 position
        ) {
            return pData.position.y > position.y ? true : false;
        }

        public static bool IsEastOf(
            this PointerEventData pData,
            Vector2 position
        ) {
            return pData.position.x > position.x ? true : false;
        }

        public static bool IsOnScreen(this PointerEventData pData) {

            bool nOverflow =
                NorthScreenOverflow(pData) > 0 ? true : false;
            bool eOverflow = 
                EastScreenOverflow(pData) > 0 ? true : false;
            bool sOverflow =
                SouthScreenOverflow(pData) > 0 ? true : false;
            bool wOverflow =
                WestScreenOverflow(pData) > 0 ? true : false;
 
            if (nOverflow || eOverflow || sOverflow || wOverflow) {
                return false;
            }

            return true;
        }

        public static float NorthScreenOverflow(this PointerEventData pData) {
            return pData.position.y - Screen.height;
        }

        public static float EastScreenOverflow(this PointerEventData pData) {
            return pData.position.x - Screen.width;
        }

        public static float SouthScreenOverflow(this PointerEventData pData) {
            return - pData.position.y;
        }

        public static float WestScreenOverflow(this PointerEventData pData) {
            return - pData.position.x;
        }
    }
}