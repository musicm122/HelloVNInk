/*
Goal: 
Introduce audience to Bill. 
Inform us how Faye handles uncomfortable interactions. 

(Bell Rings)
After class as Faye leaves she is approached by "Divorced Bill" . Bill somewhat aggressively blocks Faye's path. 
*/

===== Day1Scene3 =====
#StopSound Sound
#StopSound Music

#ClearImage Background
#ClearImage LeftExpression 
#ClearImage RightExpression 

#ClearImage Portrait_Left
#ClearImage Portrait_Center
#ClearImage Portrait_Right
#ClearTint Tint

#ClearTint Tint

#SetTint Tint Orange .10

#SetImage Background Backgrounds/Hall/Day

#SetImage Portrait_Right Characters/Bill/Left/FullBody/Neutral
#SetImage Background Backgrounds/Hall/Day


#SetImage LeftExpression Characters/Faye/Right/Neutral
#SetImage RightExpression Characters/Bill/Left/Neutral

Bill:>: Good afternoon my dear Miss Faye.

Faye:<: Yes Sir.
#SetImage LeftExpression Characters/Faye/Right/Neutral

#ClearImage LeftExpression
Bill:>: Ya'll sang good at church the other night. I think you took after your Grand mother in that department. 

#ClearImage LeftExpression
Bill fans himself with his hat as he sweats profusely at the though of Faye's mom

Bill:>: Hows your momma doin? I saw her at the grocery store the other day. I waved but, I think she might have missed me. 

#SetImage LeftExpression Characters/Faye/Right/Confused
Faye:<: She is doing fine Mr. Jamison. (as politely as she could) 

#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye:<: Thank you Mr. Jamison

#ClearImage LeftExpression
Bill:>: Well, ya'll don't be a stranger. 
Bill:>: I'll pop by next time I'm in y'all part of town with some of this good bit of hog meat I smoked. 

Bill:>: I got plenty and don't want it to go bad.  
Bill:>: Maybe save you a bit a cookin.

#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye:<: Thank you Mr. Jamison. I'm sorry but, I  gotta start heading home. 

#ClearImage LeftExpression
Bill:>: God be with you young lady.
-> Day1Scene4
