# MusicGame
音游，目前处于开发阶段，使用C#进行编写，UI非常简单；仅供试验，不一定能写完（

-----------------------------------------------------------------

#Note类型

·TAP（最基本）

·Hold（长条，有尾判）

·Break（具有奖分性质，判定比TAP更加严格）

·Break_hold（绝赞长条，尾判更加严格）

#判定细节

BREAK 2600       +-10ms

BREAK 2575       +-15ms

BREAK 2550       +-20ms（大P）

BREAK 2525       +-30ms

BREAK 2500       +-40ms（小P）

GREAT            +-80ms

GOOD             +-160ms

BAD              +200ms>x>+160ms

MISS              <-160ms

#各类Note分数

TAP: Perfect 500 ;Great 400 ;Good 250 ;Miss 0

Hold: Perfect 2x;Great 1.6x;Good 1x;Miss 0

Break: Perfect 2600 2575 2550 2525 2500 ;Great 2000 1750 1500 1250 ;Good 1000

Break Hold: Perfect 2600 2575 2550 2525 2500 ;Great 2000 1750 1500 1250 ;Good 1000
