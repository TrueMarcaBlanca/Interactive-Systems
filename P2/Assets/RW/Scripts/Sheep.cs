using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;


    public float dropDestroyDelay ;
    private Collider myCollider;
    private Rigidbody myRigidbody;


    private SheepSpawner sheepSpawner;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHayWhite()
    {
        SoundManager.Instance.PlaySheepHitClip();

        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        GameStateManager.Instance.SavedSheep();
    }

    private void HitByHayBlack()
    {
        SoundManager.Instance.PlaySheepDroppedClip();

        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);
        GameStateManager.Instance.DroppedSheep();
        GameStateManager.Instance.DroppedSheep();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay && this.CompareTag("WhiteSheep"))
        {
            Destroy(other.gameObject);
            HitByHayWhite();
        }
        else if (other.CompareTag("Hay") && !hitByHay && this.CompareTag("BlackSheep"))
        {
            Destroy(other.gameObject);
            HitByHayBlack();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }
    private void Drop()
    {
        if(this.CompareTag("WhiteSheep"))
        {
        SoundManager.Instance.PlaySheepDroppedClip();
        
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay );
        GameStateManager.Instance.DroppedSheep();
        }
        else
        {
        sheepSpawner.RemoveSheepFromList(gameObject);
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay );
        }
    }
    

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

}
