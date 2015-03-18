
//TODO のこりは＋ゲームオーバー処理

 // マップスクロール基本
#include "DxLib.h"
#include <iostream>
#include <stdio.h>
#include <time.h>

using namespace std;

#define WINDOW_WIDTH  640//Windowsサイズ
#define WINDOW_HEIGHT  480

#define MAP_SIZE	32			// マップチップ一つのドットサイズ

#define MAP_WIDTH	10			// マップの幅
#define MAP_HEIGHT	15			// マップの縦長さ

#define MOVE_FRAME	8			// 移動にかけるフレーム数

// マップのデータ
//プレイヤーが移動できる範囲を表示している
int MapData[ MAP_HEIGHT ][ MAP_WIDTH ] =
{
	{ 0, 2, 2, 2, 2, 2, 2, 2, -2, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }
} ;



//マップに配置するブロック数（マップより１マスずつ小さい
//ブロックの情報が入る
int MapBlock[ MAP_HEIGHT ][ MAP_WIDTH ] =
{
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }
};
int MapBlockCopy[ MAP_HEIGHT ][ MAP_WIDTH ] =
{
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 1, 1, 1, 1, 1, 1, 1, -1, 0 } ,
	{ 0, 0, 0, 0, 0, 0, 0, 0,  0, 0 }
};

//プレイヤーの描画
int PlayerGraph;

// プレイヤーの位置
// プレイヤーの内部初期位置をセット
int PlayerX=4 , PlayerY=8 ;

//画面表示
int windowGraph;

//えんど部分の描画
int endGraph;

// 移動しているかどうかのフラグ( 0:停止中  1:移動中 )
int Move = 0 ;

// 各方向に移動する量
int MoveX, MoveY ;

// 移動し始めてから何フレーム経過したかを保持する変数
int MoveCounter ;

//ブロックの初期配置のスイッチとなる
//一度作動すると二度と作動しない
bool blockset = true;

//一回だけボタン判定が起こる
int inputz=0;

//デフォルトカラー
int col = GetColor(255,255,255);

//キー入力メソッド
int Key[256]; // キーが押されているフレーム数を格納する

//ここで６０フレームのうち一回だけ動くために必要な変数を定義
//使う場所はDownblock();
int frame=0;

//スコア
INT64 GameScore=0;
INT64 instScore=0;//ゲームスコアが少しずつ加算されていくように見せかける

//ブロック生成用の変数
int instantiateTime=0;

//ゲームオーバー処理用変数
int gameOver=300;
bool GameOverFlag = false;

//ここからゲーム起動したときに出現するオブジェクトの生成
//ランダム関数でブロックを決める。
inline void InitRand(){//疑似乱数ではなくしっかりとした乱数値にする
    srand((unsigned int)time(NULL));
}
inline int Dice(){
    return rand() % 4 + 1;
}
void rndMap(){
	for(int i = 6; i < MAP_HEIGHT-1;i++){
		for(int j = 1; j < MAP_WIDTH-1;j++){
			MapBlock[i][j] = Dice();
		}
	}
}

