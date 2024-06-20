# Escape-from-the-Invaded-City
UnityとLeap Motion Controller 2を用いて制作した3Dシューティングゲームのソースコードです
## My Game Video
下の画像をクリックするとプレイ動画を再生できます。
[![Watch the video](https://img.youtube.com/vi/n9LwsK46Pec/maxresdefault.jpg)](https://www.youtube.com/watch?v=n9LwsK46Pec&t=3s)
以下に各ソースコードの解説を記載する。
## EnemyManager.cs(C#コード) 
コードは敵の行動全般を実装するためのクラスである. 主に索敵,プレイヤーを見つ
けた際の追跡,攻撃,効果音,HPを実装している. 「using UnityEngine.AI」と記述することで,対象
のオブジェクトを追跡するために必要な関数や変数,機能を参照するために必要なライブラリ
を用意することが可能である. 最初に,Startの中で追跡の対象となるオブジェクトの設定と効
果音の設定を行っている. 音源などはComponentにAudio Sauseを設定して,Audio Clipに使用
したい音源ファイルを入れることによって実装することが可能である.  
OnDetectObjectの中にプレイヤーを感知した際の敵の
行動について記述してある. この記述により,敵オブジェク
トは右の画像のような球状の領域にPlayerタグのオブジェ
クトが侵入してきた際に自動で追跡と攻撃をするようにプ
ログラムされている. 具体的にどのようにしてこの機能を
実装したかについて記述する. 「collider.CompareTag」で
領域に侵入したオブジェクトのタグを参照してtrueであるな
らば「_agent.destination」を侵入したオブジェクトの座標に
している. また,「if (count % 60 == 0)」で1秒に一回の射撃
を実現している. このとき,countは1フレームごとに更新さ
れる. 「audioSource.PlayOneShot(shootSound)」によって設定した効果音を再生している. また,
「OnCollisionEnter」を用いてプレイヤーの銃弾に触れた時の処理を記述している. Enemy_HP
は99に設定しているため3回攻撃を受けたら消滅するようになっている. 

## CollisionDetector.cs（C＃コード） 
また,敵の子要素の球状の領域にアタッチして,EnamyManagerの関数を呼び起こすために記述
したコードも以下に記載する.  

## GunManager.cs(C#コード)
次に,銃撃を実装するためのコードを記載する. 「power」で銃撃の威力を設定する. また,
「bullletNumber」は銃弾の最初の装弾数である. 今回の場合,トカレフの装弾数の8に設定し
た. また,ゲーム画面で右手の位置に拳銃が表示されるように,「transform.position = new 
Vector3(palmPosition.x, palmPosition.y, palmPosition.z + 2」と記述して拳銃オブジェク
トの座標を手のオブジェクトと同じになるように更新している. また,「if (bulletNumber != 
0)」の条件文の中で銃撃した際の弾の管理を行っている. また,これらの関数は手が指定の
ポーズをとった際に初めて呼び出される.  

## PlayerHPBar（C#コード） 
次に,PlayerのHP機能を実装するためのコードを記載する. 「maxHP」で自分の最大HP, 
「currentHP」で現在のHP,bool型の「isZeroHP」でHPが0になったかどうか,つまりゲームオ
ーバーになった際の処理を行うためのグローバルな変数を用意した. Unity上のHPバーに
反映させるため,「using UnityEngine.AI」でライブラリを参照している.  
 私が作ったゲームではプレイヤーは銃撃を受けたときのみダメージを受けるため
「OnTriggerEnter」でBulletタグのオブジェクトと触れたときに5ダメージずつ減るように記述
した. また,UIのHPバーの値,「slider.value」は最大1であるため,currentHPを反映させるため
には正規化を行分けばならない. 正規化は「slider.value = (float)currentHp / 
(float)maxHp」で行われる.  

## RotateObject.cs(C#コード) 
このコードの記述は弾薬箱の回転を実装するためのコードである. rotationAmountで回
転角度を指定して「ransform.Rotate(Vector3.up, rotationAmount)」で実際に回
転を実行する.  
 また,弾薬箱がPlayerと衝突した際の処理も記述してある. 「gunManager = 
obj.GetComponent<GunManager>()」でGunManagerにアクセスして,
「gunManager.bulletNumbe」でグローバルな変数であるbulletNumberの値を8増や
している. 最後に「Destroy(this.gameObject)」でこのコードがアタッチされたオ
ブジェクト自身を破壊している.

## CountDownTimer.cs(C#コード)
次に時間制限,タイムオーバー,制限時間の表示など時間に関する処理を実装する
ためのクラスを表示する.  
 グローバルな変数「isTimeOver」は時間切れになった際,ゲームオーバーの処理
を行うための処理を呼び出すための変数である.  
 分と秒をUnity上で設定できるようにするためにも新たな記述が必要である. 
「totalTime」にはインスペクターで指定した分と秒をすべて秒に変換してそれら
の和をゲームの制限時間に設定している. 「oldSeconds」は現在の制限時間の分の
部分に+1したものである（例: 現在の制限時間が01:30ならばoldSecondsは2）この
変数で制限時間が1分経るごとの処理を行っている. totalTimeはフレームが更新さ
れるごとに「Time.deltaTime」分だけ減らしている.  
 時間切れになったら「isTimeOver」を「true」に変更している.

 ## GoalDetector.cs(C#コード) 
 このコードはPlayerがゴール（バス）に到達した際の処理を記述している. 
「OnCollisionEnter」の中で効果音を再生してパブリックな変数「isGoal」をtrue
に更新してゲームクリアの際の処理を行えるようにしている. なお,このコードは
バスの子オブジェクトのSphere Colliderにアタッチした. 

## GameManager.cs(C#コード) 
最後に,ゲームの一連の流れを管理するコードを記載する. 今までのコードに出
てきたグローバルな変数にアクセスするため,「public CountDownTimer 
countDownimer」のようにScriptを定義している. また,ゲームオーバーやゲームク
リアの際に流すBGMは「[SerializeField] AudioClip gameOverBGM」と定義してい
る. ゲームオーバーやゲームクリアをした際には,それに対応したPanelを
「SetActive(true)」にして,また,今までに表示していた「PlayerCanvas」は重な
って邪魔になるためSetActve(false)で表示を消している. リトライボタンを押し
た際の処理は「Retry」関数の中に記述してある. 
「SceneManager.LoadScene(SceneManager.GetActiveScene().name)」で現在のシー
ンを再度ローディングすることでリトライを再現している. 
