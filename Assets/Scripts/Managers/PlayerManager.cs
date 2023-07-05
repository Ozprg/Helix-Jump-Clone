using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour, IPlayer, IBounceable
{
    [SerializeField] private float jumpForce;
    private float playerSpeed;
    private bool isGrounded;
    public float PlayerSpeed { get { return playerSpeed; } set { playerSpeed = value; } }
    public bool IsGrounded { get { return isGrounded; } set { isGrounded = value; } }
    private Rigidbody Rigidbody;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        playerSpeed = Rigidbody.velocity.magnitude;
    }
    private void OnCollisionEnter(Collision other)
    {
        IPlatform platform = other.gameObject.GetComponent<IPlatform>();
        Vector3 contactPoint = transform.position;
        isGrounded = true;

        if (platform != null)
        {
            if (isGrounded && platform.IsPlatformSafe == true)
            {
                CreateSplash(platform);
                Bounce();
                isGrounded = false;
            }
        }
    }
    public void Bounce()
    {
        transform.DOJump(transform.position, jumpForce, 1, 1);
    }
    public void DestroyPlayer()
    {
        GameObject.Destroy(gameObject);
    }
    private void CreateSplash(IPlatform platform)
    {
        GameObject splash = PoolingManager.Instance.GetPooledObject();
        if (splash == null)
        {
            return;
        }
        else
        {
            splash.transform.position = transform.position;
            splash.transform.SetParent(platform.PlatformTransform);
            splash.SetActive(true);
            StartCoroutine(ReturnPooledObject(splash));
        }
    }
    private IEnumerator ReturnPooledObject(GameObject splashToRemove)
    {
        yield return new WaitForSeconds(2f);
        splashToRemove.SetActive(false);
    }
}