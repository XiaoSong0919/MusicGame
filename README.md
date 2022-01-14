# MusicGame
音游，目前处于开发阶段，使用C#进行编写，UI非常简单；仅供试验，不一定能写完（

-----------------------------------------------------------------

## Note类型

·TAP（最基本）

·Hold（长条）

·Break（具有奖分性质，判定比TAP更加严格）

·Break_hold（绝赞长条，头部为Break，判定比Hold略为严格）

## 判定

Perfect +- 30ms

GREAT             +-70ms

GOOD             +-120ms

MISS              >120ms

<details>
  
 <summary><b>&nbsp;&nbsp;&nbsp; 详细判定</b></summary>
  
| Note | Max Perfect | Perfect | Perfect | Perfect | Perfect | Great  | Great | Great | Good | Good |
| :--: | :---------: |  :----: | :-----: | :-----: | :-----: | :----: | :---: | :---: | :--: | :--: |
|      | -10ms       | +-15ms  | +-20ms  | +-25ms  | +-30ms  | +-40ms | +-50ms | +-60ms | +-70ms | +-120ms |
| Tap | 500| 500 | 500 | 500 | 500 | 400 | 400 | 400 | 250 | 250 |
| Hold | 1000 | 1000 | 1000 | 1000 | 1000 | 800 | 800 | 800 | 500 | 500 |
| Break | 2600 | 2575 | 2550 | 2525 | 2500 | 2000 | 1750 | 1500 | 1250 | 1000 |

    
<br/>
  
</details>

## 各类Note分数

TAP: Perfect 500 ;Great 400 ;Good 250 ;Miss 0

Hold: Perfect 2x;Great 1.6x;Good 1x;Miss 0

Break: Perfect 2600 2575 2550 2525 2500 ;Great 2000 1750 1500 1250 ;Good 1000

Break Hold: Perfect 2600 2575 2550 2525 2500 ;Great 2000 1750 1500 1250 ;Good 1000
