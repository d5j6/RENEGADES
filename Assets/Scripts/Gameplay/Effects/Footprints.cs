//App

//Unity
using UnityEngine;

namespace RENEGADES.Gameplay.Effects
{
    //we need these
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]

    public class Footprints : MonoBehaviour
    {
        // Maximum number of footprints total handled by one instance of the script.
        private const int maxFootprints = 256;
        // the offset for the left or right footprint. In meters.
        private const float footprintSpacing = 0.3f;
        // The size of the footprint. Should match the size of the footprint that it is used for. In meters.
        private Vector2 footprintSize = new Vector2(0.4f, 0.8f);

        private Mesh mesh;
        private Mesh MESH
        {
            get { return mesh ?? (mesh = GetComponent<MeshFilter>().mesh); }
        }

        private Vector3[] vertices;
        private Vector3[] normals;
        private Vector2[] uvs;
        private int[] triangles;

        private int footprintCount = 0;

        private bool isLeft = false;

        // Initializes the array holding the footprint sections.
        private void Awake()
        {
            // - Initialize Arrays 
            vertices = new Vector3[maxFootprints * 4];
            normals = new Vector3[maxFootprints * 4];
            uvs = new Vector2[maxFootprints * 4];
            triangles = new int[maxFootprints * 6];

            //name mesh
            MESH.name = "Footprints MESH";
        }

        // Function called by the Player when adding a footprint. 
        // Adds the information needed to create the mesh later. 
        public void AddFootprint(Vector3 pos, Vector3 fwd, Vector3 rht, int footprintType)
        {
            // - Calculate the 4 corners -

            // foot offset
            float footOffset = 0.0f, footprintSpacing = 0.0f;

            if (isLeft)
            {
                footOffset = -footprintSpacing;
            }

            Vector3[] corners = new Vector3[4];

            // corners = position + left/right offset + forward + right
            corners[0] = pos + (rht * footOffset) + (fwd * footprintSize.y * 0.5f) + (-rht * footprintSize.x * 0.5f); // Upper Left
            corners[1] = pos + (rht * footOffset) + (fwd * footprintSize.y * 0.5f) + (rht * footprintSize.x * 0.5f); // Upper Right
            corners[2] = pos + (rht * footOffset) + (-fwd * footprintSize.y * 0.5f) + (-rht * footprintSize.x * 0.5f); // Lower Left
            corners[3] = pos + (rht * footOffset) + (-fwd * footprintSize.y * 0.5f) + (rht * footprintSize.x * 0.5f); // Lower Right


            for (int i = 0; i < 4; i++)
            {
                Vector3 rayPos = corners[i];

                int index = (footprintCount * 4) + i;
                // - Vertex -
                vertices[index] = transform.localPosition;

                // - Normal -
                normals[index] = transform.localPosition.normalized;

            }


            // - UVs -

            // what type of footprint is being placed
            Vector2 uvOffset;

            switch (footprintType)
            {
                case 1:
                    uvOffset = new Vector2(0.5f, 1.0f);
                    break;

                case 2:
                    uvOffset = new Vector2(0.0f, 0.5f);
                    break;

                case 3:
                    uvOffset = new Vector2(0.5f, 0.0f);
                    break;

                default:
                    uvOffset = new Vector2(0.0f, 1.0f);
                    break;
            }

            // is this the left foot or the right foot
            switch (isLeft)
            {
                case true:
                    uvs[(footprintCount * 4) + 0] = new Vector2(uvOffset.x + 0.5f, uvOffset.y);
                    uvs[(footprintCount * 4) + 1] = new Vector2(uvOffset.x, uvOffset.y);
                    uvs[(footprintCount * 4) + 2] = new Vector2(uvOffset.x + 0.5f, uvOffset.y - 0.5f);
                    uvs[(footprintCount * 4) + 3] = new Vector2(uvOffset.x, uvOffset.y - 0.5f);

                    isLeft = false;
                    break;

                case false:
                    uvs[(footprintCount * 4) + 0] = new Vector2(uvOffset.x, uvOffset.y);
                    uvs[(footprintCount * 4) + 1] = new Vector2(uvOffset.x + 0.5f, uvOffset.y);
                    uvs[(footprintCount * 4) + 2] = new Vector2(uvOffset.x, uvOffset.y - 0.5f);
                    uvs[(footprintCount * 4) + 3] = new Vector2(uvOffset.x + 0.5f, uvOffset.y - 0.5f);

                    isLeft = true;
                    break;
            }



            // - Triangles -

            triangles[(footprintCount * 6) + 0] = (footprintCount * 4) + 0;
            triangles[(footprintCount * 6) + 1] = (footprintCount * 4) + 1;
            triangles[(footprintCount * 6) + 2] = (footprintCount * 4) + 2;

            triangles[(footprintCount * 6) + 3] = (footprintCount * 4) + 2;
            triangles[(footprintCount * 6) + 4] = (footprintCount * 4) + 1;
            triangles[(footprintCount * 6) + 5] = (footprintCount * 4) + 3;


            // - Increment counter -
            footprintCount++;

            if (footprintCount >= maxFootprints)
            {
                footprintCount = 0;
            }

            // - update mesh with new info -
            ConstructMesh();
        }

        private void ConstructMesh()
        {
            MESH.Clear();

            MESH.vertices = vertices;
            MESH.normals = normals;
            MESH.triangles = triangles;
            MESH.uv = uvs;
        }


    }
}