// マップとプレイヤーの描画関数
void GraphDraw(){
	int j , i ;
	int MapDrawPointX , MapDrawPointY ;		// 描画するマップ座標値
	int DrawMapChipNumX , DrawMapChipNumY ;	// 描画するマップチップの数



	// 描画するマップチップの数をセット
	DrawMapChipNumX = WINDOW_WIDTH / MAP_SIZE + 2 ;
	DrawMapChipNumY = WINDOW_HEIGHT / MAP_SIZE + 2 ;

	// 画面左上に描画するマップ座標をセット
	MapDrawPointX = 0;
	MapDrawPointY = 0;


	// マップを描く
	for( i = -1 ; i < DrawMapChipNumX ; i ++ ){
		for( j = -1 ; j < DrawMapChipNumY ; j ++ ){
			// 画面からはみ出た位置なら描画しない
			if( j + MapDrawPointX < 0 || i + MapDrawPointY < 0 ||
				j + MapDrawPointX >= MAP_WIDTH || i + MapDrawPointY >= MAP_HEIGHT ) continue ;

			//ここのスイッチ文でブロックを呼び出す。
			//白いブロックはエラーの可能性
			switch (MapBlock[i][j]){
				case 1:
					DrawBox(j * MAP_SIZE,			i * MAP_SIZE,
						j * MAP_SIZE + MAP_SIZE,	i * MAP_SIZE + MAP_SIZE,
						GetColor( 255 , 0 , 0 ) , TRUE ) ;
				break;
			case 2:
					DrawBox(j * MAP_SIZE,			i * MAP_SIZE,
						j * MAP_SIZE + MAP_SIZE,	i * MAP_SIZE + MAP_SIZE,
						GetColor( 144, 255 , 255 ) , TRUE ) ;
				break;
			case 3:
					DrawBox(j * MAP_SIZE,			i * MAP_SIZE,
						j * MAP_SIZE + MAP_SIZE,	i * MAP_SIZE + MAP_SIZE,
						GetColor( 0 , 255 , 0 ) , TRUE ) ;
				break;
			case 4:
					DrawBox(j * MAP_SIZE,			i * MAP_SIZE,
						j * MAP_SIZE + MAP_SIZE,	i * MAP_SIZE + MAP_SIZE,
						GetColor( 144 , 0 , 156 ) , TRUE ) ;
				break;
			case 0:
				break;
			default:
					DrawBox(j * MAP_SIZE,			i * MAP_SIZE,
						j * MAP_SIZE + MAP_SIZE,	i * MAP_SIZE + MAP_SIZE,
						GetColor( 255 , 255 , 255 ) , TRUE ) ;
				break;
			}
			// マップデータが０だったら水色の四角を描画する
			if( MapData[i][j] == 0 ){
				DrawBox(j* MAP_SIZE,			i * MAP_SIZE,
					j * MAP_SIZE + MAP_SIZE ,	i * MAP_SIZE + MAP_SIZE,
					GetColor( 12 , 177 , 255 ) , TRUE ) ;
					
			}else if(MapData[i][j]==2 || MapData[i][j]==-2){
				DrawGraph(j*MAP_SIZE,i*MAP_SIZE,endGraph,true);//ブロックきたらあかんところを描画
			}

		}
	}

	//オブジェクト（プレイヤーが消すべきブロック群の描画
	if(blockset==true){
		for(int q = 1; q < DrawMapChipNumX-1;q++){
			for(int w = 1; w < DrawMapChipNumY-1;w++){
				rndMap();
			}
		}
	}
	blockset=false;

	DrawGraph( 0,0,windowGraph,TRUE);//プレイヤー描画とTRUEによる透過
}

//ブロックを入れ替えるメソッド
void swapBlock(int PlayerY, int PlayerX){
	int temp;
	if(inputz==0){//入力されたばかりならブロック入れ替え
		temp = MapBlock[PlayerX][PlayerY];
		MapBlock[PlayerX][PlayerY] = MapBlock[PlayerX][PlayerY+1];
		MapBlock[PlayerX][PlayerY+1] = temp;
	}
}

