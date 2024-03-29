# Proxy

## そのパターンの用途、どんなケースに適用できるか
初期処理であるインスタンスの生成に時間がかかるという場合、必要になる処理を行うまではそのインスタンスを生成しないようにしたい
こういう場合にProxyパターンを使える  
書籍ではこのインスタンスが必要になった時点で生成するというのはVirtualProxyと呼ばれるもので、他にもRemoteProxyとかAccessProxyというパターンもあるとのこと  
必要になったら生成するというより、ClientとRealObjectとの間に入り込むような実装であれば、Proxyパターンと言えるのではと考えた。

## 作成したサンプルコードの概要説明
ブログサイトのAPIを考える。  
このブログサイトのAPIには、記事の一覧取得、作成、削除の3つの機能がある。  
記事を見るのは誰でもできるが、作成、削除は限られたユーザしかできない。  
この限られたユーザだけができるという機能をProxyパターンで実装してみる  

## クラス図の説明

## ソースコードの説明

## そのパターンを適用した場合のメリット
1つのユースケースに対して、インターフェースが統一されていることで、RealObjectとProxyの入れ替えが容易である  
今回の例では必要になる処理を行うまではそのインスタンスを生成しないということはやっていないのでその点に関してはメリットはない  

## 宿題
認証機能を外だししてみる。
外だししてみた。ただ、これだけだと処理を移動しただけなので、Proxyパターンっぽくならない

記事のデータを複数渡すと一気に作成してくれるという機能が追加で出てきたという状況を想定してみた。
1回1回記事を作成するAPIを呼ぶと遅いので、この追加機能を使って高速化したい。

Proxy側でCreateした際はAPIは呼ばずに貯めておいて、Realizeする時点で一気に作成する方のAPIを呼ぶ。
