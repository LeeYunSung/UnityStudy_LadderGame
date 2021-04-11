# UnityStudy_LadderGame

### - What is LadderGame?
Unity프로그램으로 구현한 사다리 게임입니다.
인원수, 인원 이름, 당첨수, 당첨항목을 설정하여 게임을 진행할 수 있습니다.

### - Major Function
1) 인원수 설정, 인원 이름, 당첨수, 당첨항목 설정 가능
2) 사다리 생성버튼 클릭 시, 설정된 인원 수 만큼 사다리 자동생성(2~9명)
3) 각각의 플레이어 클릭 시, 사다리 타는 애니메이션 실행
4) 플레이어가 끝에 도달했을 때 각각의 결과 출력, 결과보기 버튼을 눌렀을 때는 전체 결과 출력
5) 시에 모든 플레이어가 사다리를 타도록 하는 Quick 버튼
6) Reset 버튼

### - Learned
① 사다리 객체를 랜덤 위치에 생성하는 방법
  1) Row가 Column의 자식임을 이용 → Column에게 Row를 / Row에게 다음 Column을 연결
  2) for 반복문을 이용 →  인원 수 만큼 Column이 생성될 때마다 과정 반복
  3) 향후, 탐색 순서를 지정해주기 위해 연결된 Row 객체를 y값으로 정렬


② Player가 이동경로를 탐색하는 방법(Stack구조를 List<Path>와 재귀함수로 구현함)
  1) Player의 위치 = Column Index → Column[Player Index] 부터 탐색 시작
  2) Column이 갖고 있는 Row List에서 탐색(찾은 Row를 다음 경로로 지정)
  3) Row는 자신이 갖고 있는 좌우 Column 탐색(찾은 Column을 다음 경로로 지정)
  4) 마지막 RowLineList 까지 2), 3) 과정 반복
  5) 마지막 값 경로 일 때, Player에게 this를 반환(결과값)
 
③ Player가 사다리를 따라서 움직이는 애니메이션 구현 방법
1) 경로탐색 때 사용한 함수 활용 → List<Path>변수를 선언하여 경로를 반환하고, Player에게 경로를 저장함
2) 이동 시, 해당 경로의 Position 값을 가져와서 이동
3) 이 때, 부모 객체에 따라 좌표 기준이 달라서 Positoin값이 일정하지 않은 문제 발생
    -> Player객체를 이동하는 Image와 기준좌표를 지정하는 객체로 분리하여 Update()문으로 Image 객체에 Player 객체의 위치를 대입함으로써 해결함

### - Game Screenshot
![그림2](https://user-images.githubusercontent.com/32055099/114312446-ac363780-9b2d-11eb-9f26-8c338943bb36.png)
