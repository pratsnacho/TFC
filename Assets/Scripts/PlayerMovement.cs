using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    float m_jumpForce = 7;

    public Animator anim;
    [SerializeField] Rigidbody rb = null;
    GameManager gameManager;

    float horizontalInput;
    public float velocidad = 5;
    float velLateral = 6;

    bool m_wasGrounded;
    bool alive = true;
    Vector3 m_currentDirection = Vector3.zero;

    float m_jumpTimeStamp = 0;
    float m_minJumpInterval = 0.25f;
    bool m_jumpInput = false;

    bool m_isGrounded;

    List<Collider> m_collisions = new List<Collider>();

    public void Awake()
    {
        if (!anim) { gameObject.GetComponent<Animator>(); }
        if (!rb) { gameObject.GetComponent<Animator>(); }
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {

        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    public void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }

        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            m_jumpInput = true;
        }
        Transform camera = Camera.main.transform;

        Vector3 direction = camera.forward;

        anim.SetFloat("MoveSpeed", direction.magnitude);
    }

    private void FixedUpdate()
    {
        anim.SetBool("Grounded", m_isGrounded);
        DirectUpdate();

        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
    }

    public void DirectUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * velocidad * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * velLateral * Time.fixedDeltaTime * 2;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        JumpingAndLanding();
    }

    public void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            rb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            anim.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            anim.SetTrigger("Jump");
        }
    }

    public void Die()
    {
        
        alive = false;
        anim.SetTrigger("Die");

        gameManager.SaveData();
        Invoke("CargarPuntuacion", 3);
    }

    public void CargarPuntuacion()
    {
        SceneManager.LoadScene("Puntuaciones");

    }
}