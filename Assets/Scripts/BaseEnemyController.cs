using UnityEngine;
using UnityEditor;

public class BaseEnemyController : MonoBehaviour
{
    public PlayerController playerController;
    public float DistanseView;
    public float DistanseAttack;
    public float Speed;
    public float DistanseToWall;
    public int Damage;
    public int Health = 100;


    public enum EnemyBehaviourState { EnemyBehaviour1, EnemyBehaviour2, EnemyBehaviour3, EnemyBehaviour4, EnemyBehaviour5 }

    public EnemyBehaviourState ActiveState = EnemyBehaviourState.EnemyBehaviour1;

    private Vector2 enemyPos;
    private Rigidbody2D _rb2D;
    private GameObject player;
    private Vector2 transformVector;
    private int directionState;
    private int exception = 0;
    public int playerDamage = 50;
    public float ActivationDelay = 0.01f;
    public float DelayAtackPlayer = 0.01f;
    public AudioClip audioClip;
    //Config
    private string _wallTag = "Wall";
    private string _playerName = "Player";
    private string _playerTag = "Player";
    private string _weaponTag = "Weapon";
    //private CircleCollider2D circleCollider;

    void Start()
    {
        //circleCollider= GetComponent<CircleCollider2D>();   
         _rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void FixedUpdate()
    {
        if (directionState == 0)
        {
            directionState = Random.Range(1, 5);

            if (directionState == exception)
            {
                directionState = Random.Range(1, 5);
            }
        }

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, DistanseToWall,transform.up);


        //if (hit.collider != null && hit.collider.tag == _wallTag)
        //{
        //    Debug.Log("wall");
        //    directionState = 0;
        //}



        // Debug.Log(directionState);
        // transform.position = new Vector2(transformVector);

        //RaycastHit2D hit = Physics2D.CircleCast(transform.position, DistanseView, Vector2.zero);
        //if (hit.collider != null && hit.collider.tag == _playerTag)
        //{

        //    RaycastHit2D hitAtatck = Physics2D.Raycast(transform.position, Vector2.up, DistanseAttack);
        //    if (hitAtatck.collider != null && hitAtatck.collider.tag == _playerTag)
        //    {
        //        player.GetComponent<SpriteRenderer>().color = Color.red;
        //    }
        //    else
        //    {
        //        transform.position = new Vector2(enemyPos.x, enemyPos.y);

        //        player.GetComponent<SpriteRenderer>().color = Color.yellow;
        //    }
        //}
        //else if (hit.collider != null && hit.collider.tag == _walltag)
        //{

        //}
        //else
        //{
        //    player.GetComponent<SpriteRenderer>().color = Color.green;
        //}
        switch (ActiveState)
        {
            case EnemyBehaviourState.EnemyBehaviour1:
                switch (directionState)
                {
                    case 1:
                        transformVector = transform.up;
                        exception = 1;
                        break;
                    case 2:
                        transformVector = transform.right;
                        exception = 2;
                        break;
                    case 3:
                        transformVector = -transform.right;
                        exception = 3;
                        break;
                    case 4:
                        transformVector = -transform.up;
                        exception = 4;
                        break;
                    default:
                        break;
                }
                break;
            case EnemyBehaviourState.EnemyBehaviour2:
                switch (directionState)
                {
                    case 1:
                        transformVector = new Vector2(1,1);
                        exception = 1;
                        break;
                    case 2:
                        transformVector = new Vector2(-1, -1);
                        exception = 2;
                        break;
                    case 3:
                        transformVector = new Vector2(-1, 1);
                        exception = 3;
                        break;
                    case 4:
                        transformVector = new Vector2(1, -1);
                        exception = 4;
                        break;
                    default:
                        break;
                }
                break;
            case EnemyBehaviourState.EnemyBehaviour3:
                switch (directionState)
                {
                    case 1:
                        transformVector = new Vector2(1, 1);
                        break;
                    case 2:
                        transformVector = new Vector2(-1, -1);
                        break;
                    case 3:
                        transformVector = new Vector2(-1, 1);
                        break;
                    case 4:
                        transformVector = new Vector2(1, -1);
                        break;
                    default:
                        break;
                }
                break;
            case EnemyBehaviourState.EnemyBehaviour4:
                break;
            case EnemyBehaviourState.EnemyBehaviour5:
                break;
            default:
                break;
        }

        _rb2D.MovePosition(_rb2D.position + transformVector * Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _playerTag)
        {
            player.GetComponent<PlayerController>().DamagePlayer(Damage);
            player.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (other.tag == _weaponTag)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            ActivateDelayed();
            Health -= playerDamage;
            if (Health <= 0)
            {
                GetComponent<AudioSource>().PlayOneShot(audioClip);
                Destroy(gameObject);
            }
            
        }
        else
        {
            directionState = 0;
        }
    }

    private void EnemyTransform ()
    {
            enemyPos = Vector2.MoveTowards(transform.position, player.transform.position, Speed * Time.fixedDeltaTime);
            if (transform.position.x > player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (transform.position.x < player.transform.position.x)
                transform.rotation = Quaternion.Euler(0, 0, 0);
       
    }

    private void AfterDelay()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void ActivateDelayed()
    {
        Invoke(nameof(AfterDelay), ActivationDelay);
    }

    public void ActivateDelayed(float customDelay)
    {
        Invoke(nameof(AfterDelay), customDelay);
    }


}
