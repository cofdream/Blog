---
title: 'Unity 安卓环境 无法使用 GB2312'
date: 2022-09-01 16:40:24
tags: []
published: true
hideInList: false
feature: 
isTop: false
---

<!-- more -->
unity 安卓环境使用 Encoding.GetEncoding("GB2312") 报错

>错误日志：
>NotSupportedException: Encoding 936 data could not be found. Make sure you have correct international codeset assembly installed and enabled.

原因是Unity在发布安卓时并没有包含这些字符集，需要手动加相关的dll(I18N.DLL 和 I18N.CJK.DLL)加到项目内(Assets下就行，没有具体要求)。

#### 相关目录
>老版本 Editor\Data\Mono\lib\mono\2.0
>新版本 Editor\Data\MonoBleedingEdge\lib\mono\unityjit

### 参考
[Unity2019.3 and I18N.dll](https://answers.unity.com/questions/1728036/unity20193-and-i18ndll.html)