## Prototype

#### そのパターンの用途、どんなケースに適用できるか
クラスからインスタンスを作るのではなく、すでに存在するインスタンスから別のインスタンスを作る
コピーするイメージ

#### 作成したサンプルコードの概要説明

#### クラス図の説明

#### そのパターンを適用した場合のメリット

#### C#ならでは
ICloneableというインターフェースが存在し、これがCloneというメソッドの実装を強制する。
これを実装すれば、Javaと違い、別のクラスからでも呼び出し可能(publicメソッドになるため。)
また、MemberwiseCloneというのも存在する。これはprotectedメソッドなので、クラス内もしくは派生クラスからしか呼べず、書籍で言っているCloneは自分のクラスおよびサブクラスからしか呼び出せないというのと同じになる。

書籍ではcreateCloneする際にCloneNotSupportedExceptionでcatchしていたが、これはCloneableインターフェースを実装していない場合に出る例外であり、C#ではICloneableがCloneメソッドの実装を強制するため、この例外と同じような例外はないとみた。

メンバが一つもないインターフェースはマーカーインターフェースと呼ばれる。
ただどういうときに使うのかいまいちピンとこない。
msdnにもカスタム属性を使うように書いてあり、歴史的に残っているのか？
https://learn.microsoft.com/ja-jp/dotnet/standard/design-guidelines/interface

ICloneableとMemberwiseCloneの違いは？