# Interpreter

## そのパターンの用途、どんなケースに適用できるかるのでは？
自作言語を作るときの構文を解析するときに使える  
言語の文法規則をそのままクラスにしてしまう  

## 作成したサンプルコードの概要説明
マウス操作を自動化するツール  
ツールにはプログラミングする機能があり、テキストにプログラムを書くとその通りマウスを動かしてくれる  

プログラムの仕様は以下
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
動作を変えたかったらインタプリタそのものを変更する必要はなく、自作したプログラム側を変更すればいい  
インタプリタに実装されてさえいれば、用途によって、いろんなプログラムを書ける  