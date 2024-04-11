using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class play_control : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public float speed;
    public Animator anim;
    public float jumpforce;
    public LayerMask ground;
    public int collection_a = 0;
    public Text collection_a_num; 
    public int collection_b = 0;
    public Text collection_b_num;
     public int collection_c = 0;
    public Text collection_c_num;
     public AudioClip collectionSound; // 收集音效
    private AudioSource audioSource; // 音效源


    // Start is called before the first frame update
    void Start()
    {
        // 取消重力设置
        rb.gravityScale = 0f;
          // 获取音频源组件
        audioSource = gameObject.AddComponent<AudioSource>();
        // 设置音频源的clip为收集音效
        audioSource.clip = collectionSound;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Movement(); 
        Debug.Log("collection_a: " + collection_a);
        Debug.Log("collection_b: " + collection_b);
        Debug.Log("collection_c: " + collection_c);

         if (collection_a == 15 && collection_b == 12 && collection_c == 9)
        {
            Debug.Log("Condition met. Loading next scene...");
            SwitchToNextScene();
        }
    }
    
      void SwitchToNextScene()
    {
        //改成场景
        //SceneManager.LoadScene("s1");
    }
        
    
 //在Movement函数中添加以下代码
void Movement()
{
    float horizontalMove = Input.GetAxis("Horizontal");
    float facedirection = Input.GetAxisRaw("Horizontal");

    // 保存当前的速度
    Vector2 newVelocity = rb.velocity;

    if (horizontalMove != 1)
    {
        // 修改速度的x分量
        newVelocity.x = horizontalMove * speed * Time.deltaTime;
        anim.SetFloat("running", Mathf.Abs(facedirection));
        Debug.Log("moved");
    }

    if (facedirection != 0)
    {
        transform.localScale = new Vector3(facedirection, 1, 1);
        Debug.Log("changed");
    }

    // 设置人物的速度
    rb.velocity = newVelocity;
}

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Collection")
    {
        Destroy(collision.gameObject);
         Debug.Log("destoty"); // 当触发器碰到tag为"Collection"的物体时，销毁该物体
       audioSource.Play();
        collection_a += 1; 
        collection_a_num.text =collection_a.ToString();
         
         // 当触发器碰到tag为"Collection"的物体时，输出日志
    }
     if (collision.tag == "Mi")
    {
        audioSource.Play();
        Destroy(collision.gameObject);
        collection_b += 1; 
        collection_b_num.text =collection_b.ToString();
    }
    if (collision.tag == "Dou")
    {   
        audioSource.Play();
         Destroy(collision.gameObject);
        collection_c += 1; 
        collection_c_num.text =collection_c.ToString();
    }
}

}
