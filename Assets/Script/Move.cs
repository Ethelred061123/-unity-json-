using Terresquall;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Mouse Settings")]
    public float mouseSensitivity = 150f;

    public float PhoneMouseSensitivity = 100f;

    [Header("Mobile Joystick (Virtual Joystick Pack)")]
    public VirtualJoystick moveJoystick; // 移动摇杆


    private Rigidbody rb;
    private Transform cameraTransform;
    private Vector3 moveInput;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Camera cam = GetComponentInChildren<Camera>();
        if (cam != null)
            cameraTransform = cam.transform;
        else
            Debug.LogError("未找到摄像机");
#if UNITY_EDITOR || UNITY_STANDALONE
        UIphone.instance.UI.SetActive(false);
#elif UNITY_ANDROID || UNITY_IOS
        UIphone.instance.UI.SetActive(true);

#endif
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandlePCInput();
#elif UNITY_ANDROID || UNITY_IOS
        HandleMobileInput();
#endif
    }

    void FixedUpdate()
    {
        MoveRigidbody();
    }

    // PC
    void HandlePCInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveInput = (transform.right * h + transform.forward * v).normalized;

        if (Input.GetMouseButton(0) && UIMain.Instance.UI.activeSelf == false && UIQuest.Instance.UIquest.activeSelf == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            if (cameraTransform != null)
                cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }
    }

    // 移动
    void HandleMobileInput()
    {
        // 移动（保持你原来的逻辑不变）
        if (moveJoystick != null && UIMain.Instance.UI.activeSelf == false && UIQuest.Instance.UIquest.activeSelf == false)
        {
            Vector2 input = moveJoystick.GetAxis(); // 或 GetAxisRaw()
            float h = input.x;
            float v = input.y;
            moveInput = (transform.right * h + transform.forward * v).normalized;
        }

        // 旋转：仅响应右半屏的触摸滑动
        if (Input.touchCount > 0 && UIMain.Instance.UI.activeSelf == false && UIQuest.Instance.UIquest.activeSelf == false)
        {
            // 遍历所有触摸点，找到右半屏的触摸（可以处理多指，避免和左摇杆冲突）
            foreach (Touch touch in Input.touches)
            {
                // 只响应屏幕右半部分的触摸（和左摇杆区域完全分离）
                if (touch.position.x > Screen.width / 2)
                {
                    // 只处理滑动移动的阶段
                    if (touch.phase == TouchPhase.Moved)
                    {
                        /// 屏幕自适应缩放：参考屏幕宽度/高度，将 deltaPosition 转化为 0~1 范围
                        float normalizedX = touch.deltaPosition.x / Screen.width;
                        float normalizedY = touch.deltaPosition.y / Screen.height;

                        // 计算旋转增量
                        float mouseX = normalizedX * PhoneMouseSensitivity * 100f;
                        float mouseY = normalizedY * PhoneMouseSensitivity * 100f;

                        // 上下视角（相机）
                        xRotation -= mouseY;
                        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                        if (cameraTransform != null)
                            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

                        // 左右视角（角色）
                        transform.Rotate(Vector3.up * mouseX);

                        // 处理完一个触摸就跳出，避免多指冲突
                        break;
                    }
                }
            }
        }
    }

    // ---------------- Rigidbody 移动 ----------------
    void MoveRigidbody()
    {
        Vector3 targetVelocity = moveInput * moveSpeed;
        targetVelocity.y = rb.velocity.y; // 保留重力
        rb.velocity = targetVelocity;
    }
}