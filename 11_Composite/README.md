# Composite

## そのパターンの用途、どんなケースに適用できるか
再帰的な構造を持つものを表現する
容器（複数）と中身（単数）を同じように扱いたいときに使える

## 作成したサンプルコードの概要説明
Dictionary<string, object>の型からJSON文字列を書き出すことを考える  
JSONの中身はkey, valueになっており、valueがまたobjectを持つときもあるため、再帰構造になっている
これをcompositeで表現する

## クラス図の説明


## ソースコードの説明
Attributeクラスが`key: value`の一つの属性と値を表す
RootAttributeはオブジェクト(`{}`)を表し、Attributeを継承したクラスを複数持っている
StringAttributeはvalueがstringの属性のために使う、NumberAttributeはvalueがintの属性のために使う

## そのパターンを適用した場合のメリット
ToJsonStringという呼び出し一つで容器も中身もすべて一緒に統一できる