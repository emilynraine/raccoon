using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerScript : MonoBehaviour
{
    public float SPEED = 5f;
    public Rigidbody2D _rbody;
    public SpriteRenderer _srend;
    public Animator _animator;
    public Vector2 _moveInput;

    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _srend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Called automatically by the PlayerInput component
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
        print("Move Input Change: " + _moveInput);
    }

    void FixedUpdate()
    {
        _rbody.linearVelocity = _moveInput * SPEED;
    }

    // public SpriteRenderer _srend;
    // public MSMScript _manager;
    // public CameraScript _mainCamera;
    // public Rigidbody2D _rbody;
    // public Animator _animator;

    // public float _jumpScale = 5;
    // public float SPEED = 5;
    // public LayerMask _platformLayer;
    // public LayerMask _cowLayer;
    // public LayerMask _bossCowLayer;
    // float _lastTimeGrounded = 0;

    // public float _raycastDist = 1.3f;
    // bool _notPlayedDeath = true;
    // public bool _notPlayedHit = true;
    // public bool _dead = false;

    // public bool _powered = false;
    // public float _timeSincePower = 0f;
    // public int _bossHits = 0;
    // float _timeSinceBossHit = 0f;
    // public bool _enteredRegion = false;

    // public float _halfWidth = 0;
    ///public int[] _raycasts = new int {0, 1, 2};

    // void Start()
    // {
        // _srend = GetComponent<SpriteRenderer>();
        // _animator = GetComponent<Animator>();
        // _manager = FindObjectOfType<MSMScript>();
        // _rbody = GetComponent<Rigidbody2D>();
        // _halfWidth = _srend.bounds.size.x / 2;
        //print("starting halfWidth: " + _halfWidth);
    // }

    // Update is called once per frame
    // void Update()
    // {
        //print(_bossHits);
        // _animator.SetBool("Jumped", _rbody.linearVelocity.y > .5f);
        // _animator.SetBool("Falling", _rbody.linearVelocity.y < -9);

        // // Play the death/spawn noise
        // if (_notPlayedDeath)
        // {
        //     _manager.PlayDeath();
        //     _notPlayedDeath = false;
        // }

        // if (!_dead)
        // {
        //     // If the player is allowed to jump
        //     if (Input.GetKeyDown(KeyCode.Space) && WasGrounded())
        //     {
        //         _rbody.linearVelocity = Vector3.up * _jumpScale;
        //         _manager.PlayJump();
        //     }

        //     // If the player goes below the height depth e.i. fell out of the world
        //     if (_rbody.position.y < -25)
        //     {
        //         if (_notPlayedHit)
        //         {
        //             _manager.PlayHit();
        //             _notPlayedHit = false;
        //             _dead = true;
        //         }

        //     }
        // }


    // }

    // void FixedUpdate()
    // {
    //     //Move the player
    //     float x = SPEED * Input.GetAxis("Horizontal");
    //     float y = SPEED * Input.GetAxis("Vertical");
    //     _rbody.linearVelocity = new Vector2(x, y);


        //Power Up Coloring and Tracking
        // if (_powered && _timeSincePower < 5)
        // {
        //     _timeSincePower = _timeSincePower + .01f;
        // }
        // if (_timeSincePower > 5)
        // {
        //     _manager.StopSound();
        //     _powered = false;
        //     _timeSincePower = 0f;
        //     _srend.color = Color.white;
        // }

        // if (_timeSinceBossHit < 5)
        // {
        //     _timeSinceBossHit = _timeSinceBossHit + .01f;
        // }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag.Equals("BossCow") && (!_powered || _manager._piecesCollected != 6))
    //     {
    //         _dead = true;
    //         _manager.PlayHit();
    //     }

    //     if (_powered && (other.gameObject.tag.Equals("BossCow")) && _timeSinceBossHit > 3)
    //     {
    //         _powered = false;
    //         _manager.StopSound();
    //         _srend.color = Color.white;
    //         _rbody.linearVelocity = Vector3.up * 20;
    //         _manager.PlayCow();
    //         _bossHits++;
    //         _timeSinceBossHit = 0;
    //         _jumpScale = 8;
    //     }

    //     if (other.gameObject.tag.Equals("PowerUp"))
    //     {
    //         _srend.color = new Color(255 / 255f, 253 / 255f, 177 / 255f);
    //         Destroy(other.gameObject);
    //         _powered = true;
    //         _manager.PlayPowerUp();
    //     }

    //     // Checkpoint Flag Interaction
    //     if (other.gameObject.tag.Equals("Checkpoint"))
    //     {
    //         other.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    //         _manager._checkpoint = other.transform.position;
    //     }

    //     // Telescope Piece Interaction
    //     if (other.gameObject.tag.Equals("Telescope"))
    //     {
    //         Destroy(other.gameObject);
    //         _mainCamera.MoveCamera();
    //         _manager.PlayTelescope();
    //         _manager._piecesCollected++;
    //         _manager._piecesCollectedText.text = _manager._piecesCollected + "/" + _manager._totalPieces;
    //         _jumpScale = _jumpScale + .6f;

    //         //print("Updated raycast dist is: " + _raycastDist);
    //     }

    //     // Spike + Cow Interaction
    //     if (other.gameObject.tag.Equals("Spikes") || (other.gameObject.tag.Equals("Cow") && (!_powered || (_powered && !IsOnCow()))))
    //     {
    //         _dead = true;
    //         _manager.PlayHit();
    //     }

    //     if (IsOnCow() && _powered)
    //     {
    //         other.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    //         _rbody.linearVelocity = Vector3.up * 4;
    //         _manager.PlayCow();
    //         other.gameObject.GetComponent<CowScript>().ShrinkCow();
    //     }

    //     // End Goal Reached
    //     if (other.gameObject.tag.Equals("EndGoal"))
    //     {
    //         if (_manager._totalPieces == _manager._piecesCollected)
    //         {
    //             Color newYellow = new Color((float)225 / 255, (float)175 / 255, (float)72 / 255);
    //             other.GetComponent<SpriteRenderer>().color = newYellow;
    //             ParticleSystem pSystem = other.GetComponent<ParticleSystem>();
    //             ParticleSystem.MainModule pMain = pSystem.main;
    //             pMain.startColor = newYellow;
    //             other.GetComponent<CircleCollider2D>().enabled = false;
    //             _manager.PlayComplete();

    //             //If they reach the last goal reveal the winner panel and reset the player progress
    //             if (PlayerPrefs.GetString("Level") == "BossScene")
    //             {
    //                 PlayerPrefs.SetString("Level", "NewMoon");
    //                 PlayerPrefs.SetFloat("CurrTime", _manager._currTime);
    //                 _manager._isWon = true;
    //             }
    //             else
    //             {
    //                 _manager.Invoke("nextLevel", 3f);
    //             }
    //         }
    //     }
    // }

    //If the player is on a platform
    // bool IsGrounded()
    // {
    //     RaycastHit2D centerHit =
    //       Physics2D.Raycast(transform.position, Vector2.down, _raycastDist,
    //       _platformLayer);
    //     RaycastHit2D leftHit = Physics2D.Raycast(_rbody.position - new Vector2(_halfWidth, 0), Vector2.down, _raycastDist, _platformLayer);
    //     RaycastHit2D rightHit = Physics2D.Raycast(_rbody.position + new Vector2(_halfWidth, 0), Vector2.down, _raycastDist, _platformLayer);
    //     return (leftHit.collider != null || centerHit.collider != null || rightHit.collider != null);
    // }

    // bool IsOnCow()
    // {
    //     RaycastHit2D cowHit = Physics2D.Raycast(_rbody.position, Vector2.down, 1.8f, _cowLayer);
    //     RaycastHit2D bossCowHit = Physics2D.Raycast(_rbody.position, Vector2.down, 1.8f, _bossCowLayer);
    //     return (cowHit.collider != null || bossCowHit.collider != null);
    // }

    // private bool WasGrounded()
    // {
    //     return (Time.time - _lastTimeGrounded) < 0.1f;
    // }

}