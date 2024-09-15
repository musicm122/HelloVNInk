============= Day1Scene1 ===================
//Parentification
//Parentificatio
//words that mean burden child responsibility from parents

// Morning in the kitchen
/*
Goal of scene:
Establishing the status quo.
Mom works, Faye cooks, cleans and keeps up the household. 

*/


#StopSound Sound
#StopSound Music

#ClearImage CG
#ClearImage Background
#ClearImage LeftExpression 
#ClearImage RightExpression 

#ClearImage Portrait_Left
#ClearImage Portrait_Center
#ClearImage Portrait_Right
#ClearTint Tint

Start of Day 1

#SetTint Tint Orange .02
#SetImage Background Backgrounds/Kitchen2/Day
#PlaySound Music Audio/breezy

#SetImage Portrait_Right Characters/Mom/Left/FullBody/Neutral

#SetImage RightExpression Characters/Mom/Left/Neutral
Mom:>: Fayeeeee~. 

#SetImage RightExpression Characters/Mom/Left/Upset
Mom:>: You better be sure to mind your manners today.

#SetImage Portrait_Left Characters/Faye/Right/FullBody/Neutral
#SetImage LeftExpression Characters/Faye/Right/Confused
Faye:<: Yes ma'am 

#SetImage RightExpression Characters/Mom/Left/Upset
Mom:>: And be respectful of your teachers.

#SetImage LeftExpression Characters/Faye/Right/Neutral
Faye:<: Yes ma'am 

#SetImage RightExpression Characters/Mom/Left/Upset
Mom:>: Come straight home. 

#SetImage LeftExpression Characters/Faye/Right/Confused
Faye:<: Yes ma'am 

#SetImage RightExpression Characters/Mom/Left/Upset
Mom:>: No extra stops~ 

#SetImage LeftExpression Characters/Faye/Right/Confused
Faye:<: Yes ma'am 

#SetImage RightExpression Characters/Mom/Left/Neutral
Mom:>: Have a good day at school Faye. 

#SetImage LeftExpression Characters/Faye/Right/Pleased
Faye:<: Thanks mom. 
Faye:<: You have a good day too. 
Faye:<: I fixed ya collards, cornbread and chicken for your supper by the way. 

#SetImage RightExpression Characters/Mom/Left/EyesClosed
Mom:>: Oooo, I completely forgot!. 

#SetImage RightExpression Characters/Mom/Left/Neutral
Mom:>: Thank you sweetie! 

#SetImage RightExpression Characters/Mom/Left/Neutral
Mom:>: You always making sure your momma stays eatin' good. 
Mom:>: You do good.  

Faye:<: I try~
#SetImage RightExpression Characters/Mom/Left/Neutral

Mom:>: I love you. Bye~
#ClearImage RightExpression 

#SetImage LeftExpression Characters/Faye/Right/Neutral
You hear the truck start and your mom's truck pull mom pull away.  

#ClearImage RightExpression 
#ClearImage Portrait_Right
// add a truck starting sound here
// nice to have add a shot of the front of the house

#SetImage LeftExpression Characters/Faye/Right/Pleased
Faye:<: K, Now that she is gone I can do a little clean up and head to school. 

-> Title