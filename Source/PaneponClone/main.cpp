
//TODO �̂���́{�Q�[���I�[�o�[����

 // �}�b�v�X�N���[����{
#include "DxLib.h"
#include <iostream>
#include <stdio.h>
#include <time.h>

using namespace std;

#define WINDOW_WIDTH  640//Windows�T�C�Y
#define WINDOW_HEIGHT  480

#define MAP_SIZE	32			// �}�b�v�`�b�v��̃h�b�g�T�C�Y

#define MAP_WIDTH	10			// �}�b�v�̕�
#define MAP_HEIGHT	15			// �}�b�v�̏c����

#define MOVE_FRAME	8			// �ړ��ɂ�����t���[����

// �}�b�v�̃f�[�^
//�v���C���[���ړ��ł���͈͂�\�����Ă���
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



//�}�b�v�ɔz�u����u���b�N���i�}�b�v���P�}�X��������
//�u���b�N�̏�񂪓���
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

//�v���C���[�̕`��
int PlayerGraph;

// �v���C���[�̈ʒu
// �v���C���[�̓��������ʒu���Z�b�g
int PlayerX=4 , PlayerY=8 ;

//��ʕ\��
int windowGraph;

//����Ǖ����̕`��
int endGraph;

// �ړ����Ă��邩�ǂ����̃t���O( 0:��~��  1:�ړ��� )
int Move = 0 ;

// �e�����Ɉړ������
int MoveX, MoveY ;

// �ړ����n�߂Ă��牽�t���[���o�߂�������ێ�����ϐ�
int MoveCounter ;

//�u���b�N�̏����z�u�̃X�C�b�`�ƂȂ�
//��x�쓮����Ɠ�x�ƍ쓮���Ȃ�
bool blockset = true;

//��񂾂��{�^�����肪�N����
int inputz=0;

//�f�t�H���g�J���[
int col = GetColor(255,255,255);

//�L�[���̓��\�b�h
int Key[256]; // �L�[��������Ă���t���[�������i�[����

//�����łU�O�t���[���̂�����񂾂��������߂ɕK�v�ȕϐ����`
//�g���ꏊ��Downblock();
int frame=0;

//�X�R�A
INT64 GameScore=0;
INT64 instScore=0;//�Q�[���X�R�A�����������Z����Ă����悤�Ɍ���������

//�u���b�N�����p�̕ϐ�
int instantiateTime=0;

//�Q�[���I�[�o�[�����p�ϐ�
int gameOver=300;
bool GameOverFlag = false;

