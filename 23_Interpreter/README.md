# Interpreter

## そのパターンの用途、どんなケースに適用できるかるのでは？

## 作成したサンプルコードの概要説明
マウス操作を自動化するマクロツール  
ミニ言語の仕様
```
<program> ::= program <command list>
<command list> ::= <command>* end
<command> ::= <repeat command> | <primitive command>
<repeat command> ::= repeat <number> <command list>
<primitive command> ::= Move <number> <number> | LeftClick | RightClick 
```

- マウスの移動 Move x y
  - 座標を指定すると指定した座標にマウスを移動する
- 左クリック LeftClick
  - 左クリックを行う
- 右クリック RightClick
  - 右クリックを行う

## クラス図の説明

## ソースコードの説明

## そのパターンを適用した場合のメリット