//プレイヤーとそのモーションを内部的に移動するメソッド
void MovePlayer(int Key){
	// 移動中ではない場合キー入力を受け付ける
		if( Move == 0 ){
			// キー入力を得る
			Key = GetJoypadInputState( DX_INPUT_KEY_PAD1 ) ;
			
			// キー入力に応じてプレイヤーの座標を移動
			if( Key & PAD_INPUT_LEFT ){
				Move = 1 ;
				MoveX = -1;
				MoveY = 0 ;
			}
			if( Key & PAD_INPUT_RIGHT ){
				Move = 1 ;
				MoveX = 1 ;
				MoveY = 0 ;
			}
			if( Key & PAD_INPUT_UP ){
				Move = 1 ;
				MoveX = 0 ;
				MoveY = -1 ;
			}
			if( Key & PAD_INPUT_DOWN ){
				Move = 1 ;
				MoveX = 0 ;
				MoveY = 1 ;
			}
			//同時押しの際はプレイヤーを動かさない
			if( Key & PAD_INPUT_LEFT && Key & PAD_INPUT_RIGHT){
				Move = 0;
				MoveX =0;

			}
			if( Key & PAD_INPUT_DOWN && Key & PAD_INPUT_UP ){
				Move = 0;
				MoveY = 0;
			}
			
			// 進入不可能なマップだった場合は移動できない
			if( Move == 1 ){
				if( MapData[ PlayerY + MoveY ][ PlayerX + MoveX ] < 1 ){
					Move = 0 ;
				}else{
					MoveCounter = 0 ;
				}
			}
		}

		// 移動中の場合は移動処理を行う
		if( Move == 1 ){
			MoveCounter ++ ;

			// 移動処理が終了したら停止中にする
			if( MoveCounter == MOVE_FRAME ){
				Move = 0 ;

				// プレイヤーの位置を変更する
				PlayerX += MoveX ;
				PlayerY += MoveY ;
			}
		}

		//ｚキーを押した際にとなりあったブロックを入れ替える
		if(Key & PAD_INPUT_A && Move == 0){
			swapBlock(PlayerX,PlayerY);
			inputz++;
		}else{
			inputz=0;
		}
}

//プレイヤーとそのモーションを描画するメソッド
void DrawPlayer(int Mox,int Moy){
	int motion=4;
	if(Mox<0 || Moy<0){//もし左方向か上方向へいくならmoion変数を反転させる
		motion=-1*motion;
	}

	if(Move==0){
	// プレイヤーの描画

		DrawGraph( PlayerX  * MAP_SIZE,//プレイヤーX軸
			PlayerY * MAP_SIZE ,//プレイヤーY軸
			PlayerGraph,TRUE);//プレイヤー描画とTRUEによる透過
	}else if(Mox!=0 && Moy==0 && Move!=0){// ここでプレイヤーのモーションを制御する
		//左右へ行くときの描画
		DrawGraph( PlayerX  * MAP_SIZE+MoveCounter*motion,//プレイヤーX軸
			PlayerY * MAP_SIZE ,//プレイヤーY軸
			PlayerGraph,TRUE);//プレイヤー描画とTRUEによる透過
	}else if(Mox==0 && Moy!=0 &&Move!=0){
		//上下へ行くときの描画
		DrawGraph( PlayerX  * MAP_SIZE,//プレイヤーX軸
			PlayerY * MAP_SIZE + MoveCounter * motion ,//プレイヤーY軸
			PlayerGraph,TRUE);//プレイヤー描画とTRUEによる透過
	}
}

//ブロックを探索して３つ以上並んでいれば消すメソッド
void RemoveBlockX(int deleteSum,int i,int j){

	while(deleteSum>0){
		MapBlock[i][j+deleteSum-1]=0;
		deleteSum--;
	}
}

void RemoveBlockY(int deleteSum,int i,int j){
	while(deleteSum>0){
		MapBlock[i+deleteSum-1][j]=0;
		deleteSum--;
	}
}

int SeachX(int i ,int j ){
	int count=1;
	if(MapBlock[i][j]!=0){
		while(MapBlock[i][j] == MapBlock[i][j+count]){
			count++;
		}
		return count;
	}
	return 0;
}

int SeachY(int i , int j ){
	int count=1;
	if(MapBlock[i][j] != 0){
		while(MapBlock[i][j] == MapBlock[i+count][j] ){
			count++;
		}
		return count;
	}
	return 0;
}

void setScore(int set){//グローバル変数のgamescoreに対して加算をするメソッド
	switch (set){
	case 4:
		GameScore +=(set*500);
		break;
	case 5:
		GameScore +=(set*1000);
		break;
	default:
		GameScore +=(set*250);
		break;
	}
}

