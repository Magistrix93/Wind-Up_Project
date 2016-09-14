﻿using UnityEngine;
using System.Collections;

public class CuboSwitchBehaviour : MonoBehaviour
{
    public float speed;

    public float sizeX;
    public float sizeY;
    public float sizeZ;

    public bool horizontalZ;
    public bool horizontalX;

    private float maxHeightA;
    private float minHeightA;
    private float maxHeightB;
    private float minHeightB;

    private int counter;

    private bool movement;
    private bool reverseMovement;

    enum CubeType { standard, horizontalX, horizontalZ };
    CubeType cubeType;

    // Use this for initialization

    void Start()
    {

        transform.localScale = new Vector3(5 * sizeX, 5 * sizeY, 5 * sizeZ);

        movement = false;
        reverseMovement = false;

        counter = 0;

        if (horizontalX)
        {
            cubeType = CubeType.horizontalX;
            CreateCubes();
        }
        else
        {
            if (horizontalZ)
            {
                cubeType = CubeType.horizontalZ;
                CreateCubes();
            }
            else
            {
                cubeType = CubeType.standard;
                CreateCubes();
            }
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (movement)
        {
            if (this.tag == "cuboA")
            {
                if (cubeType == CubeType.standard)
                {
                    if ((transform.position.y < maxHeightA))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        movement = false;
                    }
                }
                else
                {
                    if (cubeType == CubeType.horizontalX)
                    {
                        if ((transform.position.x < maxHeightA))
                        {
                            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            movement = false;
                        }
                    }
                    else
                    {
                        if (cubeType == CubeType.horizontalZ)
                        {
                            if ((transform.position.z < maxHeightA))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                            }
                            else
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                movement = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (cubeType == CubeType.standard)
                {
                    if ((transform.position.y > minHeightB))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        movement = false;
                    }
                }
                else
                {
                    if (cubeType == CubeType.horizontalX)
                    {
                        if ((transform.position.x > minHeightB))
                        {
                            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            movement = false;
                        }
                    }
                    else
                    {
                        if (cubeType == CubeType.horizontalZ)
                        {
                            if ((transform.position.z > minHeightB))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                            }
                            else
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                movement = false;
                            }
                        }

                    }
                }
            }
        }

        if (reverseMovement)
        {
            if (this.tag == "cuboA")
            {
                if (cubeType == CubeType.standard)
                {
                    if ((transform.position.y > minHeightA))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        reverseMovement = false;
                    }
                }
                else
                {
                    if (cubeType == CubeType.horizontalX)
                    {
                        if ((transform.position.x > minHeightA))
                        {
                            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            reverseMovement = false;
                        }
                    }
                    else
                    {
                        if (cubeType == CubeType.horizontalZ)
                        {
                            if ((transform.position.z > minHeightA))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                            }
                            else
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                reverseMovement = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (cubeType==CubeType.standard)
                {
                    if ((transform.position.y < maxHeightB))
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        reverseMovement = false;
                    }
                }
                else
                {
                    if (cubeType == CubeType.horizontalX)
                    {
                        if ((transform.position.x < maxHeightB))
                        {
                            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            reverseMovement = false;
                        }
                    }
                    else
                    {
                        if (cubeType == CubeType.horizontalZ)
                        {
                            if ((transform.position.z < maxHeightB))
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                            }
                            else
                            {
                                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                                reverseMovement = false;
                            }
                        }
                    }
                }
            }
        }
    }

    private void CreateCubes()
    {
        switch (cubeType)
        {
            case CubeType.standard:
                {
                    if (this.tag == "cuboA")
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 5 * (sizeY / 2), transform.position.z);

                        maxHeightA = transform.position.y + 5 * sizeY;
                        minHeightA = transform.position.y;
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + 5 * (sizeY / 2), transform.position.z);

                        maxHeightB = transform.position.y;
                        minHeightB = transform.position.y - 5 * sizeY;
                    }
                }
                break;
            case CubeType.horizontalX:
                {
                    if (this.tag == "cuboA")
                    {
                        transform.position = new Vector3(transform.position.x - 5 * (sizeX / 2), transform.position.y, transform.position.z);

                        maxHeightA = transform.position.x + 5 * sizeX;
                        minHeightA = transform.position.x;
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x + 5 * (sizeX / 2), transform.position.y, transform.position.z);

                        maxHeightB = transform.position.x;
                        minHeightB = transform.position.x - 5 * sizeX;
                    }
                }
                break;
            case CubeType.horizontalZ:
                {
                    if (this.tag == "cuboA")
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5 * (sizeZ / 2));

                        maxHeightA = transform.position.z + 5 * sizeZ;
                        minHeightA = transform.position.z;
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5 * (sizeZ / 2));

                        maxHeightB = transform.position.z;
                        minHeightB = transform.position.z - 5 * sizeZ;
                    }
                }
                break;
        }
    }

    public void MovingCubes()
    {
        counter++;
        switch (counter)
        {
            case 1:
                {
                    movement = true;
                    reverseMovement = false;
                }
                break;
            case 2:
                {
                    movement = false;
                    reverseMovement = true;
                    counter = 0;
                }
                break;
        }
    }
}