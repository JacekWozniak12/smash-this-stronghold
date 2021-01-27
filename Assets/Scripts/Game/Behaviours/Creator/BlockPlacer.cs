using System;
using System.Collections.Generic;
using System.Linq;
using SmashStronghold.Game.Entities;
using SmashStronghold.Library;
using UnityEngine;


namespace SmashStronghold.Game.Behaviours
{
    public class BlockPlacer : MonoBehaviour
    {
        private MeshFilter meshFilter;
        private new Renderer renderer;
        private new Transform transform;
        private new BoxCollider collider;
        private Camera handler;

        [SerializeField]
        private GameObject[] blocks;

        [SerializeField]
        private Material can;

        [SerializeField]
        private Material cant;

        [SerializeField]
        private Material deletion;

        private int blockIndex;

        [SerializeField]
        private float gridSize = 0.5f;

        private const string path = "CastleBlocks/Base";

        private void Start()
        {
            Position();
            Display();
            blocks = GetBlockAssets();
            SetBlock(0);
        }

        private void Display()
        {
            renderer = GetComponent<Renderer>();
            renderer.material = can;
            meshFilter = GetComponent<MeshFilter>();
            handler = FindObjectOfType<Camera>();
        }

        private void Position()
        {
            transform = GetComponent<Transform>();
            collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
        }

        private void FixedUpdate()
        {
            GetBlockPosition();
        }

        private void GetBlockPosition()
        {
            Ray ray = handler.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5551000) && hit.collider.gameObject.tag != "placer")
            {
                if (!deletionMode && hit.collider.gameObject.TryGetComponent<Block>(out Block b))
                {
                    Vector3 temp =
                    new Vector3(hit.point.x, b.gameObject.transform.position.y, hit.point.z) +
                    new Vector3(0, b.gameObject.GetComponent<Renderer>().bounds.extents.y * 2 + 0.0001f, 0);

                    temp.x = temp.x - (temp.x % gridSize);
                    temp.z = temp.z - (temp.z % gridSize);

                    transform.position = temp;
                }
                else transform.position = hit.point;
            }
        }

        private void Update()
        {
            BlockSelection();
            BlockRotation();
            SwitchDeletionMode();
            BlockPlacement();
            BlockDeletion();
        }

        private void BlockRotation()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.transform.Rotate(new Vector3(0, 45, 0));
            }
        }

        private void SwitchDeletionMode()
        {
            if (Input.GetMouseButtonDown(1))
            {
                deletionMode = !deletionMode;
                if (deletionMode)
                {
                    renderer.material = deletion;
                    collider.enabled = false;
                }
                else
                {
                    collider.enabled = true;
                    renderer.material = can;
                }
            }
        }

        private bool canPlace = true;

        private bool deletionMode = false;

        private void OnTriggerEnter(Collider other)
        {
            if (deletionMode) return;
            renderer.material = cant;
            canPlace = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if (deletionMode) return;
            renderer.material = can;
            canPlace = true;
        }

        private void BlockPlacement()
        {
            if (!deletionMode && Input.GetMouseButtonDown(0))
            {
                if (canPlace)
                    Instantiate(blocks[blockIndex], transform.position, transform.rotation);
            }
        }

        private void BlockDeletion()
        {
            if (deletionMode && Input.GetMouseButtonDown(0))
            {
                Ray ray = handler.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 5551000) && hit.collider.gameObject.tag != "placer" && hit.collider.gameObject.TryGetComponent<Block>(out Block b))
                {
                    var Colliders = Physics.OverlapBox(transform.position + meshFilter.mesh.bounds.center, meshFilter.mesh.bounds.size, transform.rotation);

                    foreach (var item in Colliders)
                    {
                        if (item.GetComponent<Block>() != null && item != this) Destroy(item.gameObject);
                    }
                }
            }
        }

        private void BlockSelection()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                blockIndex = MathL.Loop(++blockIndex, 0, blocks.Length - 1);
                SetBlock(blockIndex);
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                blockIndex = MathL.Loop(--blockIndex, 0, blocks.Length - 1);
                SetBlock(blockIndex);
            }
        }

        private void SetBlock(int index)
        {
            meshFilter.mesh = blocks[index].GetComponent<MeshFilter>().sharedMesh;
            collider.size = blocks[index].GetComponent<Renderer>().bounds.size;
            collider.center = blocks[index].GetComponent<Renderer>().bounds.center;
        }

        private GameObject[] GetBlockAssets()
        {
            return Resources.LoadAll<GameObject>(path);
        }
    }
}


