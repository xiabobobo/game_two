
using UnityEngine;
using UnityEngine.UI;
public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // 存储要生成的物体
    public Vector3 spawnArea; // 生成区域的范围
    public float spawnInterval = 5f; // 生成间隔时间
    public int maxObjectsToSpawn = 30; // 最大生成数量
public float spawnZPosition = 0f;
public float spawnYPosition = 0f;
    private float timer = 0f;
     public Rigidbody2D rb; 
    private int spawnedObjectCount = 0;
    private bool isSpawning = false;
    // public int Tian = 0;
    //public Text TianNum;
 void Start()
    {
        // 检查rb变量是否已分配，如果未分配，则尝试获取它
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>(); 
            // 尝试获取Rigidbody2D组件
        }
    }
    private void FixedUpdate()
    {
        if (spawnedObjectCount >= maxObjectsToSpawn)
        {
            // 已达到最大生成数量，停止生成
            enabled = false;
            Debug.Log("已达到最大生成数量，停止生成");
            return;
        }
        if (!isSpawning)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= spawnInterval)
            {
                // 在生成区域内随机选择一个位置
               Vector3 spawnPosition = new Vector3(
    Random.Range(transform.position.x - spawnArea.x / 2, transform.position.x + spawnArea.x / 2),
    spawnYPosition, // 固定 Y 轴坐标
    spawnZPosition // 固定 Z 轴坐标
);

                // 检查生成位置是否有物体
                Collider[] colliders = Physics.OverlapSphere(spawnPosition, 1f); // 1f为检测半径，根据实际情况调整
                if (colliders.Length == 0)
                {
                    // 随机选择要生成的物体
                    GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
                    // 生成物体
                    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    // 增加生成的物体计数
                    spawnedObjectCount++;
                    // 立即停用脚本，以确保在同一帧内只生成一个物体
                    
                }
                isSpawning = true;
                timer = 0f;
            }
        }
    }
  
}

