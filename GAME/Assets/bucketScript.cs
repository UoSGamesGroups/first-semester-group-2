﻿using UnityEngine;
            Player = GameObject.FindGameObjectWithTag("Player");
        }
            
            {
                used = true;
                GameObject child = this.transform.GetChild(0).gameObject;
                child.SetActive(false);
                Player.GetComponent<PlayerController>().BucketPositioned();
                this.gameObject.tag = "UsedBucket";
        Debug.Log("Touched Bucket Holder");
        if (other.gameObject.tag == "BucketHolder") {
            BucketHolder = other.gameObject;
            onBooks = true;
            
        }
    }
    {
        if (other.gameObject.tag == "BucketHolder")
        {
            BucketHolder = null;
            onBooks = false;
            Debug.Log("Left Bucket Holder");
        }
    }