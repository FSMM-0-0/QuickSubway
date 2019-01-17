# QuickSubway

> Date: 2019.1  
> Author: FSMM & XCyclone

## 开发环境

* 64bit windows10
* visual studio 2017
* GUI: winform
* 语言: c++ c#

## 运行环境

Microsoft .NET framework

## 使用说明

### 命令行程序

1. 线路信息输出

```shell
QuickSubway.exe
1号线
房山线
```

2. 两点之间最短路径（最少站数）

```shell
QuickSubway.exe /b 魏公村 良乡大学城北
```

3. 两点之间最短路径（最少换乘）

```shell
QuickSubway.exe /c 魏公村 良乡大学城北
```

4. 站点全遍历（最少站数）

```shell
QuickSubway.exe /a 魏公村
```

5. 站点全遍历（最少换乘）

```shell
QuickSubway.exe /d 魏公村
```

6. 全遍历结果测试

```shell
QuickSubway.exe /z filename
```

### UI界面

1. 打开UI界面

```shell
QuickSubway_GUI.exe /g
```

2. UI界面站点全遍历

```shell
QuickSubway_GUI.exe /g 知春路
```

3. UI界面直接运行（封装后）

运行 Quick Subway.exe

## 成果展示

![全遍历](https://img-blog.csdnimg.cn/20190117001139617.gif)
