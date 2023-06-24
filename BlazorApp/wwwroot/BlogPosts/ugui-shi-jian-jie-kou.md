---
title: 'UGUI 事件接口'
date: 2022-09-14 04:55:30
tags: [UGUI,Unity]
published: true
hideInList: false
feature: 
isTop: false
---
## 拖拽事件
> IDragHandler
> IBeginDragHandler
> IEndDragHandler

其中需要注意的是 IBeginDragHandler 和 IEndDragHandler 依赖 IDragHandler，需要继承了IDragHandler的情况下才会执行对应的接口函数！

------
