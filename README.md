Unity 3D 交互信息展示系统 (Data-Driven UI)
这是一个基于 Unity 开发的 3D 物体交互展示框架。主要解决的问题是：如何通过一份外部 JSON 配置文件，动态驱动场景中多个 3D 物体的图文介绍。

设计思路
    项目采用了数据与表现分离的设计模式：
    数据驱动：所有文字描述、图片路径都写在 JSON 里，增加新物体只需改配置，不需要改代码。
双单例架构：
    DataManager: 负责一次性读取配置，作为内存中的“数据仓库”。
    UIMain: 专门负责 UI 层的刷新逻辑，不直接触碰文件 IO。
    按需加载：使用 Resources.Load 在点击瞬间加载图片，避免一开始就占用过多内存。

关键代码实现
    1. 数据模型 (ItemData.cs)
    定义了 ItemData 基础类和 jieshao 包装类。
    结构：通过 items 列表匹配 JSON 的根节点数组。
    2. 数据中心 (DataManager.cs)
    逻辑：在 Awake 时读取 Resources/Jieshao.json。
    接口：对外提供 GetItemID(int id) 方法，内部做了 id - 1 的索引修正，防止数组越界。
    3. UI 控制 (UIMain.cs)
    刷新机制：接收一个 ID，去 DataManager 拿数据。
    字符处理：通过 .Replace("\\n", "\n") 解决了 JSON 原始文本无法直接换行的问题。
    4. 交互触发 (image.cs)
    触发器：挂载在带有 Collider 的 3D 模型上，通过 OnMouseDown 触发。
    配置：每个模型在 Inspector 面板手动设置一个 idx。

“注：由于字体资源文件超过了 GitHub 限制，未上传至仓库，请下载后参考项目说明自行生成。”

给个starred吧
