using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest_test : MonoBehaviour
{
    [SerializeField]

    AnimationEvent animationEvent;
    
    public bool ChestIsOpen;
    IsInRangeOfChest isInRangeOfchest;
    Animator animator;
    public GameObject Item;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        isInRangeOfchest = GetComponentInChildren<IsInRangeOfChest>();
        animator = GetComponent<Animator>();
        //animator.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRangeOfchest.IsInPlayerInRange)
        {
            animator.Play("ChestOpening");
            //Debug.Log("helloworld");
        }
    }

    public void ItemDropEvent(/*string item*/)
    {
        float gravity = -9.81f;
        float jumpheight = 3f;
        Vector3 velocity;

        velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        Instantiate(Item);
    }

    
}