//ブロックを探索するメソッド
void SeachBlock(){
	//int seach[1][2] ={0,0};
	//mapblock[map_height][map_width]にあるすべてのブロックのデータを探索する
	//for(int i = MAP_HEIGHT-2; i >=0;i--){
		//for(int j = MAP_WIDTH-2; j > 0; j--){
	for(int i = 0; i <MAP_HEIGHT-1;i++){
		for(int j = 1;j<MAP_WIDTH-1;j++){
			int SUM = SeachX(i,j);
			if(SUM >= 3){
				RemoveBlockX(SUM,i,j);
				setScore(SUM);
			}
			SUM = SeachY(i,j);
			if(SUM >= 3){
				//printfDx("aaz");
				setScore(SUM);
				RemoveBlockY(SUM,i,j);
			}
		}
	}
}

//ブロックが落ちるようになるメソッド
void DownBlock(){
	if(frame == 15){
		for(int i = MAP_HEIGHT-3;i>=0;i--){
			for(int j = MAP_WIDTH;j>0;j--){
				if(MapBlock[i+1][j]==0){//もしmapblockのしたが何もない空間なら
					MapBlock[i+1][j]=MapBlock[i][j];//ブロックを一つ下げる
					MapBlock[i][j]=0;//元の場所にあるブロックを削除
				}
			}
		}
		frame=0;		
	}else{
		frame++;
	}
}

//スコアメソッド
void Score(){//少しずつ加算されていっているように見える
	
	if(GameScore!=instScore){
		instScore=instScore+10;
	}
	DrawFormatString(540,0,col,"SCORE");
	DrawFormatString(540,20,col,"%d",instScore);//得点表示
}
//ハイスコア保存メソッド
//このメソッドでテキストファイルを作成し、その中にハイスコアを保存する。
int RefreshScore(int score){
  FILE* fp;
  int hiscore;
  fp = fopen("score.txt", "r");
  if(fp != NULL){
    fscanf(fp, "%d", &hiscore);
    fclose(fp);
  }
  if(fp == NULL || hiscore < score){
    fp = fopen("score.txt", "w");
    fprintf(fp, "%d", score);
    fclose(fp);
	return score;
  }
  if(hiscore>=score){
	  return hiscore;
  }
}
//ブロック生成メソッド
void BlockInstance(){
	int instTime=180;//通常はおよそ3秒でブロック生成
	bool swt=true;
	instTime -= (int)((GameScore / 3000)*9);//スコアが貯まると減っていく
	if(instTime<20)instTime=20;
	if(instantiateTime>=instTime){
		instantiateTime=0;
		//
		for(int i = 1 ; i < MAP_WIDTH-1 ; i++){//2次元配列でのlengthができなかったので代用
			if(MapBlock[0][i]!=0)swt = false;
		}
		if(swt==true){
			int rnd=rand()%8+1;
			int rnd2=rand()%8+1;
			if(rnd == rnd2 && rnd !=8){
				rnd2++;
			}else if(rnd==8){
				rnd2--;
			}else if(rnd==1){
				rnd2++;
			}
			MapBlock[0][rnd]=Dice();
			if(GameScore>=5000){
				MapBlock[0][rnd2]=Dice();
			}
		}
			
	}else{
	instantiateTime++;
	}
}

//ゲームオーバーメソッド
void GameOver(){
	bool block = false;

	for(int i = 1; i< MAP_WIDTH-1; i++){
		if(MapBlock[0][i]!=0){
			block = true;
		}
	}
	if(block == true){
		gameOver--;
	}else{
		gameOver= 300;
	}
	float go = (float)gameOver/60.0+0.9;
	DrawFormatString(540,80,col,"DEATH COUNT");
	DrawFormatString(540,100,col,"%d",(int)(go));//得点表示

	if(gameOver<=0){
		GameOverFlag=true;
	}
}
//再挑戦するときのメソッド
//無理やりすぎるけど時間なさすぎ
void retry(){
	PlayerX=4;
	PlayerY=8;
	Move=0;
	inputz=0;
	blockset=true;
	GameScore=0;
	instScore=0;
	instantiateTime=0;
	gameOver=300;
	GameOverFlag=false;

	for(int i = 0; i<MAP_HEIGHT;i++){
		for(int j = 0;j<MAP_WIDTH; j++){
			MapBlock[i][j]=MapBlockCopy[i][j];
		}
	}
}

