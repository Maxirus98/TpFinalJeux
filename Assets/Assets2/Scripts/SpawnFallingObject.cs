using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnFallingObject : MonoBehaviour
{
    private List<Transform> _tiles;
    private Spell spell;
    private Vector3 offset;
    Random random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        spell = GameObject.Find("Boss").GetComponent<Spell>();
        offset = Vector3.up * 50;
        AddTiles();
    }


    void AddTiles()
    {
        _tiles = new List<Transform>();
        foreach (Transform tile in transform)
        {
            _tiles.Add(tile);
            print(tile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Every 5 seconds spawn a random falling bus 
        if (Time.time >= spell.TimeStamp)
        {
            Spawn();
        }

        void Spawn()
        {
           
            var randomTile = _tiles[random.Next(_tiles.Count)];
            var cloneFallingObject = Instantiate(spell.go, randomTile.position + offset, spell.go.transform.rotation);
            var cloneRandomTile = Instantiate(randomTile.gameObject, randomTile.position + Vector3.up/5, randomTile.rotation);
            
            cloneRandomTile.GetComponent<Renderer>().material.color = Color.red;
            spell.TimeStamp = Time.time + spell.cooldown;
            Destroy(cloneRandomTile, spell.cooldown);
            Destroy(cloneFallingObject, spell.cooldown);

        }
    }

}
