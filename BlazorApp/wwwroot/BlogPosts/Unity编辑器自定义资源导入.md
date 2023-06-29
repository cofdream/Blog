# Unity编辑器自定义资源导入


### 涉及类/属性

[ScriptedImporter](https://docs.unity3d.com/cn/current/ScriptReference/AssetPostprocessor.html)

> 自定义资源导入器的抽象基类。脚本化导入器是与特定文件扩展名关联的脚本。Unity 的资源管线调用它们来将关联文件的内容转换为资源。

[ScriptedImporterAttribute](https://docs.unity3d.com/cn/current/ScriptReference/AssetImporters.ScriptedImporterAttribute.html)

> 用于向 Unity 的资源导入管线注册派生自 ScriptedImporter 的自定义资源导入器的类属性。使用 ScriptedImporterAttribute 类可向资源管线注册自定义导入器。

[AssetDatabase.SetImporterOverride<T>(string path) where T : ScriptedImporter](https://docs.unity3d.com/cn/current/ScriptReference/AssetDatabase.SetImporterOverride.html)

> 将特定导入器设置为用于资源。

[AssetPostprocessor](https://docs.unity3d.com/cn/current/ScriptReference/AssetPostprocessor.html)

> 在资源导入或重新导入以后由unity调用。主要使用 OnPreprocessAsset() 或者OnPostprocessAllAssets