// ＷｉｎＭａｉｎ関数
int WINAPI WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow ){
	ChangeWindowMode(true);
	int Key = 0;

	//間に合わせ変数
	int OP = 0;//オープニング用
	//				640				480
	SetGraphMode( WINDOW_WIDTH , WINDOW_HEIGHT , 16 ) ;
	if( DxLib_Init() == -1 )	// ＤＸライブラリ初期化処理
	{
		 return -1;				// エラーが起きたら直ちに終了
	}

	// 描画先画面を裏画面にする
	SetDrawScreen( DX_SCREEN_BACK ) ;

	//プレイヤー描画
	PlayerGraph = LoadGraph("Player1.png");

	//操作説明画像
	windowGraph = LoadGraph("keyboard.png");

	//endブロック描画
	endGraph  = LoadGraph("end.png");

	//擬似ランダムを完全なランダムにする
	InitRand();
	
	//スコア準備
	Score();

	// 最初は停止中(0)にしておく
	Move = 0 ;


	// ループ
	while( ProcessMessage() == 0 && CheckHitKey( KEY_INPUT_ESCAPE ) == 0){
		// 画面を初期化
		ClearDrawScreen() ;

		//ゲームオープニング
		switch (OP){
		case 0:
			DrawFormatString(WINDOW_WIDTH/2-30,WINDOW_HEIGHT/2-80,col,"PANERIS");

			DrawFormatString(WINDOW_WIDTH/2-55,WINDOW_HEIGHT/2,col,"PUSH \"S\" KEY");
			
			if(CheckHitKey(KEY_INPUT_S)!=0){
				OP = 1;
			}
			break;
		case 1:
		//ゲームオーバーフラグが立たない限り以下の内容を繰り返す
		if(GameOverFlag == false){

		// マップを描画
		GraphDraw() ;

		//プレイヤーを内部的に場所移動
		//ちなみにここでブロック入れ替えのメソッドを使用している
		//swapBlock（）；
		MovePlayer(Key);

		//ブロック入れかえを終えた後に判定を行う
		//３マス以上並べば消す判定とする
		//その場合はseachblockメソッドにあるRemoveBlockメソッドを利用
		SeachBlock();

		//ブロックが生成されるようになるメソッド
		BlockInstance();
		//ブロックが落ちるようになるメソッド
		DownBlock();

		//プレイヤーとそのモーションを描画
		//引数でどの方向に移動したかを判定する
		DrawPlayer(MoveX,MoveY);

		//スコア表示
		Score();
		
		//ゲームオーバー処理
		GameOver();

		}else{//ゲームオーバーフラグが立ったら
			int high = RefreshScore(GameScore);
			DrawFormatString(WINDOW_WIDTH/2-50,WINDOW_HEIGHT/2-125,col,"GAME OVER");
			DrawFormatString(WINDOW_WIDTH/2-50,WINDOW_HEIGHT/2-85,col,"HIGH SCORE");
			DrawFormatString(WINDOW_WIDTH/2-30,WINDOW_HEIGHT/2-60,col,"%d",high);//ハイスコア
			DrawFormatString(WINDOW_WIDTH/2-30,WINDOW_HEIGHT/2-25,col,"SCORE");
			DrawFormatString(WINDOW_WIDTH/2-30,WINDOW_HEIGHT/2,col,"%d",GameScore);
			DrawFormatString(WINDOW_WIDTH/2-100,WINDOW_HEIGHT/2+100,col,"RETRY:PUSH \"R\" KEY");
			if(CheckHitKey(KEY_INPUT_R)!=0){
				retry();
			}
		}
		break;
		default:
			break;
		}
		// 裏画面の内容を表画面に映す
		ScreenFlip();
	}

	DxLib_End() ;				// ＤＸライブラリ使用の終了処理

	return 0 ;					// ソフトの終了
}
