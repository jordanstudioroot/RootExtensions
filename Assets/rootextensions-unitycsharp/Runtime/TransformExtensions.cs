using UnityEngine;

namespace RootExtensions {
    public static class TransformExtensions {
        public static Vector3 Feet(this Transform transform) {
            if (transform.GetComponent<MeshRenderer>()) {
                float boundsSizeY =
                    transform.GetComponent<MeshRenderer>().bounds.size.y;

                Vector3 halfBoundsSizeY =
                    transform.up *
                    boundsSizeY * .5f;

                return (transform.position - halfBoundsSizeY);
            }
            else {
                throw new System.Exception(
                    "GameObject of attached transform must have an attached" +
                    " MeshRenderer."
                );
            }
        }

        public static void StandOn(
            this Transform myTransform,
            Vector3 positionToStand
        ) {
            if(myTransform.GetComponent<MeshRenderer>()) {
                float centerDist =
                    Vector3.Distance(
                        myTransform.Feet(),
                        myTransform.position
                    );
                
                myTransform.position = new Vector3(
                    positionToStand.x,
                    positionToStand.y + centerDist,
                    positionToStand.z
                );
            }
            else {
                throw new System.Exception(
                    "GameObject of attached transform must have an attached" +
                    " MeshRenderer."
                );
            }
        }
    }
}