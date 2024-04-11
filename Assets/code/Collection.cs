using UnityEngine;

public class Collection : MonoBehaviour
{
    public Rigidbody2D rb; 
    public LayerMask ground;// 声明一个公共的Rigidbody2D变量

    void Start()
    {
        // 检查rb变量是否已分配，如果未分配，则尝试获取它
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>(); // 尝试获取Rigidbody2D组件
        }

        // 检查rb变量是否仍未分配，如果仍未分配，则打印错误消息
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D组件未找到！");
        }
        else
        {
            // 启用重力
            rb.gravityScale = 1f;
        }
    }

    // 在这里定义其他的变量和方法

    // 处理触发器碰撞的逻辑
 private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("触发器碰撞到物体：" + collision.gameObject.name); // 添加调试日志，检查是否进入了 OnTriggerEnter2D 方法

    if (collision.tag == "ground")
    {
        Destroy(collision.gameObject); // 当触发器碰到tag为"Collection"的物体时，销毁该物体
    }
}

}