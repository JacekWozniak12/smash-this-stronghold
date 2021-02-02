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
        #region components

        private MeshFilter meshFilter;
        private new Renderer renderer;
        private new Transform transform;
        private new BoxCollider collider;
        private Camera handler;

        #endregion

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

        public event Action BrickPlaced;
        public event Action BrickDeleted;
        public event Action BrickRotated;
        public event Action BrickMode;
        public event Action BrickSelected;

        private const string path = "CastleBlocks/Base";

        private void Update()
        {
            SwitchDeletionMode();
            BlockSelection();
            BlockRotation();
            BlockPlacement();
            BlockDeletion();
        }
        private void FixedUpdate()
        {
            GetBlockPosition();
            GetOverlapping();
        }

        private void Start()
        {
            GetPositionComponents();
            GetDisplayComponents();
            blocks = GetBlockAssets();
            SetBlock(0);
        }

        private void GetDisplayComponents()
        {
            renderer = GetComponent<Renderer>();
            renderer.material = can;
            meshFilter = GetComponent<MeshFilter>();
            handler = FindObjectOfType<Camera>();
        }

        private void GetPositionComponents()
        {
            transform = GetComponent<Transform>();
            collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
        }


        [SerializeField]
        Collider[] items;

        private void GetOverlapping()
        {
            if (deletionMode)
            {
                renderer.material = deletion;
                transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                return;
            }
            else
            {
                transform.localScale = Vector3.one;
            }

            items = Physics.OverlapBox(
                collider.bounds.center,
                collider.bounds.size / 2,
                transform.rotation);

            Vector3 pos = transform.position;

            foreach (var item in items)
            {
                if (item.gameObject != gameObject && item.gameObject.tag != "ground")
                {
                    if (Vector3.Distance(
                        item.ClosestPoint(pos),
                        collider.ClosestPoint(item.transform.position)) < -0.1f)
                    {

                        canPlace = false;
                        renderer.material = cant;
                        return;
                    }
                }
            }
            canPlace = true;
            renderer.material = can;
        }

        private void GetBlockPosition()
        {
            Ray ray = handler.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5551000) && hit.collider.gameObject.tag != "placer")
            {
                if (hit.collider.gameObject.TryGetComponent<Block>(out Block b))
                {
                    if (!deletionMode)
                    {
                        Vector3 temp =
                        new Vector3(hit.point.x, b.gameObject.transform.position.y, hit.point.z) +
                        new Vector3(0, b.gameObject.GetComponent<Renderer>().bounds.extents.y * 2 + 0.01f, 0);

                        temp.x = temp.x - (temp.x % gridSize);
                        temp.z = temp.z - (temp.z % gridSize);

                        transform.position = temp;
                    }
                    else
                    {
                        transform.position = hit.collider.gameObject.transform.position;
                    }
                }
                else
                {
                    Vector3 temp = hit.point;
                    temp.x = temp.x - (temp.x % gridSize);
                    temp.z = temp.z - (temp.z % gridSize);
                    transform.position = hit.point;
                }
            }
        }

        private void BlockRotation()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.transform.Rotate(new Vector3(0, 45, 0));
                BrickRotated?.Invoke();
            }
        }

        private void SwitchDeletionMode()
        {
            if (Input.GetMouseButtonDown(1))
            {
                deletionMode = !deletionMode;
                if (deletionMode) renderer.material = deletion;
                else renderer.material = can;
                BrickMode?.Invoke();
            }
        }

        private bool canPlace = true;

        private bool deletionMode = false;

        private void BlockPlacement()
        {
            if (!deletionMode && Input.GetMouseButtonDown(0))
            {
                if (canPlace || Input.GetKey(KeyCode.LeftShift))
                {
                    Instantiate(blocks[blockIndex], transform.position, transform.rotation);
                    BrickPlaced?.Invoke();
                }
            }
        }

        private void BlockDeletion()
        {
            if (deletionMode && Input.GetMouseButtonDown(0))
            {
                Debug.Log(meshFilter.mesh.bounds.center);

                var Colliders = Physics.OverlapBox(
                    transform.position + meshFilter.mesh.bounds.center,
                    meshFilter.mesh.bounds.size,
                    transform.rotation);

                int temp = 0;

                foreach (var item in Colliders)
                {
                    if (item.GetComponent<Block>() != null && item != this.collider)
                    {
                        Destroy(item.gameObject);
                        temp++;
                    }
                }

                if (temp > 0) BrickDeleted?.Invoke();
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

        private void SetBlock(int index) => SetBlock(blocks[index]);

        private void SetBlock(GameObject obj)
        {
            meshFilter.mesh = obj.GetComponent<MeshFilter>().sharedMesh;
            collider.size = meshFilter.mesh.bounds.size;
            collider.center = meshFilter.mesh.bounds.center;
            BrickSelected?.Invoke();
        }

        private GameObject[] GetBlockAssets() => Resources.LoadAll<GameObject>(path);
    }
}


