※初回以外



※操作を間違えたら**データが消える**こともあるので気をつけろよ

※自分の担当しているステージに謎の変更があったりしたらLINEで言って

# 作業開始前

1. GitHub Desktopを開く
2. 左上の「Current repository」がshobonであることを確認する
3. 「Current repository」の右の「Current branch」をクリックし、developを選択する(「Switch branch」という画面が出てくるけど、気にせず初期状態で「Switch branch」をクリック)
4. 「Current branch」の隣のFetch Originをクリックする(リモートの状態を取得する)
5. もしリモートに変更があった場合、「Fetch origin」がPull originに変化する
6. その場合、ローカルの内容が上書きされることを理解して(上書きされたくないときは、作業終了後の手順を踏む)、「Pull origin」をクリックする
7. この状態で、Unitを開き作業をする。

# 作業終了後

1. 作業を終了したら、Unityでしっかり保存してから、Unityを閉じる
2. Github Desktopを開く
3. 同様に、左上の「Current repository」がshobonであることを確認
4. 同様に「Current repository」の右の「Current branch」をクリックし、developを選択する(「Switch branch」という画面が出てくるけど、気にせず初期状態で「Switch branch」をクリック)
5. 左上の「Current repository」の下のchangesをクリックする
6. すると「〇 changed files」と表示されている
7. その左のチェックを何回かクリックして、チェックをつけた状態にする
8. 左下の「Summary (required)」にコミットメッセージ(適当に何をやったか書いてほしい、もし余裕があったら[こことか](https://qiita.com/itosho/items/9565c6ad2ffc24c09364)を参考に)を書く
9. すると下の 「commit to develop」(ここがcommit to main担ってたらダメ)がクリックできるようになるので、クリックをする
10. するともしかしたらまだ 1 changed file とでて、shobonファイルが残っているかもしれないけど無視する
11. 次は「Fetch origin」や「Pull origi」などで使った部分が 「Push origin」に変わっているはず
12. 覚悟を決めて(リモートが更新されるため)、Push origin をクリックする。(ここで何か警告が出る場合は下の「conflictが起きた時」を見る)


# conflictが起きた時

- 通常あり得ない、誰かが自分の担当ではないファイルをいじった時に発生する
- 同じファイルを二人がいじっていたために起きています

## 直す手順

1. 警告の画面が出ている
2. Fetchを選択する
3. 右のchangesをクリックする
4. すると三角の警告マークが出ているファイルがあるのでクリックする。

![例](img/スクリーンショット%202022-09-12%20025159.png)

5. 上のようになっていると思います
6. 今度はは警告マークが出ているファイルを右クリックして、「Open in Visual Studio Code」を選択

        <<<<<<< HEAD 
        ...... (a)
        ========
        .......(b)
        >>>>>>> jlfsaofsdaghasfjs

7. ある人の編集した状態が(a)の内容で、別の人の編集した状態が(b)の内容であることを表している
8. このうち正しいほう(これが分からない場合はLINEで)、だけを残す

        .......(a)

![例](img/スクリーンショット%202022-09-12%20030249.png)

9. これでファイルを上書き(crl+s)して、Github Desktopに戻るとファイルの隣の警告マークが消えていると思う
10. 同様に 〇 changed file の右を何回かクリックしてチェックを付ける
11. まだ警告マークと 「Resolve conflicts to continue merge into develop.[View conflict]()」が出ている部分があるので、「View conflict」をクリック
12. Continue mergeをクリックする
13. 「Push origin」をクリックする(もしかしたら、また同じ現象が起きるかもしれないが、その時はこの手順をまた繰り返そう、不安なら相談)
