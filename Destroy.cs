using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    [SerializeField] AudioClip soundClipForBlock;
    [SerializeField] GameObject particles;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] sprites;
    int totalHit;
    GameState point;
    // cached ref
    Level level;
    private void Start()
    {
        ObjectCount();

    }

    private void ObjectCount()
    {
        level = FindObjectOfType<Level>();
        point = FindObjectOfType<GameState>();
        if (tag == "Breakable")
        {

            level.CountBreakableObjects();
        }
    }

    private void Particles()
    {
        GameObject sparkles = Instantiate(particles, transform.position, transform.rotation);
        Destroy(sparkles,2f);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            totalHit++;
            AudioSource.PlayClipAtPoint(soundClipForBlock, Camera.main.transform.position);
            if (totalHit >= maxHits)
            {
                Destroy(gameObject);
                level.CountBreakableObjects2();
                point.Point();
                Particles();
            }
            else
            {
                ChangeSpriteDamage();
            }
        }
        //can be used to delay destroy effect
        //Destroy(gameObject,1f);
 
        //can be used later to show the colliders in debug
        //Debug.Log(collision.gameObject.name);
    }

    private void ChangeSpriteDamage()
    {
        int spriteNumber = totalHit - 1;
        GetComponent<SpriteRenderer>().sprite = sprites[spriteNumber];
    }
}
