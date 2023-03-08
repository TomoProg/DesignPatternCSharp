# Visitor

## そのパターンの用途、どんなケースに適用できるか
データ構造と処理を分離させる  
あるクラスにその処理を書くのではなく、その処理を持つクラスを作るイメージ  
（データ構造と処理を分離させたいときとかある？？？）  

## 作成したサンプルコードの概要説明
あるモデルクラスのすべての属性を出力したいというときを考える  
モデルクラスがConcreateElement役、出力するのがConcreateVisitor役とする  

## クラス図の説明
https://lucid.app/lucidchart/804768a6-74c8-410b-9202-b8008e87a003/edit?viewport_loc=-32%2C12%2C2545%2C1237%2CHWEp-vi-RSFO&invitationId=inv_70baa3aa-f07c-449e-956a-4f961c365f60

## ソースコードの説明

## そのパターンを適用した場合のメリット
処理を追加するときにConcreateElementの中身を変える必要はなく  
ConcreateVisitorを追加していくだけでいい  
