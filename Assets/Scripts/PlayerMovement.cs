using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GroundSpawner GroundSpawnerScript;
    Vector3 Direction;
    public float Speed;
    public static bool fall;
    public float Acceleration;
    void Start()
    {//Başlangıç için default yön verdim
        Direction = Vector3.forward;
        fall = false;
    }

    
    void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            fall = true;
        }
        if (fall == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Direction.x == 0)//x sıfırsa top sola döner
            {
                Direction = Vector3.left;
            }
            else//x'te herhangi bir değer varsa forwardlanır,sağa döner
            {
                Direction = Vector3.forward;
            }
            Speed += Acceleration * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Vector3 Movement = Direction * Time.deltaTime * Speed;
        transform.position += Movement;//döndükten sonra eksen sabitleme 
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Path")
        {
            ScoreCounter.score++;
            StartCoroutine(wait(collision.gameObject));
            //collision.gameObject.AddComponent<Rigidbody>();

            GroundSpawnerScript._GroundSpawn();
            StartCoroutine(groundDeleter(collision.gameObject));
        }
    }
    IEnumerator wait(GameObject game)
    {
        yield return new WaitForSeconds(0.3f);
            game.AddComponent<Rigidbody>();

    }
    IEnumerator groundDeleter(GameObject deletedGround)
    {

        yield return new WaitForSeconds(3f);
        Destroy(deletedGround);
    }
}