//��������Q�[���N�������Ƃ��ɏo������I�u�W�F�N�g�̐���
//�����_���֐��Ńu���b�N�����߂�B
inline void InitRand(){//�^�������ł͂Ȃ���������Ƃ��������l�ɂ���
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

// �}�b�v�ƃv���C���[�̕`��֐�
void GraphDraw(){
	int j , i ;
	int MapDrawPointX , MapDrawPointY ;		// �`�悷��}�b�v���W�l
	int DrawMapChipNumX , DrawMapChipNumY ;	// �`�悷��}�b�v�`�b�v�̐�



	// �`�悷��}�b�v�`�b�v�̐����Z�b�g
	DrawMapChipNumX = WINDOW_WIDTH / MAP_SIZE + 2 ;
	DrawMapChipNumY = WINDOW_HEIGHT / MAP_SIZE + 2 ;

	// ��ʍ���ɕ`�悷��}�b�v���W���Z�b�g
	MapDrawPointX = 0;
	MapDrawPointY = 0;


	// �}�b�v��`��
	for( i = -1 ; i < DrawMapChipNumX ; i ++ ){
		for( j = -1 ; j < DrawMapChipNumY ; j ++ ){
			// ��ʂ���͂ݏo���ʒu�Ȃ�`�悵�Ȃ�
			if( j + MapDrawPointX < 0 || i + MapDrawPointY < 0 ||
				j + MapDrawPointX >= MAP_WIDTH || i + MapDrawPointY >= MAP_HEIGHT ) continue ;

			//�����̃X�C�b�`���Ńu���b�N���Ăяo���B
			//�����u���b�N�̓G���[�̉\��
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
			// �}�b�v�f�[�^���O�������琅�F�̎l�p��`�悷��
			if( MapData[i][j] == 0 ){
				DrawBox(j* MAP_SIZE,			i * MAP_SIZE,
					j * MAP_SIZE + MAP_SIZE ,	i * MAP_SIZE + MAP_SIZE,
					GetColor( 12 , 177 , 255 ) , TRUE ) ;
					
			}else if(MapData[i][j]==2 || MapData[i][j]==-2){
				DrawGraph(j*MAP_SIZE,i*MAP_SIZE,endGraph,true);//�u���b�N�����炠����Ƃ����`��
			}

		}
	}

	//�I�u�W�F�N�g�i�v���C���[�������ׂ��u���b�N�Q�̕`��
	if(blockset==true){
		for(int q = 1; q < DrawMapChipNumX-1;q++){
			for(int w = 1; w < DrawMapChipNumY-1;w++){
				rndMap();
			}
		}
	}
	blockset=false;

	DrawGraph( 0,0,windowGraph,TRUE);//�v���C���[�`���TRUE�ɂ�铧��
}

//�u���b�N�����ւ��郁�\�b�h
void swapBlock(int PlayerY, int PlayerX){
	int temp;
	if(inputz==0){//���͂��ꂽ�΂���Ȃ�u���b�N����ւ�
		temp = MapBlock[PlayerX][PlayerY];
		MapBlock[PlayerX][PlayerY] = MapBlock[PlayerX][PlayerY+1];
		MapBlock[PlayerX][PlayerY+1] = temp;
	}
}

//�v���C���[�Ƃ��̃��[�V����������I�Ɉړ����郁�\�b�h
void MovePlayer(int Key){
	// �ړ����ł͂Ȃ��ꍇ�L�[���͂��󂯕t����
		if( Move == 0 ){
			// �L�[���͂𓾂�
			Key = GetJoypadInputState( DX_INPUT_KEY_PAD1 ) ;
			
			// �L�[���͂ɉ����ăv���C���[�̍��W���ړ�
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
			//���������̍ۂ̓v���C���[�𓮂����Ȃ�
			if( Key & PAD_INPUT_LEFT && Key & PAD_INPUT_RIGHT){
				Move = 0;
				MoveX =0;

			}
			if( Key & PAD_INPUT_DOWN && Key & PAD_INPUT_UP ){
				Move = 0;
				MoveY = 0;
			}
			
			// �i���s�\�ȃ}�b�v�������ꍇ�͈ړ��ł��Ȃ�
			if( Move == 1 ){
				if( MapData[ PlayerY + MoveY ][ PlayerX + MoveX ] < 1 ){
					Move = 0 ;
				}else{
					MoveCounter = 0 ;
				}
			}
		}

		// �ړ����̏ꍇ�͈ړ��������s��
		if( Move == 1 ){
			MoveCounter ++ ;

			// �ړ��������I���������~���ɂ���
			if( MoveCounter == MOVE_FRAME ){
				Move = 0 ;

				// �v���C���[�̈ʒu��ύX����
				PlayerX += MoveX ;
				PlayerY += MoveY ;
			}
		}

		//���L�[���������ۂɂƂȂ肠�����u���b�N�����ւ���
		if(Key & PAD_INPUT_A && Move == 0){
			swapBlock(PlayerX,PlayerY);
			inputz++;
		}else{
			inputz=0;
		}
}

//�v���C���[�Ƃ��̃��[�V������`�悷�郁�\�b�h
void DrawPlayer(int Mox,int Moy){
	int motion=4;
	if(Mox<0 || Moy<0){//������������������ւ����Ȃ�moion�ϐ��𔽓]������
		motion=-1*motion;
	}

	if(Move==0){
	// �v���C���[�̕`��

		DrawGraph( PlayerX  * MAP_SIZE,//�v���C���[X��
			PlayerY * MAP_SIZE ,//�v���C���[Y��
			PlayerGraph,TRUE);//�v���C���[�`���TRUE�ɂ�铧��
	}else if(Mox!=0 && Moy==0 && Move!=0){// �����Ńv���C���[�̃��[�V�����𐧌䂷��
		//���E�֍s���Ƃ��̕`��
		DrawGraph( PlayerX  * MAP_SIZE+MoveCounter*motion,//�v���C���[X��
			PlayerY * MAP_SIZE ,//�v���C���[Y��
			PlayerGraph,TRUE);//�v���C���[�`���TRUE�ɂ�铧��
	}else if(Mox==0 && Moy!=0 &&Move!=0){
		//�㉺�֍s���Ƃ��̕`��
		DrawGraph( PlayerX  * MAP_SIZE,//�v���C���[X��
			PlayerY * MAP_SIZE + MoveCounter * motion ,//�v���C���[Y��
			PlayerGraph,TRUE);//�v���C���[�`���TRUE�ɂ�铧��
	}
}

//�u���b�N��T�����ĂR�ȏ����ł���Ώ������\�b�h
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

void setScore(int set){//�O���[�o���ϐ���gamescore�ɑ΂��ĉ��Z�����郁�\�b�h
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

//�u���b�N��T�����郁�\�b�h
void SeachBlock(){
	//int seach[1][2] ={0,0};
	//mapblock[map_height][map_width]�ɂ��邷�ׂẴu���b�N�̃f�[�^��T������
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

//�u���b�N��������悤�ɂȂ郁�\�b�h
void DownBlock(){
	if(frame == 15){
		for(int i = MAP_HEIGHT-3;i>=0;i--){
			for(int j = MAP_WIDTH;j>0;j--){
				if(MapBlock[i+1][j]==0){//����mapblock�̂����������Ȃ���ԂȂ�
					MapBlock[i+1][j]=MapBlock[i][j];//�u���b�N���������
					MapBlock[i][j]=0;//���̏ꏊ�ɂ���u���b�N���폜
				}
			}
		}
		frame=0;		
	}else{
		frame++;
	}
}

//�X�R�A���\�b�h
void Score(){//���������Z����Ă����Ă���悤�Ɍ�����
	
	if(GameScore!=instScore){
		instScore=instScore+10;
	}
	DrawFormatString(540,0,col,"SCORE");
	DrawFormatString(540,20,col,"%d",instScore);//���_�\��
}
//�n�C�X�R�A�ۑ����\�b�h
//���̃��\�b�h�Ńe�L�X�g�t�@�C�����쐬���A���̒��Ƀn�C�X�R�A��ۑ�����B
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
//�u���b�N�������\�b�h
void BlockInstance(){
	int instTime=180;//�ʏ�͂��悻3�b�Ńu���b�N����
	bool swt=true;
	instTime -= (int)((GameScore / 3000)*9);//�X�R�A�����܂�ƌ����Ă���
	if(instTime<20)instTime=20;
	if(instantiateTime>=instTime){
		instantiateTime=0;
		//
		for(int i = 1 ; i < MAP_WIDTH-1 ; i++){//2�����z��ł�length���ł��Ȃ������̂ő�p
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

//�Q�[���I�[�o�[���\�b�h
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
	DrawFormatString(540,100,col,"%d",(int)(go));//���_�\��

	if(gameOver<=0){
		GameOverFlag=true;
	}
}
//�Ē��킷��Ƃ��̃��\�b�h
//������肷���邯�ǎ��ԂȂ�����
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

// �v�����l�������֐�
int WINAPI WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow ){
	ChangeWindowMode(true);
	int Key = 0;

	//�Ԃɍ��킹�ϐ�
	int OP = 0;//�I�[�v�j���O�p
	//				640				480
	SetGraphMode( WINDOW_WIDTH , WINDOW_HEIGHT , 16 ) ;
	if( DxLib_Init() == -1 )	// �c�w���C�u��������������
	{
		 return -1;				// �G���[���N�����璼���ɏI��
	}

	// �`����ʂ𗠉�ʂɂ���
	SetDrawScreen( DX_SCREEN_BACK ) ;

	//�v���C���[�`��
	PlayerGraph = LoadGraph("Player1.png");

	//��������摜
	windowGraph = LoadGraph("keyboard.png");

	//end�u���b�N�`��
	endGraph  = LoadGraph("end.png");

	//�[�������_�������S�ȃ����_���ɂ���
	InitRand();
	
	//�X�R�A����
	Score();

	// �ŏ��͒�~��(0)�ɂ��Ă���
	Move = 0 ;


	// ���[�v
	while( ProcessMessage() == 0 && CheckHitKey( KEY_INPUT_ESCAPE ) == 0){
		// ��ʂ�������
		ClearDrawScreen() ;

		//�Q�[���I�[�v�j���O
		switch (OP){
		case 0:
			DrawFormatString(WINDOW_WIDTH/2-30,WINDOW_HEIGHT/2-80,col,"PANERIS");

			DrawFormatString(WINDOW_WIDTH/2-55,WINDOW_HEIGHT/2,col,"PUSH \"S\" KEY");
			
			if(CheckHitKey(KEY_INPUT_S)!=0){
				OP = 1;
			}
			break;
		case 1:
		//�Q�[���I�[�o�[�t���O�������Ȃ�����ȉ��̓��e���J��Ԃ�
		if(GameOverFlag == false){

		// �}�b�v��`��
		GraphDraw() ;

		//�v���C���[������I�ɏꏊ�ړ�
		//���Ȃ݂ɂ����Ńu���b�N����ւ��̃��\�b�h���g�p���Ă���
		//swapBlock�i�j�G
		MovePlayer(Key);

		//�u���b�N���ꂩ�����I������ɔ�����s��
		//�R�}�X�ȏ���ׂΏ�������Ƃ���
		//���̏ꍇ��seachblock���\�b�h�ɂ���RemoveBlock���\�b�h�𗘗p
		SeachBlock();

		//�u���b�N�����������悤�ɂȂ郁�\�b�h
		BlockInstance();
		//�u���b�N��������悤�ɂȂ郁�\�b�h
		DownBlock();

		//�v���C���[�Ƃ��̃��[�V������`��
		//�����łǂ̕����Ɉړ��������𔻒肷��
		DrawPlayer(MoveX,MoveY);

		//�X�R�A�\��
		Score();
		
		//�Q�[���I�[�o�[����
		GameOver();

		}else{//�Q�[���I�[�o�[�t���O����������
			int high = RefreshScore(GameScore);
			DrawFormatString(WINDOW_WIDTH/2-50,WINDOW_HEIGHT/2-125,col,"GAME OVER");
			DrawFormatString(WINDOW_WIDTH/2-50,WINDOW_HEIGHT/2-85,col,"HIGH SCORE");
			DrawFormatString(WINDOW_WIDTH/2-30,WINDOW_HEIGHT/2-60,col,"%d",high);//�n�C�X�R�A
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
		// ����ʂ̓��e��\��ʂɉf��
		ScreenFlip();
	}

	DxLib_End() ;				// �c�w���C�u�����g�p�̏I������

	return 0 ;					// �\�t�g�̏I��
}
