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
  
BREAK 2600       +-10ms（大P）

BREAK 2575       +-15ms

BREAK 2550       +-20ms

BREAK 2525       +-25ms

BREAK 2500       +-30ms（小P）

GREAT 2000       +-40ms
  
  GREAT 1750     +-50ms
  
  GREAT 1500     +-60ms

GOOD 1250        +-70ms
  
  GOOD 1000        +-120ms

MISS              >120ms

    
<br/>
  
</details>

## 各类Note分数

TAP: Perfect 500 ;Great 400 ;Good 250 ;Miss 0

Hold: Perfect 2x;Great 1.6x;Good 1x;Miss 0

Break: Perfect 2600 2575 2550 2525 2500 ;Great 2000 1750 1500 1250 ;Good 1000

Break Hold: Perfect 2600 2575 2550 2525 2500 ;Great 2000 1750 1500 1250 ;Good 1000
